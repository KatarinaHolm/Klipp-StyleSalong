
using Klipp_StyleSalong.Data;
using Klipp_StyleSalong.Endpoints;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Klipp_StyleSalong
{
    public class Program
    {
        public static void Main(string[] args)
        {           
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<SalonDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            BookingEndpoints.RegisterEndpoints(app);
          
            app.Run();
        }
    }
}
