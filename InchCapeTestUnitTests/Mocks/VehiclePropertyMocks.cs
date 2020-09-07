using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;
using InchCapeTest.Enums;
using InchCapeTest.Interfaces;
using Moq;

namespace InchCapeTestUnitTests.Mocks
{
    public class VehiclePropertyMocks
    {
        public IVehiclePropertyService VehiclePropertyService;
        private readonly IList<MakeEntity> _makes = new List<MakeEntity>
        {
            new MakeEntity() { Id = 1, Make = "MyAudi" },
            new MakeEntity() { Id = 2, Make = "MyBmw" }
        };
        private readonly IList<VehicleTypeEntity> _vehicleTypes = new List<VehicleTypeEntity>
        {
            new VehicleTypeEntity() { Id = 1, VehicleType = "MyCar" },
            new VehicleTypeEntity() { Id = 2, VehicleType = "MyBike" },
            new VehicleTypeEntity() { Id = 3, VehicleType = "MyVan" }
        };
        private readonly IList<QuoteTypeEntity> _quoteTypes = new List<QuoteTypeEntity>
        {
            new QuoteTypeEntity() { Id = 1, QuoteType = "MyHp" },
            new QuoteTypeEntity() { Id = 2, QuoteType = "MyPcp" }
        };

        public void SetUpMock()
        {
            var vehiclePropertyServiceMoq = new Mock<IVehiclePropertyService>();
            var vehiclePropertyModels = _makes.Select(e => new VehiclePropertyModel
            {
                Id = e.Id,
                Label = e.Make
            }).ToList();
            
            vehiclePropertyServiceMoq
                .Setup(o => o.GetAll(VehiclePropertyEnum.Make))
                .Returns(Task.FromResult<IList<VehiclePropertyModel>>(vehiclePropertyModels));

            vehiclePropertyServiceMoq
                .Setup(o => o.AddNew(It.IsAny<VehiclePropertyRequestModel>(),
                    VehiclePropertyEnum.Make))
                .Callback((VehiclePropertyRequestModel model, VehiclePropertyEnum type) =>
                {
                    vehiclePropertyModels.Add(new VehiclePropertyModel
                    {
                        Id = _makes.Last().Id + 1,
                        Label = model.Label
                    });
                });

            VehiclePropertyService = vehiclePropertyServiceMoq.Object;
        }

        public IList<MakeEntity> GetFakeMakes()
        {
            return _makes;
        }
        
        public IList<VehicleTypeEntity> GetFakeVehicleTypes()
        {
            return _vehicleTypes;
        }

        public IList<QuoteTypeEntity> GetFakeQuoteTypes()
        {
            return _quoteTypes;
        }
    }
}