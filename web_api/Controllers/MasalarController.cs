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
    public class MasalarController : ApiController
    {
        // GET: api/Masalar
        public IHttpActionResult masalar()
        {
            if(!SQL.baglanti_test())
                return Ok(new islem() { action = "Get", controller = "Masalar", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });


            DataTable dt_masalar = SQL.get("SELECT * FROM masalar WHERE silindi = 0");
            Models.masa[] masa = new Models.masa[dt_masalar.Rows.Count];
            for (int i = 0; i < dt_masalar.Rows.Count; i++)
            {
                masa[i] = new Models.masa {
                    masa_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_id"]),
                    masa_adi = dt_masalar.Rows[i]["masa_adi"].ToString(),
                    masa_kategori_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_kategori_id"])
                };
            }

            islem<List<Models.masa>> sonuc = new islem<List<Models.masa>>()
            {
                action = "Get",
                controller = "Masalar",
                hata = false,
                mesaj = "",
                sonuc = masa.ToList()
            };
                
            return Ok(sonuc);
        }

        public IHttpActionResult kategoriler()
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "kategoriler", controller = "Masalar", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });
            
            DataTable dt_masalar = SQL.get("SELECT masa_kategori_id, masa_kategori, adet = (SELECT COUNT(*) FROM masalar m WHERE m.silindi = 0 AND m.masa_kategori_id = mk.masa_kategori_id) FROM masalar_kategori mk WHERE mk.silindi = 0 ORDER by adet DESC");
            Models.masa_kategori[] masa_kategori = new Models.masa_kategori[dt_masalar.Rows.Count];
            for (int i = 0; i < dt_masalar.Rows.Count; i++)
            {
                masa_kategori[i] = new Models.masa_kategori
                {
                    masa_kategori_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_kategori_id"]),
                    kategori = dt_masalar.Rows[i]["masa_kategori"].ToString()
                };
            }

            islem<List<Models.masa_kategori>> sonuc = new islem<List<Models.masa_kategori>>()
            {
                action = "kategoriler",
                controller = "Masalar",
                hata = false,
                mesaj = "",
                sonuc = masa_kategori.ToList()
            };

            return Ok(sonuc);
        }

        public IHttpActionResult kategori([FromBody] Models.masa_kategori ms)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "kategori", controller = "Masalar", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_masalar = SQL.get("SELECT * FROM masalar_kategori WHERE silindi = 0 AND masa_kategori_id = " + ms.masa_kategori_id);
            Models.masa_kategori[] masa_kategori = new Models.masa_kategori[dt_masalar.Rows.Count];
            for (int i = 0; i < dt_masalar.Rows.Count; i++)
            {
                masa_kategori[i] = new Models.masa_kategori
                {
                    masa_kategori_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_kategori_id"]),
                    kategori = dt_masalar.Rows[i]["masa_kategori"].ToString()
                };
            }

            islem<List<Models.masa_kategori>> sonuc = new islem<List<Models.masa_kategori>>()
            {
                action = "kategori",
                controller = "Masalar",
                hata = false,
                mesaj = "",
                sonuc = masa_kategori.ToList()
            };

            return Ok(sonuc);
        }

        public IHttpActionResult masa([FromBody] Models.masa ms)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "fromMasaID", controller = "Masalar", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_masalar = SQL.get("SELECT * FROM masalar WHERE silindi = 0 AND masa_id = " + ms.masa_id);
            Models.masa[] masa = new Models.masa[dt_masalar.Rows.Count];
            for (int i = 0; i < dt_masalar.Rows.Count; i++)
            {
                masa[i] = new Models.masa
                {
                    masa_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_id"]),
                    masa_adi = dt_masalar.Rows[i]["masa_adi"].ToString(),
                    masa_kategori_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_kategori_id"])
                };
            }

            islem<List<Models.masa>> sonuc = new islem<List<Models.masa>>()
            {
                action = "fromMasaID",
                controller = "Masalar",
                hata = false,
                mesaj = "",
                sonuc = masa.ToList()
            };

            return Ok(sonuc);
        }

        public IHttpActionResult fromMasaKategoriID([FromBody] Models.masa_kategori ms)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "fromMasaKategoriID", controller = "Masalar", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_masalar = SQL.get(
                "SELECT " +
                "   adisyon_alindi = ISNULL(a.adisyon_alindi, 0), " +
                "   odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), " +
                "   m.masa_id, " +
                "   m.masa_adi, " +
                "   m.masa_kategori_id, " +
                "   acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, " +
                "   sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), " +
                "   kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) " +
                "FROM " +
                "   masalar m " +
                "   LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id " +
                "WHERE " +
                "   m.silindi = 0  " +
                "   AND (m.masa_kategori_id = " + ms.masa_kategori_id + " OR " + ms.masa_kategori_id + " = 0) " +
                "ORDER by m.masa_adi");

            Models.masa[] masa = new Models.masa[dt_masalar.Rows.Count];
            for (int i = 0; i < dt_masalar.Rows.Count; i++)
            {
                masa[i] = new Models.masa
                {
                    masa_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_id"]),
                    masa_adi = dt_masalar.Rows[i]["masa_adi"].ToString(),
                    masa_kategori_id = Convert.ToInt32(dt_masalar.Rows[i]["masa_kategori_id"]),
                    acik_mi = Convert.ToInt32(dt_masalar.Rows[i]["acik_mi"]),
                    adisyon_alindi = Convert.ToInt32(dt_masalar.Rows[i]["adisyon_alindi"]),
                    odeme_sayisi = Convert.ToInt32(dt_masalar.Rows[i]["odeme_sayisi"]),
                    sure = Convert.ToInt32(dt_masalar.Rows[i]["sure"]),
                    kullanici = dt_masalar.Rows[i]["kullanici"].ToString()
                };
            }

            islem<List<Models.masa>> sonuc = new islem<List<Models.masa>>()
            {
                action = "fromMasaKategoriID",
                controller = "Masalar",
                hata = false,
                mesaj = "",
                sonuc = masa.ToList()
            };

            return Ok(sonuc);
        }

        public IHttpActionResult adisyon([FromBody] Models.masa ms)
        {
            if (!SQL.baglanti_test())
                return Ok(new islem() { action = "adisyon", controller = "Masalar", hata = true, mesaj = "SQL ile bağlantı sağlanamadı" });

            DataTable dt_masalar = SQL.get(
                "SELECT " +
                "    ak.kayit_tarihi, " +
                "    ad_soyad = kl.ad + ' ' + kl.soyad, " +
                "    ak.adisyon_id, " +
                "    u.hedef_id, " +
                "    ak.odendi, " +
                "    ak.adisyon_kalem_id, " +
                "    u.urun_adi, " +
                "    ak.miktar, " +
                "    ak.ikram_miktar, " +
                "    tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, " +
                "    olcu_birimi = p.deger, " +
                "    ak.durum_parametre_id, " +
                "    durum = dr.deger " +
                "FROM " +
                "    adisyon a " +
                "    INNER JOIN adisyon_kalem ak ON ak.adisyon_id = a.adisyon_id " +
                "    INNER JOIN urunler u ON u.urun_id = ak.urun_id " +
                "    INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id " +
                "    INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id " +
                "    LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id " +
                "WHERE " +
                "    ak.silindi = 0 " +
                "    AND a.silindi = 0 " +
                "    AND a.kapandi = 0 " +
                "    AND a.masa_id = " + ms.masa_id + " " +
                "ORDER by ak.odendi");

            Models.adisyon[] masa = new Models.adisyon[dt_masalar.Rows.Count];
            for (int i = 0; i < dt_masalar.Rows.Count; i++)
            {
                masa[i] = new Models.adisyon
                {
                    kayit_tarihi = Convert.ToDateTime(dt_masalar.Rows[i]["kayit_tarihi"]),
                    ad_soyad = dt_masalar.Rows[i]["ad_soyad"].ToString(),
                    adisyon_id = Convert.ToInt32(dt_masalar.Rows[i]["adisyon_id"]),
                    hedef_id = Convert.ToInt32(dt_masalar.Rows[i]["hedef_id"]),
                    odendi = Convert.ToInt32(dt_masalar.Rows[i]["odendi"]),
                    adisyon_kalem_id = Convert.ToInt32(dt_masalar.Rows[i]["adisyon_kalem_id"]),
                    urun_adi = dt_masalar.Rows[i]["urun_adi"].ToString(),
                    miktar = Convert.ToDecimal(dt_masalar.Rows[i]["miktar"]),
                    ikram_miktar = Convert.ToDecimal(dt_masalar.Rows[i]["ikram_miktar"]),
                    tutar = Convert.ToDecimal(dt_masalar.Rows[i]["tutar"]),
                    olcu_birimi = dt_masalar.Rows[i]["olcu_birimi"].ToString(),
                    durum_parametre_id = Convert.ToInt32(dt_masalar.Rows[i]["durum_parametre_id"]),
                    durum = dt_masalar.Rows[i]["durum"].ToString()
                };
            }

            islem<List<Models.adisyon>> sonuc = new islem<List<Models.adisyon>>()
            {
                action = "adisyon",
                controller = "Masalar",
                hata = false,
                mesaj = "",
                sonuc = masa.ToList()
            };

            return Ok(sonuc);
        }
    }
}
