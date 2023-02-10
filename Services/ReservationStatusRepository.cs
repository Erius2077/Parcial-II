using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Services
{
    public class BookingStatusRepository: GenericRepository<ReservationStatus>, IReservationStatusRepository
    {
        public ReservationStatusRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
