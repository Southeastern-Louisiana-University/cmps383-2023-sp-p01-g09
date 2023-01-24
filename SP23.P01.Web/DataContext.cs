using Microsoft.EntityFrameworkCore;
using SP23.P01.Web;
using SP23.P01.Web.Features.TrainStation;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public  DbSet<WeatherForecast> WeatherForecasts { get; set;}
    public  DbSet<TrainStation> TrainStations { get; set;}
}
