using BusinessLogic.Contracts;
using BusinessLogic.Models;
using M008_Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M003_VehicleFleetApi.Controllers
{
    // Mit diesem Attribut muss der User sein JWT Bearer Token im Request Header setzen
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclesController> _logger;
        private readonly AuthDemoDbContext _context;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger, AuthDemoDbContext context)
        {
            _vehicleService = vehicleService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles.ToArrayAsync();
        }

        [HttpPost]
        [Route("generate")]
        public async Task<IActionResult> GenerateVehicles([FromQuery] int count)
        {
            var vehicles = Enumerable.Range(0, count)
                .Select(i => _vehicleService.CreateVehicle(i))
                .ToArray();

            _context.Vehicles.AddRange(vehicles);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
