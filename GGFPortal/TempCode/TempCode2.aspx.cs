using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.TempCode
{
    public partial class TempCode2 : System.Web.UI.Page
    {
        //字串處理 切字串 = new 字串處理();
        //static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        //ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        //string StrError名稱, StrProgram;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題
            string StrPageName = "TempCode", StrProgram = "TempCode.aspx";
            BrandLB.Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion
        }
    }
}