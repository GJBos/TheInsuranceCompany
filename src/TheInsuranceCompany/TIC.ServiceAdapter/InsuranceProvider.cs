
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
            DatabaseStub.Add(new LiabilityInsurance());
        }

        public IEnumerable<DomainModel.Insurance> GetInsurances()
        {
            var insurances = DatabaseStub.GetAllInsurances();
            return insurances.Map();
        }
        public IEnumerable<DomainModel.Insurance> GetDutchTravelInsurances()
        {
            return DatabaseStub.GetAllInsurances()
                .Select(MapToDomainModel) 
                .ToList();
        }
        private DomainModel.Insurance MapToDomainModel(ServiceAdapter.Models.Insurance insurance)
        {
            // Map common properties
            if (insurance is ServiceAdapter.Models.TravelInsurance travelInsurance)
            {
                return new DomainModel.TravelInsurance
                {
                    Name = travelInsurance.Name,
                    Description = travelInsurance.Description,
                    InsurancePremium = travelInsurance.InsurancePremium,
                    InsuredAmount = travelInsurance.InsuredAmount,
                    Coverage = travelInsurance.Coverage?.Select(c => new DomainModel.Country
                    {
                        Code = c.Code,
                        Name = c.Name
                    }).ToList()
                };
            }

            if (insurance is ServiceAdapter.Models.CarInsurance carInsurance)
            {
                return new DomainModel.CarInsurance
                {
                    Name = carInsurance.Name,
                    Description = carInsurance.Description,
                    InsurancePremium = carInsurance.InsurancePremium
                };
            }

            return null; 
        }
    }
}