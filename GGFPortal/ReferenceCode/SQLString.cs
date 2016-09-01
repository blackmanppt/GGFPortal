using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class StringConvert
    {
        public string SplitArray(string strtext, string strwhere, string strType)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] strtextarry = strtext.Split(stringSeparators, StringSplitOptions.None);
            if (strtextarry.Length > 1)
            {
                string strIn = " and " + strType + " in ( ";
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (i == 0)
                            strIn += " '" + strtextarry[i].Trim() + "' ";
                        else
                            strIn += " ,'" + strtextarry[i].Trim() + "' ";
                }
                strIn += " ) ";
                strwhere += strIn;
            }
            else
                strwhere += " and " + strType + " = '" + strtext + "' ";
            return strwhere;
        }
        public string GetDateString(string strtext)
        {
            string[] words = strtext.Split('/');
            string rstr = "";
            foreach (string s in words)
            {
                rstr = (s.Length < 2) ? rstr + "0" + s : rstr + s;
            }
            return rstr;
        }
    }
}