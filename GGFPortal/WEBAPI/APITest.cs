using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GGFPortal.DataSetSource;
using System.Data;
using Newtonsoft.Json;

namespace GGFPortal.WEBAPI
{
    public class APITest : ApiController
    {
        GGFCubeDBEntities db = new GGFCubeDBEntities();
        // GET api/<controller>
        public string Get()
        {
            var xx = db.WebURL;
            string jjson = JsonConvert.SerializeObject(xx);
            return jjson;
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