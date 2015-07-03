using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeter.Entity
{
    public class CustomerInvoice
    {
        public int CustomerID { get; set; }

        public int MeterID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int PinCode { get; set; }

        public long Consumption { get; set; }

        public double Total { get; set; }

        public double TaxAmount { get; set; }

        public double TaxPercentage { get; set; }

        public double GrandTotal { get; set; }

    }
}
