using GGFPortal.DataSetSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS.site
{
    public partial class site4F : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GGFEntitiesMGT db = new GGFEntitiesMGT();
            var 四樓資料 = db.View員工基本資料.Where(c => c.狀態 == "啟用").ToList();
            foreach (var item in 四樓資料)
            {
                try
                {
                    Label lbName, lbCName;
                    lbName = (Label)FindControl("Name" + item.分機 + "LB");
                    lbName.Text = item.英文名字;
                    lbCName = (Label)FindControl("CName" + item.分機 + "LB");
                    lbCName.Text = item.名字;
                }
                catch (Exception)
                {

                    continue;
                }
            }
        }
    }
}