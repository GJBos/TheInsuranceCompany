﻿using TIC.DomainModel;
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

        public IEnumerable<TravelInsurance> GetDutchTravelInsurances()
        {
            var insurances = _insuranceProvider.GetInsurances();
            return insurances.OfType<TravelInsurance>().Where(ti => ti.Coverage != null && ti.Coverage.Any(c => c.Code == "NL"));
        }

        public void AddInsurance(Insurance insurance)
        {
            _insuranceProvider.AddInsurance(insurance);
        }
    }
}