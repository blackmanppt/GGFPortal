using GGFPortal.DataSetSource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.test
{
    public partial class Jsontest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Get());
        }
        GGFCubeDBEntities db = new GGFCubeDBEntities();
        // GET api/<controller>
        public string Get()
        {
            var xx = db.WebURL.ToList();
            string jjson = JsonConvert.SerializeObject(xx);
            return jjson;
        }
    }
}