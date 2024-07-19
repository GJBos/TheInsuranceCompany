using TIC.WebAPI.Models;
using TIC.WebAPI.Models.Requests;

namespace TIC.WebAPI.Mappers.Impl
{
    public class AddInsuranceRequestMapper : IAddInsuranceRequestMapper
    {
        public DomainModel.Insurance Map(AddInsuranceRequest request)
        {
            if (request.CarInsurance != null)
            {
                return Map(request.CarInsurance);
            }
            if (request.TravelInsurance != null)
            {
                return Map(request.TravelInsurance);
            }
            if (request.LiabilityInsurance != null)
            {
                return Map(request.LiabilityInsurance);
            }

            return null;
        }

        private DomainModel.CarInsurance Map(CarInsurance insurance)
        {
            return new DomainModel.CarInsurance
            {
                Name = insurance.Name,
                Description = insurance.Description,
                InsurancePremium = insurance.InsurancePremium,
                LicensePlate = insurance.LicensePlate,
                WeightInKg = insurance.WeightInKg,
                DateOfBirth = insurance.DateOfBirth
            };
        }

        private DomainModel.TravelInsurance Map(TravelInsurance insurance)
        {
            return new DomainModel.TravelInsurance
            {
                Name = insurance.Name,
                Description = insurance.Description,
                InsurancePremium = insurance.InsurancePremium,
                Coverage = MapCoverage(insurance.Coverage),
                InsuredAmount = insurance.InsuredAmount
            };
        }

        private static IEnumerable<DomainModel.Country>? MapCoverage(IEnumerable<Country>? countries)
        {
            return countries?.Select(c => new DomainModel.Country { Code = c.Code, Name = c.Name });
        }

        private DomainModel.LiabilityInsurance Map(LiabilityInsurance insurance)
        {
            return new DomainModel.LiabilityInsurance
            {
                Name = insurance.Name,
                Description = insurance.Description,
                InsurancePremium = insurance.InsurancePremium,
                InsuredAmount = insurance.InsuredAmount,
                Excess = insurance.Excess,
                ExcessAmount = insurance.ExcessAmount
            };
        }
    }
}
