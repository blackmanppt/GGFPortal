using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class 計算函式
    {
        /// <summary>
        /// 當年第幾周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int 當年第幾週(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}