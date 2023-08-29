using TIC.WebAPI.Models.Requests;

namespace TIC.WebAPI.Mappers;

public interface IGetInsurancesRequestMapper
{
    DomainModel.Request.GetInsurancesRequest Map(GetInsurancesRequest request);
    DomainModel.Request.GetDutchTravelInsurancesRequest Map(GetDutchTravelInsurancesRequest request);
}