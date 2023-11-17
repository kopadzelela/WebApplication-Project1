namespace WebApplication_Project1.DomainModels.Product
{
    public class WarehouseDTO
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExipryDate { get; set; }

    }
}
