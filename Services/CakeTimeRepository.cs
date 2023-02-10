using Pasteleria.Data;
using Pasteleria.Models;

namespace Pasteleria.Services
{
    public class CakeTimeRepository: GenericRepository<CakeTime>, ICakeTimeRepository
    {
        public CakeTimeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
