using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitApp.Model
{
    public class Charge
    {
        public int Id { get; set; }
        public IList<decimal> Price { get; set; }

        public Charge(int id)
        {
            Id = id;
            Price = new List<decimal>();
        }
    }
}
