using TIC.ServiceAdapter.Models;

namespace TIC.ServiceAdapter.Mappers
{
    public static class TravelInsuranceMapper
    {
        public static ICollection<DomainModel.TravelInsurance> Map(this IEnumerable<TravelInsurance> travelInsurances)
        {
            return travelInsurances.Select(insurance => insurance.Map()).ToList();
        }

        private static DomainModel.TravelInsurance Map(this TravelInsurance insurance)
        {
            return new DomainModel.TravelInsurance
            {
                Name = insurance.Name,
                Description = insurance.Description,
                InsurancePremium = insurance.InsurancePremium,
                Coverage = insurance.Coverage?.Select(c => new DomainModel.Country { Code = c.Code, Name = c.Name }).ToList(),
                InsuredAmount = insurance.InsuredAmount
            };
        }
    }
}
