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
    public class ReportController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        [HttpPost("CreateReport")]
        public async Task<ActionResult<int>> CreateReport(ReportDto report)
        {
            string sql = @"EXEC dbo.spReport_Upsert
                         @Id = @IdParameter,
                         @IsArchive = @IsArchiveParameter,
                         @StartDate = @StartDateParameter,
                         @EndDate = @EndDateParameter,
                         @VehicleId = @VehicleIdParameter,
                         @UserId = @UserIdParameter,
                         @AppointmentId = @AppointmentIdParameter,
                         @CustomerId = @CustomerIdParameter,
                         @Date = @DateParameter,
                         @Odometer = @OdometerParameter,
                         @RoadTestComments = @RoadTestCommentsParameter,
                         @GeneralComments = @GeneralCommentsParameter,
                         @StoredFaultCodes = @StoredFaultCodesParameter,
                         @AirConditioning = @AirConditioningParameter,
                         @Optics = @OpticsParameter,
                         @Lights = @LightsParameter,
                         @LightsComments = @LightsCommentsParameter,
                         @FrontWiper = @FrontWiperParameter,
                         @BackWiper = @BackWiperParameter,
                         @Battery = @BatteryParameter,
                         @BatteryComments = @BatteryCommentsParameter,
                         @RHFTyre = @RHFTyreParameter,
                         @LHFTyre = @LHFTyreParameter,
                         @RHRTyre = @RHRTyreParameter,
                         @LHRTyre = @LHRTyreParameter,
                         @TyresComments = @TyresCommentsParameter,
                         @IsNeedAlignment = @IsNeedAlignmentParameter,
                         @AirFilter = @AirFilterParameter,
                         @CabinFilter = @CabinFilterParameter,
                         @DriveBelts = @DriveBeltsParameter,
                         @TimingBelts = @TimingBeltsParameter,
                         @Radiator = @RadiatorParameter,
                         @Hoses = @HosesParameter,
                         @HosesComment = @HosesCommentParameter,
                         @EngineOil = @EngineOilParameter,
                         @Coolant = @CoolantParameter,
                         @BrakeFluid = @BrakeFluidParameter,
                         @PowerSteeringFluid = @PowerSteeringFluidParameter,
                         @TransmissionFluid = @TransmissionFluidParameter,
                         @WindScreenWasherFluid = @WindScreenWasherFluidParameter,
                         @FluidComments = @FluidCommentsParameter,
                         @SparkPlugs = @SparkPlugsParameter,
                         @FuelFilter = @FuelFilterParameter,
                         @FrontSuspension = @FrontSuspensionParameter,
                         @FrontSuspensionComments = @FrontSuspensionCommentsParameter,
                         @RearSuspension = @RearSuspensionParameter,
                         @RearSuspensionComments = @RearSuspensionCommentsParameter,
                         @FrontBrakes = @FrontBrakesParameter,
                         @FrontBrakesComments = @FrontBrakesCommentsParameter,
                         @RearBrakes = @RearBrakesParameter,
                         @RearBrakesComments = @RearBrakesCommentsParameter,
                         @Exhaust = @ExhaustParameter,
                         @ExhaustComments = @ExhaustCommentsParameter,
                         @OilLeaks = @OilLeaksParameter,
                         @OilLeaksComments = @OilLeaksCommentsParameter,
                         @CoolantLeaks = @CoolantLeaksParameter,
                         @CoolantLeaksComments = @CoolantLeaksCommentsParameter,
                         @Other = @OtherParameter,
                         @OtherInspectionComments = @OtherInspectionCommentsParameter";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@IdParameter", report.Id, DbType.Int32);
            sqlParameters.Add("@IsArchiveParameter", report.IsArchive, DbType.Boolean);
            sqlParameters.Add("@StartDateParameter", report.StartDate, DbType.DateTime);
            sqlParameters.Add("@EndDateParameter", report.EndDate, DbType.DateTime);
            sqlParameters.Add("@VehicleIdParameter", report.VehicleId, DbType.Int32);
            sqlParameters.Add("@UserIdParameter", report.UserId, DbType.Int32);
            sqlParameters.Add("@AppointmentIdParameter", report.AppointmentId, DbType.Int32);
            sqlParameters.Add("@CustomerIdParameter", report.CustomerId, DbType.Int32);
            sqlParameters.Add("@DateParameter", report.Date, DbType.DateTime);
            sqlParameters.Add("@OdometerParameter", report.Odometer, DbType.Int32);
            sqlParameters.Add("@RoadTestCommentsParameter", report.RoadTestComments, DbType.String);
            sqlParameters.Add("@GeneralCommentsParameter", report.GeneralComments, DbType.String);
            sqlParameters.Add("@StoredFaultCodesParameter", report.StoredFaultCodes, DbType.String);
            sqlParameters.Add("@AirConditioningParameter", report.AirConditioning, DbType.String);
            sqlParameters.Add("@OpticsParameter", report.Optics, DbType.String);
            sqlParameters.Add("@LightsParameter", report.Lights, DbType.String);
            sqlParameters.Add("@LightsCommentsParameter", report.LightsComments, DbType.String);
            sqlParameters.Add("@FrontWiperParameter", report.FrontWiper, DbType.String);
            sqlParameters.Add("@BackWiperParameter", report.BackWiper, DbType.String);
            sqlParameters.Add("@BatteryParameter", report.Battery, DbType.String);
            sqlParameters.Add("@BatteryCommentsParameter", report.BatteryComments, DbType.String);
            sqlParameters.Add("@RHFTyreParameter", report.RHFTyre, DbType.String);
            sqlParameters.Add("@LHFTyreParameter", report.LHFTyre, DbType.String);
            sqlParameters.Add("@RHRTyreParameter", report.RHRTyre, DbType.String);
            sqlParameters.Add("@LHRTyreParameter", report.LHRTyre, DbType.String);
            sqlParameters.Add("@TyresCommentsParameter", report.TyresComments, DbType.String);
            sqlParameters.Add("@IsNeedAlignmentParameter", report.IsNeedAlignment, DbType.Boolean);
            sqlParameters.Add("@AirFilterParameter", report.AirFilter, DbType.String);
            sqlParameters.Add("@CabinFilterParameter", report.CabinFilter, DbType.String);
            sqlParameters.Add("@DriveBeltsParameter", report.DriveBelts, DbType.String);
            sqlParameters.Add("@TimingBeltsParameter", report.TimingBelts, DbType.String);
            sqlParameters.Add("@RadiatorParameter", report.Radiator, DbType.String);
            sqlParameters.Add("@HosesParameter", report.Hoses, DbType.String);
            sqlParameters.Add("@HosesCommentParameter", report.HosesComment, DbType.String);
            sqlParameters.Add("@EngineOilParameter", report.EngineOil, DbType.String);
            sqlParameters.Add("@CoolantParameter", report.Coolant, DbType.String);
            sqlParameters.Add("@BrakeFluidParameter", report.BrakeFluid, DbType.String);
            sqlParameters.Add("@PowerSteeringFluidParameter", report.PowerSteeringFluid, DbType.String);
            sqlParameters.Add("@TransmissionFluidParameter", report.TransmissionFluid, DbType.String);
            sqlParameters.Add("@WindScreenWasherFluidParameter", report.WindScreenWasherFluid, DbType.String);
            sqlParameters.Add("@FluidCommentsParameter", report.FluidComments, DbType.String);
            sqlParameters.Add("@SparkPlugsParameter", report.SparkPlugs, DbType.String);
            sqlParameters.Add("@FuelFilterParameter", report.FuelFilter, DbType.String);
            sqlParameters.Add("@FrontSuspensionParameter", report.FrontSuspension, DbType.String);
            sqlParameters.Add("@FrontSuspensionCommentsParameter", report.FrontSuspensionComments, DbType.String);
            sqlParameters.Add("@RearSuspensionParameter", report.RearSuspension, DbType.String);
            sqlParameters.Add("@RearSuspensionCommentsParameter", report.RearSuspensionComments, DbType.String);
            sqlParameters.Add("@FrontBrakesParameter", report.FrontBrakes, DbType.String);
            sqlParameters.Add("@FrontBrakesCommentsParameter", report.FrontBrakesComments, DbType.String);
            sqlParameters.Add("@RearBrakesParameter", report.RearBrakes, DbType.String);
            sqlParameters.Add("@RearBrakesCommentsParameter", report.RearBrakesComments, DbType.String);
            sqlParameters.Add("@ExhaustParameter", report.Exhaust, DbType.String);
            sqlParameters.Add("@ExhaustCommentsParameter", report.ExhaustComments, DbType.String);
            sqlParameters.Add("@OilLeaksParameter", report.OilLeaks, DbType.String);
            sqlParameters.Add("@OilLeaksCommentsParameter", report.OilLeaksComments, DbType.String);
            sqlParameters.Add("@CoolantLeaksParameter", report.CoolantLeaks, DbType.String);
            sqlParameters.Add("@CoolantLeaksCommentsParameter", report.CoolantLeaksComments, DbType.String);
            sqlParameters.Add("@OtherParameter", report.Other, DbType.String);
            sqlParameters.Add("@OtherInspectionCommentsParameter", report.OtherInspectionComments, DbType.String);


            int reportId = await _dapper.ExecuteScalarWithParamsAsync<int>(sql, sqlParameters);

            if (reportId != 0)
            {
                return Ok(reportId);
            }
            return BadRequest("Échec de la création  du rapport.");
        }

        [HttpPut("ArchiverReport/{reportId}")]
        public async Task<ActionResult> MarkMessageAsRead(int reportId)
        {
            string sql = @"EXEC GRA_DB.dbo.spReport_Archive
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", reportId, DbType.Int32);

            if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec d'archivation de raport");
        }

        [HttpGet("GetAllReports")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAllReports()
        {
            string sql = @"EXEC GRA_DB.dbo.spMessage_Report_GetAll";
            var messages = await _dapper.LoadDataAsync<ReportDto>(sql);

            if (messages != null)
            {
                return Ok(messages);
            }
            return BadRequest("Echec de la récupération des raports");

        }

        [HttpGet("GetReportById/{reportId}")]
        public async Task<ActionResult<ReportDto>> GetReportById(int reportId)
        {
            string sql = @"EXEC GRA_DB.dbo.spReport_GetById
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", reportId, DbType.Int32);

            var repair = await _dapper.LoadDataWithParamsAsync<ReportDto>(sql, sqlParameters);

            if (repair != null)
            {
                return Ok(repair);
            }
            return BadRequest("Echec de la récupération de raport");
        }

        [HttpGet("GetReportByVehicleId/{vehicleId}")]
        public async Task<ActionResult<RepairDto>> GetReportByVehicleId(int vehicleId)
        {
            string sql = @"EXEC GRA_DB.dbo.spReport_GetByVehicleId
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", vehicleId, DbType.Int32);

            var repair = await _dapper.LoadDataWithParamsAsync<RepairDto>(sql, sqlParameters);

            if (repair != null)
            {
                return Ok(repair);
            }
            return BadRequest("Echec de la récupération de raport");
        }

        [HttpGet("GetReportByCustomerId/{customerId}")]
        public async Task<ActionResult<RepairDto>> GetReportByCustomerId(int customerId)
        {
            string sql = @"EXEC GRA_DB.dbo.spReport_GetByCustomerId
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", customerId, DbType.Int32);

            var repair = await _dapper.LoadDataWithParamsAsync<RepairDto>(sql, sqlParameters);

            if (repair != null)
            {
                return Ok(repair);
            }
            return BadRequest("Echec de la récupération de raport");
        }

        [HttpGet("GetReportsCount")]
        public async Task<ActionResult<int>> GetReportsCount()
        {
            string sql = @"EXEC GRA_DB.dbo.spReport_GetReportsCount";
                         
            var count = await _dapper.LoadDataAsync<int>(sql);

            if (count != null)
            {
                return Ok(count);
            }
            return BadRequest("Echec de comptage des rendez-vous");

        }
    }
    
}
