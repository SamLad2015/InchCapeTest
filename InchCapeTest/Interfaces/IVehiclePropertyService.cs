using System.Collections.Generic;
using System.Threading.Tasks;
using InchCapeTest.DtoS;
using InchCapeTest.Enums;

namespace InchCapeTest.Interfaces
{
    public interface IVehiclePropertyService
    {
        Task<IList<VehiclePropertyModel>> GetAll(VehiclePropertyEnum property);
        void AddNew(VehiclePropertyRequestModel model, VehiclePropertyEnum property);
    }
}