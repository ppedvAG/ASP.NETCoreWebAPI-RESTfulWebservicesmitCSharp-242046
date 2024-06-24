using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace M003_VehicleFleetApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpGet]
        [Route("vehicles")]
        public IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles = Enumerable.Range(0, 5)
                .Select(i => _vehicleService.CreateVehicle(i))
                .ToArray();

            return vehicles;
        }
    }
}
