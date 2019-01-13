using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace GGFPortal.test
{
    public partial class RegexTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string pattern = txtPattern.Text;
            string input = txtInput.Text;

            RegexOptions opt = new RegexOptions();
            opt = RegexOptions.IgnoreCase | RegexOptions.Multiline;
            Regex reg;

            try
            {
                reg = new Regex(pattern, opt);
                lb.Text = "Found " + reg.Matches(input).Count.ToString() + " match(es).<hr />";
                for (int i = 0; i < reg.Matches(input).Count; i++)
                {
                    Match match = reg.Matches(input)[i];
                    lb.Text += "Match[" + i.ToString() + "] as the following -<b r />";
                    for (int j = 0; j < match.Groups.Count; j++)
                    {
                        lb.Text += "Group[" + j.ToString() + "] = " +
                                   match.Groups[j].ToString() + "<b r />";
                    }
                    lb.Text += "<hr />";
                }
            }
            catch (Exception ex)
            {
                lb.Text = "Error: " + ex.Message;
            }
        }
    }
    
}