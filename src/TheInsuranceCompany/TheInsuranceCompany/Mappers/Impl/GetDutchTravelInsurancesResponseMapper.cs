using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchTravelInsurancesResponseMapper : IGetDutchTravelInsurancesResponseMapper
    {
        public IEnumerable<GetDutchTravelInsurancesResponse> Map(IEnumerable<TravelInsurance> travelInsurances)
        {



            return travelInsurances.Select(item =>
                  new GetDutchTravelInsurancesResponse
                  {
                      Name = item.Name,
                      Description = item.Description,
                      InsurancePremium = item.InsurancePremium,
                      InsuredAmount = item.InsuredAmount
                  });



            
        }

    }
}

