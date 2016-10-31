using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class StringConvert
    {
        //將換行資料放入舉陣內
        public string SplitArray(string strtext, string strwhere, string strType)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] strtextarry = strtext.Split(stringSeparators, StringSplitOptions.None);
            if (strtextarry.Length > 1)
            {
                string strIn = string.Format(" and {0} in ( ", strType);
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (i == 0)
                            strIn += string.Format(" '{0}' ", strtextarry[i].Trim());
                        else
                            strIn += string.Format(" ,'{0}' ", strtextarry[i].Trim());
                }
                strIn += " ) ";
                strwhere += strIn;
            }
            else
                strwhere += string.Format(" and {0} = '{1}' ", strType, strtext);
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
        public string GetSQLString(string strTableName)
        {
            string strSql;
            strSql = " select * from " + strTableName;
            return strSql;
        }
    }
}