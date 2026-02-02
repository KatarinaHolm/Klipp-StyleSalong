using Klipp_StyleSalong.Models;
using Microsoft.EntityFrameworkCore;

namespace Klipp_StyleSalong.Data
{
    public class SalonDbContext : DbContext
    {

        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base (options)
        {
            
        }
        public DbSet<Booking> Bookings { get; set; }

    }
}
