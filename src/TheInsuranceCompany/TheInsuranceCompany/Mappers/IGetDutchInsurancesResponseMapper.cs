using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers
{
    public interface IGetDutchInsurancesResponseMapper
    {
        GetDutchTravelInsurancesResponse Map(IEnumerable<DomainModel.TravelInsurance> travelInsurances);
    }
}
