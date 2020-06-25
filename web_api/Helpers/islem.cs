using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Helpers
{
    public class islem
    {
        public string controller { get; set; }
        public string action { get; set; }
        public bool hata { get; set; }
        public string mesaj { get; set; }
    }
    public class islem<T> : islem
    {
        public T sonuc { get; set; }
    }
}