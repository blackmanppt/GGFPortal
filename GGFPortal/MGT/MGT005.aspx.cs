using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MGT
{
    public partial class MGT005 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("onclick", "printPage()");
            if (!Page.IsPostBack)
            {
                int iuid = 0,iid=0;
                int.TryParse(Session["uid"].ToString(), out iuid);
                int.TryParse(Session["id"].ToString(), out iid);
                if (iuid>0&& iid>0)
                {
                    DataSetSource.GGFEntitiesMGT db = new DataSetSource.GGFEntitiesMGT();
                    var 提單列印 = db.快遞單明細.Where(p => p.id == iid&&p.uid<=iuid);
                    快遞編號LB.Text = 提單列印.Count().ToString();
                    var 提單列印明細 = 提單列印.Where(p => p.uid == iuid).FirstOrDefault();
                    快遞廠商LB.Text = 提單列印明細.快遞單.快遞廠商;
                    快遞日期LB.Text = 提單列印明細.快遞單.提單日期.ToString("yyyy-MM-dd");
                    提單號碼LB.Text = 提單列印明細.快遞單.提單號碼;
                    寄件人LB.Text = 提單列印明細.寄件人+"("+ 提單列印明細.寄件人分機+")";

                    送件地點LB.Text = 提單列印明細.快遞單.送件地點+"-"+ 提單列印明細.快遞單.地點備註;
                    收件人LB.Text = 提單列印明細.收件人;
                    明細LB.Text = 提單列印明細.明細;
                    string str備註 = 提單列印明細.備註二??"";
                    if (str備註.IndexOf("\r\n") > 0)
                        str備註.Replace("\r\n", "<br/>");
                    備註LB.Text = str備註;
                    英文名LB.Text = (string.IsNullOrEmpty(提單列印明細.email))?"": 提單列印明細.email.Substring(0, 提單列印明細.email.IndexOf(@"@"));
                    快遞單檔案Literal.Text = @"<img alt='提單' src='MGTFile\" + 提單列印明細.快遞單.快遞單檔案 + @"' />";
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}