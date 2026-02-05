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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, Date = new DateOnly(2026, 2, 10), Time = new TimeOnly(9, 0), Hairdresser = "Anna", CustomerName = "Sofia Larsson", PhoneNr = "0701234567" },
                new Booking { Id = 2, Date = new DateOnly(2026, 2, 10), Time = new TimeOnly(10, 0), Hairdresser = "Erik", CustomerName = "Johan Svensson", PhoneNr = "0739876543" },
                new Booking { Id = 3, Date = new DateOnly(2026, 2, 10), Time = new TimeOnly(11, 0), Hairdresser = "Anna", CustomerName = "Elin Andersson", PhoneNr = "0725551234" },
                new Booking { Id = 4, Date = new DateOnly(2026, 2, 11), Time = new TimeOnly(9, 30), Hairdresser = "Erik", CustomerName = "Mikael Johansson", PhoneNr = "0761122334" },
                new Booking { Id = 5, Date = new DateOnly(2026, 2, 11), Time = new TimeOnly(10, 30), Hairdresser = "Anna", CustomerName = "Lisa Karlsson", PhoneNr = "0709988776" },
                new Booking { Id = 6, Date = new DateOnly(2026, 2, 12), Time = new TimeOnly(13, 0), Hairdresser = "Erik", CustomerName = "Fredrik Nilsson", PhoneNr = "0736655443" },
                new Booking { Id = 7, Date = new DateOnly(2026, 2, 12), Time = new TimeOnly(14, 0), Hairdresser = "Anna", CustomerName = "Emma Olsson", PhoneNr = "0723344556" },
                new Booking { Id = 8, Date = new DateOnly(2026, 2, 13), Time = new TimeOnly(10, 0), Hairdresser = "Erik", CustomerName = "Patrik Lindberg", PhoneNr = "0707766554" },
                new Booking { Id = 9, Date = new DateOnly(2026, 2, 13), Time = new TimeOnly(11, 0), Hairdresser = "Anna", CustomerName = "Johanna Berg", PhoneNr = "0732233445" },
                new Booking { Id = 10, Date = new DateOnly(2026, 2, 14), Time = new TimeOnly(12, 0), Hairdresser = "Erik", CustomerName = "David Svensson", PhoneNr = "0728899001" },
                new Booking { Id = 11, Date = new DateOnly(2026, 2, 15), Time = new TimeOnly(13, 0), Hairdresser = "Erik", CustomerName = "Hanna Svensson", PhoneNr = "0768990565" }
                );
        }

    }
}
