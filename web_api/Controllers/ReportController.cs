using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_api.Helpers;
using DevExpress;

namespace web_api.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Raporlama";

            if (!SQL.baglanti_test())
                return RedirectToAction("Index", "Report", new { hata = "Bağlantı Sağlanamadı" });
            
            if (Session["kullanici_id"] != null)
                return RedirectToAction("Dashboard", "Report");

            return View();
        }

        public ActionResult girisYap(string sifre)
        {
            if(sifre.Length <= 0)
                return RedirectToAction("Index", "Report", new { hata = "Şifre Giriniz" });

            if (!SQL.baglanti_test())
                return RedirectToAction("Index", "Report", new { hata = "Bağlantı Sağlanamadı" });

            DataTable dt_kullanici = SQL.get("SELECT * FROM kullanicilar WHERE sifre = " + sifre);
            if (dt_kullanici.Rows.Count > 0)
            {
                DataTable dt_yetki = SQL.get("SELECT * FROM kullanicilar_yetki WHERE silindi = 0 AND yetki_id = 6 AND (kullanici_id = " + dt_kullanici.Rows[0]["kullanici_id"] + " OR '" + dt_kullanici.Rows[0]["ad"] + "' = 'ADMİN')");
                if(dt_yetki.Rows.Count > 0)
                {
                    Session.Add("kullanici_id", dt_kullanici.Rows[0]["kullanici_id"]);
                    Session.Add("ad_soyad", dt_kullanici.Rows[0]["ad"] + " " + dt_kullanici.Rows[0]["soyad"]);
                    return RedirectToAction("Dashboard", "Report");
                }
                else
                    return RedirectToAction("Index", "Report", new { hata = "Yetkiniz yok" });
            }
            else
                return RedirectToAction("Index", "Report", new { hata = "Kullanıcı Bulunamadı" });
        }

        public ActionResult cikisYap()
        {
            Session["kullanici_id"] = null;
            return RedirectToAction("Index", "Report");
        }

        public ActionResult Dashboard()
        {
            if (Session["kullanici_id"] == null)
                return RedirectToAction("Index", "Report");

            DataTable dt_gun = SQL.get("SELECT TOP 1 * FROM gunler ORDER by gun_id DESC");
            DataTable dt_gunluk_satis_nakit = SQL.get("SELECT tutar = FORMAT(ISNULL(SUM(miktar), 0), 'N2') FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 25 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_satis_kredi = SQL.get("SELECT tutar = FORMAT(ISNULL(SUM(miktar), 0), 'N2') FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 26 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_satis_yfisi = SQL.get("SELECT tutar = FORMAT(ISNULL(SUM(miktar), 0), 'N2') FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 27 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");

            DataTable dt_gunluk_urunler = SQL.get("SELECT adet = FORMAT(ISNULL(SUM(miktar), 0), 'N1') FROM adisyon_kalem WHERE silindi = 0 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_adisyon = SQL.get("SELECT adet = ISNULL(COUNT(*), 0) FROM (SELECT adisyon_id FROM adisyon_kalem WHERE silindi = 0 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC) GROUP by adisyon_id) as tbl");

            DataTable dt_gunluk_iptal = SQL.get("SELECT miktar = FORMAT(ISNULL(SUM(miktar), 0), 'N1') FROM adisyon_kalem WHERE silindi = 1 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_ikram = SQL.get("SELECT miktar = FORMAT(ISNULL(SUM(ikram_miktar), 0), 'N1') FROM adisyon_kalem WHERE silindi = 0 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");

            ViewBag.Title = "Genel Bakış";
            ViewBag.Nakit = dt_gunluk_satis_nakit.Rows[0]["tutar"];
            ViewBag.Kredi = dt_gunluk_satis_kredi.Rows[0]["tutar"];
            ViewBag.Yfisi = dt_gunluk_satis_yfisi.Rows[0]["tutar"];
            ViewBag.Urunler = dt_gunluk_urunler.Rows[0]["adet"];
            ViewBag.Adisyon = dt_gunluk_adisyon.Rows[0]["adet"];
            ViewBag.Iptal = dt_gunluk_iptal.Rows[0]["miktar"];
            ViewBag.Ikram = dt_gunluk_ikram.Rows[0]["miktar"];

            DataTable dt = SQL.get(
                "SELECT " +
                "    m.masa_id, " +
                "    m.masa_adi, " +
                "    mk.masa_kategori," +
                "    adisyon_id = ISNULL(a.adisyon_id, 0), " +
                "    tutar = FORMAT((SELECT SUM((ak.miktar - ak.ikram_miktar) * u.fiyat) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.adisyon_id = a.adisyon_id AND ak.silindi = 0), 'N2'), " +
                "    sure = DATEDIFF(MINUTE, a.kayit_tarihi, GETDATE()) " +
                "FROM " +
                "    masalar m " +
                "    INNER JOIN masalar_kategori mk ON mk.masa_kategori_id = m.masa_kategori_id" +
                "    LEFT OUTER JOIN adisyon a ON a.masa_id = m.masa_id AND a.silindi = 0 AND a.kapandi = 0 " +
                "WHERE " +
                "    m.silindi = 0 " +
                "ORDER by mk.masa_kategori, m.masa_adi");

            return View(dt);
        }

        public ActionResult toplamSatis(int gun_id = 0, string ilk_tarih = null, string son_tarih = null) {
            if (Session["kullanici_id"] != null)
                return RedirectToAction("Dashboard", "Report");

            return View();
        }
    }
}