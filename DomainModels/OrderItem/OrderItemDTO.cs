namespace WebApplication_Project1.DomainModels.OrderItem
{
    public class OrderItemDTO
    {
        public int? Id { get; set; }    
        public int ProductId { get; set; }  
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool? IsDiscounter { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}
