using Pasteleria.Commands;
using Pasteleria.Configuration;
using Pasteleria.Models;
using Pasteleria;

namespace Pasteleria.QueryHandler
{
    public class PermissionQueryHandler : IQueryHandler<Permission, QueryByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            return await _unitOfWork.Permission.GetAllAsync();
        }

        public async Task<Permission> GetOne(QueryByIdCommand query)
        {
            return await _unitOfWork.Permission.GetById(query.Id);
        }
    }
}
