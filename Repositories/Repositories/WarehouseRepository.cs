using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.Repositories.Repositories
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository (ProjectDBContext dBContext) : base(dBContext)
        {


        }
    }
}
