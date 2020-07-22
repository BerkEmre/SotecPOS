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
    public partial class pos_masa_satis : Form
    {
        DataTable dt_secili;
        string text = "";

        int masa_id;
        int adisyon_id = 0;
        decimal toplam_tutar = 0;
        decimal odenen = 0;

        bool virgul = false;
        int virgulden_sonra_sifir = 0;

        public pos_masa_satis(int masa_id)
        {
            this.masa_id = masa_id;
            InitializeComponent();
        }

        private void pos_masa_satis_Load(object sender, EventArgs e)
        {
            try { text = System.IO.File.ReadAllText(@"printer_info.txt"); } catch { text = ""; }

            float x = (Convert.ToInt32(pnl_kok.Width) - Convert.ToInt32(pnl_center.Width)) / 2;
            float y = (Convert.ToInt32(pnl_kok.Height) - Convert.ToInt32(pnl_center.Height)) / 2;

            pnl_center.Location = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));
            
            dt_secili = new DataTable();
            dt_secili.Columns.Add("adisyon_kalem_id", typeof(Int32));
            dt_secili.Columns.Add("urun_adi", typeof(String));
            dt_secili.Columns.Add("miktar", typeof(Decimal));
            dt_secili.Columns.Add("ikram_miktar", typeof(Decimal));
            dt_secili.Columns.Add("tutar", typeof(Decimal));
            dt_secili.Columns.Add("fiyat", typeof(Decimal));
            dt_secili.Columns.Add("olcu_birimi", typeof(String));
            dt_secili.Columns.Add("menu", typeof(String));
            grid_odenecekler.DataSource = dt_secili;

            DataTable dt_masa = SQL.get("SELECT masa_adi, masa_id FROM masalar WHERE masa_id = " + masa_id);
            lbl_kullanici.Text = SQL.ad + " " + SQL.soyad;
            lbl_masa.Text = dt_masa.Rows[0]["masa_adi"].ToString();

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count != 0) {
                adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by (CASE ak.odendi WHEN 0 THEN 0 ELSE 1 END), (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            lbl_toplam.Text = toplam_tutar.ToString("c2");
            lbl_odenen.Text = odenen.ToString("c2");
            lbl_kalan.Text = (toplam_tutar - odenen).ToString("c2");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = 0;
            virgul = false;
            virgulden_sonra_sifir = 0; tb_miktar.Value = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "7");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "7");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "8");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "8");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "9");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "9");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "4");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "4");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "5");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "5");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "6");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "6");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "1");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "1");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "2");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "2");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "3");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "3");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                virgulden_sonra_sifir++;
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir));
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "0");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (virgul) virgul = false;
            else virgul = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 10;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 20;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 50;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 100;
        }

        private string kac_tane_sifir(int kac_tane)
        {
            string sifir = "";
            for (int i = 0; i < kac_tane; i++)
            {
                sifir += "0";
            }
            return sifir;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = (toplam_tutar - odenen);

            DataRow dr_secilen;
            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                dr_secilen = tv_adisyon.GetDataRow(i);
                if(dr_secilen["odendi"].ToString() == "0")
                {
                    for (int j = 0; j < dt_secili.Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dr_secilen["adisyon_kalem_id"]) == Convert.ToInt32(dt_secili.Rows[j]["adisyon_kalem_id"]))
                            continue;
                    }

                    DataRow dr = dt_secili.NewRow();
                    dr["adisyon_kalem_id"] = dr_secilen["adisyon_kalem_id"];
                    dr["urun_adi"] = dr_secilen["urun_adi"];
                    dr["miktar"] = dr_secilen["miktar"];
                    dr["ikram_miktar"] = dr_secilen["ikram_miktar"];
                    dr["tutar"] = dr_secilen["tutar"];
                    dr["fiyat"] = dr_secilen["fiyat"];
                    dr["olcu_birimi"] = dr_secilen["olcu_birimi"];
                    dr["menu"] = dr_secilen["menu"];
                    dt_secili.Rows.Add(dr);
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = (toplam_tutar - odenen) / 6;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = (toplam_tutar - odenen) / 5;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = (toplam_tutar - odenen) / 4;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = (toplam_tutar - odenen) / 3;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = (toplam_tutar - odenen) / 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_miktar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_miktar.Value - odenecek_tutar;
            }
            else
                odenecek_tutar = tb_miktar.Value;

            if(odenecek_tutar <= 0)
            {
                new mesaj("Ödenecek tutar bulunamadı!").ShowDialog();
                return;
            }

            DataTable dt_fh = SQL.get("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (25, " + odenecek_tutar.ToString().Replace(',', '.') + ", " + adisyon_id + "); SELECT SCOPE_IDENTITY();");

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count != 0)
            {
                for (int i = 0; i < dt_secili.Rows.Count; i++)
                {
                    SQL.set("UPDATE adisyon_kalem SET odendi = " + dt_fh.Rows[0][0] + ", odenen_miktar = odenen_miktar + " + dt_secili.Rows[i]["miktar"].ToString().Replace(',', '.') + " WHERE adisyon_kalem_id = " + dt_secili.Rows[i]["adisyon_kalem_id"]);
                }

                /*DialogResult dialogResult = MessageBox.Show("Ödeme çıktısı almak ister misiniz?", "Çıktı", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {*/
                    rp_odeme s = new rp_odeme(Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]), dt_secili, "NAKİT", odenecek_tutar);
                    ReportPrintTool printTool = new ReportPrintTool(s);
                    try { printTool.Print(text); } catch { printTool.Print(); }
                //}

                dt_secili.Rows.Clear();

                adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by (CASE ak.odendi WHEN 0 THEN 0 ELSE 1 END), (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            lbl_toplam.Text = toplam_tutar.ToString("c2");
            lbl_odenen.Text = odenen.ToString("c2");
            lbl_kalan.Text = (toplam_tutar - odenen).ToString("c2");

            //new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Para Üstü: " + para_ustu.ToString("c2"): "")).ShowDialog();
            tb_miktar.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_miktar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_miktar.Value - odenecek_tutar;

                new mesaj("Ödeme Alınmadı!\nKalan tutardan yüksek ödeme girdiniz!").ShowDialog();
                return;
            }
            else
                odenecek_tutar = tb_miktar.Value;

            if (odenecek_tutar <= 0)
            {
                new mesaj("Ödenecek tutar bulunamadı!").ShowDialog();
                return;
            }

            DataTable dt_fh = SQL.get("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (26, " + odenecek_tutar.ToString().Replace(',', '.') + ", " + adisyon_id + "); SELECT SCOPE_IDENTITY();");

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count != 0)
            {
                for (int i = 0; i < dt_secili.Rows.Count; i++)
                {
                    SQL.set("UPDATE adisyon_kalem SET odendi = " + dt_fh.Rows[0][0] + ", odenen_miktar = odenen_miktar + " + dt_secili.Rows[i]["miktar"].ToString().Replace(',', '.') + " WHERE adisyon_kalem_id = " + dt_secili.Rows[i]["adisyon_kalem_id"]);
                }
                /*DialogResult dialogResult = MessageBox.Show("Ödeme çıktısı almak ister misiniz?", "Çıktı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {*/
                    rp_odeme s = new rp_odeme(Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]), dt_secili, "KREDİ", odenecek_tutar);
                    ReportPrintTool printTool = new ReportPrintTool(s);
                    try { printTool.Print(text); } catch { printTool.Print(); }
                //}
                dt_secili.Rows.Clear();

                adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by (CASE ak.odendi WHEN 0 THEN 0 ELSE 1 END), (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            lbl_toplam.Text = toplam_tutar.ToString("c2");
            lbl_odenen.Text = odenen.ToString("c2");
            lbl_kalan.Text = (toplam_tutar - odenen).ToString("c2");

            //new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Para Üstü: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_miktar.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_miktar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_miktar.Value - odenecek_tutar;

                new mesaj("Ödeme Alınmadı!\nKalan tutardan yüksek ödeme girdiniz!").ShowDialog();
                return;
            }
            else
                odenecek_tutar = tb_miktar.Value;

            if (odenecek_tutar <= 0)
            {
                new mesaj("Ödenecek tutar bulunamadı!").ShowDialog();
                return;
            }

            DataTable dt_fh = SQL.get("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (27, " + odenecek_tutar.ToString().Replace(',', '.') + ", " + adisyon_id + "); SELECT SCOPE_IDENTITY();");

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count != 0)
            {
                for (int i = 0; i < dt_secili.Rows.Count; i++)
                {
                    SQL.set("UPDATE adisyon_kalem SET odendi = " + dt_fh.Rows[0][0] + ", odenen_miktar = odenen_miktar + " + dt_secili.Rows[i]["miktar"].ToString().Replace(',', '.') + " WHERE adisyon_kalem_id = " + dt_secili.Rows[i]["adisyon_kalem_id"]);
                }
                /*DialogResult dialogResult = MessageBox.Show("Ödeme çıktısı almak ister misiniz?", "Çıktı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {*/
                    rp_odeme s = new rp_odeme(Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]), dt_secili, "Y.FİŞİ", odenecek_tutar);
                    ReportPrintTool printTool = new ReportPrintTool(s);
                    try { printTool.Print(text); } catch { printTool.Print(); }
                //}
                dt_secili.Rows.Clear();

                adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by (CASE ak.odendi WHEN 0 THEN 0 ELSE 1 END), (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            lbl_toplam.Text = toplam_tutar.ToString("c2");
            lbl_odenen.Text = odenen.ToString("c2");
            lbl_kalan.Text = (toplam_tutar - odenen).ToString("c2");

            //new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Para Üstü: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_miktar.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_adisyon_Click(object sender, EventArgs e)
        {
            if (tv_adisyon.SelectedRowsCount <= 0)
                return;

            DataRow dr_secilen = tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0]);

            decimal odenecek_miktar = (Convert.ToDecimal(dr_secilen["miktar"]) - Convert.ToDecimal(dr_secilen["odenen_miktar"]));
            /*if(odenecek_miktar != 1)
            { 
                using (var form = new num_pad(odenecek_miktar))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        odenecek_miktar = form.tb_miktar.Value;
                    }
                }
            }*/

            if (odenecek_miktar > 1)
                odenecek_miktar = 1;
            
            if(odenecek_miktar > (Convert.ToDecimal(dr_secilen["miktar"]) - Convert.ToDecimal(dr_secilen["odenen_miktar"])))
                odenecek_miktar = (Convert.ToDecimal(dr_secilen["miktar"]) - Convert.ToDecimal(dr_secilen["odenen_miktar"]));

            if (odenecek_miktar == 0)
                return;


            if (dr_secilen["odendi"].ToString() != "0")
            {
                if(Convert.ToDecimal(dr_secilen["odenen_miktar"]) >= Convert.ToDecimal(dr_secilen["miktar"]))
                    return;
            }

            bool varmi = false;
            for (int i = 0; i < dt_secili.Rows.Count; i++)
            {
                if (Convert.ToInt32(dr_secilen["adisyon_kalem_id"]) == Convert.ToInt32(dt_secili.Rows[i]["adisyon_kalem_id"]))
                {
                    if ((Convert.ToDecimal(dt_secili.Rows[i]["miktar"]) + 1) >= (Convert.ToDecimal(dr_secilen["miktar"]) - Convert.ToDecimal(dr_secilen["odenen_miktar"])))
                        dt_secili.Rows[i]["miktar"] = (Convert.ToDecimal(dr_secilen["miktar"]) - Convert.ToDecimal(dr_secilen["odenen_miktar"]));
                    else
                        dt_secili.Rows[i]["miktar"] = Convert.ToDecimal(dt_secili.Rows[i]["miktar"]) + odenecek_miktar;
                    dt_secili.Rows[i]["tutar"] = (dr_secilen["menu"].ToString().Length == 0 ? (odenecek_miktar - Convert.ToDecimal(dr_secilen["ikram_miktar"])) * Convert.ToDecimal(dr_secilen["fiyat"]) : Convert.ToDecimal(dr_secilen["tutar"]));//(Convert.ToDecimal(dt_secili.Rows[i]["miktar"]) - Convert.ToDecimal(dt_secili.Rows[i]["ikram_miktar"])) * Convert.ToDecimal(dt_secili.Rows[i]["fiyat"]);
                    varmi = true;
                }
            }

            if(!varmi)
            {
                DataRow dr = dt_secili.NewRow();
                dr["adisyon_kalem_id"] = dr_secilen["adisyon_kalem_id"];
                dr["urun_adi"] = dr_secilen["urun_adi"];
                dr["miktar"] = odenecek_miktar;
                dr["ikram_miktar"] = dr_secilen["ikram_miktar"];
                dr["tutar"] = (dr_secilen["menu"].ToString().Length == 0 ? (odenecek_miktar - Convert.ToDecimal(dr_secilen["ikram_miktar"])) * Convert.ToDecimal(dr_secilen["fiyat"]): Convert.ToDecimal(dr_secilen["tutar"]));//dr_secilen["tutar"];
                dr["fiyat"] = dr_secilen["fiyat"];
                dr["olcu_birimi"] = dr_secilen["olcu_birimi"];
                dr["menu"] = dr_secilen["menu"];
                dt_secili.Rows.Add(dr);
            }
            
            
            decimal top_tutar = 0;
            for (int i = 0; i < tv_odenecekler.RowCount; i++)
            {
                top_tutar += Convert.ToDecimal(tv_odenecekler.GetDataRow(i)["tutar"]);
            }
            tb_miktar.Value = top_tutar;
        }

        private void grid_odenecekler_Click(object sender, EventArgs e)
        {
            if (tv_odenecekler.SelectedRowsCount <= 0)
                return;
            
            tv_odenecekler.DeleteRow(tv_odenecekler.GetSelectedRows()[0]);

            decimal top_tutar = 0;
            for (int i = 0; i < tv_odenecekler.RowCount; i++)
            {
                top_tutar += Convert.ToDecimal(tv_odenecekler.GetDataRow(i)["tutar"]);
            }
            tb_miktar.Value = top_tutar;
        }

        private void tv_adisyon_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            DataRow dr = tv_adisyon.GetDataRow(e.RowHandle);
            if (dr["odendi"].ToString() != "0")
            {
                if (Convert.ToDecimal(dr["odenen_miktar"]) >= Convert.ToDecimal(dr["miktar"]))
                    e.Item.AppearanceItem.Normal.BackColor = Color.Red;
                else
                    e.Item.AppearanceItem.Normal.BackColor = Color.Yellow;
            }
        }

        private void grid_odemeler_DoubleClick(object sender, EventArgs e)
        {
            if (tv_odemeler.SelectedRowsCount <= 0)
                return;

            pos_masa_satis_finans_sil_duzenle f = new pos_masa_satis_finans_sil_duzenle(Convert.ToInt32(tv_odemeler.GetDataRow(tv_odemeler.GetSelectedRows()[0])["finans_hareket_id"]));
            f.FormClosing += F_FormClosing;
            f.ShowDialog();
        }

        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);

            adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by (CASE ak.odendi WHEN 0 THEN 0 ELSE 1 END), (ak.miktar - ak.odenen_miktar) DESC");
            grid_adisyon.DataSource = dt_adisyon_kalem;

            DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
            toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

            DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
            odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

            DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
            grid_odemeler.DataSource = dt_odemeler;

            lbl_toplam.Text = toplam_tutar.ToString("c2");
            lbl_odenen.Text = odenen.ToString("c2");
            lbl_kalan.Text = (toplam_tutar - odenen).ToString("c2");

            tb_miktar.Value = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(tb_yuzde.Value <= 0)
            {
                new mesaj("Yüzde rakamı giriniz!").Show();
                return;
            }

            tb_miktar.Value = tb_miktar.Value / 100 * tb_yuzde.Value;
            tb_yuzde.Value = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_miktar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_miktar.Value - odenecek_tutar;

                new mesaj("İndirim Alınmadı!\nKalan tutardan yüksek indirim girdiniz!").ShowDialog();
                return;
            }
            else
                odenecek_tutar = tb_miktar.Value;

            if (odenecek_tutar <= 0)
            {
                new mesaj("İndirim yapılacak tutar bulunamadı!").ShowDialog();
                return;
            }

            DataTable dt_fh = SQL.get("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (59, " + odenecek_tutar.ToString().Replace(',', '.') + ", " + adisyon_id + "); SELECT SCOPE_IDENTITY();");

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count != 0)
            {
                for (int i = 0; i < dt_secili.Rows.Count; i++)
                {
                    SQL.set("UPDATE adisyon_kalem SET odendi = " + dt_fh.Rows[0][0] + ", odenen_miktar = odenen_miktar + " + dt_secili.Rows[i]["miktar"].ToString().Replace(',', '.') + " WHERE adisyon_kalem_id = " + dt_secili.Rows[i]["adisyon_kalem_id"]);
                }
                dt_secili.Rows.Clear();

                adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by (CASE ak.odendi WHEN 0 THEN 0 ELSE 1 END), (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            lbl_toplam.Text = toplam_tutar.ToString("c2");
            lbl_odenen.Text = odenen.ToString("c2");
            lbl_kalan.Text = (toplam_tutar - odenen).ToString("c2");

            //new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Kalan Tutar: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_miktar.Value = 0;
        }

        private void pnl_kok_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
