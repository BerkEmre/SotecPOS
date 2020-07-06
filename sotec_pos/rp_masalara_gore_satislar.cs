using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_masalara_gore_satislar : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_masalara_gore_satislar(DateTime tarih1, DateTime tarih2)
        {
            InitializeComponent();

            lbl_tarih.Text = tarih1.Day + "." + tarih1.Month + "." + tarih1.Year + "-" + tarih2.Day + "." + tarih2.Month + "." + tarih2.Year;
            DataTable dt = SQL.get(" SELECT " +
                                   "     m.masa_adi, " +
                                   "     tutar = ISNULL((SELECT SUM(fh.miktar) FROM finans_hareket fh INNER JOIN adisyon a ON a.adisyon_id = fh.referans_id AND a.masa_id = m.masa_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27) AND fh.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0) " +
                                   " FROM masalar m WHERE m.silindi = 0 AND 0 != ISNULL((SELECT SUM(fh.miktar) FROM finans_hareket fh INNER JOIN adisyon a ON a.adisyon_id = fh.referans_id AND a.masa_id = m.masa_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27) AND fh.kayit_tarihi BETWEEN '" + tarih1.ToString("yyyy-MM-dd HH:mm:00.000") + "' AND DATEADD(DAY, 0, '" + tarih2.ToString("yyyy-MM-dd HH:mm:00.000") + "')), 0)");

            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "masa_adi", "");
            tc_masa.DataBindings.Add(binding0);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "tutar", "{0:c2}");
            tc_tutar.DataBindings.Add(binding3);
            
            GroupField sortField = new GroupField("tutar");
            sortField.SortOrder = XRColumnSortOrder.Descending;
            this.Detail.SortFields.Add(sortField);
        }

    }
}
