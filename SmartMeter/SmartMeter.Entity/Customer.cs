﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeter.Entity
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public int MeterID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int PinCode { get; set; }
    }
}
