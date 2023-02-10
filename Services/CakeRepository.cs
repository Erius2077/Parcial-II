using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Services
{
    public class TreatmentRepository: GenericRepository<Cake>, ITreatmentRepository
    {
        public TreatmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
