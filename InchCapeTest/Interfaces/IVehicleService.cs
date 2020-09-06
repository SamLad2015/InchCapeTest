using System.Collections.Generic;
using System.Threading.Tasks;
using InchCapeTest.DtoS;
using InchCapeTest.Enums;

namespace InchCapeTest.Interfaces
{
    public interface IVehicleService
    {
        Task<IList<VehicleModel>> GetAll();
        void AddNew(VehicleRequestModel model);
    }
}