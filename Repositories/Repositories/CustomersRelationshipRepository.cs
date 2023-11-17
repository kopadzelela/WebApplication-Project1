using WebApplication_Project1.DataAccess;
using WebApplication_Project1.Repositories.Interfaces;

namespace WebApplication_Project1.Repositories.Repositories
{
    public class CustomersRelationshipRepository : BaseRepository<CustomersRelationship>, ICustomersRelationshipRepository
    {
        public CustomersRelationshipRepository(ProjectDBContext dBContext) : base(dBContext)
        {


        }
    }
}
