using GRA.Api.Models;
using Dapper;
using GRA.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using GRA.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace GRA.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpPut("UpsertUser")]
        public IActionResult UpsertUser(UserModel user)
        {
            string sql = @"EXEC GRA_DB.dbo.spUser_Upsert
					@Id = @IdParam,
                    @IdRole = @IdRoleParam,
					@LastName = @LastNameParam,
					@FirstName = @FirstNameParam,
                    @Email = @EmailParam,
                    @Password = @PasswordParam,
                    @BirthDay = @BirthDayParam,
                    @Phone = @PhoneParam,
                    @LastLogin = @LastLoginParam,
                    @IsDeactivated = @IsIsDeactivatedParam";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@IdParam", user.Id, DbType.Int32);
            sqlParameters.Add("@IdRoleParam", user.IdRole, DbType.Int32);
            sqlParameters.Add("@LastNameParam", user.LastName, DbType.String);
            sqlParameters.Add("@FirstNameParam", user.FirstName, DbType.String);
            sqlParameters.Add("@EmailParam", user.Email, DbType.String);
            sqlParameters.Add("@BirthDayParam", user.BirthDay, DbType.Date);
            sqlParameters.Add("@PhoneParam", user.Phone, DbType.String);
            sqlParameters.Add("@LastLoginParam", user.LastLogin, DbType.DateTime);
            sqlParameters.Add("@IsIsDeactivatedParam", user.IsDesactived, DbType.Boolean);

            if (_dapper.ExecuteSqlWithParameters(sql, sqlParameters))
            {
                return Ok();
            }

            throw new Exception("Échec de la mise à jour de l'utilisateur");
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            string sql = @"EXEC GRA_DB.dbo.spUser_Delete
            @UserId = @UserIdParameter";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@UserIdParameter", userId, DbType.Int32);

            if (_dapper.ExecuteSqlWithParameters(sql, sqlParameters))
            {
                return Ok();
            }

            throw new Exception("Échec de la suppression de l'utilisateur");
        }

        [HttpGet("GetGetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetGetAllUsers()
        {
            string sql = @"EXEC GRA_DB.dbo.spUser_GetAll";
            var customers = await _dapper.LoadDataAsync<UserDto>(sql);

            if (customers != null)
            {
                return Ok(customers);
            }
            return BadRequest("Echec de la récupération des users");
        }
    }
}