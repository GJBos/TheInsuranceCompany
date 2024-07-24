using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers;

public interface IGetDutchTravelInsurancesResponseMapper
{
    GetDutchTravelInsurancesResponse Map(IEnumerable<DomainModel.TravelInsurance> insurances);
}