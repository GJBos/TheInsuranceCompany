using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchInsurancesResponseMapper : IGetDutchInsurancesResponseMapper
    {
        public GetDutchTravelInsurancesResponse Map(IEnumerable<DomainModel.TravelInsurance> travelInsurances)
        {
            return new GetDutchTravelInsurancesResponse
            {
                Name = travelInsurances.Select(x => x.Name),
                Description = travelInsurances.Select(x => x.Description),
                InsurancePremium = travelInsurances.Select(x => x.InsurancePremium),
                InsuredAmount = travelInsurances.Select(x => x.InsuredAmount),
            };
        }
    }
}
