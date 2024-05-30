using GRA.Models.Dtos;
using System.Threading.Tasks;
namespace GRA.App.Services.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>?> GetAllCustomers();
        Task DeleteCustomer(int id);
        Task<CustomerDto?> GetCustomerById(int id);
        Task<IEnumerable<CustomerDto>?> SearchCustomer(string SearchTerm);
        Task<int> CreateCustomer(CustomerDto customer);
    }
}
