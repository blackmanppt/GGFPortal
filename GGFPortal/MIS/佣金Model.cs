using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGFPortal.MIS
{
    public class 佣金Model
    {
        public string shp_nbr { get; set; }
        /// <summary>
        /// 外幣佣金
        /// </summary>
        public decimal commiss_amount { get; set; }
        /// <summary>
        /// 本幣佣金
        /// </summary>
        public decimal base_commiss_amount { get; set; }
        /// <summary>
        /// 佣金比率
        /// </summary>
        public decimal commiss_amt { get; set; }
    }
}