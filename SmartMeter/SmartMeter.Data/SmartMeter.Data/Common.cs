using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SmartMeter.Entity;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartMeter.Data
{
    public class Common
    {
        public static List<Tariff> LoadTariff()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Tariff", sqlCon);                    
                    sqlCon.Open();
                    SqlDataReader dr = sqlCmd.ExecuteReader();

                    List<Tariff> tariffs = new List<Tariff>();

                    while (dr.Read())
                    {
                        tariffs.Add(new Tariff()
                        {
                            StartTier = Convert.ToInt32((dr["StartTier"])),
                            EndTier = Convert.ToInt32((dr["EndTier"])),
                            Rate = Convert.ToDouble((dr["Rate"])),  
                        });
                    }
                    dr.Close();
                    return tariffs;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
