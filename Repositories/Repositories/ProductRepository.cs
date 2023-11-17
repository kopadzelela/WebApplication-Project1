using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.Repositories.Repositories
{
    public class ProductRepository: BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(ProjectDBContext dBContext):base(dBContext)
        {
                
        }
    }
}
