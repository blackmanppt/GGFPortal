using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sales016 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題
            //網頁標題
            string StrPageName = "布價歷史資料查詢", StrProgram = "Sales016.aspx";
            TitleLB.Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode.aspx";
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {

        }

        protected void Remark_Click(object sender, EventArgs e)
        {

        }
    }
}