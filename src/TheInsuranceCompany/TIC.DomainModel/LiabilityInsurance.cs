namespace TIC.DomainModel
{
    public class LiabilityInsurance : Insurance
    {
        public bool Excess { get; set; }
        public decimal ExcessAmount { get; set; }
    }
}