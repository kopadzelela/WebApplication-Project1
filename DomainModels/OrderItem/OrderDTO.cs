namespace WebApplication_Project1.DomainModels.OrderItem
{
    public class OrderDTO
    {
        public int? Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public int TotalAmount { get; set; }
    }
}
