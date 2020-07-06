using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_masa_grubuna_gore_satislar : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_masa_grubuna_gore_satislar(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();
            
            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;
            DataTable dt = SQL.get(" SELECT " +
                                   "     mk.masa_kategori, " +
                                   "     tutar = ISNULL((SELECT SUM(fh.miktar) FROM finans_hareket fh INNER JOIN adisyon a ON a.adisyon_id = fh.referans_id INNER JOIN masalar m ON m.masa_id = a.masa_id AND m.masa_kategori_id = mk.masa_kategori_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27) AND fh.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0) " +
                                   " FROM masalar_kategori mk " +
                                   " WHERE mk.silindi = 0 " +
                                   " AND 0 != ISNULL((SELECT SUM(fh.miktar) FROM finans_hareket fh INNER JOIN adisyon a ON a.adisyon_id = fh.referans_id INNER JOIN masalar m ON m.masa_id = a.masa_id AND m.masa_kategori_id = mk.masa_kategori_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27) AND fh.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0)");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "masa_kategori", "");
            tc_masa_grubu.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding1);

            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);
        }

    }
}
