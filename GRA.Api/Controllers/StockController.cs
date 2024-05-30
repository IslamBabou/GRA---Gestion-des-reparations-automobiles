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
    public class StockController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        [HttpPost("CreateStock")]
        public async Task<ActionResult<int>> CreateStock(StockDto stock)
        {
            string sql = @"EXEC dbo.spStock_Upsert
                         @Id = @IdParameter,
                         @ItemName = @ItemNameParameter,
                         @Quantity = @QuantityParameter,
                         @Unit = @UnitParameter,
                         @MinQty = @MinQtyParameter";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("@IdParameter", stock.Id, DbType.Int32);
            sqlParameters.Add("@ItemNameParameter", stock.ItemName, DbType.String);
            sqlParameters.Add("@QuantityParameter", stock.Quantity, DbType.Decimal);
            sqlParameters.Add("@UnitParameter", stock.Unit, DbType.String);
            sqlParameters.Add("@MinQtyParameter", stock.MinQty, DbType.Decimal);

            int stockId = await _dapper.ExecuteScalarWithParamsAsync(sql, sqlParameters);

            if (stockId != 0)
            {
                return Ok(stockId);
            }
            return BadRequest("Echec de la création de stock");
        }

        [HttpDelete("DeleteStock/{stockId}")]
        public async Task<ActionResult> DeleteStock(int stockId)
        {
            string sql = @"EXEC GRA_DB.dbo.spStock_Delete
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new();

            sqlParameters.Add("@IdParameter", stockId, DbType.Int32);

            if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec de la supression de stock");
        }

        [HttpGet("GetGetAllStocks")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetGetAllStocks()
        {
            string sql = @"EXEC GRA_DB.dbo.spStock_GetAll";
            var customers = await _dapper.LoadDataAsync<StockDto>(sql);

            if (customers != null)
            {
                return Ok(customers);
            }
            return BadRequest("Echec de la récupération des stocks");
        }

        [HttpGet("GetStockById/{stockId}")]
        public async Task<ActionResult<StockDto>> GetStockById(int stockId)
        {
            string sql = @"EXEC GRA_DB.dbo.spCustomer_GetById
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", stockId, DbType.Int32);

            var stock = await _dapper.LoadDataWithParamsAsync<StockDto>(sql, sqlParameters);

            if (stock != null)
            {
                return Ok(stock);
            }
            return BadRequest("Echec de la récupération de stock");
        }

        [HttpGet("GetLowsStocks")]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetLowsStocks()
        {
            string sql = @"EXEC GRA_DB.dbo.spStock_GetLows";
            var stocks = await _dapper.LoadDataAsync<StockDto>(sql);

            if (stocks != null)
            {
                return Ok(stocks);
            }
            return BadRequest("Echec de la récupération des stocks");
        }

        [HttpGet("SearchStocks/{searchTerm}")]
        public async Task<ActionResult<StockDto>> SearchStocks(string searchTerm)
        {
            string sql = @"EXEC GRA_DB.dbo.spStock_Search
                         @SearchTerm = @SearchTermParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@SearchTermParameter", searchTerm, DbType.String);

            var stock = await _dapper.LoadDataWithParamsAsync<StockDto>(sql, sqlParameters);

            if (stock != null)
            {
                return Ok(stock);
            }
            return BadRequest("Echec de la récupération de stock");
        }
    }
}
