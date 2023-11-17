using WebApplication_Project1.DomainModels.Customer;

namespace WebApplication_Project1.BusinessLogic.Contracts
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetCustomers();
        CustomerDTO GetCustomerById(int customerId);
        bool RegisterCustomer (CustomerDTO customer);
        bool EditCustomer (CustomerDTO customer);
        bool DeleteCustomer(int customerId);
        List<RelationshipTypeDTO> GetRelationshipType (int customerId);
    }
}
