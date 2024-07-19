using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchTravelInsurancesResponseMapper : IGetDutchTravelInsurancesResponseMapper
    {
        public IEnumerable<GetDutchTravelInsurancesResponse> Map(IEnumerable<TravelInsurance> travelInsurances)
        {
            return travelInsurances.Select(insurance => new GetDutchTravelInsurancesResponse
            {
                Name = insurance.Name,
                Description = insurance.Description,
                InsurancePremium = insurance.InsurancePremium,                
                InsuredAmount = insurance.InsuredAmount
            }).ToList();
        }
    }
}
