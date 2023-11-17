using WebApplication_Project1.DomainModels.Product;

namespace WebApplication_Project1.BusinessLogic.Contracts
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProductById(int productId);
        bool RegisterProduct(ProductDTO product);
        bool EditProduct(ProductDTO product);
        bool DeleteProduct(int productId);
        List<WarehouseDTO> GetWarehouse (int productId);
    }
}
