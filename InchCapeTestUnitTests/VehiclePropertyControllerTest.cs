using System.Collections.Generic;
using System.Linq;
using InchCapeTest.Controllers.v1;
using InchCapeTest.DtoS;
using InchCapeTestUnitTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InchCapeTestUnitTests
{
    public class VehiclePropertyControllerTest
    {
        private readonly VehiclePropertyMocks _vehiclePropertyMocks;

        public VehiclePropertyControllerTest()
        {
            _vehiclePropertyMocks = new VehiclePropertyMocks();
            _vehiclePropertyMocks.SetUpMock();
        }
        
        [Fact]
        public void GetMakesTest_Should_Result_OkObjectResult_With_VehicleMakes_Data()
        {
            var controller = new VehiclePropertyController(_vehiclePropertyMocks.VehiclePropertyService);
            var vehiclesMakesTask = controller.GetMakes().Result;
            var result = vehiclesMakesTask.Result as OkObjectResult;
            var makes = (IList<VehiclePropertyModel>) result?.Value;
            Assert.True(makes != null && makes.Count() == 2);
        }
        
        [Fact]
        public void AddNew_Should_Result_OkObjectResult_With_Adding_Data()
        {
            var mockVehicleMakeToAdd = new VehiclePropertyRequestModel
            {
                Label = "MyVehicle"
            };
            var controller = new VehiclePropertyController(_vehiclePropertyMocks.VehiclePropertyService);
            controller.AddMake(mockVehicleMakeToAdd);
            var vehicleMakesTask = controller.GetMakes().Result;
            var result = vehicleMakesTask.Result as OkObjectResult;
            var makes = (IList<VehiclePropertyModel>) result?.Value;
            Assert.True(makes != null && makes.Count() == 3);
        }
    }
}