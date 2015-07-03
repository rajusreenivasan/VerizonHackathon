using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using SmartMeter.Entity;

namespace SmartMeter.Data
{
    public class ProcessInvoice
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MeterIDs { get; set; }       

        public List<CustomerInvoice> GetConsumption()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Connection.GetConnectionString()))
                {                   
                    SqlCommand sqlCmd = new SqlCommand("usp_GetConsumption", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();
                    SqlDataReader dr = sqlCmd.ExecuteReader();

                    List<CustomerInvoice> customers = new List<CustomerInvoice>();
                    
                    while (dr.Read())
                    {
                        customers.Add(new CustomerInvoice()
                        {
                            CustomerID = Convert.ToInt32((dr["CustomerID"])),
                            MeterID = Convert.ToInt32((dr["MeterID"])),
                            Name = dr["Name"].ToString(),
                            Address = dr["Address"].ToString(),
                            PinCode = Convert.ToInt32((dr["PinCode"])),
                            Consumption = Convert.ToInt32((dr["Consumption"]))
                        });
                    }
                    dr.Close();
                    return customers;
                }
            }
            catch (Exception ex)
            {                
                throw;
            }

       }
    }
}
