using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitApp.Model
{
    public class Trip
    {
        public int NumberOfParticipants { get; set; }

        public IList<Charge> Charges { get; set; }

        public Trip(int amount)
        {
            NumberOfParticipants = amount;
            Charges = new List<Charge>();
        }

        private decimal GetAverageCharges()
        {
            var totalCharges = Charges.Sum(x => x.Price.Sum());
            var averageCharges = totalCharges / NumberOfParticipants;
            return averageCharges;
        }

        private decimal GetPaidPerPerson(int personID)
        {
            var paidvalue = Charges.Where(x => x.Id == personID).Sum(s => s.Price.Sum()); ;
            return paidvalue;
        }
        public decimal GetAmountOwedPerPerson(int personID)
        {
            return decimal.Round(GetAverageCharges() - GetPaidPerPerson(personID), 2, MidpointRounding.AwayFromZero);
        }
    }
}
