using TIC.DomainModel;
using TIC.DomainModel.Request;
using TIC.ServiceAdapter;

namespace TIC.DomainAPI.Impl
{
    public class InsuranceDomain : IInsuranceDomain
    {
        private readonly IInsuranceProvider _insuranceProvider;

        public InsuranceDomain(IInsuranceProvider insuranceProvider)
        {
            _insuranceProvider = insuranceProvider;
        }

        public IEnumerable<Insurance> GetInsurances(GetInsurancesRequest getInsurancesRequest)
        {
            return _insuranceProvider.GetInsurances();
        }

        public void AddInsurance(Insurance insurance)
        {
            _insuranceProvider.AddInsurance(insurance);
        }

        IEnumerable<Insurance> IInsuranceDomain.GetInsurances(GetInsurancesRequest getInsurancesRequest)
        {
            return _insuranceProvider.GetInsurances().ToList();
        }

        void IInsuranceDomain.AddInsurance(Insurance insurance)
        {
            throw new NotImplementedException();
        }

        List<TIC.DomainModel.TravelInsurance> IInsuranceDomain.GetDutchTravelInsurances()
        {
            var result = _insuranceProvider.GetInsurances().Where(x => x is TravelInsurance).ToList();

            var list = new List<TravelInsurance>();

            foreach (var insurance in result) {
                list.Add((TravelInsurance)insurance);
            }

            return list;
        }
    }
}