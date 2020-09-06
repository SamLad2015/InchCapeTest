using InchCapeTest.Interfaces;

namespace InchCapeTest.DtoS
{
    public class VehiclePropertyModel : VehiclePropertyRequestModel, IBaseModel
    {
        public int Id { get; set; }
    }
}