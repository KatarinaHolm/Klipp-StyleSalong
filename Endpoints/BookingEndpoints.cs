using Klipp_StyleSalong.Data;
using Klipp_StyleSalong.DTOs;
using Klipp_StyleSalong.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Klipp_StyleSalong.Endpoints
{
    //Lägg till kommentarer med fluent, lägg till på ReadMe pagingering och GET datum, + Avancerad validering: Se till att en tid inte kan bokas om den redan passert
    public class BookingEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            app.MapGet("/bookings", async (SalonDbContext context, int page, int pageSize) =>
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
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (!bookings.Any())
                {
                    return Results.NoContent();
                }

                return Results.Ok(bookings);

            })
            .WithSummary("")
            .WithDescription("");


            app.MapGet("/bookings/date/{date}", async (SalonDbContext context, DateOnly date) =>
            {
                var bookings = await context.Bookings
                    .Where(b => b.Date == date)
                    .Select(b => new BookingDto
                    {
                        Date = b.Date,
                        Time = b.Time,
                        Hairdresser = b.Hairdresser,
                        CustomerName = b.CustomerName,
                        PhoneNr = b.PhoneNr
                    })                  
                    .ToListAsync();

                if (!bookings.Any())
                {
                    return Results.NoContent();
                }

                return Results.Ok(bookings);

            })
            .WithSummary("")
            .WithDescription("");


            app.MapPost("/bookings", async (SalonDbContext context, BookingDto newBooking) =>
            {
                var validationContext = new ValidationContext(newBooking);

                var validationResults = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newBooking, validationContext, validationResults, true);

                if (!isValid)
                {
                    return Results.BadRequest();
                }

                var booking = new Booking()
                {
                    Date = newBooking.Date,
                    Time = newBooking.Time,
                    Hairdresser = newBooking.Hairdresser,
                    CustomerName = newBooking.CustomerName,
                    PhoneNr = newBooking.PhoneNr
                };

                context.Bookings.Add(booking);
                await context.SaveChangesAsync();

                return Results.Ok(booking);

            })
            .WithSummary("")
            .WithDescription("");

            app.MapDelete("/bookings/{id}", async (SalonDbContext context, int id) =>
            {
                var booking = await context.Bookings.FindAsync(id);

                if (booking == null)
                {
                    return Results.NotFound();
                }

                context.Bookings.Remove(booking);
                await context.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithSummary("")
            .WithDescription("");
        }
    }
}
