using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Services
{
    public class UserRepository: GenericRepository<Client>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
