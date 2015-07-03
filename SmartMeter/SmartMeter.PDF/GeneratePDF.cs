using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf;
using System.Net;
using System.IO;

namespace SmartMeter.PDFWriter
{
    public class GeneratePDF
    {
        public void Generate(string BasePath, string SourceURL)
        {
            try 
	        {	        
		        string path = BasePath;
                string LicensePath = path + @"\.lic";
                string HTMLFile = path + @"\PDFOut_" + DateTime.Now.ToString() + ".html";
                string PDFName =  @"\PDFOut_"  + DateTime.Now.ToString()+ ".pdf";
                string PdfFile = path + PDFName;

                WebRequest request = WebRequest.Create(SourceURL);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();

                string html = String.Empty;
                using(StreamReader sr = new StreamReader(data))
                {
                    html = sr.ReadToEnd();
                }
                StreamWriter myStream = File.CreateText(HTMLFile);
                myStream.Write(html);
                myStream.Close();

                //HtmlLoadOptions htmloptions = new HtmlLoadOptions(BasePath);
                //Document doc = new Document(HTMLFile);
                //doc.Save(PdfFile);

                // Instantiate an object PDF class
                Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
                // add the section to PDF document sections collection
                Aspose.Pdf.Generator.Section section = pdf.Sections.Add();

                // Read the contents of HTML file into StreamReader object
                StreamReader r = File.OpenText(HTMLFile);
                //Create text paragraphs containing HTML text
                Aspose.Pdf.Generator.Text text2 = new Aspose.Pdf.Generator.Text(section, r.ReadToEnd());

                // enable the property to display HTML contents within their own formatting
                text2.IsHtmlTagSupported = true;
                //Add the text paragraphs containing HTML text to the section
                section.Paragraphs.Add(text2);

                //Save the pdf document
                pdf.Save(PdfFile);
	        }
	        catch (Exception ex)
	        {		
		        throw;
	        }
        }
    }
}
