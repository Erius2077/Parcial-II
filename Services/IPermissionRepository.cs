using Pasteleria.Models;

namespace Pasteleria.Services
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<Permission> GetById(int id);
    }
}
