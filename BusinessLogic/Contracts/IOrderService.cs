using WebApplication_Project1.DomainModels.OrderItem;

namespace WebApplication_Project1.BusinessLogic.Contracts
{
    public interface IOrderService
    {
        List<OrderDTO> GetOrders();
        OrderDTO GetOrderById(int orderId);
        bool RegisterOrder(OrderDTO order);
        bool EditOrder(OrderDTO order);
        bool DeleteOrder(int OrderId);
        List<OrderItemDTO> GetOrderItems(int productId);
    }
}
