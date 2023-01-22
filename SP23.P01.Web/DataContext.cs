using Microsoft.EntityFrameworkCore;
using SP23.P01.Web;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public  DbSet<WeatherForecast> WeatherForecasts { get; set;}
}
