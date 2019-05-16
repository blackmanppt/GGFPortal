using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace GGFPortal.test
{
    /// <summary>
    /// Handler2 的摘要描述
    /// </summary>
    public class Handler2 : IHttpHandler
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        public void ProcessRequest(HttpContext context)
        {
            string command = context.Request.QueryString["test"];//前台传的标示值  
            if (command == "add")
            {//调用添加方法  
             //Add(context);//我暂时只是绑定，所以把这些给注释了
            }
            else if (command == "modify")
            {//调用修改方法  
             //Modify(context);//我暂时只是绑定，所以把这些给注释了
            }
            else
            {//调用查询方法  
                Query(context);
            }
        }
        public void Query(HttpContext context)
        {
            //调用B层的方法从而获取数据库的Dataset  
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(@"SELECT *
                                                              FROM [dbo].[View員工基本資料]", Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            string str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);

            context.Response.Write(str_json);//返回给前台页面  
            context.Response.End();

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}