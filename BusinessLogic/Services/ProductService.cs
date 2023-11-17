using WebApplication_Project1.BusinessLogic.Contracts;
using WebApplication_Project1.DataAccess;
using WebApplication_Project1.DomainModels.Product;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        public ProductService(IProductRepository productRepository, 
               IWarehouseRepository warehouseRepository)
        {
            this._productRepository = productRepository;  
            this._warehouseRepository = warehouseRepository;
        }
        public List<ProductDTO> GetProducts()
        {
            var products = _productRepository.GetAll();
            List<ProductDTO> result = products.Select(c => new ProductDTO
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                CategoryId = c.CategoryId,
                ProductCategoryId = c.ProductCategoriesId
            }).ToList();
            return result;
        }
        public bool RegisterProduct(ProductDTO product)
        {
            try
            {
                if (product == null)
                    throw new Exception("Invalid Data !");
                Product p = new Product();
                p.Code = product.Code;
                p.Name = product.Name;
                p.CategoryId = product.CategoryId;
                p.ProductCategoriesId = product.ProductCategoryId;
                _productRepository.Insert(p);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditProduct(ProductDTO product)
        {
            try
            {
                if (product == null || !product.Id.HasValue)
                    throw new Exception("Invalid Data !");
                var p = _productRepository.Get(product.Id.Value);
                p.Code = product.Code;
                p.Name = product.Name;
                p.CategoryId = product.CategoryId;
                p.ProductCategoriesId = product.ProductCategoryId;
                _productRepository.Update(p);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteProduct(int productId)
        {
            try
            {
                var product = _productRepository.Get(productId);
                if (product == null)
                    throw new Exception("Not Found !");
                _productRepository.Delete(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ProductDTO GetProductById(int productId)
        {
             var p = _productRepository.Get(productId);
            ProductDTO result = new ProductDTO
            {
             Id = p.Id,
             Code = p.Code,
             Name = p.Name,
             CategoryId = p.CategoryId,
             ProductCategoryId = p.ProductCategoriesId        
            };
            return result;
        }
        public List<WarehouseDTO> GetWarehouse(int productId)
        {
            try
            {
                var p = _productRepository.Get(productId);
                if (p == null)
                    throw new Exception("Not Found !");
                var pa = _warehouseRepository.FindByCondition(p => p.ProductId == productId);
                if (!pa.Any())
                    return new List<WarehouseDTO>();
                List<WarehouseDTO> result = pa.Select(i => new WarehouseDTO 
                { Code = i.Product.Code, 
                  Name = i.Product.Name,
                  UnitPrice = i.UnitPrice, 
                  UnitName = i.Unit.Name, 
                  Quantity = i.Quantity, 
                  ExipryDate = i.ExipryDate
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
