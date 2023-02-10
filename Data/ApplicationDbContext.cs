using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pasteleria.Models;
using Microsoft.EntityFrameworkCore;



namespace Pasteleria.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Spa.Models.UserRole> UserRole { get; set; } = default!;
        public DbSet<Spa.Models.Client> Client { get; set; } = default!;
        public DbSet<Spa.Models.Cake> Cake { get; set; } = default!;
        public DbSet<Spa.Models.Calendary> Calendary { get; set; } = default!;
        public DbSet<Spa.Models.ReservationStatus> ReservationStatus { get; set; } = default!;
        public DbSet<Spa.Models.Reservation> Reservation { get; set; } = default!;


    }
}