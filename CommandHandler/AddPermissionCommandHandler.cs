using Microsoft.Extensions.Internal;
using Spa.Configuration;
using Spa.DTOs;
using Spa.Models;

namespace Spa.CommandHandler
{
    public class AddPermissionCommandHandler : ICommandHandler<PermissionDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public CommandResult Execute(PermissionDTO permission)
        {
            var newPermission = new Permission()
            {
                Id = permission.Id,
                EmployeeForename = permission.EmployeeForename,
                EmployeeSurname = permission.EmployeeSurname,
                PermissionDate = permission.PermissionDate,
                PermissionTypeId = permission.PermissionTypeId
            };
            _unitOfWork.Permission.Add(newPermission);
            _unitOfWork.Commit();

            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        }

        Spa.CommandResult ICommandHandler<PermissionDTO>.Execute(PermissionDTO command)
        {
            throw new NotImplementedException();
        }
    }
}
