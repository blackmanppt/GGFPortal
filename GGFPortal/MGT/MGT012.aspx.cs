using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MGT
{
    public partial class MGT012 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "快遞核准單", StrProgram = "MGT012.aspx";
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
            if(!Page.IsPostBack)
            {
                int iuid = 0, iid = 0;
                //int.TryParse(Session["uid"].ToString(), out iuid);
                int.TryParse(Session["id"].ToString(), out iid);
                DbInit(iid);
            }
        }
        protected void DbInit(int iid)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("明細", iid).ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            }
            if (dt.Rows.Count > 0)
            {

                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("MGT004", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                DataTable dt2 = new DataTable();
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("單頭", iid).ToString(), Conn);
                    myAdapter.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }
                ReportDataSource source2 = new ReportDataSource("MGT004_1", dt2);
                ReportViewer1.LocalReport.DataSources.Add(source2);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql(string strType, int iid)
        {

            StringBuilder strsql = new StringBuilder();
            if (strType == "明細")
            {
                strsql.Append(@"SELECT ROW_NUMBER() over(order by uid ) as 流水號,a.寄件人,a.寄件人分機,a.重量,a.明細,a.責任歸屬,a.付款方式,a.IsDeleted,c.Dept as'寄件人部門',a.客戶名稱
                                                        FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id left join [192.168.0.116].[EIP].[dbo].[Dept] c on a.寄件人部門 =(c.Dept_ID COLLATE Chinese_Taiwan_Stroke_CI_AS )
                                    where b.IsDeleted = 0  ");
                if (iid > 0)
                    strsql.AppendFormat(@" and  b.id={0} ", iid);

                strsql.AppendFormat(@" and  Dept_ID = '{0}' ", Session["部門"].ToString());
                //strsql.AppendFormat(@"SELECT ROW_NUMBER() over(order by uid ) as 流水號,a.*
                //                                        FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id
                //                    where (UPPER(b.[提單號碼]) = '{0}' or b.id={1} ) and b.IsDeleted = 0  
                //                                    ", 提單TB.Text.Trim().ToUpper(),iid);
            }
            else
            {

                strsql.Append(@"SELECT top 1 id,提單號碼,提單日期,快遞廠商,快遞單檔案,送件地點+地點備註 as '送件地點',IsDeleted,修改日期,建立日期 FROM [快遞單] 
                                    where  IsDeleted = 0  ");
                if (iid > 0)
                    strsql.AppendFormat(@" and  id={0} ", iid);

                //strsql.AppendFormat(@"( UPPER([提單號碼]) = '{0}' or id={1} and IsDeleted = 0  
                //                    order by 建立日期  desc ", 提單TB.Text.Trim().ToUpper(),iid);
            }
            
            return strsql;
        }
        
        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}