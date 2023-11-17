using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DomainModels.OrderItem;

namespace WebApplication_Project1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("GetAllOrder", Name = "GetAllOrder")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDTO>))]
        public IEnumerable<OrderDTO> GetAllOrder() => _orderService.GetOrders();

        [HttpGet("GetOrderById/{id:int}", Name = "GetOrderById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
        public OrderDTO GetOrderById(int id) => _orderService.GetOrderById(id);

        [HttpPost("CreateOrder", Name = "CreateOrder")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateOrder([FromBody] OrderDTO order)
        {
            try
            {
                if (order == null || !order.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია !");
                var result = _orderService.RegisterOrder(order);
                if (!result)
                    throw new Exception("შეკვეთის რეგისტრაცია წარუმატებელია !");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("EditOrder", Name = "EditOrder")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditOrder([FromBody] OrderDTO order)
        {
            try
            {
                if (order == null || !order.Id.HasValue)
                    return BadRequest("მონაცემები არავალიდურია !");
                var c = _orderService.GetOrderById(order.Id.Value);
                if (c == null)
                    return NotFound($"რეგისტრირებული შეკვეთა , უნიკალური ნომრით {order.Id.Value} ვერ მოიძებნა !");
                var result = _orderService.EditOrder(order);
                if (!result)
                    throw new Exception("შეკვეთის რედაქტირება წარუმატებელია !");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteOrder/{id:int}", Name = "DeleteOrder")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var c = _orderService.GetOrderById(id);
                if (c == null)
                    return NotFound($"რეგისტრირებული შეკვეთა , უნიკალური ნომრით {id} ვერ მოიძებნა !");
                var result = _orderService.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetOrderItem", Name = "GetOrderItem")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderItemDTO>))]
        public List<OrderItemDTO> GetOrderItem(int productId) => _orderService.GetOrderItems(productId);

    }
}
