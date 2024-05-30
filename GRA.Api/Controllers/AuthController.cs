using GRA.Api.Helpers;
using GRA.Models.Dtos;
using Dapper;
using GRA.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GRA.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        private readonly AuthHelper _authHelper;

        public AuthController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _authHelper = new AuthHelper(config);
        }

        [AllowAnonymous]
        [HttpGet("Connection")]
        public DateTime Connection()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration.Password == userForRegistration.ConfirmPassword)
            {
                string sqlCheckUserExists = "EXEC GRA_DB.dbo.spEmailExists_Get @Email = @EmailParameter";

                DynamicParameters sqlUserExistsParameters = new DynamicParameters();
                sqlUserExistsParameters.Add("@EmailParameter", userForRegistration.Email, DbType.String);

                IEnumerable<string> existingUsers = await _dapper.LoadDataWithParamsAsync<string>(sqlCheckUserExists, sqlUserExistsParameters);

                if (!existingUsers.Any())
                {
                    UserForLoginDto userForSetPassword = new UserForLoginDto()
                    {
                        Email = userForRegistration.Email,
                        Password = userForRegistration.Password!
                    };

                    if (_authHelper.SetPassword(userForSetPassword))
                    {
                        string sqlAddUser = @"EXEC GRA_DB.dbo.spUser_Upsert
                            @Id = @IdParameter,
                            @IdRole = @IdRoleParameter,
                            @LastName = @LastNameParameter,
                            @FirstName = @FirstNameParameter,
							@Email = @EmailParameter,
                            @BirthDay = @BirthDayParameter,
                            @Phone = @PhoneParameter,
                            @LastLogin = @LastLoginParameter,
                            @IsDeactivated = @IsDeactivatedParameter";

                        DynamicParameters sqlAddUserParameters = new DynamicParameters();
                        sqlAddUserParameters.Add("@IdParameter", userForRegistration.Id, DbType.Int32);
                        sqlAddUserParameters.Add("@IdRoleParameter", userForRegistration.IdRole, DbType.Int32);
                        sqlAddUserParameters.Add("@LastNameParameter", userForRegistration.LastName, DbType.String);
                        sqlAddUserParameters.Add("@FirstNameParameter", userForRegistration.FirstName, DbType.String);
                        sqlAddUserParameters.Add("@EmailParameter", userForRegistration.Email, DbType.String);
                        sqlAddUserParameters.Add("@BirthDayParameter", userForRegistration.BirthDay, DbType.Date);
                        sqlAddUserParameters.Add("@PhoneParameter", userForRegistration.Phone, DbType.String);
                        sqlAddUserParameters.Add("@LastLoginParameter", userForRegistration.LastLogin, DbType.DateTime);
                        sqlAddUserParameters.Add("@IsDeactivatedParameter", userForRegistration.IsDeactivated, DbType.Boolean);

                        if (await _dapper.ExecuteSqlWithParametersAsync(sqlAddUser, sqlAddUserParameters))
                            return Ok();

                        throw new Exception("L'ajout d'un utilisateur a échoué!");
                    }
                    throw new Exception("L'enregistrement de l'utilisateur a échoué!");
                }
                throw new Exception("L'utilisateur avec cet email existe déjà!");
            }
            throw new Exception("Les mots de passe ne correspondent pas!");
        }

        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(UserForLoginDto userForSetPassword) // add new model with password and password confirm
        {
            if (_authHelper.SetPassword(userForSetPassword))
            {
                return Ok();
            }
            throw new Exception("La mise à jour du mot de passe a échoué!");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            string sqlForHashAndSalt = @"EXEC GRA_DB.dbo.spLoginConfirmation_Get @Email = @EmailParam";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@EmailParam", userForLogin.Email, DbType.String);

            UserForLoginConfirmationDto userForConfirmation = await _dapper
                .LoadDataSingleWithParamsAsync<UserForLoginConfirmationDto>(sqlForHashAndSalt, sqlParameters);

            byte[] passwordHash = _authHelper.GetPasswordHash(userForLogin.Password!, userForConfirmation.PasswordSalt);

            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != userForConfirmation.PasswordHash[i])
                    return StatusCode(401, "Mot de passe incorrect!");
            }

            string userIdSql = "EXEC GRA_DB.dbo.spUserId_Get @Email = @EmailParameter";

            DynamicParameters sqlUserIdParameters = new DynamicParameters();
            sqlUserIdParameters.Add("@EmailParameter", userForLogin.Email, DbType.String);

            int userId = await _dapper.LoadDataSingleWithParamsAsync<int>(userIdSql, sqlUserIdParameters);

            return Ok(_authHelper.CreateToken(userId));
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            string userIdSql = "EXEC GRA_DB.dbo.spUserId_Get @UserId = @UserIdParameter";

            DynamicParameters sqlUserIdParameters = new DynamicParameters();
            sqlUserIdParameters.Add("@UserIdParameter", User.FindFirst("userId")?.Value, DbType.Int32);

            int userIdFromDb = await _dapper.LoadDataSingleWithParamsAsync<int>(userIdSql, sqlUserIdParameters);

            return Ok(_authHelper.CreateToken(userIdFromDb));
        }
    }
}