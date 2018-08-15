using GGFPortal.ReferenceCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GGFPortal.MIS
{
    public class 佣金Controller : ApiController
    {
        字串處理 字串處理 = new 字串處理();
        // GET api/<controller>
        public IEnumerable<string> Get(string shp_nbr)
        {
            佣金Model 佣金 = new 佣金Model();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" where shp_nbr in {0}", 字串處理.字串多筆資料搜尋(shp_nbr).ToString());
            if (sb.Length > 0)
            {
                DataTable dt = new DataTable();
                using (SqlConnection Conn = new SqlConnection(""))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sb.ToString(), Conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }
                if (dt.Rows.Count > 0)
                {
                  
                }

            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}