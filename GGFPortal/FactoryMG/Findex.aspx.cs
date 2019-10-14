using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using GGFPortal.ReferenceCode;

namespace GGFPortal.FactoryMG
{
    public partial class Findex : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["Error"].ToString()))
                    FError(Session["Error"].ToString());
            }
            catch (Exception)
            {
                FError("Error");
                
            }

            if (Page.IsPostBack)
            {

            }
        }

        protected void StyleBT_Click(object sender, EventArgs e)
        {
            if (!FCheck())
            {
                FError("Select Factory");
            }
            else
            {

            }
        }
        public bool FCheck()
        {
            bool BCheck = true;
            //未選擇產區
            if (string.IsNullOrEmpty(FactoryDDL.SelectedValue))
            {
                BCheck = false;
                FError("Please select Factory");
            }
            return BCheck;
        }
        public void FError(string StrError)
        {
            MessageLB.Text = StrError;
            AlertPanel_ModalPopupExtender.Show();
            //ModalPopupExtender Pop = (ModalPopupExtender)Page.FindControl("");
            //Pop.Show();
        }

        protected void FactoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FactoryDDL.SelectedValue))
            {
                IronBT.Visible = false;
                QCBT.Visible = false;
                StitchBT.Visible = false;
                CutBT.Visible = false;
                PackageBT.Visible = false;
            }
            else
            {
                IronBT.Visible = true;
                QCBT.Visible = true;
                StitchBT.Visible = true;
                CutBT.Visible = true;
                PackageBT.Visible = true;
            }
            switch (FactoryDDL.SelectedValue)
            {
                case "GAMA":
                    IronBT.Text = "Iron";
                    QCBT.Text = "QC";
                    StitchBT.Text = "Stitch";
                    CutBT.Text = "Cut";
                    PackageBT.Text = "Package";
                    break;
                case "VGG":
                    IronBT.Text = "Là";
                    QCBT.Text = "Kiểm tra chất lượng";
                    StitchBT.Text = "Stitch";
                    CutBT.Text = "Cắt";
                    PackageBT.Text = "Đóng gói";
                    break;
                default:
                    break;
            }
        }

        protected void StitchBT_Click(object sender, EventArgs e)
        {
            if(FCheck())
            {
                Session["Team"] = "Stitch";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir();
            }
        }

        protected void PackageBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "Package";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir();
            }
        }

        protected void CutBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "Cut";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir();
            }
        }

        protected void IronBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "Iron";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir();
            }
        }

        protected void QCBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "QC";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir();
            }
        }
        void F_Redir()
        {

            Response.Redirect("F002.aspx");
        }
    }
}