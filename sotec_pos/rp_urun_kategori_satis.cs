using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_urun_kategori_satis : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_urun_kategori_satis(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();

            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;
            DataTable dt = SQL.get("SELECT k.kategori_adi, tutar = ISNULL((SELECT SUM(ak.miktar * u.fiyat) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.kategori_id = k.kategori_id WHERE ak.silindi = 0 AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0) FROM kategoriler k " +
                " WHERE k.silindi = 0 AND k.ust_kategori_id != 0 AND k.menude_gosterilsin = 1 AND 0 != ISNULL((SELECT SUM(ak.miktar * u.fiyat) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.kategori_id = k.kategori_id WHERE ak.silindi = 0 AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0)");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "kategori_adi", "");
            tc_masa_grubu.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding1);

            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);
        }

    }
}
