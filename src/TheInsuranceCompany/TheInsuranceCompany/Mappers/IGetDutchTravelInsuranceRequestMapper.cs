using TIC.WebAPI.Models.Requests;

namespace TIC.WebAPI.Mappers
{
    public interface IGetDutchTravelInsuranceRequestMapper
    {
        DomainModel.Request.GetDutchTravelInsurance Map(GetDutchTravelInsuranceRequest request);
    }
}