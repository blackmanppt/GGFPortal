﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.test
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('"+ strConnectString + "');</script>");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            TextBox1.Text = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string xx = "-1";
            int zz = 9;
            Label1.Text = int.TryParse(xx,out zz).ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.Hour.ToString();
        }
        void 程式測試_List()
        {
            //list運用
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            //顯示資料
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            names.Add("test1");
            names.Add("test2");
            names.Remove("Ana");
            //顯示資料
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine($"Show Name have {names.Count} Data");
            Console.WriteLine($"Data 1: {names[0]} Data");

            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Sort: {name.ToUpper()}!");
            }
        }
    }
}