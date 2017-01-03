using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GGFPortal.Sales
{
    /// <summary>
    ///WebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();

        [WebMethod]
        public CascadingDropDownNameValue[] GetCountries(string knownCategoryValues)
        {
            string query = "SELECT CountryName, CountryId FROM Countries";
            List<CascadingDropDownNameValue> countries = GetData(query);
            return countries.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetStates(string knownCategoryValues)
        {
            string country = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["CountryId"];
            string query = string.Format("SELECT StateName, StateId FROM States WHERE CountryId = {0}", country);
            List<CascadingDropDownNameValue> states = GetData(query);
            return states.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetCities(string knownCategoryValues)
        {
            string state = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["StateId"];
            string query = string.Format("SELECT CityName, CityId FROM Cities WHERE StateId = {0}", state);
            List<CascadingDropDownNameValue> cities = GetData(query);
            return cities.ToArray();
        }

        private List<CascadingDropDownNameValue> GetData(string query)
        {
            string conString = strConnectString;
            SqlCommand cmd = new SqlCommand(query);
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                cmd.Connection = con;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        values.Add(new CascadingDropDownNameValue
                        {
                            name = reader[0].ToString(),
                            value = reader[1].ToString()
                        });
                    }
                    reader.Close();
                    con.Close();
                    return values;
                }
            }
        }


        [WebMethod]
        public CascadingDropDownNameValue[] getType(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  cus_id from ordc_bah1 where bah_status <>'CA'";
                    //cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<CascadingDropDownNameValue> StyleNo = new List<CascadingDropDownNameValue>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(new CascadingDropDownNameValue(sdr["cus_id"].ToString(), sdr["cus_id"].ToString()));
                        }
                    }
                    conn.Close();
                    return StyleNo.ToArray();
                }
            }

            //SqlConnection conn = demotools.getSqlConnection();
            ////SqlCommand comm = new SqlCommand("SQL語句", conn);
            //conn.Open();
            //SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            //while (reader.Read())
            //{
            //    values.Add(new CascadingDropDownNameValue(reader[1].ToString(), reader[0].ToString()));
            //}
            //conn.Dispose();
            //comm.Dispose();
            //reader.Dispose();
            //return values.ToArray();
        }
        [WebMethod]
        public CascadingDropDownNameValue[] getkind(string knownCategoryValues, string category)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  brand from ordc_bah1 where bah_status <>'CA'";
                    //cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<CascadingDropDownNameValue> StyleNo = new List<CascadingDropDownNameValue>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(new CascadingDropDownNameValue(sdr["brand"].ToString(), sdr["brand"].ToString()));
                        }
                    }
                    conn.Close();
                    return StyleNo.ToArray();
                }
            }
            //StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            //List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            //SqlConnection conn = demotools.getSqlConnection();
            //SqlCommand comm = new SqlCommand("SELECT text, Id FROM View WHERE (parnetId = " + kv["t"] + ")", conn);
            //conn.Open();
            //SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            //while (reader.Read())
            //{
            //    values.Add(new CascadingDropDownNameValue(reader[0].ToString(), reader[1].ToString()));
            //}
            //conn.Dispose();
            //comm.Dispose();
            //reader.Dispose();
            //return values.ToArray();
        }
    }
}
