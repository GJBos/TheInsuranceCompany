using TIC.WebAPI.Models.Requests;

namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchTravelInsuranceRequestMapper : IGetDutchTravelInsuranceRequestMapper
    {
        public DomainModel.Request.GetDutchTravelInsurance Map(GetDutchTravelInsuranceRequest request)
        {
            return new DomainModel.Request.GetDutchTravelInsurance();
        }
    }
}
