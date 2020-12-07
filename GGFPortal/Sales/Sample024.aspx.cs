using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sample024 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "打樣單附件資料查詢";
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
            DbInit();
        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("new").ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            DataTable dt2 = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("old").ToString(), Conn);
                myAdapter.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }



            if (dt.Rows.Count > 0)
            {
                ToDayGV.DataSource = dt;
                ToDayGV.DataBind();
            }
            else
                F_ErrorShow("當日無資料");
            if(dt2.Rows.Count>0)
            {
                OldGV.DataSource = dt2;
                OldGV.DataBind();
            }
        }

        private StringBuilder selectsql(string StrSearchType)
        {

            StringBuilder strsql = new StringBuilder(" select top 100 * from [View打樣單客來參考版] ");
            if(StrSearchType=="new")
            {
                strsql.Append($" where [上傳日期] = '{DateTime.Now.ToString("yyyy-MM-dd")}'");
            }
            else
                strsql.Append($" where [上傳日期] between '{DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd")}' and  '{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}' order by [上傳日期] desc ");

            return strsql;
        }


        protected void ToDayGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label1 = (Label)e.Row.FindControl("Label1");
                string StrLink = label1.Text;
                if (!string.IsNullOrEmpty(StrLink) && StrLink != "&nbsp;")
                {
                    string StrUrl;
                    StrLink = StrLink.Substring(3, StrLink.Length - 3);
                    Label label = (Label)e.Row.FindControl("LinkLB");
                    StrUrl=string.Format(@" <a href=""/W/{0}"">檔案</a>", StrLink);
                    label.Text = StrUrl;
                }
            }
        }

        protected void OldGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label1 = (Label)e.Row.FindControl("Label1");
                string StrLink = label1.Text;
                if (!string.IsNullOrEmpty(StrLink) && StrLink != "&nbsp;")
                {
                    string StrUrl;
                    StrLink = StrLink.Substring(3, StrLink.Length - 3);
                    Label label = (Label)e.Row.FindControl("LinkLB");
                    StrUrl = string.Format(@" <a href=""/W/{0}"">檔案</a>", StrLink);
                    label.Text = StrUrl;
                }
            }
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}