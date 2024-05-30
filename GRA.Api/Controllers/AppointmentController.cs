using Dapper;
using GRA.Api.Data;
using GRA.Api.Helpers;
using GRA.Api.Models;

using GRA.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;

namespace GRA.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        public AppointmentController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpPost("CreateAppointment")]
        public async Task<ActionResult<int>> CreateAppointment(AppointmentDto appointment)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_Create
                         @Id = @IdParameter,
                         @CustomerId = @CustomerIdParameter,
                         @VehicleId = @VehicleIdParameter,
                         @DateAppointment = @DateAppointmentParameter,
                         @UserId = @UserIdParameter,
                         @IsCompleted = @IsCompletedParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", appointment.Id, DbType.Int32);
            sqlParameters.Add("@CustomerIdParameter", appointment.CustomerId, DbType.Int32);
            sqlParameters.Add("@VehicleIdParameter", appointment.VehicleId, DbType.Int32);
            sqlParameters.Add("@DateAppointmentParameter", appointment.DateAppointment, DbType.DateTime);
            sqlParameters.Add("@UserIdParameter", appointment.UserId, DbType.Int32);
            sqlParameters.Add("@IsCompletedParameter", appointment.IsCompleted, DbType.Int32);

            int appointmentId = await _dapper.ExecuteScalarWithParamsAsync(sql, sqlParameters);
            
            if (appointmentId != 0 ) 
            {
                return Ok(appointmentId);
            }
            return BadRequest("Echec de la création de rendez-vous");
        }

        [HttpDelete("DeleteAppointment/{appointmentId}")]
        public async Task<ActionResult> DeleteAppointment(int appointmentId)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_Delete
                            @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", appointmentId, DbType.Int32);

            if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec de la supression de rendez-vous");
        }

        [HttpGet("GetAllAppointmentsDetails")]
        public async Task<ActionResult<AppointmentsDetailsDto>> GetAllAppointmentsDetails()
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_Details_GetAll";
            var appointmentsDetails = await _dapper.LoadDataAsync<AppointmentsDetailsDto>(sql);

            if (appointmentsDetails != null)
            {
                return Ok(appointmentsDetails);
            }
            return BadRequest("Echec de la récupération des rendez-vous");
            
        }

        [HttpGet("GetAllAppointments")]
        public async Task<ActionResult<BookAppointmentDto>> GetAllAppointments()
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_GetAll";
            var appointments = await _dapper.LoadDataAsync<BookAppointmentDto>(sql);

            if (appointments != null)
            {
                return Ok(appointments);
            }
            return BadRequest("Echec de la récupération des rendez-vous");
        }

        [HttpGet("GetAppointmentById/{appointmentId}")]
        public async Task<ActionResult<AppointmentsDetailsDto>> GetAppointmentById(int appointmentId)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_GetById
                            @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", appointmentId, DbType.Int32);

            var appointment = await _dapper.LoadDataWithParamsAsync<AppointmentsDetailsDto>(sql , sqlParameters);

            if (appointment != null)
            {
                return Ok(appointment);
            }
            return BadRequest("Echec de la récupération de rendez-vous");
        }

        [HttpGet("GetTodayAppointments")]
        public async Task<ActionResult<AppointmentsDetailsDto>> GetTodayAppointments()
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_GetToday";
            var appointments = await _dapper.LoadDataAsync<AppointmentsDetailsDto>(sql);

            if (appointments != null)
            {
                return Ok(appointments);
            }
            return BadRequest("Echec de la récupération des rendez-vous");

        }

        [HttpGet("GetUncompletedAppointments")]
        public async Task<ActionResult<AppointmentsDetailsDto>> GetUncompletedAppointments()
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_GetUncompleted";
            var appointments = await _dapper.LoadDataAsync<AppointmentsDetailsDto>(sql);

            if (appointments != null)
            {
                return Ok(appointments);
            }
            return BadRequest("Echec de la récupération des rendez-vous");

        }

        [HttpPut("UpdateCompletedAppointmentById/{appointmentId}")]
        public async Task<ActionResult> UpdateCompletedAppointmentById(int appointmentId)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_UpdateCompletedById
                            @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", appointmentId, DbType.Int32);

            if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec de la mise a jour de rendez-vous");
        }

        [HttpGet("CountAppointmentsByMechanicToday/{mechanicId}")]
        public async Task<ActionResult<int>> CountAppointmentsByMechanicToday(int mechanicId)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_CountByMechanicToday
                                @Id = @IdParamater";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@IdParameter", mechanicId, DbType.Int32);
            var count = await _dapper.LoadDataWithParamsAsync<int>(sql, sqlParameters);

            if (count != null)
            {
                return Ok(count);
            }
            return BadRequest("Echec de comptage des rendez-vous");

        }

        [HttpPut("AssignMechanic")]
        public async Task<ActionResult> AssignMechanic(AppointmentDto appointment)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_AssignMechanicById
                         @MechanicId = @MechanicIdParameter, 
                         @AppointmentId = @AppointmentIdParameter";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@MechanicIdParameter", appointment.UserId, DbType.Int32);
            sqlParameters.Add("@AppointmentIdParameter", appointment.Id, DbType.Int32);

            if(await _dapper.ExecuteSqlWithParametersAsync(sql,sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec d'affictation de la fiche d'intervention au mécanicien");
        }
    }
}
