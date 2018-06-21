using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales009 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath(@"~\ExcelUpLoad\Salse\SIZE\");
            string tempFolder = System.IO.Path.GetTempPath(); // Get folder 
            string FileName = FileUpload1.FileName.ToString(); // Get xml file name
            string strpo = FileName.Substring(FileName.Length-12, 8);
                //"GREGIA_20180605203002208_02075624.XML"
            savePath = savePath + FileName;


            if (string.IsNullOrEmpty(FileUpload1.FileName))
            {
                MessageLB.Text = "請選擇檔案";
                AlertPanel_ModalPopupExtender.Show();
            }
            else
            {
                try
                {
                    MessageLB.Text = "";
                    FileUpload1.SaveAs(savePath);

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
                    TempTable.Columns.Add("訂單Style");
                    TempTable.Columns.Add("客戶PO");
                    TempTable.Columns.Add("目的地代號");
                    TempTable.Columns.Add("PO別");
                    TempTable.Columns.Add("Style");

                    TempTable.Columns.Add("FOB單價");
                    TempTable.Columns.Add("客戶交期");
                    TempTable.Columns.Add("顏色(英文)");
                    if (dtSize.Rows.Count > 0)
                        for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                        {
                            TempTable.Columns.Add(dtSize.Rows[iSizeCount][0].ToString().ToUpper().Trim());
                        }
                    //----不考慮多單價，所有item都會相同
                    //for (int po資料筆數 = 0; po資料筆數 < dt3.Rows.Count; po資料筆數++)
                    //{
                    //}

                    for (int i顏色數量 = 0; i顏色數量 < dtColor.Rows.Count; i顏色數量++)
                    {
                        DataRow row;
                        row = TempTable.NewRow();
                        //----不考慮多單價，所有item都會相同
                        row["訂單Style"] = dt3.Rows[0]["ItemBuyerOrderNo"];
                        row["FOB單價"] = dt3.Rows[0]["ItemUnitPriceTotal"];
                        //----
                        row["客戶PO"] = strpo;
                        row["客戶交期"] = dt2.Rows[0]["ShipmentDeliveryDate"];
                        row["顏色(英文)"] = dtColor.Rows[i顏色數量][0];
                        for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                        {
                            object obtest;
                            obtest = dt.Compute("sum(數量)", "Color = '" + dtColor.Rows[i顏色數量][0].ToString() + "' and Size = '" + dtSize.Rows[iSizeCount][0] + "'");
                            row[dtSize.Rows[iSizeCount][0].ToString()] = obtest.ToString().ToUpper().Trim();
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
                    ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
                    xx.ExcelWithNPOI(TempTable, @"xlsx");
                }
                catch (Exception ex)
                {
                    MessageLB.Text = ex.ToString();
                    AlertPanel_ModalPopupExtender.Show();
                }
                
            }

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string savePath = Server.MapPath(@"~\ExcelUpLoad\Salse\SIZE\");
            string tempFolder = System.IO.Path.GetTempPath(); // Get folder 
            string FileName = FileUpload1.FileName.ToString(); // Get xml file name
            string strpo = FileName.Substring(FileName.Length - 12, 8);
            //"GREGIA_20180605203002208_02075624.XML"
            savePath = savePath + FileName;


            if (string.IsNullOrEmpty(FileUpload1.FileName))
            {
                MessageLB.Text = "請選擇檔案";
                AlertPanel_ModalPopupExtender.Show();
            }
            else
            {
                try
                {
                    MessageLB.Text = "";
                    FileUpload1.SaveAs(savePath);

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
                    TempTable.Columns.Add("訂單Style");
                    TempTable.Columns.Add("客戶PO");
                    TempTable.Columns.Add("目的地代號");
                    TempTable.Columns.Add("PO別");
                    TempTable.Columns.Add("Style");
                    TempTable.Columns.Add("顏色(英文)");
                    TempTable.Columns.Add("Size");
                    TempTable.Columns.Add("數量");
                    TempTable.Columns.Add("FOB單價");
                    TempTable.Columns.Add("DC_Date");
                    TempTable.Columns.Add("客戶交期(起)");
                    TempTable.Columns.Add("客戶交期(迄)");
                    TempTable.Columns.Add("客戶交期");
                    
                    //if (dtSize.Rows.Count > 0)
                    //    for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                    //    {
                    //        TempTable.Columns.Add(dtSize.Rows[iSizeCount][0].ToString().ToUpper().Trim());
                    //    }
                    //----不考慮多單價，所有item都會相同
                    //for (int po資料筆數 = 0; po資料筆數 < dt3.Rows.Count; po資料筆數++)
                    //{
                    //}

                    for (int i顏色數量 = 0; i顏色數量 < dtColor.Rows.Count; i顏色數量++)
                    {
                        
                        for (int iSizeCount = 0; iSizeCount < dtSize.Rows.Count; iSizeCount++)
                        {
                            DataRow row;
                            row = TempTable.NewRow();
                            //----不考慮多單價，所有item都會相同
                            row["訂單Style"] = dt3.Rows[0]["ItemBuyerOrderNo"];
                            row["FOB單價"] = dt3.Rows[0]["ItemUnitPriceTotal"];
                            //----
                            ////----空的資料
                            //row["目的地代號"] = "";
                            //row["PO別"] = "";
                            //row["Style"] = "";
                            //row["DC_Date"] = "";
                            //row["客戶交期(起)"] = "";
                            //row["客戶交期(迄)"] = "";
                            ////----
                            row["客戶PO"] = strpo;
                            row["客戶交期"] = dt2.Rows[0]["ShipmentDeliveryDate"];
                            row["顏色(英文)"] = dtColor.Rows[i顏色數量][0];
                            row["Size"] = (dtSize.Rows[iSizeCount][0].ToString().IndexOf(" (") > 0)? dtSize.Rows[iSizeCount][0].ToString().Substring(0, dtSize.Rows[iSizeCount][0].ToString().IndexOf(" (")) : dtSize.Rows[iSizeCount][0];
                            object obtest;
                            obtest = dt.Compute("sum(數量)", "Color = '" + dtColor.Rows[i顏色數量][0].ToString() + "' and Size = '" + dtSize.Rows[iSizeCount][0] + "'");
                            //row[dtSize.Rows[iSizeCount][0].ToString()] = obtest.ToString().ToUpper().Trim();
                            row["數量"] = obtest.ToString().ToUpper().Trim();
                            TempTable.Rows.Add(row);
                        }
                        
                    }
                    //if (TempTable.Columns.Count > 0)
                    //    for (int i = 0; i < TempTable.Columns.Count; i++)
                    //    {
                    //        if (TempTable.Columns[i].ColumnName.IndexOf(" (") > 0)
                    //        {
                    //            //刪除多餘尺寸說明/
                    //            TempTable.Columns[i].ColumnName = TempTable.Columns[i].ColumnName.Substring(0, TempTable.Columns[i].ColumnName.IndexOf(" ("));
                    //        }
                    //    }
                    ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
                    xx.ExcelWithNPOI(TempTable, @"xlsx");
                }
                catch (Exception ex)
                {
                    MessageLB.Text = ex.ToString();
                    AlertPanel_ModalPopupExtender.Show();
                }

            }
        }
    }
}