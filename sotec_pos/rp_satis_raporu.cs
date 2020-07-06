using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_satis_raporu : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_satis_raporu(int masa_id, DateTime ilk_tarih, DateTime son_tarih)
        {
            InitializeComponent();

            lbl_siparis_tarihi.Text = ilk_tarih.ToShortDateString() + " - " + son_tarih.ToShortDateString();

            DataTable dt = SQL.get("SELECT fh.kayit_tarihi, fh.miktar, p.deger, m.masa_adi FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id INNER JOIN adisyon a ON a.adisyon_id = fh.referans_id INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27) AND (m.masa_id = " + masa_id + " OR " + masa_id + " = 0) AND fh.kayit_tarihi BETWEEN '" + ilk_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND DATEADD(DAY, 0, '" + son_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')");
            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "kayit_tarihi", "");
            xrTableCell4.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "deger", "");
            xrTableCell5.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "masa_adi", "");
            xrTableCell6.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:c2}");
            xrTableCell7.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "miktar", "{0:c2}");
            xrTableCell12.DataBindings.Add(binding4);

            XRSummary sum1 = new XRSummary(SummaryRunning.Page, SummaryFunc.Sum, "{0:c2}");
            xrTableCell12.Summary = sum1;
        }
    }
}
