using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeter.Entity
{
    public class Tariff
    {
        public int StartTier { get; set; }

        public int EndTier { get; set; }

        public double Rate { get; set; }
    }
}
