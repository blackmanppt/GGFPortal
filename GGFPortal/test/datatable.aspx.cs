using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.test
{
    public partial class datatable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("OrderBy");
            DataRow dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "stone";
            dr[2] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = 2;
            dr[1] = "stone";
            dr[2] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "li";
            dr[2] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "wu";
            dr[2] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow(); 
            dr[0] = 1;
            dr[1] = "wu";
            dr[2] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "hsu";
            dr[2] = 1;
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            string str = "";
            foreach(var row in dt.AsEnumerable().GroupBy(p =>new { 
               ID= p.Field<string>("ID"),
               Name=p.Field<string>("Name")
            } ).Select(x => new { ID = x.Key, Count = x.Count() }))
            {
                {
                    if(row.Count>1)
                        str+=string.Format("{0} {1} </br>", row.ID,row.Count);
                }
            }
            Label1.Text = str;
            




        }
    }
}