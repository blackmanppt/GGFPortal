using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MGT
{
    public partial class MGT005 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onclick", "printPage()");
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
                    //快遞編號LB2.Text = 提單列印.Count().ToString();
                    var 提單列印明細 = 提單列印.Where(p => p.uid == iuid).FirstOrDefault();
                    快遞廠商LB.Text = 提單列印明細.快遞單.快遞廠商;
                    快遞日期LB.Text = 提單列印明細.快遞單.提單日期.ToString("yyyy-MM-dd");
                    提單號碼LB.Text = 提單列印明細.快遞單.提單號碼;
                    寄件人LB.Text =  提單列印明細.寄件人分機;
                    送件地點LB.Text = 提單列印明細.快遞單.送件地點+"-"+ 提單列印明細.快遞單.地點備註;
                    收件人LB.Text = 提單列印明細.收件人;
                    明細LB.Text = 提單列印明細.明細;
                    Session["部門"] = 提單列印明細.寄件人部門;




                    string str備註 = 提單列印明細.備註二??"";
                    if (str備註.IndexOf("\r\n") > 0)
                        str備註=str備註.Replace("\r\n", "<br/>");
                    備註LB.Text = str備註;
                    公斤LB.Text = 提單列印明細.重量.ToString();
                    //英文名LB.Text = (string.IsNullOrEmpty(提單列印明細.email))?"": 提單列印明細.email.Substring(0, 提單列印明細.email.IndexOf(@"@"));
                    快遞單檔案Literal.Text = @"<img alt='提單' src='MGTFile\" + 提單列印明細.快遞單.快遞單檔案 + @"' />";
                    decimal d總重 = 0;
                    using (SqlConnection conn1 = new SqlConnection(strConnectString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = conn1;
                        command.CommandText = @"SELECT   sum(a.重量) as 總重
                                            FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id left join bas_dept c on a.寄件人部門 =c.dept_no and c.site='GGF'
                                    where b.IsDeleted = 0 and a.IsDeleted = 0  and a.id=@id and a.寄件人部門=@寄件人部門";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@id", SqlDbType.Int).Value = iid;
                        command.Parameters.Add("@寄件人部門", SqlDbType.NVarChar).Value = 提單列印明細.寄件人部門;
                        conn1.Open();
                        d總重 = Convert.ToDecimal(command.ExecuteScalar());
                        //SqlDataReader reader = command.ExecuteReader();

                        //if (reader.HasRows)
                        //{
                        //    if (reader.Read())
                        //    {
                        //        //DataReader讀出欄位內資料的方式，通常也可寫Reader[0]、[1]...[N]代表第一個欄位到N個欄位。
                        //        d總重 = reader.GetInt32(0);
                        //    }
                        //}
                        //reader.Close();
                    }
                    
                    if(d總重>=2&& d總重<5)
                    {
                        過重LB.Text = "部門寄包裹總重"+ d總重 + "KG已超過2kg以上，需經理級批核，請列印快遞核准單";
                    }
                    else if(d總重>=5&& d總重<10)
                    {
                        過重LB.Text = "部門寄包裹總重" + d總重 + "KG已超過5kg以上，需副總級批核，請列印快遞核准單";
                    }
                    else if(d總重>=10 && d總重 < 20)
                    {
                        過重LB.Text = "部門寄包裹總重" + d總重 + "KG已超過10kg以上，需總經理批核，請列印快遞核准單";
                    }
                    else if (d總重 >= 20 )
                    {
                        過重LB.Text = "部門寄包裹總重" + d總重 + "KG已超過20kg以上，需董事長批核，請列印快遞核准單";
                    }
                    //if (d總重 >= 2)
                    //    Button1.Visible = true;
                    //快遞廠商LB2.Text = 提單列印明細.快遞單.快遞廠商;
                    //快遞日期LB2.Text = 提單列印明細.快遞單.提單日期.ToString("yyyy-MM-dd");
                    //提單號碼LB2.Text = 提單列印明細.快遞單.提單號碼;
                    //寄件人LB2.Text = 提單列印明細.寄件人 + "(" + 提單列印明細.寄件人分機 + ")";
                    //送件地點LB2.Text = 提單列印明細.快遞單.送件地點 + "-" + 提單列印明細.快遞單.地點備註;
                    //收件人LB2.Text = 提單列印明細.收件人;
                    //明細LB2.Text = 提單列印明細.明細;
                    //備註LB2.Text = str備註;
                    //公斤LB2.Text = 提單列印明細.重量.ToString();
                    //英文名LB2.Text = (string.IsNullOrEmpty(提單列印明細.email)) ? "" : 提單列印明細.email.Substring(0, 提單列印明細.email.IndexOf(@"@"));
                    //快遞單檔案Literal2.Text = @"<img alt='提單' src='MGTFile\" + 提單列印明細.快遞單.快遞單檔案 + @"' />";
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session.RemoveAll();
            //Session["uid"] = struid;
            //Session["id"] = ACRGV.Rows[row.RowIndex].Cells[1].Text;
            //Session["提單日期"] = ACRGV.Rows[row.RowIndex].Cells[3].Text;
            //Response.Redirect("MGT003.aspx");
            Response.Redirect("MGT012.aspx");
        }
    }
}