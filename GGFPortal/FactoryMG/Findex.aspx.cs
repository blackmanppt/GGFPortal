﻿using System;
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
        static 多語 lang = new 多語();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Session.Clear();
            try
            {

                lang.讀取多語資料("Factory");
            }
            catch (Exception)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["Error"] != null)
                    if (!string.IsNullOrEmpty(Session["Error"].ToString()) )
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
                    IronBT.Text = lang.gg.Find(p => p.資料代號 == "Iron").英文;
                    QCBT.Text = lang.gg.Find(p => p.資料代號 == "QC").英文; 
                    StitchBT.Text = lang.gg.Find(p => p.資料代號 == "Stitch").英文;
                    CutBT.Text = lang.gg.Find(p => p.資料代號 == "Cut").英文; 
                    PackageBT.Text = lang.gg.Find(p => p.資料代號 == "Package").英文;
                    break;
                case "VGG":
                    IronBT.Text = lang.gg.Find(p => p.資料代號 == "Iron").越文;
                    QCBT.Text = lang.gg.Find(p => p.資料代號 == "QC").越文;
                    StitchBT.Text = lang.gg.Find(p => p.資料代號 == "Stitch").越文;
                    CutBT.Text = lang.gg.Find(p => p.資料代號 == "Cut").越文;
                    PackageBT.Text = lang.gg.Find(p => p.資料代號 == "Package").越文;
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
                F_Redir("F002.aspx");
            }
        }

        protected void PackageBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "Package";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir("F002.aspx");
            }
        }

        protected void CutBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "Cut";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir("F002.aspx");
            }
        }

        protected void IronBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "Iron";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir("F002.aspx");
            }
        }

        protected void QCBT_Click(object sender, EventArgs e)
        {
            if (FCheck())
            {
                Session["Team"] = "QC";
                Session["Area"] = FactoryDDL.SelectedValue;
                F_Redir("F002.aspx");
            }
        }
        void F_Redir(string strDirect)
        {
            Response.Redirect(strDirect);
        }

        protected void ImportLogSearchBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F005.aspx");
        }

        protected void ImportDataSearchBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F007.aspx");
        }

        protected void MonthTimeSumBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F008.aspx");
        }

        protected void TeamQtyBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F010.aspx");
        }

        protected void TeamCMBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F011.aspx");
        }

        protected void TimeSecBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F012.aspx");
        }

        protected void TimeSecTeamBT_Click(object sender, EventArgs e)
        {
            Session["Area"] = FactoryDDL.SelectedValue;
            F_Redir("F013.aspx");
        }
    }
}