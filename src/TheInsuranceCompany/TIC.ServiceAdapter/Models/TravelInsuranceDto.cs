using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC.ServiceAdapter.Models
{
    public class TravelInsuranceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal InsurancePremium { get; set; }
        public decimal InsuredAmount { get; set; }
    }
}
