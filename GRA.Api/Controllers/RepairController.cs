using Dapper;
using GRA.Api.Data;
using GRA.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GRA.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RepairController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        public RepairController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpPut("CreateRepair")]
        public async Task<ActionResult<int>> CreateRepair(AddOrUpdateRepairDto repair)
        {
            string sql = @"EXEC GRA_DB.dbo.spRepair_Upsert
                         @Id = @IdParameter,
                         @Code = @CodeParameter,
                         @VehicleId = @VehicleIdParameter,
                         @DateOpening = @DateOpeningParameter,
                         @DateClosing = @DateClosingParameter,
                         @Status = @StatusParameter,
                         @CreatedBy = @CreatedByParameter,
                         @UpdatedBy = @UpdatedByParameter,
                         @Total = @TotalParameter,
                         @Paid = @PaidParameter,
                         @PaiementStatus = @PaiementStatusParameter";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", repair.Id, DbType.Int32);
            sqlParameters.Add("@CodeParameter", repair.Code, DbType.String);
            sqlParameters.Add("@VehicleIdParameter", repair.VehicleId, DbType.Int32);
            sqlParameters.Add("@DateOpeningParameter", repair.DateOpening, DbType.DateTime);
            sqlParameters.Add("@DateClosingParameter", repair.DateClosing, DbType.DateTime);
            sqlParameters.Add("@StatusParameter", repair.Status, DbType.Int32);
            sqlParameters.Add("@CreatedByParameter", repair.CreatedBy, DbType.String);
            sqlParameters.Add("@UpdatedByParameter", repair.UpdatedBy, DbType.String);
            sqlParameters.Add("@TotalParameter", repair.Total, DbType.Decimal);
            sqlParameters.Add("@PaidParameter", repair.Paid, DbType.Decimal);
            sqlParameters.Add("@PaiementStatusParameter", repair.PaymentStatus, DbType.Int32);

            int repairId = await _dapper.ExecuteScalarWithParamsAsync(sql, sqlParameters);

            if (repairId != 0)
            {
                return Ok(repairId);
            }
            return BadRequest("Échec de la création de la réparation");
        }

        [HttpGet("GetAllRepair")]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetAllRepair()
        {
            string sql = @"EXEC GRA_DB.dbo.spRepair_GetAll";
            var repairs = await _dapper.LoadDataAsync<RepairDto>(sql);

            if (repairs != null)
            {
                return Ok(repairs);
            }
            return BadRequest("Echec de la récupération des réparations");
        }

        [HttpGet("GetRepairByCustomerId/{customerId}")]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetRepairByCustomerId(int customerId)
        {
            string sql = @"EXEC GRA_DB.dbo.spRepair_GetByCustomerId
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", customerId, DbType.Int32);

            var client = await _dapper.LoadDataWithParamsAsync<RepairDto>(sql, sqlParameters);

            if (client != null)
            {
                return Ok(client);
            }
            return BadRequest("Echec de la récupération des réparations");
        }

        [HttpGet("GetRepairById/{id}")]
        public async Task<ActionResult<RepairDto>> GetRepairById(int id)
        {
            string sql = @"EXEC GRA_DB.dbo.spRepair_GetById
                 @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", id, DbType.Int32);

            var repair = await _dapper.LoadDataWithParamsAsync<RepairDto>(sql, sqlParameters);

            if (repair!= null)
            {
                return Ok(repair);
            }
            return BadRequest("Echec de la récupération de réparation");
        }

        [HttpGet("GetRepairByNumberPlate/{numberPlate}")]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetRepairByNumberPlate(int numberPlate)
        {
            string sql = @"EXEC GRA_DB.dbo.spRepair_GetByPlateNumber
                 @PlateNumber = @PlateNumberParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@PlateNumberParameter", numberPlate, DbType.Int32);

            var repairs = await _dapper.LoadDataWithParamsAsync<RepairDto>(sql, sqlParameters);

            if (repairs != null)
            {
                return Ok(repairs);
            }
            return BadRequest("Echec de la récupération des réparations");
        }
    }
}
