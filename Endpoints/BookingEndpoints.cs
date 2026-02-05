using Klipp_StyleSalong.Data;
using Klipp_StyleSalong.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Klipp_StyleSalong.Endpoints
{
    public class BookingEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/bookings", async (SalonDbContext context) =>
            {                
                var bookings = await context.Bookings
                    .Select(b => new BookingDto
                    {
                        Date = b.Date,
                        Time = b.Time,
                        Hairdresser = b.Hairdresser,
                        CustomerName = b.CustomerName,
                        PhoneNr = b.PhoneNr
                    })
                    .ToListAsync();

                if (bookings == null)
                {
                    return Results.NoContent();
                }

                return Results.Ok(bookings);

            });
        }
    }
}
