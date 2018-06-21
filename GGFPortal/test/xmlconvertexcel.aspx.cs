using System;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;
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
            //轉換數量類型
            dt.Columns.Add("數量", typeof(int), "Convert(Quantity,'System.Int32')");
            DataTable dt1 = ds.Tables["PrePack"];
            DataTable dt2 = ds.Tables["Shipment"];
            DataTable dt3 = ds.Tables["Item"];

            DataTable dtColor = new DataTable(), dtSize = new DataTable();
            dtColor = dt.DefaultView.ToTable(true, new string[] { "Color" });
            dtSize = dt.DefaultView.ToTable(true, new string[] { "Size" });

            DataTable TempTable = new DataTable();
            TempTable.Columns.Add("Style");
            TempTable.Columns.Add("UnitPrice");
            TempTable.Columns.Add("ShipmentDeliveryDate");
            TempTable.Columns.Add("Color");
            if (dtSize.Rows.Count>0)
                for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                {
                    TempTable.Columns.Add(dtSize.Rows[iSizeCount][0].ToString());
                }
            for (int po資料筆數 = 0; po資料筆數 < dt3.Rows.Count; po資料筆數++)
            {
                for (int i顏色數量 = 0; i顏色數量 < dtColor.Rows.Count; i顏色數量++)
                {
                    DataRow row;
                    row = TempTable.NewRow();
                    row["Style"] = dt3.Rows[po資料筆數]["ItemBuyerOrderNo"];
                    row["UnitPrice"] = dt3.Rows[po資料筆數]["ItemUnitPriceTotal"];
                    row["ShipmentDeliveryDate"] = dt2.Rows[po資料筆數]["ShipmentDeliveryDate"];
                    row["Color"] = dtColor.Rows[i顏色數量][0];
                    for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                    {
                        object obtest;
                        obtest = dt.Compute("sum(數量)", "Color = '" + dtColor.Rows[i顏色數量][0].ToString() + "' and Size = '" + dtSize.Rows[iSizeCount][0] + "'");
                        row[dtSize.Rows[iSizeCount][0].ToString()] = obtest.ToString();
                    }
                    TempTable.Rows.Add(row);
                }
                if(TempTable.Columns.Count>0)
                    for (int i = 0; i < TempTable.Columns.Count; i++)
                    {
                        if(TempTable.Columns[i].ColumnName.IndexOf(" (")>0)
                        {
                            TempTable.Columns[i].ColumnName = TempTable.Columns[i].ColumnName.Substring(0, TempTable.Columns[i].ColumnName.IndexOf(" ("));
                        }
                    }
                DataTable temptable2 = TempTable;
                GridView5.DataSource = temptable2;
                GridView5.DataBind();

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string savePath = Server.MapPath(@"~\ExcelUpLoad\Salse\SIZE\");
            string tempFolder = System.IO.Path.GetTempPath(); // Get folder 
            string FileName = FileUpload1.FileName.ToString(); // Get xml file name
            savePath = savePath + FileName;
            FileUpload1.SaveAs(savePath);
            //string savePath = Server.MapPath(@"~\ExcelUpLoad\VN\test.xml");
            //string FileName = FileUpload1.FileName.ToString(); // Get xml file name
            //savePath = savePath + FileName;

            DataSet ds = new DataSet();
            //透過DataSet的ReadXml方法來讀取Xmlreader資料
            ds.ReadXml(savePath);
            //建立DataTable並將DataSet中的第0個Table資料給DataTable
            DataTable dt = ds.Tables["ColorSize"];
            //轉換數量類型
            dt.Columns.Add("數量", typeof(int), "Convert(Quantity,'System.Int32')");
            DataTable dt1 = ds.Tables["PrePack"];
            DataTable dt2 = ds.Tables["Shipment"];
            DataTable dt3 = ds.Tables["Item"];

            DataTable dtColor = new DataTable(), dtSize = new DataTable();
            dtColor = dt.DefaultView.ToTable(true, new string[] { "Color" });
            dtSize = dt.DefaultView.ToTable(true, new string[] { "Size" });

            DataTable TempTable = new DataTable();
            TempTable.Columns.Add("Style");
            TempTable.Columns.Add("UnitPrice");
            TempTable.Columns.Add("ShipmentDeliveryDate");
            TempTable.Columns.Add("Color");
            if (dtSize.Rows.Count > 0)
                for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                {
                    TempTable.Columns.Add(dtSize.Rows[iSizeCount][0].ToString());
                }

            for (int po資料筆數 = 0; po資料筆數 < dt3.Rows.Count; po資料筆數++)
            {
                for (int i顏色數量 = 0; i顏色數量 < dtColor.Rows.Count; i顏色數量++)
                {
                    DataRow row;
                    row = TempTable.NewRow();
                    row["Style"] = dt3.Rows[po資料筆數]["ItemBuyerOrderNo"];
                    row["UnitPrice"] = dt3.Rows[po資料筆數]["ItemUnitPriceTotal"];
                    row["ShipmentDeliveryDate"] = dt2.Rows[po資料筆數]["ShipmentDeliveryDate"];
                    row["Color"] = dtColor.Rows[i顏色數量][0];
                    for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                    {
                        object obtest;
                        obtest = dt.Compute("sum(數量)", "Color = '" + dtColor.Rows[i顏色數量][0].ToString() + "' and Size = '" + dtSize.Rows[iSizeCount][0] + "'");
                        row[dtSize.Rows[iSizeCount][0].ToString()] = obtest.ToString();
                    }
                    TempTable.Rows.Add(row);
                }
                if (TempTable.Columns.Count > 0)
                    for (int i = 0; i < TempTable.Columns.Count; i++)
                    {
                        if (TempTable.Columns[i].ColumnName.IndexOf(" (") > 0)
                        {
                            //刪除多餘尺寸說明
                            TempTable.Columns[i].ColumnName = TempTable.Columns[i].ColumnName.Substring(0, TempTable.Columns[i].ColumnName.IndexOf(" ("));
                        }
                    }
            }
            ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
            xx.ExcelWithNPOI(TempTable, @"xlsx");
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