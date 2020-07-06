using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_personel_ikram : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_personel_ikram(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();

            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;
            DataTable dt = SQL.get("SELECT ad_soyad = k.ad + ' ' + k.soyad, u.urun_adi, miktar = SUM(ak.ikram_miktar), tutar = SUM(ak.ikram_miktar * u.fiyat), p.deger FROM kullanicilar k LEFT OUTER JOIN adisyon_kalem ak ON ak.silindi = 0 AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "') AND ak.ikram != 0 AND ak.kaydeden_kullanici_id = k.kullanici_id INNER JOIN urunler u ON u.urun_id = ak.urun_id LEFT OUTER JOIN parametreler p ON p.parametre_id = ak.ikram " +
                " WHERE k.silindi = 0 " + 
                " GROUP by k.ad, k.soyad, u.urun_adi, p.deger");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "ad_soyad", "");
            lbl_personel.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "deger", "");
            lbl_deger.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            tc_urun.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:n2}");
            tc_miktar.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding4);

            XRBinding binding5 = new XRBinding("Text", this.DataSource, "miktar", "{0:c2}");
            tc_top_miktar.DataBindings.Add(binding5);
            XRSummary sum1 = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:c2}");
            tc_top_miktar.Summary = sum1;
            XRBinding binding6 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_top_tutar.DataBindings.Add(binding6);
            XRSummary sum2 = new XRSummary(SummaryRunning.Group, SummaryFunc.Sum, "{0:c2}");
            tc_top_tutar.Summary = sum2;

            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);

            GroupField groupField = new GroupField("ad_soyad");
            GroupHeader2.GroupFields.Add(groupField);
            GroupField groupField1 = new GroupField("deger");
            GroupHeader1.GroupFields.Add(groupField1);
            
        }
    }
}
