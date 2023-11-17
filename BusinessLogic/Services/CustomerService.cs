
using System.Data;
using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DataAccess;
using WebApplication_Project1.DomainModels.Customer;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomersRelationshipRepository _customersRelationshipRepository;
        public CustomerService(ICustomerRepository customerRepository,
            ICustomersRelationshipRepository customersRelationshipRepository)
        {
            this._customerRepository = customerRepository;
            this._customersRelationshipRepository = customersRelationshipRepository;
        }

        public bool RegisterCustomer(CustomerDTO customer)
        {
            try
            {
                if (customer == null)
                    throw new Exception("Invalid Data !");
                Customer c = new Customer();
                c.PersonalNumber = customer.PersonalNumber;
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.GenderId = customer.GenderId;
                c.BirthDate = customer .BirthDate;
                c.CityId = customer.CityId;
                c.CountryId = customer.CountryId;
                c.Email = customer.Email;
                _customerRepository.Insert(c);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditCustomer(CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                    throw new Exception("Invalid Data !");
                var c = _customerRepository.Get(customer.Id.Value);
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.CityId = customer.CityId;
                c.CountryId = customer.CountryId;
                c.Email = customer.Email;
                _customerRepository.Update(c);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = _customerRepository.Get(customerId);
                if (customer == null)
                    throw new Exception("Not Found !");
                _customerRepository.Delete(customer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public CustomerDTO GetCustomerById(int customerId)
        {
            var c = _customerRepository.Get(customerId);
            CustomerDTO result = new CustomerDTO
            { 
                Id = c.Id, 
                FirstName = c.FirstName, 
                LastName = c.LastName, 
                PersonalNumber = c.PersonalNumber, 
                BirthDate = c.BirthDate, 
                GenderId = c.GenderId, 
                CityId = c.CityId, 
                CountryId = c.CountryId, 
                Email = c.Email, 
                StartCustomer = c.StartCustomer, 
                EndCustomer = c.EndCustomer
            };
            return result;
        }
        public List<CustomerDTO> GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            List<CustomerDTO> result = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PersonalNumber = c.PersonalNumber,
                BirthDate = c.BirthDate,
                GenderId = c.GenderId,
                CityId = c.CityId,
                CountryId = c.CountryId,
                Email = c.Email,
                StartCustomer = c.StartCustomer,
                EndCustomer = c.EndCustomer
            }).ToList();
            return result;
        }
        public List<RelationshipTypeDTO> GetRelationshipType (int CustomerId)
        {
            try
            {
                var c = _customerRepository.Get(CustomerId);
                if (c == null)
                    throw new Exception("Not Found !");
                var cc = _customersRelationshipRepository.FindByCondition(c => c.StartCustomerId == CustomerId);
                if (!cc.Any())
                return new List<RelationshipTypeDTO>();
                List <RelationshipTypeDTO> result = cc.Select(i => new RelationshipTypeDTO { Name = i.RelationshipType.Name }).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
