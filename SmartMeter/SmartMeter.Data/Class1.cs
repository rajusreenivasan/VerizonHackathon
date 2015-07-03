using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace SmartMeter.Data
{
    public class ImportExcel
    {
       
       public void importdatafromexcel(string excelfilepath, string sheetName)
      {

        //declare variables - edit these based on your particular situation
        string ssqltable = "usage";
        // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different
        //string myexceldataquery = "select * from [sheet1$]";
        string myexceldataquery = "select * from " + sheetName;
        try
        {
        //create our connection strings
        string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
        string ssqlconnectionstring = Connection.GetConnectionString();
        //execute a query to erase any previous data from our destination table
        string sclearsql = "TRUNCATE TABLE " + ssqltable;
        SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
        SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
        sqlconn.Open();
        sqlcmd.ExecuteNonQuery();
        sqlconn.Close();
        //series of commands to bulk copy data from the excel file into our sql table
        OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
        OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
        oledbconn.Open();
        OleDbDataReader dr = oledbcmd.ExecuteReader();
        SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
        bulkcopy.DestinationTableName = ssqltable;
        while (dr.Read())
        {
            bulkcopy.WriteToServer(dr);
        }     
        oledbconn.Close();
    }
    catch (Exception ex)
    {
        //handle exception
    }
}
    }


}
