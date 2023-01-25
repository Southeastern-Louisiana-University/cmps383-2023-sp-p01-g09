
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SP23.P01.Web.Features.TrainStation;

namespace SP23.P01.Web.Controllers
{
    [ApiController]
    [Route("api/stations")]
    public class TrainStationController : Controller
    {
        private DataContext _dataContext;
        public TrainStationController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public ActionResult GetStations()
        {
            var returnedStations = _dataContext.TrainStations.Select(x => new TrainStationDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).ToList();

            return Ok(returnedStations);
        }

        [HttpGet("{id}")]
        public ActionResult GetStationById(int id)
        {
            List<String> Errors = new List<String>();
            if (id <= 0)
            {
                Errors.Add("Ids are only integers 1 and up.");
                return BadRequest(Errors);
            }
            var matchingStation = _dataContext.TrainStations.FirstOrDefault(x => x.Id == id);
            if (matchingStation == null)
            {
                Errors.Add("The train station the user was seeking does not exist.");
                return NotFound(Errors);
            }
            else
            {
                var returnStation = new TrainStationDto
                {
                    Id = matchingStation.Id,
                    Name = matchingStation.Name,
                    Address = matchingStation.Address
                };
                return Ok(returnStation);
            }
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStation(int id, TrainStationUpdateDto updatesDto)
        {
            List<String> Errors = new List<String>();
            if (id <= 0)
            {
                Errors.Add("Ids are only integers 1 and up.");
            }
            if (updatesDto.Name.Trim() == "")
            {
                Errors.Add("The name can't be empty.");
            }
            if (updatesDto.Name.Trim().Length > 120)
            {
                Errors.Add("The name can't be longer than 120 characters.");
            }
            if (updatesDto.Address.Trim() == "")
            {
                Errors.Add("The address can't be empty.");
            }
            if (Errors.Count > 0)
            {
                return BadRequest(Errors.ToArray());
            }
            var stationToUpdate = _dataContext.TrainStations.FirstOrDefault(x => x.Id == id);
            if (stationToUpdate == null)
            {
                Errors.Add("The train station the user was seeking does not exist.");
                return NotFound(Errors);
            }
          
                stationToUpdate.Name = updatesDto.Name;
                stationToUpdate.Address = updatesDto.Address;
                _dataContext.SaveChanges();

                TrainStationDto returnStation = new TrainStationDto
                {
                    Id = stationToUpdate.Id,
                    Name = stationToUpdate.Name,
                    Address = stationToUpdate.Address,
                };
                return Ok(returnStation);
        }

       /* public IActionResult Index()
        {
            return View();
        }*/
    }
}
