using System.Threading.Tasks;
using InchCapeTest.DtoS;
using InchCapeTest.Enums;
using InchCapeTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InchCapeTest.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VehiclePropertyController: ControllerBase
    {
        private readonly IVehiclePropertyService _vehiclePropertyService;

        public VehiclePropertyController(IVehiclePropertyService vehiclePropertyService)
        {
            _vehiclePropertyService = vehiclePropertyService;
        }
        [HttpGet]
        [Route("makes", Name = nameof(GetMakes))]
        public async Task<IActionResult> GetMakes()
        {
            return Ok(await _vehiclePropertyService.GetAll(VehiclePropertyEnum.Make));
        }
        
        [HttpGet]
        [Route("quoteTypes", Name = nameof(GetQuoteTypes))]
        public async Task<IActionResult> GetQuoteTypes()
        {
            return Ok(await _vehiclePropertyService.GetAll(VehiclePropertyEnum.QuoteType));
        }
        
        [HttpGet]
        [Route("vehicleTypes", Name = nameof(GetVehicleTypes))]
        public async Task<IActionResult> GetVehicleTypes()
        {
            return Ok(await _vehiclePropertyService.GetAll(VehiclePropertyEnum.VehicleType));
        }
        
        [HttpPost]
        [Route("makes", Name = nameof(AddMake))]
        public IActionResult AddMake([FromBody] VehiclePropertyRequestModel model)
        { 
            return AddNew(model, VehiclePropertyEnum.Make);
        }
        
        [HttpPost]
        [Route("quoteTypes", Name = nameof(AddQuoteType))]
        public IActionResult AddQuoteType([FromBody] VehiclePropertyRequestModel model)
        {
            return AddNew(model, VehiclePropertyEnum.QuoteType);
        }
        
        [HttpPost]
        [Route("vehicleTypes", Name = nameof(AddVehicleType))]
        public IActionResult AddVehicleType([FromBody] VehiclePropertyRequestModel model)
        {
            return AddNew(model, VehiclePropertyEnum.VehicleType);
        }

        private IActionResult AddNew(VehiclePropertyRequestModel model, VehiclePropertyEnum type)
        {
            if (string.IsNullOrEmpty(model.Label))
            {
                return BadRequest(new
                {
                    message = $"Value cannot be empty for {type.ToString()}"
                });
            }
            _vehiclePropertyService.AddNew(model, type);
             return Ok();
        }
    }
}