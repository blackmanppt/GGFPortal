using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sales029 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static string strVNNConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["VNNGGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "AMZ 資料查詢", StrProgram = "Sales029.aspx";
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
        protected void DbInit(string StrSearchType)
        {
            string Str成衣庫存sql = @"
                                        select  C.cus_item_no 款號
                                        ,A.item_no 料號
                                        ,A.stockroom 儲位
                                        ,B.color_ename 顏色英 
                                        ,substring(A.lot_nbr,0,CHARINDEX('/',A.lot_nbr)) as 顏色代號 ,substring(A.lot_nbr,CHARINDEX('/',A.lot_nbr)+1,len(A.lot_nbr)) as 尺寸
                                        ,A.oh_qty as 成品庫存量
                                        ,A.lot_nbr 顏色尺寸
                                        from inv_ord_balance as A left join  bas_color as B on 
                                        substring(A.lot_nbr,1,CHARINDEX('/',A.lot_nbr)-1) = B.color_no and A.site=B.site and B.cus_id='AMZ'
                                        left join  ordc_bah1 as C on A.site=C.site and A.ord_nbr =C.ord_nbr
                                        where
                                        A.item_no like 'AMZ%' and
                                        A.oh_qty>0 
                                        ";
            string Str原料庫存sql = @"
                                        select  
                                        C.cus_item_no 款號
                                        ,C.ord_nbr 訂單號碼
                                        ,A.item_no 料號
                                        ,B.item_spk 料號規格
                                        ,F.color_ename
										--,A.stockroom 儲位
                                        --,E.stockroom_name 儲位名稱
                                        ,A.oh_qty as 在手量碼
                                        ,D.cloth_y_weight as 碼重
                                        ,cast(round((sum(A.oh_qty)*D.cloth_y_weight/1000*2.2046),2) as decimal(9,2)) as 在手量磅
                                        ,cast(round((sum(A.oh_qty)*D.cloth_y_weight/1000),2) as decimal(9,2)) as 在手量公斤
                                        from inv_ord_balance as A
                                        left join  bas_item_master as B on A.site=B.site and A.item_no=B.item_no 
                                        left join ordc_bah1 as C on A.site=C.site and A.ord_nbr=C.ord_nbr
                                        --left join bas_stockroom as E on A.site=E.site and A.stockroom=E.stockroom
                                        left join purc_purchase_detail as D on A.ord_nbr = D.ord_nbr and A.item_no = D.item_no
                                        left join bas_color as F on right(A.item_no,CHARINDEX('-', REVERSE(A.item_no))-1) =F.color_no and F.cus_id='AMZ'
                                        where A.ord_nbr = C.ord_nbr and
                                        --A.stockroom = E.stockroom and
                                        A.item_no = B.item_no and
                                        C.agents ='AMZ' and
                                        A.item_no like 'F%' and
                                        A.oh_qty >0 
										group by 
										C.cus_item_no 
                                        ,C.ord_nbr 
                                        ,A.item_no 
                                        ,B.item_spk 
                                        --,A.stockroom 
                                        --,E.stockroom_name 
                                        ,A.oh_qty  
                                        ,D.cloth_y_weight  
										,F.color_ename
                                        ";
            string StrVNN原料庫存sql = @"
                                        select  
                                        C.cus_item_no 款號
                                        ,C.ord_nbr 訂單號碼
                                        ,A.item_no 料號
                                        ,B.item_spk 料號規格
                                        ,F.color_ename
										,A.stockroom 儲位
                                        ,E.stockroom_name 儲位名稱
                                        ,A.oh_qty as 在手量碼
                                        ,D.cloth_y_weight as 碼重
                                        ,cast(round((sum(A.oh_qty)*D.cloth_y_weight/1000*2.2046),2) as decimal(9,2)) as 在手量磅
                                        ,cast(round((sum(A.oh_qty)*D.cloth_y_weight/1000),2) as decimal(9,2)) as 在手量公斤
                                        from inv_ord_balance as A
                                        left join  bas_item_master as B on A.site=B.site and A.item_no=B.item_no 
                                        left join ordc_bah1 as C on A.site=C.site and A.ord_nbr=C.ord_nbr
                                        left join bas_stockroom as E on A.site=E.site and A.stockroom=E.stockroom
                                        left join purc_purchase_detail as D on A.ord_nbr = D.ord_nbr and A.item_no = D.item_no
                                        left join bas_color as F on right(A.item_no,CHARINDEX('-', REVERSE(A.item_no))-1) =F.color_no and F.cus_id='AMZ'
                                        where A.ord_nbr = C.ord_nbr and
                                        A.stockroom = E.stockroom and
                                        A.item_no = B.item_no and
                                        C.agents ='AMZ' and
                                        A.item_no like 'F%' and
                                        A.oh_qty >0 
										group by 
										C.cus_item_no 
                                        ,C.ord_nbr 
                                        ,A.item_no 
                                        ,B.item_spk 
                                        ,A.stockroom 
                                        ,E.stockroom_name 
                                        ,A.oh_qty  
                                        ,D.cloth_y_weight  
										,F.color_ename
                                        ";

            //下載成衣庫存
            if (StrSearchType == "越南主料庫存")
            {
                DataTable dtVNN = new DataTable(), dtTW = new DataTable(), dtCompare = new DataTable();

                //dtVNN = F_庫存資料(越南成衣庫存, Str成衣庫存sql + " and A.stockroom = 'A031008' ", strVNNConnectString);
                //dtTW = F_庫存資料(台灣成衣庫存, Str成衣庫存sql + "  and A.site='GGF' ", strConnectString);

                //dtCompare = dtVNN.Clone();
                //DataColumn dataColumn不同數量 = new DataColumn();
                //dataColumn不同數量.ColumnName = "台灣數量";
                //dataColumn不同數量.DataType = System.Type.GetType("System.Decimal");
                //dtCompare.Columns.Add(dataColumn不同數量);

                //foreach (DataRow item in dtVNN.Rows)
                //{
                //    DataRow dr = dtCompare.NewRow();
                //    for (int i = 0; i < item.ItemArray.Length-1; i++)
                //    {
                //        dr[i] = item[i];
                //    }
                //    DataView dataView = new DataView(dtTW);
                //    dataView.RowFilter = " 料號 = '" + item["料號"] + "' and 顏色尺寸 ='" + item["顏色尺寸"] + "'";
                //    dr["台灣數量"] = dataView.Count > 0 ? dataView[0][6].ToString() : "0";
                //    dtCompare.Rows.Add(dr);
                //}
                dtVNN = F_庫存資料(Str原料庫存sql, strVNNConnectString);
                dtTW = F_庫存資料(Str原料庫存sql, strConnectString);

                dtCompare = dtVNN.Clone();

                DataColumn dataColumn台灣在手碼 = new DataColumn();
                dataColumn台灣在手碼.ColumnName = "台灣在手碼";
                dataColumn台灣在手碼.DataType = System.Type.GetType("System.Decimal");
                dtCompare.Columns.Add(dataColumn台灣在手碼);

                DataColumn dataColumn台灣碼 = new DataColumn();
                dataColumn台灣碼.ColumnName = "台灣碼";
                dataColumn台灣碼.DataType = System.Type.GetType("System.Decimal");
                dtCompare.Columns.Add(dataColumn台灣碼);

                DataColumn dataColumn台灣在手磅 = new DataColumn();
                dataColumn台灣在手磅.ColumnName = "台灣在手磅";
                dataColumn台灣在手磅.DataType = System.Type.GetType("System.Decimal");
                dtCompare.Columns.Add(dataColumn台灣在手磅);

                DataColumn dataColumn台灣在手公斤 = new DataColumn();
                dataColumn台灣在手公斤.ColumnName = "台灣在手公斤";
                dataColumn台灣在手公斤.DataType = System.Type.GetType("System.Decimal");
                dtCompare.Columns.Add(dataColumn台灣在手公斤);

                foreach (DataRow item in dtVNN.Rows)
                {
                    DataRow dr = dtCompare.NewRow();
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        dr[i] = item[i];
                    }
                    DataView dataView = new DataView(dtTW);
                    dataView.RowFilter = " 料號 = '" + item["料號"] + "' and 款號 ='" + item["款號"] + "'";
                    if (dataView.Count > 0)
                    {
                        try
                        {
                            //dr["台灣儲位"] = !string.IsNullOrEmpty(dataView[0][5].ToString()) ? dataView[0][5].ToString() : "";
                            dr["台灣在手碼"] = !string.IsNullOrEmpty(dataView[0][5].ToString()) ? dataView[0][5].ToString() : "0";
                            dr["台灣碼"] = !string.IsNullOrEmpty(dataView[0][6].ToString()) ? dataView[0][6].ToString() : "0";
                            dr["台灣在手磅"] = !string.IsNullOrEmpty(dataView[0][7].ToString()) ? dataView[0][7].ToString() : "0";
                            dr["台灣在手公斤"] = !string.IsNullOrEmpty(dataView[0][8].ToString()) ? dataView[0][8].ToString() : "0";
                        }
                        catch (Exception)
                        {
                            F_ErrorShow($"台灣資料轉換異常，請確認台灣資料，料號：{item["料號"]}，款號：{item["款號"]}");
                        }
                    }
                    else
                    {
                        //dr["台灣儲位"] = "";
                        dr["台灣在手碼"] = "0";
                        dr["台灣碼"] = "0";
                        dr["台灣在手磅"] = "0";
                        dr["台灣在手公斤"] = "0";
                    }
                    dtCompare.Rows.Add(dr);
                }
                if (dtCompare.Rows.Count > 0)
                {
                    ConvertToExcel convertToExcel = new ConvertToExcel();
                    convertToExcel.ExportExcelByCloseExcel(dtCompare, "越南主料庫存");
                }
                else
                    F_ErrorShow("越南連線異常，請稍後在試");
            }
            //越南主料庫存
            else if (StrSearchType == "越南原料庫存")
            {
                DataTable dt = new DataTable();
                dt = F_庫存資料(StrVNN原料庫存sql, strVNNConnectString);
                if (dt.Rows.Count > 0)
                {
                    ConvertToExcel convertToExcel = new ConvertToExcel();
                    convertToExcel.ExportExcelByCloseExcel(dt, "越南原料庫存");
                }
                else
                    F_ErrorShow("越南連線異常，請稍後在試");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = F_庫存資料(Str成衣庫存sql, strVNNConnectString);
                if (dt.Rows.Count>0)
                {
                    ConvertToExcel convertToExcel = new ConvertToExcel();
                    convertToExcel.ExportExcelByCloseExcel(dt, "AMZ成衣庫存比較");
                }
                else
                    F_ErrorShow("越南連線異常，請稍後在試");
            }
        }

        private static DataTable F_庫存資料(string Str成衣庫存sql,string StrConn)
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(StrConn))
            using (var cmd = new SqlCommand(Str成衣庫存sql, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return dt;
        }

        protected void AMZ成衣資料匯出BT_Click(object sender, EventArgs e)
        {
            DbInit("AMZ成衣庫存");
        }

        protected void AMZ主料庫存匯出BT_Click(object sender, EventArgs e)
        {
            DbInit("越南主料庫存");
        }

        protected void AMZ越南主料庫存匯出含儲位BT_Click(object sender, EventArgs e)
        {
            DbInit("越南原料庫存");
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}