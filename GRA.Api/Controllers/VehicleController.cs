using Dapper;
using GRA.Api.Data;
using GRA.Api.Helpers;
using GRA.Api.Models;
using GRA.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GRA.Api.Controllers
{
    namespace GRA.Api.Controllers
    {
        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class VehicleController : ControllerBase
        {
            private readonly DataContextDapper _dapper;


            [HttpPut("CreateOrUpdateVehicle")]
            public async Task<ActionResult<int>> CreateVehicle(VehicleDto vehicle)
            {
                string sql = @"EXEC GRA_DB.dbo.spVehicle_Upsert
                     @Id = @IdParameter,
                     @CustomerId = @CustomerIdParameter, 
                     @NumberPlate = @NumberPlateParameter, 
                     @Brand = @BrandParameter,  
                     @Model = @ModelParameter, 
                     @Year = @YearParameter,
                     @ChassisNumber = @ChassisNumberParameter,
                     @FuelType = @FuelTypeParameter,
                     @TransmissionType = @TransmissionTypeParameter,
                     @EngineDescription = @EngineDescriptionParameter, 
                     @Cylinder = @CylinderParameter, 
                     @BodyType = @BodyTypeParameter, 
                     @SizeLitre = @SizeLitreParameter, 
                     @FirstVisit = @FirstVisitParameter";

                DynamicParameters sqlParameters = new DynamicParameters();

                sqlParameters.Add("@IdParameter", vehicle.Id, DbType.Int32);
                sqlParameters.Add("@CustomerIdParameter", vehicle.CustomerId, DbType.Int32);
                sqlParameters.Add("@NumberPlateParameter", vehicle.NumberPlate, DbType.Int32);
                sqlParameters.Add("@BrandParameter", vehicle.Brand, DbType.String);
                sqlParameters.Add("@ModelParameter", vehicle.Model, DbType.String);
                sqlParameters.Add("@YearParameter", vehicle.Year, DbType.StringFixedLength);
                sqlParameters.Add("@ChassisNumberParameter", vehicle.ChassisNumber, DbType.String);
                sqlParameters.Add("@FuelTypeParameter", vehicle.FuelType, DbType.String);
                sqlParameters.Add("@TransmissionTypeParameter", vehicle.TransmissionType, DbType.String);
                sqlParameters.Add("@EngineDescriptionParameter", vehicle.EngineDescription, DbType.String);
                sqlParameters.Add("@CylinderParameter", vehicle.Cylinder, DbType.String);
                sqlParameters.Add("@BodyTypeParameter", vehicle.BodyType, DbType.String);
                sqlParameters.Add("@SizeLitreParameter", vehicle.SizeLitre, DbType.Decimal);
                sqlParameters.Add("@FirstVisitParameter", vehicle.FirstVisit, DbType.DateTime);

                int vehicleId = await _dapper.ExecuteScalarWithParamsAsync(sql, sqlParameters);

                if (vehicleId != 0)
                {
                    return Ok(vehicleId);
                }
                return BadRequest("Echec de la création de véhicule");
            }

            [HttpGet("GetGetAllCustomers")]
            public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAllVehicles()
            {
                string sql = @"EXEC GRA_DB.dbo.spVehicle_GetAll";
                var vehicles = await _dapper.LoadDataAsync<VehicleDto>(sql);

                if (vehicles != null)
                {
                    return Ok(vehicles);
                }
                return BadRequest("Echec de la récupération des véhicules");
            }

            [HttpGet("GetVehicleByCustomerId/{customerId}")]
            public async Task<ActionResult<VehicleDto>> GetVehicleByCustomerId(int customerId)
            {
                string sql = @"EXEC GRA_DB.dbo.spVehicle_GetByCustomerId
                         @CustomerId = @CustomerIdParameter";
                DynamicParameters sqlParameters = new DynamicParameters();

                sqlParameters.Add("@CustomerIdParameter", customerId, DbType.Int32);

                var vehicle = await _dapper.LoadDataWithParamsAsync<VehicleDto>(sql, sqlParameters);

                if (vehicle != null)
                {
                    return Ok(vehicle);
                }
                return BadRequest("Echec de la récupération de véhicule");
            }

            [HttpGet("GetVehicleById/{vehiculeId}")]
            public async Task<ActionResult<VehicleDto>> GetVehicleById(string vehiculeId)
            {
                string sql = @"EXEC GRA_DB.dbo.spVehicle_GetById
                             @Id = @IdParameter";
                DynamicParameters sqlParameters = new DynamicParameters();

                sqlParameters.Add("@IdParameter", vehiculeId, DbType.Int32);

                var vehicle = await _dapper.LoadDataWithParamsAsync<VehicleDto>(sql, sqlParameters);
                if (vehicle != null)
                {
                    return Ok(vehicle);
                }
                return BadRequest("Echec de la récupération de véhicule");
            }

            [HttpGet("SearchVehicle/{SearchTerm}")]
            public async Task<ActionResult<VehicleDto>> SearchVehicle(string SearchTerm)
            {
                string sql = @"EXEC GRA_DB.dbo.spVehicle_Search
             @SearchTerm = @SearchTermParameter";
                DynamicParameters sqlParameters = new DynamicParameters();

                sqlParameters.Add("@SearchTermParameter", SearchTerm, DbType.String);

                var vehicles = await _dapper.LoadDataWithParamsAsync<VehicleDto>(sql, sqlParameters);
                if (vehicles != null)
                {
                    return Ok(vehicles);
                }
                return BadRequest("Echec de la récupération des véhicules");
            }

            [HttpGet("UpdateVehicleFirstVisitById")]
            public async Task<ActionResult> UpdateVehicleFirstVisitById(VehicleDto vehicle)
            {
                string sql = @"EXEC GRA_DB.dbo.spVehicle_UpdateFirstVisitById
                             @Id = @IdParameter,
                             @FirstVisit = @FirstVisitParameter";
                DynamicParameters sqlParameters = new DynamicParameters();

                sqlParameters.Add("@IdParameter", vehicle.Id, DbType.Int32);
                sqlParameters.Add("@FirstVisitParameter", vehicle.FirstVisit, DbType.DateTime);

                if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
                {
                    return Ok();
                }
                return BadRequest("Echec de modifier la véhicule");
            }
        }
    }
}
