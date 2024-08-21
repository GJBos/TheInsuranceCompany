
namespace TIC.WebAPI.Mappers.Impl
{
    public class GetDutchTravelInsurancesRequestMapper : IGetDutchTravelInsurancesRequestMapper
    {
        public DomainModel.Request.GetDutchTravelInsurancesRequest Map(Models.Requests.GetDutchTravelInsurancesRequest request)
        {
            return new DomainModel.Request.GetDutchTravelInsurancesRequest();
        }
    }
}
