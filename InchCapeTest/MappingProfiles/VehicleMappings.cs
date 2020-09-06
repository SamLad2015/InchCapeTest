using AutoMapper;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;

namespace InchCapeTest.MappingProfiles
{
    public class VehicleMappings: Profile
    {
        public VehicleMappings()
        {
            CreateMap<VehicleEntity, VehicleModel>()
                .ForMember(dest => dest.Make,
                    opt =>
                        opt.MapFrom(s => s.Make.Make))
                .ForMember(dest => dest.QuoteType,
                    opt =>
                        opt.MapFrom(s => s.QuoteType.QuoteType))
                .ForMember(dest => dest.VehicleType,
                    opt =>
                        opt.MapFrom(s => s.VehicleType.VehicleType))
                .ForMember(dest => dest.AprRanges,
                    opt =>
                        opt.MapFrom(s => s.AprRange));

            CreateMap<VehicleRequestModel, VehicleEntity>();
        }
    }
}