
namespace TIC.WebAPI.Models.Responses
{
    public class GetDutchTravelInsurancesResponse
    {
        public bool? success { get; set; }
        public string ErrorDescription {  get; set; }
        public List<DutchTravelInsurance> insurances { get; set; }
    }
}
