using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using GGFPortal.test.LINQ;
using GGFPortal.DataSetSource;


namespace GGFPortal.test.LINQ
{
    public partial class Linqtest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //using (View出口大表 data=new View出口大表())
            //{
            //    var result=from xx in data.
            //}


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int[] source = new int[] { 0, -5, 12, -67,9,111,4 };
            List<int> results = new List<int>();

            StringBuilder strtext = new StringBuilder();
            foreach (var item in source)
            {
                if (item > 0)
                    results.Add(item);
                //strtext.AppendFormat("{0} <br/>",item);
            }
            Comparison<int> comparison = delegate (int a, int b)
             {
                 return b - a;
             };
            results.Sort(comparison);
            foreach (var item in results)
            {
                strtext.AppendFormat("{0} <br/>",item);
            }
            Literal1.Text = strtext.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int[] source = new int[] { 0, -5, 12, -67, 9, 111, 4 };
            StringBuilder strtext = new StringBuilder();
            var result = from i in source
                         where i > 0
                         orderby i descending
                         select i;
            var result2 = from x in source
                          where x> 2 && x < 100
                          orderby x descending
                          select x;
            foreach (var item in result2)
            {
                strtext.AppendFormat("{0} <br/>", item);
            }
            Literal1.Text = strtext.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //using (acr_trnd xx =new acr_trnd())
            //{
            //    var result = from x in xx
            //                 where acr_nbr > 1
            //                 select x;e
            //}
            using (TestGroupEntities xx = new TestGroupEntities())
            {
                //DataClasses1DataContext tx = new DataClasses1DataContext();
                //var tt = from QQ in tx.acr_trn
                //         where QQ.style_no.Contains( "")
                //         select QQ;
            }

        }
    }
}