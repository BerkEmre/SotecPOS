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

            DataTable dt_stok_hareket = SQL.get("SELECT uh.kayit_tarihi, uh.miktar, tip = p.deger FROM urunler_hareket uh INNER JOIN parametreler p ON p.parametre_id = uh.hareket_tipi_parametre_id WHERE uh.silindi = 0 AND uh.urun_id = " + urun_id + " AND uh.kayit_tarihi BETWEEN '" + ilk_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND DATEADD(DAY, 0, '" + son_tarih.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')");
            this.DataSource = dt_stok_hareket;

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "kayit_tarihi", "");
            xrTableCell2.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "tip", "");
            xrTableCell4.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "miktar", "{0:0.##}");
            xrTableCell5.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Text", this.DataSource, "miktar", "{0:0.##}");
            xrTableCell8.DataBindings.Add(binding3);

            XRSummary sum1 = new XRSummary(SummaryRunning.Page, SummaryFunc.Sum, "{0:0.##}");
            xrTableCell8.Summary = sum1;
        }
    }
}
