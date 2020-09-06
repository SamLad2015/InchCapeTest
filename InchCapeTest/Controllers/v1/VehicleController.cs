using System.Collections.Generic;
using System.Threading.Tasks;
using InchCapeTest.DtoS;
using InchCapeTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InchCapeTest.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VehicleController: ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet(Name = nameof(GetVehicles))]
        public async Task<ActionResult<IList<VehicleModel>>> GetVehicles()
        {
            return Ok(await _vehicleService.GetAll());
        }
        [HttpPost(Name = nameof(AddVehicle))]
        public IActionResult AddVehicle([FromBody] VehicleRequestModel model)
        {
            _vehicleService.AddNew(model);
            return Ok();
        }
    }
}