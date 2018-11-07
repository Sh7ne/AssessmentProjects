using BillSplitApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitApp.Core.Interface
{
    public interface ICalculator
    {
        IList<Trip> Calculate(string[] readLines);
    }
}
