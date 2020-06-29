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
            DataTable dt_gunluk_satis_nakit = SQL.get("SELECT tutar = ROUND(ISNULL(SUM(miktar), 0), 2) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 25 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_satis_kredi = SQL.get("SELECT tutar = ROUND(ISNULL(SUM(miktar), 0), 2) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 26 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_satis_yfisi = SQL.get("SELECT tutar = ROUND(ISNULL(SUM(miktar), 0), 2) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 27 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");

            DataTable dt_gunluk_urunler = SQL.get("SELECT adet = ROUND(ISNULL(SUM(miktar), 0), 1) FROM adisyon_kalem WHERE silindi = 0 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_adisyon = SQL.get("SELECT adet = ISNULL(COUNT(*), 0) FROM (SELECT adisyon_id FROM adisyon_kalem WHERE silindi = 0 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC) GROUP by adisyon_id) as tbl");

            DataTable dt_gunluk_iptal = SQL.get("SELECT miktar = ROUND(ISNULL(SUM(miktar), 0), 1) FROM adisyon_kalem WHERE silindi = 1 AND durum_parametre_id != 51 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gunluk_ikram = SQL.get("SELECT miktar = ROUND(ISNULL(SUM(ikram_miktar), 0), 1) FROM adisyon_kalem WHERE silindi = 0 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
           
            DataTable dt_gg_nakit = SQL.get("SELECT tutar = ROUND(ISNULL(SUM(miktar), 0), 2) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 60 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");
            DataTable dt_gg_kredi = SQL.get("SELECT tutar = ROUND(ISNULL(SUM(miktar), 0), 2) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id = 61 AND kayit_tarihi >= (SELECT TOP 1 baslangic_tarihi FROM gunler ORDER by gun_id DESC)");

            ViewBag.Title = "Genel Bakış";
            ViewBag.Nakit = Convert.ToDecimal(dt_gunluk_satis_nakit.Rows[0]["tutar"]).ToString("n2");
            ViewBag.Kredi = Convert.ToDecimal(dt_gunluk_satis_kredi.Rows[0]["tutar"]).ToString("n2");
            ViewBag.Yfisi = Convert.ToDecimal(dt_gunluk_satis_yfisi.Rows[0]["tutar"]).ToString("n2");
            ViewBag.Urunler = Convert.ToDecimal(dt_gunluk_urunler.Rows[0]["adet"]).ToString("n0");
            ViewBag.Adisyon = Convert.ToDecimal(dt_gunluk_adisyon.Rows[0]["adet"]).ToString("n0");
            ViewBag.Iptal = Convert.ToDecimal(dt_gunluk_iptal.Rows[0]["miktar"]).ToString("n0");
            ViewBag.Ikram = Convert.ToDecimal(dt_gunluk_ikram.Rows[0]["miktar"]).ToString("n0");
            ViewBag.GG = (Convert.ToDecimal(dt_gg_nakit.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gg_kredi.Rows[0]["tutar"])).ToString("n2");
            ViewBag.Ciro = (Convert.ToDecimal(dt_gunluk_satis_nakit.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gunluk_satis_kredi.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gunluk_satis_yfisi.Rows[0]["tutar"])).ToString("n2");
            ViewBag.Net = (Convert.ToDecimal(dt_gunluk_satis_nakit.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gunluk_satis_kredi.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gunluk_satis_yfisi.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gg_nakit.Rows[0]["tutar"]) + Convert.ToDecimal(dt_gg_kredi.Rows[0]["tutar"])).ToString("n2");

            DataTable dt = SQL.get(
                "SELECT " +
                "    m.masa_id, " +
                "    m.masa_adi, " +
                "    mk.masa_kategori," +
                "    adisyon_id = ISNULL(a.adisyon_id, 0), " +
                "    tutar = " +
                "       ISNULL((SELECT SUM((ak.miktar - ak.ikram_miktar) * u.fiyat) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.silindi = 0 AND ak.adisyon_id = a.adisyon_id), 0.0000) " +
                "       - " +
                "       ISNULL((SELECT SUM(fh.miktar) FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN(25, 26, 27, 59) AND referans_id = a.adisyon_id), 0.0000), " +
                "    sure = DATEDIFF(MINUTE, a.kayit_tarihi, GETDATE()), " +
                "    acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END " +
                "FROM " +
                "    masalar m " +
                "    INNER JOIN masalar_kategori mk ON mk.masa_kategori_id = m.masa_kategori_id" +
                "    LEFT OUTER JOIN adisyon a ON a.masa_id = m.masa_id AND a.silindi = 0 AND a.kapandi = 0 " +
                "WHERE " +
                "    m.silindi = 0 " +
                "ORDER by acik_mi DESC, mk.masa_kategori, m.masa_adi");

            return View(dt);
        }

        public ActionResult toplamSatis(int gun_id = 0, string ilk_tarih = null, string son_tarih = null) {
            if (Session["kullanici_id"] == null)
                return RedirectToAction("Index", "Report");

            return View();
        }

        public ActionResult raporAl(int gun_id, string baslangic_tarihi, string bitis_tarihi, string rapor_tipi)
        {
            if (gun_id != 0 && (baslangic_tarihi == null || bitis_tarihi == null))
                return RedirectToAction("toplamSatis", "Report", new { hata = "Tarih girin!" });

            return RedirectToAction("toplamSatis", "Report", new { gun_id = gun_id, baslangic_tarihi = baslangic_tarihi, bitis_tarihi = bitis_tarihi, rapor_tipi = rapor_tipi });
        }
    }
}