using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers.Impl;

public class GetDutchTravelInsurancesResponseMapper : IGetDutchTravelInsurancesResponseMapper
{
    public GetDutchTravelInsurancesResponse Map(IEnumerable<TravelInsurance> insurances)
    {
        return new GetDutchTravelInsurancesResponse
        {
            Name = insurances.Select(i => i.Name),
            Description = insurances.Select(i => i.Description),
            InsurancePremium = insurances.Select(i => i.InsurancePremium),
            InsuredAmount = insurances.Select(i => i.InsuredAmount)
        };
    }
}