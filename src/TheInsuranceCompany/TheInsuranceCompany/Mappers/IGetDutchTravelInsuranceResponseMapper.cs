using TIC.WebAPI.Models.Responses;

namespace TIC.WebAPI.Mappers
{
    public interface IGetDutchTravelInsuranceResponseMapper
    {
        GetDutchTravelInsuranceResponse Map(IEnumerable<DomainModel.TravelInsurance> insurances);
    }
}
