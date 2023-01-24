
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

       /* public IActionResult Index()
        {
            return View();
        }*/
    }
}
