
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Linq;
namespace SP23.P01.Web;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {

        
            var content = serviceProvider.GetRequiredService<DataContext>();
            content.Database.Migrate();

        using (var context = new DataContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DataContext>>()))
        {
        
            // Look for any movies.
            if (context.WeatherForecasts.Any())
            {
                return;   // DB has been seeded
            }

            context.WeatherForecasts.AddRange(
                new WeatherForecast
                {
                    Summary = "sunny",
                    Date = DateTime.Parse("1989-2-12"),          
                    TemperatureC = 32,
                },
                new WeatherForecast
                {
                    Summary = "sunny",
                    Date = DateTime.Parse("1984-3-13"),
                    TemperatureC = 32,
                }

            );
            context.SaveChanges();
        }
    }
}

