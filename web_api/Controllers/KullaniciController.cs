using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api.Helpers;

namespace web_api.Controllers
{
    public class KullaniciController : ApiController
    {
        public IHttpActionResult login([FromBody] Models.kullanici kullanici)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "login", controller = "Kullanici", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });
            
            DataTable dt_kullanici = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0 AND sifre = " + kullanici.sifre);

            if(dt_kullanici.Rows.Count <= 0)
                return Ok(new islem() { action = "login", controller = "Kullanici", hata = true, mesaj = "Kullanıcı bulunamadı" });

            Models.kullanici kul = new Models.kullanici
            { 
                kullanici_id = Convert.ToInt32(dt_kullanici.Rows[0]["kullanici_id"]),
                ad = dt_kullanici.Rows[0]["ad"].ToString(),
                soyad = dt_kullanici.Rows[0]["soyad"].ToString()
            };

            islem<Models.kullanici> sonuc = new islem<Models.kullanici>()
            {
                action = "login",
                controller = "Kullanici",
                hata = false,
                mesaj = "",
                sonuc = kul
            };

            return Ok(sonuc);
        }
    }
}
