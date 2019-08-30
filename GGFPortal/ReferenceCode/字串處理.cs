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


            return 多筆資料;
        }
        protected string[] SplitEnter(string strPur)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = strPur.Split(stringSeparators, StringSplitOptions.None);
            return lines;
        }
        public StringBuilder 逗點字串多筆資料搜尋(string strtext)
        {
            StringBuilder 多筆資料 = new StringBuilder("");
            string[] strtextarry = 切割逗點(strtext);
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
            return 多筆資料;
        }
        protected string[] 切割逗點(string str逗點)
        {
            string[] stringSeparators = new string[] { "," };
            string[] lines = str逗點.Split(stringSeparators, StringSplitOptions.None);
            return lines;
        }

        /// <summary>
        /// 產生字串：Str搜尋條件 like '%Str切割字串_1%' and Str搜尋條件 like '%Str切割字串_2%'
        /// </summary>
        /// <param name="Str搜尋條件"></param>
        /// <param name="Str切割字串"></param>
        /// <returns></returns>
        public StringBuilder 逗點字串模糊搜尋(string Str搜尋條件, string Str切割字串)
        {
            StringBuilder 多筆資料 = new StringBuilder("");
            string[] strtextarry = 切割逗點(Str切割字串);
            if (strtextarry.Length > 0)
            {
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (多筆資料.Length == 0)
                            多筆資料.AppendFormat(" {0} like '%{1}%'", Str搜尋條件, strtextarry[i].Trim());
                        else
                            多筆資料.AppendFormat(" and {0} like '%{1}%'", Str搜尋條件 , strtextarry[i].Trim());
                }
            }
            return 多筆資料;
        }
    }
}