using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class 字串處理
    {
        public StringBuilder 字串多筆資料搜尋(string strtext)
        {
            StringBuilder 多筆資料 = new StringBuilder("");
            string[] strtextarry = SplitEnter(strtext);
            if (strtextarry.Length > 0)
            {
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (多筆資料.Length == 0)
                            多筆資料.AppendFormat("('{0}'", strtextarry[i].Trim());
                        else
                            多筆資料.AppendFormat(",'{0}'", strtextarry[i].Trim());
                }
                if (多筆資料.Length > 0)
                    多筆資料.Append(")");
            }
            else
            {

            }

            return 多筆資料;
        }
        protected string[] SplitEnter(string strPur)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = strPur.Split(stringSeparators, StringSplitOptions.None);
            return lines;
        }
    }
}