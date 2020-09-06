using System.Collections.Generic;
using System.Linq;
using InchCapeTest.Controllers.v1;
using InchCapeTest.DtoS;
using InchCapeTestUnitTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InchCapeTestUnitTests
{
    public class VehicleControllerTest
    {
        private readonly VehicleMocks _vehicleMocks;
        public VehicleControllerTest()
        {
            _vehicleMocks = new VehicleMocks();
            _vehicleMocks.SetupMocks();
        }
        
        [Fact]
        public void GetAllTest_Should_Result_OkObjectResult_With_Vehicles_Data()
        {
            var controller = new VehicleController(_vehicleMocks.VehicleService);
            var vehiclesTask = controller.GetVehicles().Result;
            var result = vehiclesTask.Result as OkObjectResult;
            var vehicles = (IList<VehicleModel>) result?.Value;
            Assert.True(vehicles != null && vehicles.Count() == 4);
        }
        
        [Fact]
        public void AddNew_Should_Result_OkObjectResult_With_Adding_Data()
        {
            var mockVehicleToAdd = new VehicleRequestModel
            {
                MakeId = 1,
                QuoteTypeId = 2,
                VehicleTypeId = 2,
                Upto3MonthsApr = 3.5,
                Between3To6MonthsApr = 4.7,
                Between6To12MonthsApr = 5.1,
                MoreThan12MonthsApr = 3.7
            };
            var controller = new VehicleController(_vehicleMocks.VehicleService);
            controller.AddVehicle(mockVehicleToAdd);
            var vehiclesTask = controller.GetVehicles().Result;
            var result = vehiclesTask.Result as OkObjectResult;
            var vehicles = (IList<VehicleModel>) result?.Value;
            Assert.True(vehicles != null && vehicles.Count() == 5);
        }
    }
}