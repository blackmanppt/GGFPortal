using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.FactoryMG
{
    public partial class FactorySite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strArea, strImportType;

                strArea = (Request.Params["AREA"] != null) ? Request.Params["AREA"] : "";
                strImportType = (Request.Params["TYPE"] != null) ? Request.Params["TYPE"] : "";
                if (strArea == "" || strImportType == "")
                    Response.Redirect("VNindex.aspx");
                BrandBL.Text = strArea;
            }
            catch (Exception)
            {
                FTimeOut();
                throw;
            }
        }

        protected void FTimeOut()
        {
            Session.RemoveAll();
            Session["Error"] = "Session Timeout";
            Response.Redirect("Fcindex.aspx");
        }

        protected void QCBT_Click(object sender, EventArgs e)
        {

        }

        protected void IronBT_Click(object sender, EventArgs e)
        {

        }

        protected void CutBT_Click(object sender, EventArgs e)
        {

        }

        protected void PackageBT_Click(object sender, EventArgs e)
        {

        }

        protected void StitchBT_Click(object sender, EventArgs e)
        {

        }
    }
}