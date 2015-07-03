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

        public List<CustomerInvoice> CustomerInvoice { get; set; }

        public double TaxPercentage { get; set; }

        public void Generate()
        {
            ProcessInvoice oProcessInvoice = new ProcessInvoice();
            List<CustomerInvoice> oCustomers = oProcessInvoice.GetConsumption();
            Calculate(oCustomers);
        }

        private void Calculate(List<CustomerInvoice> CustomerList)
        {
            try
            {
                List<CustomerInvoice> oCustomers = new List<CustomerInvoice>();

                foreach (var customer in CustomerList)
                {
                    var previousMax = 0;
                    var total = 0.0;
                    var tax = 0.0;
                    var grandTotal = 0.0;

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
                    tax = Math.Round((total * TaxPercentage) / 100,2);
                    grandTotal = total + tax;

                    customer.Total = total;
                    customer.TaxAmount = tax;
                    customer.GrandTotal = grandTotal;
                    customer.TaxPercentage = TaxPercentage;

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
