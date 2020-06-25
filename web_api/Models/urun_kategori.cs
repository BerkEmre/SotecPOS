using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models
{
    public class urun_kategori
    {
        public int kategori_id { get; set; }
        public int ust_kategori_id { get; set; }
        public string kategori_adi { get; set; }
        public string ust_kategori_adi { get; set; }
    }
}