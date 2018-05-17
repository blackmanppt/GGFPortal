using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace GGFPortal.test
{
    public partial class xmlconvertexcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Excel.Application excel2; // Create Excel app
            Excel.Workbook DataSource; // Create Workbook
            Excel.Worksheet DataSheet; // Create Worksheet
            excel2 = new Excel.Application(); // Start an Excel app
            DataSource = (Excel.Workbook)excel2.Workbooks.Add(1); // Add a Workbook inside
            string savePath = Server.MapPath(@"~\ExcelUpLoad\VN\");
            string tempFolder = System.IO.Path.GetTempPath(); // Get folder 
            string FileName = FileUpload1.FileName.ToString(); // Get xml file name
            savePath = savePath + FileName;
            FileUpload1.SaveAs(savePath);

            // Open that xml file with excel
            DataSource = excel2.Workbooks.Open(savePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            // Get items from xml file
            DataSheet = DataSource.Worksheets.get_Item(1);
            // Create another Excel app as object
            Object xl_app;
            xl_app = Marshal.GetActiveObject("Excel.Application");
            Excel.Application xlApp = (Excel.Application)xl_app;
            // Set previous Excel app (Xml) as ReportPage
            Excel.Application ReportPage = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
            // Copy items from ReportPage(Xml) to current Excel object
            Excel.Workbook Copy_To_Excel = ReportPage.ActiveWorkbook;

            Copy_To_Excel.SaveAs(@"c:\test2.xls",Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            Copy_To_Excel.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath(@"~\ExcelUpLoad\VN\test.xml");
            string FileName = FileUpload1.FileName.ToString(); // Get xml file name
            savePath = savePath + FileName;

            DataSet ds = new DataSet();
            //透過DataSet的ReadXml方法來讀取Xmlreader資料
            ds.ReadXml(savePath);
            //建立DataTable並將DataSet中的第0個Table資料給DataTable
            DataTable dt = ds.Tables["ColorSize"];
            DataTable dt1 = ds.Tables["PrePack"];
            DataTable dt2 = ds.Tables["Shipment"];
            DataTable dt3 = ds.Tables["Item"];
            //回傳DataTable
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //回傳DataTable
            GridView2.DataSource = dt1;
            GridView2.DataBind();
            //回傳DataTable
            GridView3.DataSource = dt2;
            GridView3.DataBind();

            GridView4.DataSource = dt3;
            GridView4.DataBind();

            //DataTable TempTable = new DataTable();
            //TempTable.Columns.Add("");
            //DataRow row;
            //for (int i = 0; i < dt2.Rows.Count; i++)
            //{
            //    row = TempTable.NewRow();
            //    row["ShipmentNo"] = i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentDeliveryDate"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;
            //    row["ShipmentBuyerOrderNo"] = "ParentItem " + i;

            //    for (int j = 0; j < dt1.Rows.Count; j++)
            //    {

            //    }
            //    TempTable.Rows.Add(row);
            //}
            
            Label1.Text = "";





        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath(@"~\ExcelUpLoad\VN\test.xml");
            XElement po = XElement.Load(savePath);
            IEnumerable<XElement> childElements =
                    from el in po.Elements()
                    select el;
            StringBuilder sb = new StringBuilder();
            foreach (XElement el in childElements)
            { 
                sb.AppendFormat("Name: {0}" , el.Name);
            }
            Label1.Text = sb.ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "<price>19.95</price>" +
                        "</book>");

            XmlNode root = doc.FirstChild;
            string str = "";
            //Display the contents of the child nodes.
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    str = str + root.ChildNodes[i].InnerText;
                }
            }

            Label1.Text = str;


            string savePath = Server.MapPath(@"~\ExcelUpLoad\VN\");


            XmlDocument docx = new XmlDocument();
            doc.Load(savePath);
            XmlNode rootx = docx.DocumentElement;
            

            DataSet ds = new DataSet();
            //透過DataSet的ReadXml方法來讀取Xmlreader資料
            ds.ReadXml(savePath);
            
            //建立DataTable並將DataSet中的第0個Table資料給DataTable
            DataTable dt = ds.Tables[0];
            //回傳DataTable
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}