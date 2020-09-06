using InchCapeTest.Interfaces;

namespace InchCapeTest.DtoS
{
    public class VehicleModel: IBaseModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string VehicleType { get; set; }
        public string QuoteType { get; set; }
        public AprRangeModel AprRanges { get; set; }
    }
}