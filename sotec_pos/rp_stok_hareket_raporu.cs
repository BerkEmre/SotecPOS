using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_stok_hareket_raporu : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_stok_hareket_raporu(int urun_id, DateTime ilk_tarih, DateTime son_tarih)
        {
            InitializeComponent();

            DataTable dt_urun = SQL.get("SELECT * FROM urunler WHERE urun_id = " + urun_id);

            lbl_urun_adi.Text = dt_urun.Rows[0]["urun_adi"].ToString();
            lbl_siparis_tarihi.Text = ilk_tarih.ToShortDateString() + " - " + son_tarih.ToShortDateString();

            DataTable dt_stok_hareket = SQL.get("SELECT uh.kayit_tarihi, uh.miktar, tip = p.deger, m.ad_soyad, m.telefon, kurye = kur.ad + ' ' + kur.soyad FROM urunler_hareket uh INNER JOIN parametreler p ON p.parametre_id = uh.hareket_tipi_parametre_id LEFT OUTER JOIN adisyon a ON uh.hareket_tipi_parametre_id = 3 AND a.adisyon_id = uh.referans_id LEFT OUTER JOIN musteri m ON m.musteri_id = a.musteri_id LEFT OUTER JOIN kullanicilar kur ON kur.kullanici_id = a.kurye_kullanici_id WHERE uh.silindi = 0 AND uh.urun_id = " + urun_id + " AND uh.kayit_tarihi BETWEEN '" + ilk_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND DATEADD(DAY, 0, '" + son_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "') ORDER by uh.kayit_tarihi");
            this.DataSource = dt_stok_hareket;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "kayit_tarihi", "");
            xrTableCell2.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "tip", "");
            xrTableCell4.DataBindings.Add(binding1);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "ad_soyad", "");
            xrTableCell12.DataBindings.Add(binding4);
            XRBinding binding5 = new XRBinding("Text", this.DataSource, "telefon", "");
            xrTableCell13.DataBindings.Add(binding5);
            XRBinding binding6 = new XRBinding("Text", this.DataSource, "kurye", "");
            xrTableCell14.DataBindings.Add(binding6);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "miktar", "{0:0.##}");
            xrTableCell5.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:0.##}");
            xrTableCell8.DataBindings.Add(binding3);

            XRSummary sum1 = new XRSummary(SummaryRunning.Report, SummaryFunc.Sum, "{0:0.##}");
            xrTableCell8.Summary = sum1;
        }
    }
}
