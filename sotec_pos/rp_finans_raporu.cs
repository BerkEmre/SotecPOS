using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_finans_raporu : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_finans_raporu(DateTime ilk_tarih, DateTime son_tarih)
        {
            InitializeComponent();

            lbl_siparis_tarihi.Text = ilk_tarih.ToShortDateString() + " - " + son_tarih.ToShortDateString();

            DataTable dt = SQL.get("SELECT fh.kayit_tarihi, fh.miktar, p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND fh.kayit_tarihi BETWEEN '" + ilk_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND DATEADD(DAY, 0, '" + son_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')");
            this.DataSource = dt;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "kayit_tarihi", "");
            xrTableCell2.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "deger", "");
            xrTableCell4.DataBindings.Add(binding1);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:c2}");
            xrTableCell5.DataBindings.Add(binding3);
            XRBinding binding4 = new XRBinding("Text", this.DataSource, "miktar", "{0:c2}");
            xrTableCell8.DataBindings.Add(binding4);

            XRSummary sum1 = new XRSummary(SummaryRunning.Page, SummaryFunc.Sum, "{0:c2}");
            xrTableCell8.Summary = sum1;
        }
    }
}
