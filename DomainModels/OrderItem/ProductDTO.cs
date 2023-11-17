namespace WebApplication_Project1.DomainModels.OrderItem
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
