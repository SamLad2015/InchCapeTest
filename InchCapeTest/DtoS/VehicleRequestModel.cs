namespace InchCapeTest.DtoS
{
    public class VehicleRequestModel
    {
        public int MakeId { get; set; }
        public int VehicleTypeId { get; set; }
        public int QuoteTypeId { get; set; }
        public double Upto3MonthsApr { get; set; }
        public double Between3To6MonthsApr { get; set; }
        public double Between6To12MonthsApr { get; set; }
        public double MoreThan12MonthsApr { get; set; }
    }
}