using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class adisyon
    {
        public DateTime kayit_tarihi { get; set; }
        public string ad_soyad { get; set; }
        public int adisyon_id { get; set; }
        public int hedef_id { get; set; }
        public int odendi { get; set; }
        public int adisyon_kalem_id { get; set; }
        public string urun_adi { get; set; }
        public decimal miktar { get; set; }
        public decimal ikram_miktar { get; set; }
        public decimal tutar { get; set; }
        public string olcu_birimi { get; set; }
        public int durum_parametre_id { get; set; }
        public string durum { get; set; }
    }
}