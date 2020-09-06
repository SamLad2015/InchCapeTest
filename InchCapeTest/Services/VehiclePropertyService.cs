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
    public class VehiclePropertyService: IVehiclePropertyService
    {
        private readonly IReadRepository<MakeEntity> _makeReadRepository;
        private readonly IReadRepository<QuoteTypeEntity> _quoteReadRepository;
        private readonly IReadRepository<VehicleTypeEntity> _vehicleTypeReadRepository;
        private readonly IWriteRepository<MakeEntity> _makeWriteRepository;
        private readonly IWriteRepository<QuoteTypeEntity> _quoteWriteRepository;
        private readonly IWriteRepository<VehicleTypeEntity> _vehicleTypeWriteRepository;
        private readonly IMapper _mapper;
        public VehiclePropertyService(
            IReadRepository<MakeEntity> makeReadRepository,
            IReadRepository<QuoteTypeEntity> quoteReadRepository,
            IReadRepository<VehicleTypeEntity> vehicleTypeReadRepository,
            IWriteRepository<MakeEntity> makeWriteRepository,
            IWriteRepository<QuoteTypeEntity> quoteWriteRepository,
            IWriteRepository<VehicleTypeEntity> vehicleTypeWriteRepository,
            IMapper mapper)
        {
            _makeReadRepository = makeReadRepository;
            _quoteReadRepository = quoteReadRepository;
            _vehicleTypeReadRepository = vehicleTypeReadRepository;
            _makeWriteRepository = makeWriteRepository;
            _quoteWriteRepository = quoteWriteRepository;
            _vehicleTypeWriteRepository = vehicleTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<IList<VehiclePropertyModel>> GetAll(VehiclePropertyEnum property)
        {
            switch (property)
            {
                case VehiclePropertyEnum.Make:
                    return _mapper.Map<IList<VehiclePropertyModel>>(await _makeReadRepository.GetAll());
                case VehiclePropertyEnum.QuoteType:
                    return _mapper.Map<IList<VehiclePropertyModel>>(await _quoteReadRepository.GetAll());
                case VehiclePropertyEnum.VehicleType:
                    return _mapper.Map<IList<VehiclePropertyModel>>(await _vehicleTypeReadRepository.GetAll());
                default:
                    return _mapper.Map<IList<VehiclePropertyModel>>(await _makeReadRepository.GetAll());
            }
        }

        public void AddNew(VehiclePropertyRequestModel model, VehiclePropertyEnum property)
        {
            try
            {
                switch (property)
                {
                    case VehiclePropertyEnum.Make: 
                        _makeWriteRepository.Insert(_mapper.Map<MakeEntity>(model));
                        break;
                    case VehiclePropertyEnum.QuoteType:
                        _quoteWriteRepository.Insert(_mapper.Map<QuoteTypeEntity>(model));
                        break;
                    case VehiclePropertyEnum.VehicleType:
                        _vehicleTypeWriteRepository.Insert(_mapper.Map<VehicleTypeEntity>(model));
                        break;
                    default:
                        _makeWriteRepository.Insert(_mapper.Map<MakeEntity>(model));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}