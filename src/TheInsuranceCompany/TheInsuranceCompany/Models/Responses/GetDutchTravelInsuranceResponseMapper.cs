using TIC.WebAPI.Mappers;

namespace TIC.WebAPI.Models.Responses
{
    public class GetDutchTravelInsuranceResponseMapper : IGetDutchTravelInsuranceResponseMapper
    {
        public GetDutchTravelInsuranceResponse Map(IEnumerable<DomainModel.TravelInsurance> insurances)
        {
            return new GetDutchTravelInsuranceResponse
            {
                Name = insurances.Select(i => i.Name),
                Description= insurances.Select(i=>i.Description),
                InsurancePremium= insurances.Select(i=>i.InsurancePremium),
                InsuredAmount= insurances.Select(i=>i.InsuredAmount)
            };
        }
    }
}
