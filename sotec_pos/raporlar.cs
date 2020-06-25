using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sotec_pos
{
    public partial class raporlar : Form
    {
        string text = "";

        public raporlar()
        {
            InitializeComponent();
        }

        private void btn_rapor_al_cari_hesap_ekstresi_Click(object sender, EventArgs e)
        {
            rp_cari_hesap_ekstresi s = new rp_cari_hesap_ekstresi(Convert.ToInt32(cmb_cari_cari_hesap_ekstresi.EditValue), uc_tarih_cari_hesap_ekstresi.ilk_tarih, uc_tarih_cari_hesap_ekstresi.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void printPreviewBarItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void raporlar_Load(object sender, EventArgs e)
        {
            try { text = System.IO.File.ReadAllText(@"printer_info.txt"); } catch { text = ""; }

            DataTable dt = SQL.get("SELECT c.cari_id, c.cari_adi, p.deger FROM cariler c INNER JOIN parametreler p ON p.parametre_id = c.cari_tipi_parametre_id WHERE c.silindi = 0");
            cmb_cari_cari_hesap_ekstresi.Properties.DataSource = dt;
            if (dt.Rows.Count > 0) cmb_cari_cari_hesap_ekstresi.EditValue = dt.Rows[0]["cari_id"];

            DataTable dt_urun = SQL.get("SELECT u.menu_aktif, u.stok_kodu, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, olcu_birimi = p.deger, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi, stok = ISNULL((SELECT SUM(uh.miktar) FROM urunler_hareket uh WHERE uh.silindi = 0 AND uh.urun_id = u.urun_id), 0.0000) FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
            cmb_urun_stok_hareket_raporu.Properties.DataSource = dt_urun;
            if (dt_urun.Rows.Count > 0) cmb_urun_stok_hareket_raporu.EditValue = dt_urun.Rows[0]["urun_id"];

            DataTable dt_masa = SQL.get("SELECT masa_id = 0, masa_adi = 'HEPSİ' UNION ALL SELECT masa_id, masa_adi FROM masalar WHERE silindi = 0");
            cmb_masa_satis_raporu.Properties.DataSource = dt_masa;
            if (dt_masa.Rows.Count > 0) cmb_masa_satis_raporu.EditValue = dt_masa.Rows[0]["masa_id"];

            DataTable gunler = SQL.get("SELECT TOP 100 * FROM gunler WHERE silindi = 1 ORDER by gun_id DESC");
            grid_gunler.DataSource = gunler;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            rp_stok_hareket_raporu s = new rp_stok_hareket_raporu(Convert.ToInt32(cmb_urun_stok_hareket_raporu.EditValue), uc_tarih_stok_hareket_raporu.ilk_tarih, uc_tarih_stok_hareket_raporu.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            rp_satis_raporu s = new rp_satis_raporu(Convert.ToInt32(cmb_masa_satis_raporu.EditValue), uc_tarih_satis_raporu.ilk_tarih, uc_tarih_satis_raporu.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            rp_finans_raporu s = new rp_finans_raporu(uc_tarih_sec1.ilk_tarih, uc_tarih_sec1.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            rp_adisyon_satis_raporu s = new rp_adisyon_satis_raporu(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            rp_masa_grubuna_gore_satislar s = new rp_masa_grubuna_gore_satislar(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            rp_masalara_gore_satislar s = new rp_masalara_gore_satislar(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            rp_personel_satis s = new rp_personel_satis(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            rp_urun_satislari s = new rp_urun_satislari(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            rp_urun_kategori_satis s = new rp_urun_kategori_satis(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            rp_ust_kategori_satis s = new rp_ust_kategori_satis(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            rp_personel_ikram s = new rp_personel_ikram(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            rp_personel_iptal s = new rp_personel_iptal(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            rp_adisyon_satis_raporu s1 = new rp_adisyon_satis_raporu(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s1.CreateDocument();
            rp_masa_grubuna_gore_satislar s2 = new rp_masa_grubuna_gore_satislar(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s2.CreateDocument();
            rp_masalara_gore_satislar s3 = new rp_masalara_gore_satislar(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s3.CreateDocument();
            rp_personel_satis s4 = new rp_personel_satis(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s4.CreateDocument();
            rp_urun_satislari s5 = new rp_urun_satislari(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s5.CreateDocument();
            rp_urun_kategori_satis s6 = new rp_urun_kategori_satis(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s6.CreateDocument();
            rp_ust_kategori_satis s7 = new rp_ust_kategori_satis(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s7.CreateDocument();
            rp_personel_ikram s8 = new rp_personel_ikram(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s8.CreateDocument();
            rp_personel_iptal s9 = new rp_personel_iptal(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s9.CreateDocument();

            ReportPrintTool printTool1 = new ReportPrintTool(s1);
            try { printTool1.Print(text); } catch { printTool1.Print(); }
            ReportPrintTool printTool2 = new ReportPrintTool(s2);
            try { printTool2.Print(text); } catch { printTool2.Print(); }
            ReportPrintTool printTool3 = new ReportPrintTool(s3);
            try { printTool3.Print(text); } catch { printTool3.Print(); }
            ReportPrintTool printTool4 = new ReportPrintTool(s4);
            try { printTool4.Print(text); } catch { printTool4.Print(); }
            ReportPrintTool printTool5 = new ReportPrintTool(s5);
            try { printTool5.Print(text); } catch { printTool5.Print(); }
            ReportPrintTool printTool6 = new ReportPrintTool(s6);
            try { printTool6.Print(text); } catch { printTool6.Print(); }
            ReportPrintTool printTool7 = new ReportPrintTool(s7);
            try { printTool7.Print(text); } catch { printTool7.Print(); }
            ReportPrintTool printTool8 = new ReportPrintTool(s8);
            try { printTool8.Print(text); } catch { printTool8.Print(); }
            ReportPrintTool printTool9 = new ReportPrintTool(s9);
            try { printTool9.Print(text); } catch { printTool9.Print(); }
        }

        private void grid_gunler_DoubleClick(object sender, EventArgs e)
        {
            if (gv_gunler.SelectedRowsCount <= 0)
                return;

            uc_tarih_sec2.ilk_tarih = uc_tarih_sec2.dt_ilk_tarih.DateTime = Convert.ToDateTime(gv_gunler.GetDataRow(gv_gunler.GetSelectedRows()[0])["baslangic_tarihi"]);
            uc_tarih_sec2.son_tarih = uc_tarih_sec2.dt_son_tarih.DateTime = Convert.ToDateTime(gv_gunler.GetDataRow(gv_gunler.GetSelectedRows()[0])["bitis_tarihi"]);
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            rp_personel_ikram_ozet s = new rp_personel_ikram_ozet(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            rp_personel_iptal_ozet s = new rp_personel_iptal_ozet(uc_tarih_sec2.ilk_tarih, uc_tarih_sec2.son_tarih);
            s.CreateDocument();
            dv_rapor.DocumentSource = s;
        }
    }
}
