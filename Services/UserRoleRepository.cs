using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Services
{
    public class UserRoleRepository: GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
