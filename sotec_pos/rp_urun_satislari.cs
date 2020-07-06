using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_urun_satislari : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_urun_satislari(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();

            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;
            DataTable dt = SQL.get(" SELECT " +
                                   "     u.urun_adi, " +
                                   "     tutar = ISNULL((SELECT SUM(ak.miktar) * u.fiyat FROM adisyon_kalem ak WHERE ak.silindi = 0 AND ak.urun_id = u.urun_id AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0) " +
                                   " FROM urunler u WHERE u.silindi = 0 AND u.menu_aktif = 1 AND 0 != ISNULL((SELECT SUM(ak.miktar) * u.fiyat FROM adisyon_kalem ak WHERE ak.silindi = 0 AND ak.urun_id = u.urun_id AND ak.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0) ");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            tc_masa_grubu.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding1);

            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);
        }

    }
}
