using TIC.DomainModel;
using TIC.DomainModel.Request;

namespace TIC.DomainAPI;

public interface IInsuranceDomain
{
    IEnumerable<Insurance> GetInsurances(GetInsurancesRequest getInsurancesRequest);
    void AddInsurance(Insurance insurance);

    IEnumerable<TravelInsurance> GetDutchTravelInsurances(GetDutchTravelInsurance getDutchTravelInsurance);
}