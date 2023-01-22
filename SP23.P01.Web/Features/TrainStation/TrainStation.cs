using System.ComponentModel.DataAnnotations;

namespace SP23.P01.Web.Features.TrainStation
{
    public class TrainStation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
    public class TrainStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
