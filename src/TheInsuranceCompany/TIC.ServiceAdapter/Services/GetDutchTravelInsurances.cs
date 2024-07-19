using TIC.ServiceAdapter.Mappers;
using TIC.ServiceAdapter.Models;
using TIC.ServiceAdapter.Stubs;

namespace TIC.ServiceAdapter.Services
{
    public class GetDutchTravelInsurances : IGetDutchTravelInsurances
    {
        public IEnumerable<DomainModel.TravelInsurance> GetDutchTravelInsurancesList()
        {
            var insurances = DatabaseStub.GetAllInsurances().OfType<TravelInsurance>().Where(c=>c.Coverage != null && c.Coverage.Any(cd=>cd.Code=="NL"));
            return insurances.Map();
        }       
    }
}
