using TIC.DomainModel;
using TIC.DomainModel.Request;
using TIC.ServiceAdapter;
using TIC.ServiceAdapter.Services;

namespace TIC.DomainAPI.Impl
{
    public class InsuranceDomain : IInsuranceDomain
    {
        private readonly IInsuranceProvider _insuranceProvider;
        private readonly IGetDutchTravelInsurances _getDutchTravelInsurances;

        public InsuranceDomain(IInsuranceProvider insuranceProvider, IGetDutchTravelInsurances getDutchTravelInsurances)
        {
            _insuranceProvider = insuranceProvider;
            _getDutchTravelInsurances = getDutchTravelInsurances;
        }

        public IEnumerable<Insurance> GetInsurances(GetInsurancesRequest getInsurancesRequest)
        {
            return _insuranceProvider.GetInsurances();
        }

        public void AddInsurance(Insurance insurance)
        {
            _insuranceProvider.AddInsurance(insurance);
        }

        public IEnumerable<TravelInsurance> GetDutchTravelInsurances(GetDutchTravelInsurance getDutchTravelInsurance)
        {
            return _getDutchTravelInsurances.GetDutchTravelInsurancesList();
        }
    }
}