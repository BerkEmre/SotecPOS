using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class kullanici
    {
        public int kullanici_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string sifre { get; set; }
    }
}