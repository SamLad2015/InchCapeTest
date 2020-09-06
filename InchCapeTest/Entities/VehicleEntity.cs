using System.Collections.Generic;

namespace InchCapeTest.Entities
{
    public class VehicleEntity: BaseEntity
    {
        public int MakeId { get; set; }
        public int VehicleTypeId { get; set; }
        public int QuoteTypeId { get; set; }
        public int AprRangeId { get; set; }
        public MakeEntity Make { get; set; }
        public VehicleTypeEntity VehicleType { get; set; }
        public QuoteTypeEntity QuoteType { get; set; }
        public AprRangeEntity AprRange { get; set; } 
    }
}