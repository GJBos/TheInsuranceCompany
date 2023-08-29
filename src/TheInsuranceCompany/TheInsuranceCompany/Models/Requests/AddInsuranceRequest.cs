namespace TIC.WebAPI.Models.Requests
{
    [Serializable]
    public class AddInsuranceRequest
    {
        public TravelInsurance? TravelInsurance { get; set; }
        
        public CarInsurance? CarInsurance { get; set; }

        public LiabilityInsurance? LiabilityInsurance { get; set; }
    }
}
