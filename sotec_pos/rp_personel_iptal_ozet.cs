using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_personel_iptal_ozet : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_personel_iptal_ozet(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();
            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;

            DataTable dt = SQL.get("SELECT * FROM(SELECT ad_soyad = k.ad + ' ' + k.soyad, tutar = (SELECT SUM(ak.miktar * u.fiyat) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 1 AND ak.durum_parametre_id != 51 AND ak.kaydeden_kullanici_id = k.kullanici_id AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')) FROM kullanicilar k WHERE k.silindi = 0) tbl WHERE tbl.tutar != 0");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "ad_soyad", "");
            tc_urun.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "tutar", "{0:n2}");
            tc_tutar.DataBindings.Add(binding1);

            XRBinding binding6 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_top_tutar.DataBindings.Add(binding6);
            XRSummary sum2 = new XRSummary(SummaryRunning.Page, SummaryFunc.Sum, "{0:c2}");
            tc_top_tutar.Summary = sum2;

            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);
        }

    }
}
