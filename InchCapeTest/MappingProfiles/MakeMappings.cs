using AutoMapper;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;

namespace InchCapeTest.MappingProfiles
{
    public class MakeMappings: Profile
    {
        public MakeMappings()
        {
            CreateMap<MakeEntity, VehiclePropertyModel>()
                .ForMember(dest => dest.Label,
                    opt =>
                        opt.MapFrom(s => s.Make));

            CreateMap<VehiclePropertyRequestModel, MakeEntity>()
                .ForMember(dest => dest.Make,
                    opt =>
                        opt.MapFrom(s => s.Label));
        }
    }
}