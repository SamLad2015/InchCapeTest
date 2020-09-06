using AutoMapper;
using InchCapeTest.DtoS;
using InchCapeTest.Entities;

namespace InchCapeTest.MappingProfiles
{
    public class AprRangeMappings: Profile
    {
        public AprRangeMappings()
        {
            CreateMap<AprRangeEntity, AprRangeModel>().ReverseMap();
        }
    }
}