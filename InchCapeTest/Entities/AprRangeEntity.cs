namespace InchCapeTest.Entities
{
    public class AprRangeEntity: BaseEntity
    {
        public double Upto3MonthsApr { get; set; }
        public double Between3To6MonthsApr { get; set; }
        public double Between6To12MonthsApr { get; set; }
        public double MoreThan12MonthsApr { get; set; }
        public AprRangeEntity(){}
        public AprRangeEntity(int id,
            double upto3MonthsApr, 
            double between3To6MonthsApr,
            double between6To12MonthsApr,
            double moreThan12MonthsApr)
        {
            Id = id;
            Upto3MonthsApr = upto3MonthsApr;
            Between3To6MonthsApr = between3To6MonthsApr;
            Between6To12MonthsApr = between6To12MonthsApr;
            MoreThan12MonthsApr = moreThan12MonthsApr;
        }
    }
}