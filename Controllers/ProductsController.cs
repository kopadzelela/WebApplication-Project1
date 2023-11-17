using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DomainModels.Product;

namespace WebApplication_Project1.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet("GetAll", Name = "GetAll")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDTO>))]
        public IEnumerable<ProductDTO> GetAll() => _productService.GetProducts();

        [HttpGet("GetProductById/{id:int}", Name = "GetProductById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        public ProductDTO GetProductById(int id) => _productService.GetProductById(id);

        [HttpPost("CreateProduct", Name = "CreateProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProduct([FromBody] ProductDTO product)
        {
            try
            {
                if (product == null || !product.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია !");
                var result = _productService.RegisterProduct(product);
                if (!result)
                    throw new Exception("პროდუქტის რეგისტრაცია წარუმატებელია !");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("EditProduct", Name = "EditProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditProduct([FromBody] ProductDTO product)
        {
            try
            {
                if (product == null || !product.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია !");
                var c = _productService.GetProductById(product.Id.Value);
                if (c == null)
                    return NotFound($"რეგისტრირებული პროდუქტი , უნიკალური ნომრით {product.Id.Value} ვერ მოიძებნა !");
                var result = _productService.EditProduct(product);
                if (!result)
                    throw new Exception("პროდუქტის რედაქტირება წარუმატებელია !");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteProduct/{id:int}", Name = "DeleteProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var c = _productService.GetProductById(id);
                if (c == null)
                    return NotFound($"რეგისტრირებული პროდუქტი , უნიკალური ნომრით {id} ვერ მოიძებნა !");
                var result = _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetWarehouse", Name = "GetWarehouse")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDTO>))]
        public List<WarehouseDTO> GetWarehouse (int ProductId) => _productService.GetWarehouse(ProductId);

    }
}
