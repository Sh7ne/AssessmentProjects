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
    public class ProcessOutput : ILineWriter
    {
        private string FileName { get; set; }

        public ProcessOutput(string fileName)
        {
            FileName = fileName;
        }

        public void WriteOutput(IList<Trip> trips)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"InputOutput\" + FileName + ".out");
            using (TextWriter textWriter = new StreamWriter(path))
            {
                foreach (Trip trip in trips)
                {
                    WritePesonCharges(trip, textWriter);
                    textWriter.WriteLine("");
                }
            }
        }

        private void WritePesonCharges(Trip trip, TextWriter textWriter)
        {
            for (var Id = 0; Id < trip.NumberOfParticipants; Id++)
            {
                var AmountOwedPerPerson = trip.GetAmountOwedPerPerson(Id);
                textWriter.WriteLine(AmountOwedPerPerson > 0 ? 
                    "$" + AmountOwedPerPerson.ToString() : 
                    string.Format("(${0})", Math.Abs(AmountOwedPerPerson).ToString()));
            }
        }
    }
}
