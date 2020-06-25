using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class masa
    {
        public int masa_id { get; set; }
        public string masa_adi { get; set; }
        public int masa_kategori_id { get; set; }
        public int adisyon_alindi { get; set; }
        public int odeme_sayisi { get; set; }
        public int acik_mi { get; set; }
        public int sure { get; set; }
        public string kullanici { get; set; }
    }
}