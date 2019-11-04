using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GGFPortal.DataSetSource;
using Microsoft.Reporting.WebForms;

namespace GGFPortal.ReferenceCode
{
    public class Language
    {

    }
    
    public class 多語
    {
        MISEntities db = new MISEntities();
        private class 工廠資料
        {

        }
        public string 工段 { get; set; }
        //GGF多語對照表 gg = new GGF多語對照表();
        public List<GGF多語對照表> gg = new List<GGF多語對照表>();
        public void 讀取多語資料(string Str程式模組,string Str程式)
        {
            var 譯名 = db.GGF多語對照表.Where(p => p.程式 == Str程式 || p.程式 == Str程式模組);
            foreach (var item in 譯名)
            {
                gg.Add(new GGF多語對照表()
                {
                    id = item.id,
                    程式 = item.程式,
                    資料代號 = item.資料代號,
                    中文 = item.中文,
                    英文 = item.英文,
                    越文 = item.越文,
                    說明 = item.說明
                });
            }

        }
        public string 翻譯(string Str程式,string Str資料代號, string StrArea)
        {
            string Str翻譯="";
            switch (StrArea)
            {
                case "VGG":
                    Str翻譯 = gg.Find(p => p.程式 == Str程式 && p.資料代號 == Str資料代號).越文;
                    break;
                case "GAMA":
                    Str翻譯 = gg.Find(p => p.程式 == Str程式 && p.資料代號 == Str資料代號).英文;
                    break;
                case "TW":
                    Str翻譯 = gg.Find(p => p.程式 == Str程式 && p.資料代號 == Str資料代號).中文;
                    break;
                default:
                    break;
            }
            return Str翻譯;
        }
        
        public List<ReportParameter> 報表多語表頭 (string StrArea)
        {
            var 報表多語 = db.GGF多語對照表.Where(p => p.程式 == "ProductivityExcel");
            List<ReportParameter> lstParameter = new List<ReportParameter>();
            foreach (var item in 報表多語)
            {
                switch (StrArea)
                {
                    case "TW":
                        lstParameter.Add(new ReportParameter(item.資料代號, item.中文));
                        break;
                    case "GAMA":
                        lstParameter.Add(new ReportParameter(item.資料代號, item.英文));
                        break;
                    case "VGG":
                        lstParameter.Add(new ReportParameter(item.資料代號, item.越文));
                        break;
                    default:
                        break;
                }
            }
            return lstParameter;
        }
        

    }
}