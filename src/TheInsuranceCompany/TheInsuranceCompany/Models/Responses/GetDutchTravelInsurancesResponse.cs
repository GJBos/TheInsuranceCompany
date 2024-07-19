namespace TIC.WebAPI.Models.Responses
{
    public class GetDutchTravelInsurancesResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal InsurancePremium { get; set; }
        public decimal InsuredAmount { get; set; }
    }
}
