using Domain.Services;
using Spa.Data;
using Spa.Services;

namespace Spa.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable


    {
        private readonly ILogger _logger;
        private readonly ElasticClient _elasticClient;

        public IPermissionRepository Permission { get; private set; }
        public IPermissionTypeRepository PermissionType { get; private set; }

        public UnitOfWork(PermissionsWebApiContext context, ElasticClient elasticClient, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            _elasticClient = elasticClient;

            Permission = new PermissionRepository(context, elasticClient, _logger);

            PermissionType = new PermissionTypeRepository(context, elasticClient, _logger);
        }

        private readonly ApplicationDbContext _context;
        public ITreatmentRepository TreatmentRepository { get; private set; }

        public ITreatmentTimeRepository TreatmentTimeRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IUserRoleRepository UserRoleRepository { get; private set; }

        public IScheduleRepository ScheduleRepository { get; private set; }

        public IBookingRepository BookingRepository { get; private set; }

        public IBookingStatusRepository BookingStatusRepository { get; private set; }

        public IPermissionRepository Permission => throw new NotImplementedException();

        public IPermissionTypeRepository PermissionType => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            TreatmentRepository = new TreatmentRepository(_context);
            TreatmentTimeRepository = new TreatmentTimeRepository(_context);
            UserRepository = new UserRepository(_context);
            UserRoleRepository = new UserRoleRepository(_context);
            BookingRepository = new BookingRepository(_context);
            BookingStatusRepository = new BookingStatusRepository(_context);
            ScheduleRepository = new ScheduleRepository(_context);


        }
        public void Commit()
        {
            _context.SaveChanges();

        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
