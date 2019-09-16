using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GGFPortal.DataSetSource;

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
        public void 讀取多語資料(string Str程式)
        {
            var 譯名 = db.GGF多語對照表.Where(p => p.程式 == Str程式 );
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

    }
}