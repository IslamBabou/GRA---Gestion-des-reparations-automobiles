using Dapper;
using GRA.Api.Data;
using GRA.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace GRA.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private DataContextDapper _dapper;

        [HttpPost("CreateMessage")]
        public async Task<ActionResult<int>> CreateMessage(MessageDto message)
        {
            string sql = @"EXEC GRA_DB.dbo.spMessage_Create
                         @Id = @IdParameter,
                         @UserName = @UserNameParameter,
                         @Content = @ContentParameter,
                         @PublicationDate = @PublicationDateParameter,
                         @IsRead = @IsReadParameter,
                         @Tag = @TagParameter";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@IdParameter", message.Id, DbType.Int32);
            sqlParameters.Add("@UserNameParameter", message.UserName, DbType.String);
            sqlParameters.Add("@ContentParameter", message.Content, DbType.String);
            sqlParameters.Add("@PublicationDateParameter", message.PublicationDate, DbType.DateTime);
            sqlParameters.Add("@IsReadParameter", message.IsRead, DbType.Boolean);
            sqlParameters.Add("@TagParameter", message.Tag, DbType.String);


            int messageId = await _dapper.ExecuteScalarWithParamsAsync(sql, sqlParameters);

            if (messageId != 0)
            {
                return Ok(messageId);
            }
            return BadRequest("Échec de la création du message.");
        }

        [HttpGet("GetAllMessages")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetAllMessages()
        {
            string sql = @"EXEC GRA_DB.dbo.spMessage_GetAll";
            var messages = await _dapper.LoadDataAsync<MessageDto>(sql);

            if (messages != null)
            {
                return Ok(messages);
            }
            return BadRequest("Echec de la récupération des messages");

        }

        [HttpPut("MarkMessageAsRead/{messageId}")]
        public async Task<ActionResult> MarkMessageAsRead(int messageId)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_UpdateCompletedById
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", messageId, DbType.Int32);

            if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec de la mise a jour de message");
        }
}
}