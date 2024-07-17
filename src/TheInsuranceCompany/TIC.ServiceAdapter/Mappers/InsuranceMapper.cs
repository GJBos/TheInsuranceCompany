using System.Collections.Generic;
using TIC.ServiceAdapter.Models;

namespace TIC.ServiceAdapter.Mappers
{
    public static class InsuranceMapper
    {
        public static ICollection<DomainModel.Insurance> Map(this IEnumerable<Insurance> insurances)
        {
            return insurances.Select(insurance => insurance.Map()).ToList();
        }

        public static DomainModel.Insurance Map(this Insurance insurance)
        {
            if (insurance is CarInsurance carInsurance)
            {
                return Map(carInsurance);
            }
            if (insurance is TravelInsurance travelInsurance)
            {
                return Map(travelInsurance);
            }
            if (insurance is LiabilityInsurance liabilityInsurance)
            {
                return Map(liabilityInsurance);
            }

            throw new NotImplementedException();
        }

        private static DomainModel.CarInsurance Map(CarInsurance insurance)
        {
            return new DomainModel.CarInsurance
            {
                Name = insurance.Name,
                Description = insurance.Name,
                InsurancePremium = insurance.InsurancePremium,
                LicensePlate = insurance.Name,
                WeightInKg = insurance.WeightInKg,
                DateOfBirth = insurance.DateOfBirth
            };
        }

        private static DomainModel.TravelInsurance Map(TravelInsurance insurance)
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
            return countries?.Select(c => new DomainModel.Country{Code = c.Code, Name = c.Name});
        }

        private static DomainModel.LiabilityInsurance Map(LiabilityInsurance insurance)
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
        public static IEnumerable<DomainModel.TravelInsurance> GetDutchTravelInsurances(this IEnumerable<Insurance> insurances)
        {

            return insurances
            .OfType<TravelInsurance>()
            .Select(t=> Map(t))
            .Where(t => t.Coverage is not null && t.Coverage.Any(c => c.Code == "NL"))
            .ToList();

        }



    }
}