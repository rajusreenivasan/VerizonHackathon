using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMeter.Data;
using SmartMeter.Entity;

namespace SmartMeter.Business
{
    public class GenerateInvoice
    {
        public List<Tariff> TariffList { get; set; }

        public List<Customer> CustomerInvoice { get; set; }

        public void Generate()
        {
            ProcessInvoice oProcessInvoice = new ProcessInvoice();
            List<Customer> oCustomers = oProcessInvoice.GetConsumption();
            Calculate(oCustomers);
        }

        private void Calculate(List<Customer> CustomerList)
        {
            try
            {
                List<Customer> oCustomers = new List<Customer>();

                foreach (var customer in CustomerList)
                {
                    var previousMax = 0;
                    var total = 0.0;
                    foreach (var tariff in TariffList)
                    {
                        if (customer.Consumption > tariff.EndTier)
                        {
                            total += (tariff.EndTier - previousMax) * tariff.Rate;
                            previousMax = tariff.EndTier;
                        }
                        else
                        {
                            total += (customer.Consumption - previousMax) * tariff.Rate;
                            break;
                        }
                    }
                    customer.Total = total;
                    oCustomers.Add(customer);
                }
                CustomerInvoice = oCustomers;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }
    }
}
