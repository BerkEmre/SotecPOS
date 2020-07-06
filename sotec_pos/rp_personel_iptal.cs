using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_personel_iptal : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_personel_iptal(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();

            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;
            DataTable dt = SQL.get("SELECT ad_soyad = k.ad + ' ' + k.soyad, u.urun_adi, miktar = SUM(ak.miktar), tutar = SUM(ak.miktar * u.fiyat) FROM kullanicilar k LEFT OUTER JOIN adisyon_kalem ak ON ak.silindi = 1 AND ak.durum_parametre_id != 51 AND ak.kaydeden_kullanici_id = k.kullanici_id AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "') INNER JOIN urunler u ON u.urun_id = ak.urun_id " +
                " WHERE k.silindi = 0 GROUP by k.ad, k.soyad, u.urun_adi");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "ad_soyad", "");
            lbl_personel.DataBindings.Add(binding0);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            tc_urun.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:n2}");
            tc_miktar.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding4);

            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);

            GroupField groupField = new GroupField("ad_soyad");
            GroupHeader1.GroupFields.Add(groupField);
        }

    }
}
