using Klipp_StyleSalong.Data;
using Klipp_StyleSalong.DTOs;
using Klipp_StyleSalong.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Klipp_StyleSalong.Endpoints
{    
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
            .WithSummary("All bookings by pagination")
            .WithDescription("Query params are page and pageSize. Booking data include: Date, Time, Hairdresser, CustomerName, PhoneNr.");


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
            .WithSummary("All the bookings on the requested date")
            .WithDescription("Takes date as route param). Booking data include: Date, Time, Hairdresser, CustomerName, PhoneNr.");


            app.MapPost("/bookings", async (SalonDbContext context, BookingDto newBooking) =>
            {
                var validationContext = new ValidationContext(newBooking);

                var validationResults = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newBooking, validationContext, validationResults, true);

                if (!isValid)
                {
                    return Results.BadRequest();
                }

                var bookingTime = newBooking.Date.ToDateTime(newBooking.Time);
                
                if (bookingTime < DateTime.Now)
                {
                    return Results.BadRequest("Tiden har passerat");
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
            .WithSummary("Receives booking save in the database. ")
            .WithDescription("Receives booking information (JSON) in body to save as booking in the database. Requested data is: Date, Time, Hairdresser, CustomerName, PhoneNr. Validates that customer has given a PhoneNr with digits and their name in booking. Also check that booking time hasn't already passed.");

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
            .WithSummary("Removes a booking by id")
            .WithDescription("Removes a booking from database by booking id. Id is necessary to find the booking and delete it in the system.");
        }
    }
}
