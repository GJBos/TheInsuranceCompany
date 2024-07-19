using TIC.ServiceAdapter.Models;

namespace TIC.ServiceAdapter.Services
{
    public interface IGetDutchTravelInsurances
    {
        IEnumerable<DomainModel.TravelInsurance> GetDutchTravelInsurancesList();
    }
}