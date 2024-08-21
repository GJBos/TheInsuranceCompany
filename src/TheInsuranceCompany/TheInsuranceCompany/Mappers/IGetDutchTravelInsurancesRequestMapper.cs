using TIC.WebAPI.Models.Requests;

namespace TIC.WebAPI.Mappers
{
    public interface IGetDutchTravelInsurancesRequestMapper
    {
        DomainModel.Request.GetDutchTravelInsurancesRequest Map(GetDutchTravelInsurancesRequest request);
    }
}
