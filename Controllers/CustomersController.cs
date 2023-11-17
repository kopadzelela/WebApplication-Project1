using Microsoft.AspNetCore.Mvc;
using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DomainModels.Customer;
using System.Net.Mime;

namespace WebApplication_Project1.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDTO>))]
        public IEnumerable<CustomerDTO> GetAllUsers() => _customerService.GetCustomers();

        [HttpGet("GetCustomerById/{id:int}", Name = "GetCustomerById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDTO))]
        public CustomerDTO GetCustomerById(int id) => _customerService.GetCustomerById(id);

        [HttpPost("CreateCustomer", Name = "CreateCustomer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია !");
                var result = _customerService.RegisterCustomer(customer);
                if (!result)
                    throw new Exception("კლიენტის რეგისტრაცია წარუმატებელია !");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("EditCustomer", Name = "EditCustomer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია !");
                var c = _customerService.GetCustomerById(customer.Id.Value);
                if (c == null)
                    return NotFound($"რეგისტრირებული მომხმარებელი , უნიკალური ნომრით {customer.Id.Value} ვერ მოიძებნა !");
                var result = _customerService.EditCustomer(customer);
                if (!result)
                    throw new Exception("კლიენტის რედაქტირება წარუმატებელია !");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteCustomer/{id:int}", Name = "DeleteCustomer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var c = _customerService.GetCustomerById(id);
                if (c == null)
                    return NotFound($"რეგისტრირებული მომხმარებელი , უნიკალური ნომრით {id} ვერ მოიძებნა !");
                var result = _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetRelationshipType", Name = "GetRelationshipType")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDTO>))]
        public List<RelationshipTypeDTO> GetRelationshipType(int CustomerId) => _customerService.GetRelationshipType(CustomerId);

    }
}
