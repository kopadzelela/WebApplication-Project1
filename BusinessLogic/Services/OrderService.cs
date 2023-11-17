using Microsoft.CodeAnalysis;
using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DataAccess;
using WebApplication_Project1.DomainModels.OrderItem;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, 
            IOrderItemRepository orderItemRepository)
        {
            this._orderRepository = orderRepository;
            this._orderItemRepository = orderItemRepository;
        }
        public List<OrderDTO> GetOrders()
        {
            var orders = _orderRepository.GetAll();
            List<OrderDTO> result = orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                OrderNumber = o.OrderNumber,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount
            }).ToList();
            return result;
        }
        public bool RegisterOrder(OrderDTO order)
        {
            try
            {
                if (order == null)
                    throw new Exception("Invalid Data !");
                Order o = new Order();
                o.OrderDate = order.OrderDate;
                o.OrderNumber = order.OrderNumber;
                o.CustomerId = order.CustomerId;
                o.TotalAmount = order.TotalAmount;
                _orderRepository.Insert(o);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditOrder(OrderDTO order)
        {
            try
            {
                if (order == null || !order.Id.HasValue)
                    throw new Exception("Invalid Data !");
                var o = _orderRepository.Get(order.Id.Value);
                o.OrderDate = order.OrderDate;
                o.OrderNumber = order.OrderNumber;
                o.CustomerId = order.CustomerId;
                o.TotalAmount = order.TotalAmount;
                _orderRepository.Update(o);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            try
            {
                var order = _orderRepository.Get(orderId);
                if (order == null)
                    throw new Exception("Not Found !");
                _orderRepository.Delete(order);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public OrderDTO GetOrderById(int orderId)
        {
            var o = _orderRepository.Get(orderId);
            OrderDTO result = new OrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                OrderNumber = o.OrderNumber,
                CustomerId = o.CustomerId,
                TotalAmount = o.TotalAmount,
            };
            return result;
        }
        public List<OrderItemDTO> GetOrderItems(int productId)
        {
            try
            {
                var o = _orderItemRepository.Get(productId);
                if (o == null)
                    throw new Exception("Not Found !");
                var oi = _orderItemRepository.FindByCondition(o => o.ProductId == productId);
                if (!oi.Any())
                    return new List<OrderItemDTO>();
                List<OrderItemDTO> result = oi.Select(i => new OrderItemDTO
                {
                    ProductCode = i.Product.Code,
                    ProductCategory = i.Product.Category.Name,
                    ProductName = i.Product.Name,
                    Price = (decimal)((i.UnitPrice - (i.DiscountPrice)) * i.Quantity)

                }).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
