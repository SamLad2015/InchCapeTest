using AutoMapper;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;

namespace InchCapeTest.MappingProfiles
{
    public class QuoteTypeMappings: Profile
    {
        public QuoteTypeMappings()
        {
            CreateMap<QuoteTypeEntity, VehiclePropertyModel>()
                .ForMember(dest => dest.Label,
                    opt =>
                        opt.MapFrom(s => s.QuoteType));

            CreateMap<VehiclePropertyRequestModel, QuoteTypeEntity>()
                .ForMember(dest => dest.QuoteType,
                    opt =>
                        opt.MapFrom(s => s.Label));
        }
    }
}