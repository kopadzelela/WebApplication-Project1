using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.Repositories.Repositories
{
    public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(ProjectDBContext dBContext):base(dBContext)
        {
            

        }
    }
}
