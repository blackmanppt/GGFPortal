using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
namespace GGFPortal.test
{
    public partial class CrystalReportTest1 : System.Web.UI.Page
    {
        ReportDocument rpt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            SqlDataAdapter adapter;
            DataTable dt = new DataTable();

            adapter = new SqlDataAdapter(@"select * from purc_pkm ",connection);
            adapter.Fill(dt);

            string reportName = @"\ReportSource\CrytalReportTest.rpt";
            rpt.Load(Server.MapPath(reportName));
            rpt.SetDataSource(dt);
            CrystalReportPartsViewer1.ReportSource = rpt;
            CrystalReportPartsViewer1.DataBind();
        }
    }
}