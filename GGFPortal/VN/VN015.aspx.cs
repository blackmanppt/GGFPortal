using AjaxControlToolkit;
using ClosedXML.Excel;
using GGFPortal.ReferenceCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.VN
{
    public partial class VN015 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "Search For Grid", StrProgram = "TempCode.aspx";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            //using (SqlConnection Conn = new SqlConnection(strConnectString))
            //{
            //    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
            //    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            //}
            #region query 使用 In
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("createExcelImport");
                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    #region 查詢
                    string Str搜尋參數 = "";
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format(@"SELECT d* from 
                                 where {1} in ( {0} ) and a.site='GGF'
                                 ", string.Join(",", parameters), Str搜尋參數);
                    command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    for (int i = 0; i < StrArrary.Length; i++)
                        command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);
                    transaction1.Rollback();
                    throw;
                }
                finally
                {
                    conn1.Close();
                    transaction1.Dispose();
                }
            }
            #endregion

            if (dt.Rows.Count > 0)
            {
                //ReportViewer1.Visible = true;
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportDataSource source = new ReportDataSource("採購單料號訂單資料", dt);
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(source);
                //ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(" select * from [View採購單料號訂單資料] where 1=1 ");
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節年度])  = '{0}' ", 年度DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節])  = '{0}' ", 季節DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 款號TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    strsql.AppendFormat(" and upper([品牌])  = '{0}' ", 品牌TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    strsql.AppendFormat(" and upper([代理商])  = '{0}' ", 代理商TB.Text.ToUpper());
            //if (主料CB.Checked)
            //    strsql.Append(" and upper([主副料])  = 'M' ");
            //if (入庫CB.Checked)
            //    strsql.Append(" and upper([採購單狀態])  = 'IN' ");
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    bCheck = true;
            return bCheck;

        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="EditData"||e.CommandName=="DeleteData")
                using (GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer)
                {
                    ////抓key
                    //string strid = GV.DataKeys[row.RowIndex].Values[0].ToString();
                    ////抓資料
                    //Session["Uid"] = GV.Rows[row.RowIndex].Cells[3].Text;
                    switch (e.CommandName)
                    {
                        case "EditData":
                            //ModalPopupExtender modalPopupExtender = (ModalPopupExtender)FindControl("ContentPlaceHolder1_AlertPanel_ModalPopupExtender");
                            //modalPopupExtender.Show();
                            //EditLB.Text = "sfse";
                            EditPanel_ModalPopupExtender.Show();
                            break;
                        case "DeleteData":

                            break;
                        //case "SelectData":
                        //    break;
                        default:
                            break;
                    }
                }

        }
        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
        protected void ExcelDbInit()
        {
            DataTable dt振大主表 = new DataTable(), dt振大布類 = new DataTable(), dt振大顏色 = new DataTable();
            string StrError = "";
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(Selectsql("振大主表").ToString(), Conn);
                myAdapter.Fill(dt振大主表);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                myAdapter.SelectCommand.CommandText = Selectsql("振大布類").ToString();
                myAdapter.Fill(dt振大布類);
                myAdapter.SelectCommand.CommandText = Selectsql("振大顏色").ToString();
                myAdapter.Fill(dt振大顏色);
            }

            if (dt振大主表 == null)
            {
                StrError += "振大主表無資料<br/>";
            }
            if (dt振大布類 == null)
            {
                StrError += "振大布料無資料<br/>";
            }
            if (dt振大布類 == null)
            {
                StrError += "振大布類無資料";
            }
            if (StrError.Length > 0)
                F_ErrorShow(StrError);
            else
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt振大主表, "振大主表");
                    wb.Worksheets.Add(dt振大布類, "振大布類");
                    wb.Worksheets.Add(dt振大顏色, "振大顏色");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "檔案名稱"));
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {
            if ((upload_file.PostedFile != null) && (upload_file.PostedFile.ContentLength > 0))
            {
                string fileName = Path.GetFileName(upload_file.PostedFile.FileName);
                string LocationFiled = Server.MapPath(Str上傳路徑);


                string fileName = Path.GetFileName(upload_file.PostedFile.FileName);

                string LocationFiled = HttpContext.Current.Server.MapPath(Str儲存路徑);

                string Str副檔名 = Path.GetExtension(fileName).ToUpper();
                while (File.Exists(LocationFiled + fileName))
                {
                    fileName = fileName.Substring(0, fileName.Length - Str副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Str副檔名;
                }
                upload_file.PostedFile.SaveAs(LocationFiled + fileName);
            }
        }
        private StringBuilder Selectsql(string Str搜尋條件)
        {
            StringBuilder strsql = new StringBuilder();
            switch (Str搜尋條件)
            {
                case "振大主表":
                    strsql.AppendFormat(@"select b.cus_name_brief 客戶名稱,a.season 季節,a.season_y 季節年度,item_statistic_name 款式
                        ,(select pur_nbr+',' from purc_purchase_master where ord_nbr =a.ord_nbr and vendor_id='F0173'  FOR XML PATH('')) as 採購單  ,cus_item_no as 款號
                        from ordc_bah1 a 
                        left join bas_cus_master b on a.site=b.site and a.agents=b.cus_id
                        left join bas_item_statistic c on a.site=c.site and a.item_statistic=c.item_statistic
                        where cus_item_no ='{0}'", "");
                    break;
                case "振大布類":
                    strsql.AppendFormat(@"select  
                        a.pur_nbr 採購單,
                        c.cus_item_no 款號,
                        d.item_spk 料號規格,
                        sum(a.pur_qty) as 採購數量,
                        b.currency_id 幣別,a.pur_unit 單位,
                        b.pur_total_amt 採購金額,
                        a.pur_price 採購單價,
                        a.cloth_g_weight 克重
                        ,'GM/M2' 重量單位
                        ,e.cloth_width 幅寬
                        from purc_purchase_detail a left join purc_purchase_master b on a.site=b.site and a.pur_nbr=b.pur_nbr
                        left join ordc_bah1 c on a.site=c.site and a.ord_nbr=c.ord_nbr
                        left join bas_item_master d on a.org_item_no=d.item_no and a.site=d.site
                        left join ordc_material e on a.ord_nbr=e.ord_nbr and a.site=e.site and a.org_item_no =e.item_no AND b.vendor_id=e.vendor_id
                        where b.vendor_id='F0173' and cus_item_no ='{0}' and a.pur_detail_status <>'CA'
                        group by
                        a.pur_nbr,
                        c.cus_item_no,
                        b.pur_total_amt,
                        a.pur_price,
                        a.cloth_g_weight,
                        d.item_spk,b.currency_id
                        ,a.pur_unit,e.cloth_width", "");
                    break;
                case "振大顏色":
                    strsql.AppendFormat(@"select 
                        a.pur_nbr 採購單,a.pur_seq 採購單流水號,c.cus_item_no 款號,e.color_ename 顏色,a.pur_qty 採購數量,a.pur_unit 採購單位
                        ,a.overage_allow 允收上限,a.shortage_allow 允收下限,'%' as 上下限單位
                        ,a.pur_price 採購單價,b.currency_id 採購幣別,a.pur_amt 採購金額
                        from purc_purchase_detail a left join purc_purchase_master b on a.site=b.site and a.pur_nbr=b.pur_nbr
                        left join ordc_bah1 c on a.site=c.site and a.ord_nbr=c.ord_nbr
                        left join bas_item_master d on a.item_no=d.item_no and a.site=c.site
                        left join ordc_orders_color e on a.site=e.site and a.ord_nbr=e.ord_nbr and d.color_id=e.color_id
                        where b.vendor_id='F0173' and cus_item_no ='{0}' and a.pur_detail_status <>'CA'
                        order by a.pur_nbr,a.pur_seq
                        ", "");
                    break;
                default:
                    break;
            }
            return strsql;
        }
    }
}