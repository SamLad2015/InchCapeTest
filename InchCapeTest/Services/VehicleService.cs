using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;
using InchCapeTest.Enums;
using InchCapeTest.Interfaces;

namespace InchCapeTest.Services
{
    public class VehicleService: IVehicleService
    {
        private readonly IReadRepository<VehicleEntity> _vehicleReadRepository;
        private readonly IWriteRepository<VehicleEntity> _vehicleWriteRepository;
        private readonly IWriteRepository<AprRangeEntity> _aprRangeWriteRepository;
        private readonly IMapper _mapper;

        public VehicleService(
            IReadRepository<VehicleEntity> vehicleReadRepository,
            IWriteRepository<VehicleEntity> vehicleWriteRepository,
            IWriteRepository<AprRangeEntity> aprRangeWriteRepository,
            IMapper mapper)
        {
            _vehicleReadRepository = vehicleReadRepository;
            _vehicleWriteRepository = vehicleWriteRepository;
            _aprRangeWriteRepository = aprRangeWriteRepository;
            _mapper = mapper;
        }

        public async Task<IList<VehicleModel>> GetAll()
        {
            IList<string> includes = new List<string>()
            {
                "Make",
                "QuoteType",
                "VehicleType",
                "AprRange"
            };
            return _mapper.Map<IList<VehicleModel>>(await _vehicleReadRepository.GetAll(includes));
        }

        public void AddNew(VehicleRequestModel model)
        {
            try
            {
                var aprToAdd = _mapper.Map<AprRangeEntity>(new AprRangeModel
                {
                    Upto3MonthsApr = model.Upto3MonthsApr,
                    Between3To6MonthsApr = model.Between3To6MonthsApr,
                    Between6To12MonthsApr = model.Between6To12MonthsApr,
                    MoreThan12MonthsApr = model.MoreThan12MonthsApr
                });
                _aprRangeWriteRepository.Insert(aprToAdd);
                var vehicleToAdd = _mapper.Map<VehicleEntity>(model);
                vehicleToAdd.AprRangeId = aprToAdd.Id;
                _vehicleWriteRepository.Insert(vehicleToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}