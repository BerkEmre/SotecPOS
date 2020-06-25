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
    public class UrunlerController : ApiController
    {
        public IHttpActionResult urunler()
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "urunler", controller = "Urunler", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_urunler = SQL.get("SELECT u.urun_id, u.hedef_id, u.kategori_id, u.olcu_birimi_parametre_id, u.sira, u.urun_adi, u.barkod, u.stok_kodu, olcu_birimi = p.deger, kategori = k.kategori_adi, u.fiyat FROM urunler u INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id WHERE u.silindi = 0");
            Models.urun[] urun = new Models.urun[dt_urunler.Rows.Count];
            for (int i = 0; i < dt_urunler.Rows.Count; i++)
            {
                urun[i] = new Models.urun
                {
                    urun_id = Convert.ToInt32(dt_urunler.Rows[i]["urun_id"]),
                    hedef_id = Convert.ToInt32(dt_urunler.Rows[i]["hedef_id"]),
                    kategori_id = Convert.ToInt32(dt_urunler.Rows[i]["kategori_id"]),
                    olcu_birimi_parametre_id = Convert.ToInt32(dt_urunler.Rows[i]["olcu_birimi_parametre_id"]),
                    sira = Convert.ToInt32(dt_urunler.Rows[i]["sira"]),
                    urun_adi = dt_urunler.Rows[i]["urun_adi"].ToString(),
                    barkod = dt_urunler.Rows[i]["barkod"].ToString(),
                    stok_kodu = dt_urunler.Rows[i]["stok_kodu"].ToString(),
                    kategori = dt_urunler.Rows[i]["kategori"].ToString(),
                    olcu_birimi = dt_urunler.Rows[i]["olcu_birimi"].ToString(),
                    fiyat = Convert.ToDecimal(dt_urunler.Rows[i]["fiyat"])
                };
            }

            islem<List<Models.urun>> sonuc = new islem<List<Models.urun>>()
            {
                action = "urunler",
                controller = "Urunler",
                hata = false,
                mesaj = "",
                sonuc = urun.ToList()
            };

            return Ok(sonuc);
        }

        public IHttpActionResult urun([FromBody] Models.urun u)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "urun", controller = "Urunler", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_urunler = SQL.get("SELECT u.urun_id, u.hedef_id, u.kategori_id, u.olcu_birimi_parametre_id, u.sira, u.urun_adi, u.barkod, u.stok_kodu, olcu_birimi = p.deger, kategori = k.kategori_adi, u.fiyat FROM urunler u INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id WHERE u.silindi = 0 AND u.urun_id = " + u.urun_id);
            Models.urun urun = new Models.urun
            {
                urun_id = Convert.ToInt32(dt_urunler.Rows[0]["urun_id"]),
                hedef_id = Convert.ToInt32(dt_urunler.Rows[0]["hedef_id"]),
                kategori_id = Convert.ToInt32(dt_urunler.Rows[0]["kategori_id"]),
                olcu_birimi_parametre_id = Convert.ToInt32(dt_urunler.Rows[0]["olcu_birimi_parametre_id"]),
                sira = Convert.ToInt32(dt_urunler.Rows[0]["sira"]),
                urun_adi = dt_urunler.Rows[0]["urun_adi"].ToString(),
                barkod = dt_urunler.Rows[0]["barkod"].ToString(),
                stok_kodu = dt_urunler.Rows[0]["stok_kodu"].ToString(),
                kategori = dt_urunler.Rows[0]["kategori"].ToString(),
                olcu_birimi = dt_urunler.Rows[0]["olcu_birimi"].ToString(),
                fiyat = Convert.ToDecimal(dt_urunler.Rows[0]["fiyat"])
            };

            islem<Models.urun> sonuc = new islem<Models.urun>()
            {
                action = "urun",
                controller = "Urunler",
                hata = false,
                mesaj = "",
                sonuc = urun
            };

            return Ok(sonuc);
        }

        public IHttpActionResult altKategoriler()
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "altKategoriler", controller = "Urunler", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_urunler = SQL.get("SELECT k.kategori_id, k.kategori_adi, k.ust_kategori_id, ust_kategori_adi = ku.kategori_adi FROM kategoriler k INNER JOIN kategoriler ku ON ku.silindi = 0 AND ku.kategori_id = k.ust_kategori_id AND ku.menude_gosterilsin = 1 WHERE k.silindi = 0 AND k.ust_kategori_id != 0 AND k.menude_gosterilsin = 1 ORDER by ku.sira, k.sira");
            Models.urun_kategori[] urun_kategori = new Models.urun_kategori[dt_urunler.Rows.Count];
            for (int i = 0; i < dt_urunler.Rows.Count; i++)
            {
                urun_kategori[i] = new Models.urun_kategori
                {
                    kategori_id = Convert.ToInt32(dt_urunler.Rows[i]["kategori_id"]),
                    kategori_adi = dt_urunler.Rows[i]["kategori_adi"].ToString(),
                    ust_kategori_id = Convert.ToInt32(dt_urunler.Rows[i]["ust_kategori_id"]),
                    ust_kategori_adi = dt_urunler.Rows[i]["ust_kategori_adi"].ToString()
                };
            }

            islem<List<Models.urun_kategori>> sonuc = new islem<List<Models.urun_kategori>>()
            {
                action = "altKategoriler",
                controller = "Urunler",
                hata = false,
                mesaj = "",
                sonuc = urun_kategori.ToList()
            };

            return Ok(sonuc);
        }

        public IHttpActionResult fromKategoriID([FromBody] Models.urun_kategori u)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "urun", controller = "Urunler", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_urunler = SQL.get("SELECT u.urun_id, u.hedef_id, u.kategori_id, u.olcu_birimi_parametre_id, u.sira, u.urun_adi, u.barkod, u.stok_kodu, olcu_birimi = p.deger, kategori = k.kategori_adi, u.fiyat FROM urunler u INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id WHERE u.silindi = 0 AND (u.kategori_id = " + u.kategori_id + " OR " + u.kategori_id + " = 0) ORDER by sira");
            Models.urun[] urun = new Models.urun[dt_urunler.Rows.Count];

            for (int i = 0; i < dt_urunler.Rows.Count; i++)
            {
                urun[i] = new Models.urun
                {
                    urun_id = Convert.ToInt32(dt_urunler.Rows[i]["urun_id"]),
                    hedef_id = Convert.ToInt32(dt_urunler.Rows[i]["hedef_id"]),
                    kategori_id = Convert.ToInt32(dt_urunler.Rows[i]["kategori_id"]),
                    olcu_birimi_parametre_id = Convert.ToInt32(dt_urunler.Rows[i]["olcu_birimi_parametre_id"]),
                    sira = Convert.ToInt32(dt_urunler.Rows[i]["sira"]),
                    urun_adi = dt_urunler.Rows[i]["urun_adi"].ToString(),
                    barkod = dt_urunler.Rows[i]["barkod"].ToString(),
                    stok_kodu = dt_urunler.Rows[i]["stok_kodu"].ToString(),
                    kategori = dt_urunler.Rows[i]["kategori"].ToString(),
                    olcu_birimi = dt_urunler.Rows[i]["olcu_birimi"].ToString(),
                    fiyat = Convert.ToDecimal(dt_urunler.Rows[i]["fiyat"])
                };
            }

            islem<List<Models.urun>> sonuc = new islem<List<Models.urun>>()
            {
                action = "urun",
                controller = "Urunler",
                hata = false,
                mesaj = "",
                sonuc = urun.ToList()
            };

            return Ok(sonuc);
        }
    }
}
