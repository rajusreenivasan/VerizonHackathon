using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["UsageFileName"] != null)
            {
                SmartMeter.Data.ImportExcel ImportExcel = new SmartMeter.Data.ImportExcel();
                string Path = Request.PhysicalApplicationPath + @"\Data\" + System.Configuration.ConfigurationManager.AppSettings["UsageFileName"].ToString();
                ImportExcel.importdatafromexcel(Path, "[sheet1$]");
                Application.Add("Imported", 1);
            } 
        }           
    }
}
