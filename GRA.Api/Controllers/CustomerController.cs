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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        


        [HttpPut("CreateOrUpdateCustomer")]
        public async Task<ActionResult<int>> CreateCustomer(CustomerDto customer)
        {
            string sql = @"EXEC GRA_DB.dbo.spCustomer_Upsert
                     @Id = @IdParameter,
                     @LastName = @LastNameParameter,
                     @FirstName = @FirstNameParameter,
                     @CompanyName = @CompanyNameParameter,
                     @NIN = @NINParameter,
                     @Email = @EmailParameter,
                     @Phone =@PhoneParameter, 
                     @Address = @AddressParameter,
                     @ZipCode = @ZipCodeParameter,
                     @City = @CityParameter";
            DynamicParameters sqlParameters = new();

            sqlParameters.Add("@IdParameter", customer.Id, DbType.Int32);
            sqlParameters.Add("@LastNameParameter", customer.LastName, DbType.String);
            sqlParameters.Add("@FirstNameParameter", customer.FirstName, DbType.String);
            sqlParameters.Add("@CompanyNameParameter", customer.CompanyName, DbType.String);
            sqlParameters.Add("@NINParameter", customer.NIN, DbType.String);
            sqlParameters.Add("@EmailParameter", customer.Email, DbType.String);
            sqlParameters.Add("@PhoneParameter", customer.Phone, DbType.String);
            sqlParameters.Add("@AddressParameter", customer.Address, DbType.String);
            sqlParameters.Add("@ZipCodeParameter", customer.ZipCode, DbType.String);
            sqlParameters.Add("@CityParameter", customer.City, DbType.String);

            int customerId = await _dapper.ExecuteScalarWithParamsAsync(sql, sqlParameters);

            if (customerId != 0)
            {
                return Ok(customerId);
            }
            return BadRequest("Echec de la création de client");
        }

        [HttpDelete("DeleteCustomer/{customerId}")]
        public async Task<ActionResult> DeleteCustomer(int customerId)
        {
            string sql = @"EXEC GRA_DB.dbo.spCustomer_Delete
                            @Id = @IdParameter";
            DynamicParameters sqlParameters = new();

            sqlParameters.Add("@IdParameter", customerId, DbType.Int32);

            if (await _dapper.ExecuteSqlWithParametersAsync(sql, sqlParameters))
            {
                return Ok();
            }
            return BadRequest("Echec de la supression de client");
        }

        [HttpGet("GetGetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            string sql = @"EXEC GRA_DB.dbo.spCustomer_GetAll";
            var customers = await _dapper.LoadDataAsync<CustomerDto>(sql);

            if ( customers!= null)
            {
                return Ok(customers);
            }
            return BadRequest("Echec de la récupération des clients");
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int customerId)
        {
            string sql = @"EXEC GRA_DB.dbo.spCustomer_GetById
                         @Id = @IdParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@IdParameter", customerId, DbType.Int32);

            var client = await _dapper.LoadDataWithParamsAsync<CustomerDto>(sql, sqlParameters);

            if (client != null)
            {
                return Ok(client);
            }
            return BadRequest("Echec de la récupération de client");
        }

        [HttpGet("SearchCustomer/{SearchTerm}")]
        public async Task<ActionResult<CustomerDto>> SearchCustomer(string SearchTerm)
        {
            string sql = @"EXEC GRA_DB.dbo.spAppointment_Search
                         @SearchTerm = @SearchTermParameter";
            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@SearchTermParameter", SearchTerm, DbType.String);

            var client = await _dapper.LoadDataWithParamsAsync<CustomerDto>(sql, sqlParameters);

            if (client != null)
            {
                return Ok(client);
            }
            return BadRequest("Echec de la récupération de client");
        }
    }
}

