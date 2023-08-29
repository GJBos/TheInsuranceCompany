
using TIC.ServiceAdapter.Mappers;
using TIC.ServiceAdapter.Models;
using TIC.ServiceAdapter.Stubs;

namespace TIC.ServiceAdapter
{
    /// <summary>
    /// DO NOT MODIFY. The Provieder simply mimics a database for the porpuse of this test.
    /// </summary>
    public class InsuranceProvider : IInsuranceProvider
    {
        public void AddInsurance(DomainModel.Insurance insurance)
        {
            CarInsurance carInsurance = new ()
            {
                Name = insurance.Name,
                Description = insurance.Description,
                InsurancePremium = insurance.InsurancePremium,
            };
            DatabaseStub.Add(carInsurance);
        }

        public IEnumerable<DomainModel.Insurance> GetInsurances()
        {
            var insurances = DatabaseStub.GetAllInsurances();
            return insurances.Map();
        }
    }
}