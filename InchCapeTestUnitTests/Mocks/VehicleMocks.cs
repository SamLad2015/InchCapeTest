using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InchCapeTest.DtoS;
using InchCapeTest.Interfaces;
using Moq;

namespace InchCapeTestUnitTests.Mocks
{
    public class VehicleMocks
    {
        public IVehicleService VehicleService;
        private readonly IList<VehicleModel> _vehicles = new List<VehicleModel>();
     
        public void SetupMocks() 
        {
            var vehiclePropertyMocks = new VehiclePropertyMocks();
            var vehicleServiceMoq = new Mock<IVehicleService>();

            var makes = vehiclePropertyMocks.GetFakeMakes();
            var vehicleTypes = vehiclePropertyMocks.GetFakeVehicleTypes();
            var quoteTypes = vehiclePropertyMocks.GetFakeQuoteTypes();

            vehicleServiceMoq
                .Setup(o => o.GetAll())
                .Returns(Task.FromResult(FakeVehicleModels()));
            
            vehicleServiceMoq
                .Setup(o => o.AddNew(It.IsAny<VehicleRequestModel>()))
                .Callback((VehicleRequestModel model) =>
                { 
                    _vehicles.Add(new VehicleModel
                    {
                        Id = _vehicles.Last().Id + 1,
                        Make = makes.First(m => m.Id == model.MakeId).Make,
                        VehicleType = vehicleTypes.First(m => m.Id == model.VehicleTypeId).VehicleType,
                        QuoteType = quoteTypes.First(m => m.Id == model.QuoteTypeId).QuoteType,
                        AprRanges = new AprRangeModel
                        {
                            Upto3MonthsApr = model.Upto3MonthsApr,
                            Between3To6MonthsApr = model.Between3To6MonthsApr,
                            Between6To12MonthsApr = model.Between6To12MonthsApr,
                            MoreThan12MonthsApr = model.MoreThan12MonthsApr
                        }
                    });
                });
            
            VehicleService = vehicleServiceMoq.Object;
        }

        private IList<VehicleModel> FakeVehicleModels()
        {
            _vehicles.Add(new VehicleModel
            {
                Id = 1,
                Make = "MyAudi",
                VehicleType = "MyCar",
                QuoteType = "MyPcp",
                AprRanges = new AprRangeModel()
                {
                    Upto3MonthsApr = 3.5,
                    Between3To6MonthsApr = 6.0,
                    Between6To12MonthsApr = 4.5,
                    MoreThan12MonthsApr = 5.5
                }
            });
            _vehicles.Add(new VehicleModel
            {
                Id = 2,
                Make = "MyBmw",
                VehicleType = "MyCar",
                QuoteType = "MyHp",
                AprRanges = new AprRangeModel()
                {
                    Upto3MonthsApr = 3.1,
                    Between3To6MonthsApr = 7.0,
                    Between6To12MonthsApr = 4.5,
                    MoreThan12MonthsApr = 5.5
                }
            });
            _vehicles.Add(new VehicleModel
            {
                Id = 3,
                Make = "Ducati",
                VehicleType = "MyBike",
                QuoteType = "MyPcp",
                AprRanges = new AprRangeModel()
                {
                    Upto3MonthsApr = 7.1,
                    Between3To6MonthsApr = 5.0,
                    Between6To12MonthsApr = 4.5,
                    MoreThan12MonthsApr = 5.5
                }
            });
            _vehicles.Add(new VehicleModel
            {
                Id = 4,
                Make = "Caddy",
                VehicleType = "MyVan",
                QuoteType = "MyHp",
                AprRanges = new AprRangeModel()
                {
                    Upto3MonthsApr = 5.7,
                    Between3To6MonthsApr = 2.0,
                    Between6To12MonthsApr = 7.5,
                    MoreThan12MonthsApr = 9.5
                }
            });
            return _vehicles;
        }
    }
}