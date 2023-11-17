using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.Repositories.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository (ProjectDBContext dBContext) : base(dBContext)
        {

        }
    }
}
