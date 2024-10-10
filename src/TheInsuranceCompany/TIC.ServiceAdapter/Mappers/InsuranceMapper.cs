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

        public static IEnumerable<DomainModel.TravelInsurance>? GetDutchTravelInsurances(this IEnumerable<Insurance> insurances)
        {
            var travelInsurances = insurances.OfType<TravelInsurance>();
            var mappedInsurances = travelInsurances.Select(x => Map(x));
            var validInsurances = mappedInsurances
                .Where(x => x.Coverage != null && x.Coverage.Any(y => y.Code == "NL"))
                .ToList();
            return validInsurances;
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
    }
}