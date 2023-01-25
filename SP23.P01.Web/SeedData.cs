
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using SP23.P01.Web.Features.TrainStation;
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
            
            if (context.TrainStations.Any())
            {
                return;   // DB has been seeded
            }

            context.TrainStations.AddRange(
                new TrainStation
                {
                    Name = "Hammond Station",
                    Address = "110 Hammond Square Street"
                },
                new TrainStation
                {
                    Name = "Peachtree Station",
                    Address = "1688 Peachtree Street"
                },
                new TrainStation
                {
                    Name = "Cincinnati Union Terminal",
                    Address = "1301 Western Avenue"
                }

            );
            context.SaveChanges();
        }
    }

}

