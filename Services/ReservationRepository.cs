using Microsoft.EntityFrameworkCore;
using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Services
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            var applicationDbContext = _context.Reservation.Include(b => b.User);
            return await applicationDbContext.ToListAsync();
        }
        public async Task<Reservation> GetByIdAsync(int id )
        {
             return await _context.Reservation
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
