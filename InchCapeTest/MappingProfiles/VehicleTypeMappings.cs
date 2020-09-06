using AutoMapper;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;

namespace InchCapeTest.MappingProfiles
{
    public class VehicleTypeMappings: Profile
    {
        public VehicleTypeMappings()
        {
            CreateMap<VehicleTypeEntity, VehiclePropertyModel>()
                .ForMember(dest => dest.Label,
                    opt =>
                        opt.MapFrom(s => s.VehicleType));

            CreateMap<VehiclePropertyRequestModel, VehicleTypeEntity>()
                .ForMember(dest => dest.VehicleType,
                    opt =>
                        opt.MapFrom(s => s.Label));
        }
    }
}