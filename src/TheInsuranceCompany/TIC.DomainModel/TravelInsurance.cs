namespace TIC.DomainModel
{
    public class TravelInsurance : Insurance
    {
        public IEnumerable<Country> ?Coverage { get; set; }
    }
}