using BillSplitApp.Core.Interface;
using BillSplitApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitApp.Core
{
    public class ProcessInput: ICalculator
    {
        public IList<Trip> AllTrips { get; private set; }
        private int row = 0;

        public ProcessInput()
        {
            AllTrips = new List<Trip>();
        }
        public IList<Trip> Calculate(string[] readLines)
        {
            
            while (Convert.ToInt32(readLines[row]) != 0)
            {
                var currentTrip = new Trip(Convert.ToInt32(readLines[row]));
                ProcessTrip(currentTrip, readLines);
                AllTrips.Add(currentTrip);

                //go to next line for the next trip
                row++;
            }

            return AllTrips;
        }

        private void ProcessTrip(Trip currentTrip, string[] lines)
        {
            for (var personId = 0; personId < currentTrip.NumberOfParticipants; personId++)
            {
                row++;
                ProcessCharges(currentTrip, lines, personId);
            }
        }

        private void ProcessCharges(Trip currentTrip, string[] lines, int tripPersonID)
        {
            int lineOfCharges = Convert.ToInt32(lines[row]);
            var charge = new Charge(tripPersonID);
            for (var chargeIndex = 0; chargeIndex < lineOfCharges; chargeIndex++)
            {
                row++;
                charge.Price.Add(Convert.ToDecimal(lines[row]));
            }
            currentTrip.Charges.Add(charge);
        }
    }
}
