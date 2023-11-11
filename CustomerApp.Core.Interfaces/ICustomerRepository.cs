using CustomerApp.Core.Models;

namespace CustomerApp.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetCustomerDetails(IEnumerable<ConfigDetails> configDetails);
        // Other methods as needed
    }
}