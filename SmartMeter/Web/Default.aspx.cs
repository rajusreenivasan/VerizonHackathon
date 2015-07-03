using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartMeter.Data;
using SmartMeter.Business;
using SmartMeter.Entity;
using System.IO;

//using Aspose.Pdf;

//using System.Data;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;

using SmartMeter.PDFWriter;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (System.Configuration.ConfigurationManager.AppSettings["UsageFileName"] != null)
        {
            ImportExcel ImportExcel = new ImportExcel();
            string Path = Request.PhysicalApplicationPath + @"\Data\" + System.Configuration.ConfigurationManager.AppSettings["UsageFileName"].ToString();
            ImportExcel.importdatafromexcel(Path, "[sheet1$]");
        }       
    }

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        GenerateInvoice oGen = new GenerateInvoice();
        oGen.TariffList = (List<Tariff>)Application["Tariff"];
        oGen.TaxPercentage = Convert.ToDouble(Application["TaxPercentage"]);
        oGen.Generate();
        gvInvoice.DataSource = oGen.CustomerInvoice;
        gvInvoice.DataBind();
        PDF();
    }

    private void PDF()
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();

        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //divPDF.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

        
        //String basePath = Request.ApplicationPath;
        //HtmlLoadOptions htmloptions = new HtmlLoadOptions(basePath);
        //// Load HTML file
        //Document doc = new Document(Request.ApplicationPath + @"\HtmlPage.html", htmloptions);
        //// Save HTML file
        //doc.Save(Request.ApplicationPath + @"\Output.pdf");

        if (System.Configuration.ConfigurationManager.AppSettings["HostedURL"] != null)
        {
            GeneratePDF oGen = new GeneratePDF();
            string URL = System.Configuration.ConfigurationManager.AppSettings["HostedURL"].ToString() + "/Bill.aspx";
            oGen.Generate(Request.PhysicalApplicationPath, URL);
        }        
    }
}