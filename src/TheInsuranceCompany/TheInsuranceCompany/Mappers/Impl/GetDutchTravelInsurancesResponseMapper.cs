using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchTravelInsurancesResponseMapper : IGetDutchTravelInsurancesResponseMapper
    {
        public GetDutchTravelInsurancesResponse Map(IEnumerable<TravelInsurance> insurances)
        {
            var ins = insurances.ToList();

            var response = new GetDutchTravelInsurancesResponse() { 
                success = true,
                insurances = new List<Models.DutchTravelInsurance>()
            };

            foreach ( var item in insurances )
            {
                response.insurances.Add(
                        new Models.DutchTravelInsurance() 
                        {
                            Name = item.Name, 
                            Description = item.Description, 
                            InsurancePremium = item.InsurancePremium,
                            InsuredAmount = item.InsuredAmount
                        }
                    );
            }

            return response;
        }
    }
}
