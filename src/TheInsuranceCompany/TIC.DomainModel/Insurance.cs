namespace TIC.DomainModel
{
    public abstract class Insurance
    {
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public decimal InsurancePremium { get; set; }
        public decimal InsuredAmount { get; set; }
    }
}