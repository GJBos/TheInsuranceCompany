using TIC.DomainModel;
using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers
{
    public interface IGetDutchTravelInsurancesResponseMapper
    {
        IEnumerable<GetDutchTravelInsurancesResponse> Map(IEnumerable<TravelInsurance> travelInsurances);
    }
}