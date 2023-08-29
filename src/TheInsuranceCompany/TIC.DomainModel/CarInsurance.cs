using System.Xml.Linq;

namespace TIC.DomainModel
{
    public class CarInsurance : Insurance
    {
        public string LicensePlate { get; set; }

        public int WeightInKg { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}