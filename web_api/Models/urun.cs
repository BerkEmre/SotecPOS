using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class urun
    {
        public int urun_id { get; set; }
        public string urun_adi { get; set; }
        public int kategori_id { get; set; }
        public string kategori { get; set; }
        public decimal fiyat { get; set; }
        public string stok_kodu { get; set; }
        public string barkod { get; set; }
        public int olcu_birimi_parametre_id { get; set; }
        public string olcu_birimi { get; set; }
        public int hedef_id { get; set; }
        public int sira { get; set; }
    }
}