using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SP23.P01.Web.Features.TrainStation
{
    public class TrainStation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

    }
    public class TrainStationConfiguration : IEntityTypeConfiguration<TrainStation>
    {
        public void Configure(EntityTypeBuilder<TrainStation> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(t => t.Address)
                .IsRequired();
        }
    }
    

    public class TrainStationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

    }
    public class TrainStationCreateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }

    }
    public class TrainStationUpdateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
