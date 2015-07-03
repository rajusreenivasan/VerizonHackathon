using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeter.Data
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            return "Data Source=SCSBWIN-12596\\SQLEXPRESS;Initial Catalog=hackathon;User ID=webuser;Password=webuser123!";
        }
    }
}
