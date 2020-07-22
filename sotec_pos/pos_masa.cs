using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
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
    public partial class pos_masa : Form
    {
        pos p;
        menu m;

        int masa_id;
        string text = "";

        public pos_masa(int masa_id, pos p, menu m)
        {
            this.masa_id = masa_id;
            this.p = p;
            this.m = m;

            InitializeComponent();
        }

        private void pos_masa_Load(object sender, EventArgs e)
        {
            try { text = System.IO.File.ReadAllText(@"printer_info.txt"); } catch { text = ""; }

            DataTable dt_masa = SQL.get("SELECT masa_adi, masa_id FROM masalar WHERE masa_id = " + masa_id);
            lbl_kullanici.Text = SQL.ad + " " + SQL.soyad;
            switch (masa_id)
            {
                case -1: lbl_masa.Text = "PAKET SERVİS"; break;
                case 0: lbl_masa.Text = "SELF SERVİS"; break;
                default: lbl_masa.Text = dt_masa.Rows[0]["masa_adi"].ToString(); break;
            }
            //lbl_masa.Text = masa_id == 0 ? "SELF SERVİS" : dt_masa.Rows[0]["masa_adi"].ToString();

            DataTable dt_aresler = SQL.get("SELECT parametre_id = 1, deger = 'Adres'");
            cmb_adres.Properties.DataSource = dt_aresler;
            cmb_adres.EditValue = dt_aresler.Rows[0]["parametre_id"];

            if (masa_id == 0)//self servis
            {
                button6.Visible = button8.Visible = false;
                btn_nakit.Visible = btn_kredi.Visible = btn_yfisi.Visible = btn_indirim.Visible = tb_tutar.Visible = grid_odemeler.Visible = btn_top_fiyat.Visible = true;
                lbl_ad_soyad.Visible = tb_ad_soyad.Visible = true;

                DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
                if(dt_adisyon1.Rows.Count != 0)
                {
                    DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + dt_adisyon1.Rows[0]["adisyon_id"]);
                    grid_odemeler.DataSource = dt_odemeler;
                }
            }
            if (masa_id == -1)//paket servis
            {
                button6.Visible = button8.Visible = false;
                cmb_adres.Visible = btn_nakit.Visible = btn_kredi.Visible = btn_yfisi.Visible = btn_indirim.Visible = tb_tutar.Visible = grid_odemeler.Visible = btn_top_fiyat.Visible = btn_musteri_gecmisi.Visible = true;
                lbl_ad_soyad.Visible = tb_ad_soyad.Visible = lbl_telefon.Visible = tb_telefon.Visible = tb_adres.Visible = btn_kurye_sec.Visible = true;
                button5.Text = "Kuryeye Aktar";

                dt_aresler = SQL.get("SELECT parametre_id = 1, deger = 'Adres 1' UNION ALL SELECT parametre_id = 2, deger = 'Adres 2' UNION ALL SELECT parametre_id = 3, deger = 'Adres 3'");
                cmb_adres.Properties.DataSource = dt_aresler;
                cmb_adres.EditValue = dt_aresler.Rows[0]["parametre_id"];

                DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
                if (dt_adisyon1.Rows.Count != 0)
                {
                    DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + dt_adisyon1.Rows[0]["adisyon_id"]);
                    grid_odemeler.DataSource = dt_odemeler;
                }
            }

            DataTable dt_kategori = SQL.get("SELECT ust_kategori_adi = '', ust_kategori_id = 0, kategori_adi = 'Hepsi', kategori_id = 0, usira = -1, sira = -1 UNION ALL SELECT ust_kategori_adi = CAST(k1.sira AS NVARCHAR) + '-' + k1.kategori_adi, ust_kategori_id = k1.kategori_id, k2.kategori_adi, k2.kategori_id, usira = k1.sira, sira = k2.sira FROM kategoriler k1 INNER JOIN kategoriler k2 ON k2.ust_kategori_id = k1.kategori_id AND k2.silindi = 0 AND k2.menude_gosterilsin = 1 WHERE k1.silindi = 0 AND k1.menude_gosterilsin = 1 ORDER by usira, sira");
            grid_kategori.DataSource = dt_kategori;

            DataTable dt_urun = SQL.get("SELECT urun_adi, urun_id, fiyat, sira, sicak_satis FROM urunler WHERE silindi = 0 AND menu_aktif = 1 ORDER by sira");
            grid_urun.DataSource = dt_urun;

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id, kurye = ISNULL(k.ad, '') + ' ' + ISNULL(k.soyad, ''), a.ad_soyad, m.telefon, m.adres FROM adisyon a LEFT OUTER JOIN kullanicilar k ON k.kullanici_id = a.kurye_kullanici_id LEFT OUTER JOIN musteri m ON m.musteri_id = a.musteri_id WHERE a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
            {
                btn_adisyon.FlatAppearance.BorderColor = btn_adisyon.ForeColor = Color.GreenYellow;
                btn_adisyon.BackColor = Color.DimGray;
            }
            else
            {
                btn_adisyon.Text = "Adisyon Yazdır";
                btn_adisyon.FlatAppearance.BorderColor = btn_adisyon.ForeColor = Color.DimGray;
                btn_adisyon.BackColor = Color.GreenYellow;

                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.kayit_tarihi, ad_soyad = kl.ad + ' ' + kl.soyad, ak.adisyon_id ,u.hedef_id, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                if(dt_adisyon.Rows[0]["kurye"].ToString().Length > 2)
                {
                    btn_kurye_sec.Text = dt_adisyon.Rows[0]["kurye"].ToString();
                }
                if (dt_adisyon.Rows[0]["ad_soyad"].ToString().Length > 2)
                {
                    tb_ad_soyad.Text = dt_adisyon.Rows[0]["ad_soyad"].ToString();
                }
                if (dt_adisyon.Rows[0]["telefon"].ToString().Length > 2)
                {
                    tb_telefon.Text = dt_adisyon.Rows[0]["telefon"].ToString();
                }
                if (dt_adisyon.Rows[0]["adres"].ToString().Length > 2)
                {
                    tb_adres.Text = dt_adisyon.Rows[0]["adres"].ToString();
                }
            }

            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_kategori_Click(object sender, EventArgs e)
        {
            if (tv_kategori.SelectedRowsCount <= 0)
                return;

            int secili_kategori_id = Convert.ToInt32(tv_kategori.GetDataRow(tv_kategori.GetSelectedRows()[0])["kategori_id"]);

            DataTable dt_urun = SQL.get("SELECT urun_adi, urun_id, fiyat, sicak_satis, sira FROM urunler WHERE silindi = 0 AND menu_aktif = 1 AND (kategori_id = " + secili_kategori_id + " OR 0 = " + secili_kategori_id + ") ORDER by sira");
            grid_urun.DataSource = dt_urun;
        }

        private void grid_urun_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_adisyon_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if(dt_adisyon.Rows.Count == 0)
            {
                SQL.set("INSERT INTO adisyon (masa_id) VALUES (" + masa_id + ")");

                btn_adisyon.Text = "Adisyon Yazdır";
                btn_adisyon.FlatAppearance.BorderColor = btn_adisyon.ForeColor = Color.DimGray;
                btn_adisyon.BackColor = Color.GreenYellow;
            }
            else
            {
                musteri_kaydet();
                if (!paket_servis_olur_mu()) return;

                SQL.set("UPDATE adisyon SET adisyon_alindi = 1 WHERE adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);

                rp_adisyon s = new rp_adisyon(Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]));
                ReportPrintTool printTool = new ReportPrintTool(s);
                try { printTool.Print(text); } catch { printTool.Print(); }
            }
        }

        private void grid_adisyon_DoubleClick(object sender, EventArgs e)
        {
            if (tv_adisyon.SelectedRowsCount <= 0)
                return;
            
            if(Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["durum_parametre_id"]) == 51)
            {
                if (!(SQL.yetki_kontrol(30) || SQL.yetki_kontrol(15)))
                {
                    new mesaj("Yetkiniz Yok!").ShowDialog();
                    return;
                }
            }
            else
            {
                if (!SQL.yetki_kontrol(15))
                {
                    new mesaj("Yetkiniz Yok!").ShowDialog();
                    return;
                }
            }

            if(Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["odendi"]) != 0)
            {
                new mesaj("Ödenmiş kalem iptal edilemez!").Show();
                return;
            }

            pos_masa_urun_iptal p = new pos_masa_urun_iptal(Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["adisyon_kalem_id"]));
            p.FormClosing += P_FormClosing;
            p.Show();
        }

        private void P_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id, kurye = ISNULL(k.ad, '') + ' ' + ISNULL(k.soyad, '') FROM adisyon a LEFT OUTER JOIN kullanicilar k ON k.kullanici_id = a.kurye_kullanici_id WHERE a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = " + masa_id);

            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.kayit_tarihi, u.fiyat, ad_soyad = kl.ad + ' ' + kl.soyad, ak.adisyon_id ,u.hedef_id, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi");
            grid_adisyon.DataSource = dt_adisyon_kalem;

            if (dt_adisyon.Rows[0]["kurye"].ToString().Length > 2)
            {
                btn_kurye_sec.Text = dt_adisyon.Rows[0]["kurye"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(17))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
                return;

            if (tv_adisyon.SelectedRowsCount <= 0)
                return;
            
            pos_masa_urun_ikram p = new pos_masa_urun_ikram(Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["adisyon_kalem_id"]));
            p.FormClosing += P_FormClosing;
            p.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(14))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if(masa_id == -1)
            {
                DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
                if (dt_adisyon.Rows.Count == 0)
                    return;

                pos_masa_masa_aktar_birlestir m = new pos_masa_masa_aktar_birlestir(masa_id, 0);
                m.FormClosing += M_FormClosing;
                m.ShowDialog();
            }
            else
            {
                DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
                if (dt_adisyon.Rows.Count == 0)
                    return;

                int adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);

                decimal toplam_tutar = 0;
                decimal odenen = 0;
                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                if ((toplam_tutar - odenen) == 0)
                {
                    SQL.set("UPDATE adisyon SET kapandi = 1 WHERE adisyon_id = " + adisyon_id);
                    this.Close();
                }
                else
                {
                    using (var form = new pos_masa_masa_kapat("Masada ödenmemiş tutar bulunmakta,\nkapatmak istediğinizden emin misiniz ? "))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            SQL.set("UPDATE adisyon SET kapandi = 1, masa_kapat_parametre_id = " + form.cmb_ikram.EditValue + " WHERE adisyon_id = " + adisyon_id);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(13))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
                return;

            pos_masa_masa_aktar_birlestir m = new pos_masa_masa_aktar_birlestir(masa_id, 0);
            m.FormClosing += M_FormClosing;
            m.ShowDialog();
        }

        private void M_FormClosing(object sender, FormClosingEventArgs e)
        {
            new mesaj("Masa aktarıldı...").ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(16))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
                return;

            pos_masa_satis s = new pos_masa_satis(masa_id);
            s.FormClosing += P_FormClosing;
            s.ShowDialog();
        }

        private void tb_miktar_Click(object sender, EventArgs e)
        {
            using (var form = new num_pad())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tb_miktar.Value = form.tb_miktar.Value;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> hedef_ids = new List<int>();
            DataRow dr;
            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                dr = tv_adisyon.GetDataRow(i);
                
                if (Convert.ToInt32(dr["durum_parametre_id"]) == 51)
                {
                    DataTable dt_hedef = SQL.get("SELECT * FROM hedef WHERE hedef_id = " + dr["hedef_id"]);
                    if (Convert.ToInt32(dt_hedef.Rows[0]["hedefte_yazdir"]) == 1)
                    {
                        if(!hedef_ids.Exists(x => x == Convert.ToInt32(dr["hedef_id"])))
                        {
                            hedef_ids.Add(Convert.ToInt32(dr["hedef_id"]));
                            if (SQL.get("SELECT * FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + dr["hedef_id"] + " WHERE ak.silindi = 0 AND ak.durum_parametre_id = 51 AND ak.adisyon_id = " + dr["adisyon_id"]).Rows.Count > 0)
                            {
                                rp_hedefte_yazdir s = new rp_hedefte_yazdir(Convert.ToInt32(dr["adisyon_id"]), Convert.ToInt32(dr["hedef_id"]));
                                ReportPrintTool printTool = new ReportPrintTool(s);
                                try { printTool.Print(dt_hedef.Rows[0]["yazici"].ToString()); } catch { printTool.Print(); }
                                SQL.set("UPDATE adisyon_kalem SET durum_parametre_id = 55 WHERE adisyon_kalem_id IN (SELECT adisyon_kalem_id FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + dr["hedef_id"] + " WHERE ak.adisyon_id = " + dr["adisyon_id"] + " AND ak.silindi = 0)");
                            }
                        }
                    }
                    else
                    {
                        SQL.set("UPDATE adisyon_kalem SET durum_parametre_id = 54 WHERE adisyon_kalem_id = " + dr["adisyon_kalem_id"]);
                    }
                }
            }

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count <= 0) return;
            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.kayit_tarihi, u.fiyat, ad_soyad = kl.ad + ' ' + kl.soyad, ak.adisyon_id ,u.hedef_id, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi");
            grid_adisyon.DataSource = dt_adisyon_kalem;

            if(masa_id != 0 && masa_id != -1)
            {
                this.Close();
                p.Close();
                m.Close();
            }
        }

        private void tv_adisyon_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            DataRow dr = tv_adisyon.GetDataRow(e.RowHandle);
            if (dr["odendi"].ToString() != "0")
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.Red;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
                return;

            if (tv_adisyon.SelectedRowsCount <= 0)
                return;

            pos_masa_kalem_aciklama p = new pos_masa_kalem_aciklama(Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["adisyon_kalem_id"]));
            p.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);

            if (dt_adisyon.Rows.Count <= 0)
                return;

            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.kayit_tarihi, u.fiyat, ad_soyad = kl.ad + ' ' + kl.soyad, ak.adisyon_id ,u.hedef_id, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi");
            grid_adisyon.DataSource = dt_adisyon_kalem;
        }

        private void grid_urun_DoubleClick(object sender, EventArgs e)
        {
            if (tv_urun.SelectedRowsCount <= 0)
                return;

            if (tb_miktar.Value <= 0)
                return;

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
            {
                SQL.set("INSERT INTO adisyon (masa_id) VALUES (" + masa_id + ")");

                btn_adisyon.Text = "Adisyon Yazdır";
                btn_adisyon.FlatAppearance.BorderColor = btn_adisyon.ForeColor = Color.DimGray;
                btn_adisyon.BackColor = Color.GreenYellow;
            }

            dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            DataRow dr = tv_urun.GetFocusedDataRow();
            int adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
            int urun_id = Convert.ToInt32(dr["urun_id"]);
            int sicak_satis = Convert.ToInt32(dr["sicak_satis"]);
            if (sicak_satis == 1)
            {
                pos_masa_sicak_satis dlg = new pos_masa_sicak_satis(urun_id, adisyon_id, Convert.ToDecimal(tb_miktar.Value), 0, 0);
                dlg.FormClosing += P_FormClosing;
                dlg.ShowDialog();
            }
            else
            {
                SQL.set("INSERT INTO adisyon_kalem (adisyon_id, urun_id, miktar, kaydeden_kullanici_id) VALUES (" + adisyon_id + ", " + urun_id + ", " + tb_miktar.Value.ToString().Replace(',', '.') + ", " + SQL.kullanici_id + ")");
                SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + urun_id + ", 3, " + (tb_miktar.Value * -1).ToString().Replace(',', '.') + ", " + adisyon_id + ", 0.0000)");
            }

            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.kayit_tarihi, u.fiyat, ad_soyad = kl.ad + ' ' + kl.soyad, ak.adisyon_id ,u.hedef_id, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id LEFT OUTER JOIN kullanicilar kl ON kl.kullanici_id = ak.kaydeden_kullanici_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi");
            grid_adisyon.DataSource = dt_adisyon_kalem;

            tb_miktar.Value = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(13))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
                return;

            if (tv_adisyon.SelectedRowsCount <= 0)
                return;

            pos_masa_masa_aktar_birlestir m = new pos_masa_masa_aktar_birlestir(masa_id, Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["adisyon_kalem_id"]));
            m.FormClosing += M_FormClosing;
            m.ShowDialog();
        }

        private void btn_nakit_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon1.Rows.Count == 0)
            {
                new mesaj("Ödenecek ürün bulunamadı!").Show();
                return;
            }
            musteri_kaydet();
            if (!paket_servis_olur_mu()) return;

            int adisyon_id = Convert.ToInt32(dt_adisyon1.Rows[0]["adisyon_id"]);
            decimal toplam_tutar = 0;
            decimal odenen = 0;

            DataTable dt_secili = new DataTable();
            dt_secili.Columns.Add("adisyon_kalem_id", typeof(Int32));
            dt_secili.Columns.Add("urun_adi", typeof(String));
            dt_secili.Columns.Add("miktar", typeof(Decimal));
            dt_secili.Columns.Add("ikram_miktar", typeof(Decimal));
            dt_secili.Columns.Add("tutar", typeof(Decimal));
            dt_secili.Columns.Add("fiyat", typeof(Decimal));
            dt_secili.Columns.Add("olcu_birimi", typeof(String));

            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                toplam_tutar += Convert.ToDecimal(tv_adisyon.GetDataRow(i)["tutar"]);

                DataRow dr = dt_secili.NewRow();
                dr["adisyon_kalem_id"] = tv_adisyon.GetDataRow(i)["adisyon_kalem_id"];
                dr["urun_adi"] = tv_adisyon.GetDataRow(i)["urun_adi"];
                dr["miktar"] = tv_adisyon.GetDataRow(i)["miktar"];
                dr["ikram_miktar"] = tv_adisyon.GetDataRow(i)["ikram_miktar"];
                dr["tutar"] = tv_adisyon.GetDataRow(i)["tutar"];
                dr["fiyat"] = tv_adisyon.GetDataRow(i)["fiyat"];
                dr["olcu_birimi"] = tv_adisyon.GetDataRow(i)["olcu_birimi"];
                dt_secili.Rows.Add(dr);
            }
            for (int i = 0; i < tv_odemeler.RowCount; i++)
            {
                odenen += Convert.ToDecimal(tv_odemeler.GetDataRow(i)["miktar"]);
            }

            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_tutar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_tutar.Value - odenecek_tutar;
            }
            else
                odenecek_tutar = tb_tutar.Value;

            if (odenecek_tutar <= 0)
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
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi, (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = CASE ak.menu_id WHEN 0 THEN ISNULL(SUM((ak.miktar - ak.ikram_miktar) * u.fiyat), 0.0000) ELSE ak.fiyat END FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }
            new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Para Üstü: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_tutar.Value = 0;
        }

        private void btn_kredi_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon1.Rows.Count == 0)
            {
                new mesaj("Ödenecek ürün bulunamadı!").Show();
                return;
            }
            musteri_kaydet();
            if (!paket_servis_olur_mu()) return;

            int adisyon_id = Convert.ToInt32(dt_adisyon1.Rows[0]["adisyon_id"]);
            decimal toplam_tutar = 0;
            decimal odenen = 0;

            DataTable dt_secili = new DataTable();
            dt_secili.Columns.Add("adisyon_kalem_id", typeof(Int32));
            dt_secili.Columns.Add("urun_adi", typeof(String));
            dt_secili.Columns.Add("miktar", typeof(Decimal));
            dt_secili.Columns.Add("ikram_miktar", typeof(Decimal));
            dt_secili.Columns.Add("tutar", typeof(Decimal));
            dt_secili.Columns.Add("fiyat", typeof(Decimal));
            dt_secili.Columns.Add("olcu_birimi", typeof(String));

            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                toplam_tutar += Convert.ToDecimal(tv_adisyon.GetDataRow(i)["tutar"]);

                DataRow dr = dt_secili.NewRow();
                dr["adisyon_kalem_id"] = tv_adisyon.GetDataRow(i)["adisyon_kalem_id"];
                dr["urun_adi"] = tv_adisyon.GetDataRow(i)["urun_adi"];
                dr["miktar"] = tv_adisyon.GetDataRow(i)["miktar"];
                dr["ikram_miktar"] = tv_adisyon.GetDataRow(i)["ikram_miktar"];
                dr["tutar"] = tv_adisyon.GetDataRow(i)["tutar"];
                dr["fiyat"] = tv_adisyon.GetDataRow(i)["fiyat"];
                dr["olcu_birimi"] = tv_adisyon.GetDataRow(i)["olcu_birimi"];
                dt_secili.Rows.Add(dr);
            }
            for (int i = 0; i < tv_odemeler.RowCount; i++)
            {
                odenen += Convert.ToDecimal(tv_odemeler.GetDataRow(i)["miktar"]);
            }

            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_tutar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_tutar.Value - odenecek_tutar;

                new mesaj("Ödeme Alınmadı!\nKalan tutardan yüksek ödeme girdiniz!").ShowDialog();
                return;
            }
            else
                odenecek_tutar = tb_tutar.Value;

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
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi, (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = CASE ak.menu_id WHEN 0 THEN ISNULL(SUM((ak.miktar - ak.ikram_miktar) * u.fiyat), 0.0000) ELSE ak.fiyat END FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Para Üstü: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_tutar.Value = 0;
        }

        private void btn_yfisi_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon1.Rows.Count == 0)
            {
                new mesaj("Ödenecek ürün bulunamadı!").Show();
                return;
            }
            musteri_kaydet();
            if (!paket_servis_olur_mu()) return;

            int adisyon_id = Convert.ToInt32(dt_adisyon1.Rows[0]["adisyon_id"]);
            decimal toplam_tutar = 0;
            decimal odenen = 0;

            DataTable dt_secili = new DataTable();
            dt_secili.Columns.Add("adisyon_kalem_id", typeof(Int32));
            dt_secili.Columns.Add("urun_adi", typeof(String));
            dt_secili.Columns.Add("miktar", typeof(Decimal));
            dt_secili.Columns.Add("ikram_miktar", typeof(Decimal));
            dt_secili.Columns.Add("tutar", typeof(Decimal));
            dt_secili.Columns.Add("fiyat", typeof(Decimal));
            dt_secili.Columns.Add("olcu_birimi", typeof(String));

            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                toplam_tutar += Convert.ToDecimal(tv_adisyon.GetDataRow(i)["tutar"]);

                DataRow dr = dt_secili.NewRow();
                dr["adisyon_kalem_id"] = tv_adisyon.GetDataRow(i)["adisyon_kalem_id"];
                dr["urun_adi"] = tv_adisyon.GetDataRow(i)["urun_adi"];
                dr["miktar"] = tv_adisyon.GetDataRow(i)["miktar"];
                dr["ikram_miktar"] = tv_adisyon.GetDataRow(i)["ikram_miktar"];
                dr["tutar"] = tv_adisyon.GetDataRow(i)["tutar"];
                dr["fiyat"] = tv_adisyon.GetDataRow(i)["fiyat"];
                dr["olcu_birimi"] = tv_adisyon.GetDataRow(i)["olcu_birimi"];
                dt_secili.Rows.Add(dr);
            }
            for (int i = 0; i < tv_odemeler.RowCount; i++)
            {
                odenen += Convert.ToDecimal(tv_odemeler.GetDataRow(i)["miktar"]);
            }

            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_tutar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_tutar.Value - odenecek_tutar;

                new mesaj("Ödeme Alınmadı!\nKalan tutardan yüksek ödeme girdiniz!").ShowDialog();
                return;
            }
            else
                odenecek_tutar = tb_tutar.Value;

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
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi, (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = CASE ak.menu_id WHEN 0 THEN ISNULL(SUM((ak.miktar - ak.ikram_miktar) * u.fiyat), 0.0000) ELSE ak.fiyat END FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Para Üstü: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_tutar.Value = 0;
        }

        private void btn_indirim_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon1.Rows.Count == 0)
            {
                new mesaj("Ödenecek ürün bulunamadı!").Show();
                return;
            }
            musteri_kaydet();
            if (!paket_servis_olur_mu()) return;

            int adisyon_id = Convert.ToInt32(dt_adisyon1.Rows[0]["adisyon_id"]);
            decimal toplam_tutar = 0;
            decimal odenen = 0;

            DataTable dt_secili = new DataTable();
            dt_secili.Columns.Add("adisyon_kalem_id", typeof(Int32));
            dt_secili.Columns.Add("urun_adi", typeof(String));
            dt_secili.Columns.Add("miktar", typeof(Decimal));
            dt_secili.Columns.Add("ikram_miktar", typeof(Decimal));
            dt_secili.Columns.Add("tutar", typeof(Decimal));
            dt_secili.Columns.Add("fiyat", typeof(Decimal));
            dt_secili.Columns.Add("olcu_birimi", typeof(String));

            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                toplam_tutar += Convert.ToDecimal(tv_adisyon.GetDataRow(i)["tutar"]);

                DataRow dr = dt_secili.NewRow();
                dr["adisyon_kalem_id"] = tv_adisyon.GetDataRow(i)["adisyon_kalem_id"];
                dr["urun_adi"] = tv_adisyon.GetDataRow(i)["urun_adi"];
                dr["miktar"] = tv_adisyon.GetDataRow(i)["miktar"];
                dr["ikram_miktar"] = tv_adisyon.GetDataRow(i)["ikram_miktar"];
                dr["tutar"] = tv_adisyon.GetDataRow(i)["tutar"];
                dr["fiyat"] = tv_adisyon.GetDataRow(i)["fiyat"];
                dr["olcu_birimi"] = tv_adisyon.GetDataRow(i)["olcu_birimi"];
                dt_secili.Rows.Add(dr);
            }
            for (int i = 0; i < tv_odemeler.RowCount; i++)
            {
                odenen += Convert.ToDecimal(tv_odemeler.GetDataRow(i)["miktar"]);
            }

            decimal odenecek_tutar;
            decimal para_ustu = 0;
            if (tb_tutar.Value > (toplam_tutar - odenen))
            {
                odenecek_tutar = (toplam_tutar - odenen);
                para_ustu = tb_tutar.Value - odenecek_tutar;

                new mesaj("İndirim Alınmadı!\nKalan tutardan yüksek indirim girdiniz!").ShowDialog();
                return;
            }
            else
                odenecek_tutar = tb_tutar.Value;

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
                DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi, (ak.miktar - ak.odenen_miktar) DESC");
                grid_adisyon.DataSource = dt_adisyon_kalem;

                DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = CASE ak.menu_id WHEN 0 THEN ISNULL(SUM((ak.miktar - ak.ikram_miktar) * u.fiyat), 0.0000) ELSE ak.fiyat END FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                toplam_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);

                DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);

                DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
                grid_odemeler.DataSource = dt_odemeler;
            }

            new mesaj("Ödeme Alındı!\n" + (para_ustu > 0 ? "Kalan Tutar: " + para_ustu.ToString("c2") : "")).ShowDialog();
            tb_tutar.Value = 0;
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

            int adisyon_id = Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]);
            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.odenen_miktar, u.fiyat, ak.odendi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END, olcu_birimi = p.deger, mn.menu FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id LEFT OUTER JOIN menuler mn ON mn.menu_id = ak.menu_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"] + " ORDER by ak.odendi, (ak.miktar - ak.odenen_miktar) DESC");
            grid_adisyon.DataSource = dt_adisyon_kalem;
            
            DataTable dt_odemeler = SQL.get("SELECT fh.finans_hareket_id, fh.miktar, odeme_tipi = p.deger FROM finans_hareket fh INNER JOIN parametreler p ON p.parametre_id = fh.hareket_tipi_parametre_id WHERE fh.silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + adisyon_id);
            grid_odemeler.DataSource = dt_odemeler;
            
            tb_miktar.Value = 0;
        }

        private void btn_top_fiyat_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon1 = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon1.Rows.Count == 0)
            {
                new mesaj("Ödenecek ürün bulunamadı!").Show();
                return;
            }

            int adisyon_id = Convert.ToInt32(dt_adisyon1.Rows[0]["adisyon_id"]);
            decimal toplam_tutar = 0;
            decimal odenen = 0;

            for (int i = 0; i < tv_adisyon.RowCount; i++)
            {
                toplam_tutar += Convert.ToDecimal(tv_adisyon.GetDataRow(i)["tutar"]);
            }
            for (int i = 0; i < tv_odemeler.RowCount; i++)
            {
                odenen += Convert.ToDecimal(tv_odemeler.GetDataRow(i)["miktar"]);
            }

            decimal odenecek_tutar = (toplam_tutar - odenen);

            tb_tutar.Value = odenecek_tutar;
        }

        private void btn_kurye_sec_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
            {
                new mesaj("Lütfen önce adisyonu açın!").ShowDialog();
                return;
            }

            pos_masa_kurye_sec f = new pos_masa_kurye_sec(Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]));
            f.FormClosing += P_FormClosing;
            f.ShowDialog();
        }

        private void tb_telefon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataTable dt = SQL.get("SELECT * FROM musteri WHERE telefon = '" + tb_telefon.Text + "' AND silindi = 0");
                if(dt.Rows.Count <= 0)
                {
                    return;
                }

                tb_ad_soyad.Text = dt.Rows[0]["ad_soyad"].ToString();
                tb_adres.Text = dt.Rows[0]["adres"].ToString();
            }
        }

        private void musteri_kaydet()
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
            {
                new mesaj("Lütfen önce adisyonu açın!").ShowDialog();
                return;
            }

            int yeni_musteri_id = 0;

            if (tb_telefon.Text.Length > 3)
            {
                DataTable dt = SQL.get("SELECT * FROM musteri WHERE telefon = '" + tb_telefon.Text + "' AND silindi = 0");
                if (dt.Rows.Count <= 0)
                {
                    DataTable dt_m = SQL.get("INSERT INTO musteri (kaydeden_kullanici_id, ad_soyad, telefon, " + (cmb_adres.EditValue.ToString() == "1" ? "adres" : "adres_" + cmb_adres.EditValue.ToString()) + ") VALUES (" + SQL.kullanici_id + ", '" + tb_ad_soyad.Text + "', '" + tb_telefon.Text + "', '" + tb_adres.Text + "'); SELECT SCOPE_IDENTITY();");
                    yeni_musteri_id = Convert.ToInt32(dt_m.Rows[0][0]);
                }
                else
                {
                    if(tb_adres.Text.Length > 0)
                        SQL.set("UPDATE musteri SET ad_soyad = '" + tb_ad_soyad.Text + "', " + (cmb_adres.EditValue.ToString() == "1" ? "adres" : "adres_" + cmb_adres.EditValue.ToString()) + " = '" + tb_adres.Text + "' WHERE musteri_id = " + dt.Rows[0]["musteri_id"]);
                    yeni_musteri_id = Convert.ToInt32(dt.Rows[0]["musteri_id"]);
                }
            }

            SQL.set("UPDATE adisyon SET musteri_id = " + yeni_musteri_id + ", ad_soyad = '" + tb_ad_soyad.Text + "', adres = " + cmb_adres.EditValue + " WHERE adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
        }

        private bool paket_servis_olur_mu()
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id, kurye_kullanici_id, musteri_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
            {
                return false;
            }

            if (masa_id != -1)
                return true;

            if(dt_adisyon.Rows[0]["kurye_kullanici_id"].ToString() == "0")
            {
                new mesaj("Kurye seçiniz!").ShowDialog();
                return false;
            }

            if (dt_adisyon.Rows[0]["musteri_id"].ToString() == "0")
            {
                new mesaj("Adres giriniz!").ShowDialog();
                return false;
            }

            return true;
        }

        private void btn_musteri_gecmisi_Click(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM musteri WHERE telefon = '" + tb_telefon.Text + "'");
            if (dt.Rows.Count <= 0)
            {
                new mesaj("Müşteri bulunamadı...").ShowDialog();
                return;
            }

            musteri_gecmisi m = new musteri_gecmisi(Convert.ToInt32(dt.Rows[0]["musteri_id"]));
            m.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_adres_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM musteri WHERE telefon = '" + tb_telefon.Text + "'");
            if (dt.Rows.Count <= 0)
            {
                return;
            }

            tb_adres.Text = dt.Rows[0][(cmb_adres.EditValue.ToString() == "1" ? "adres" : "adres_" + cmb_adres.EditValue.ToString())].ToString();
        }

        private void tb_adres_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_adres_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void tb_adres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'")
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            if (dt_adisyon.Rows.Count == 0)
            {
                SQL.set("INSERT INTO adisyon (masa_id) VALUES (" + masa_id + ")");

                btn_adisyon.Text = "Adisyon Yazdır";
                btn_adisyon.FlatAppearance.BorderColor = btn_adisyon.ForeColor = Color.DimGray;
                btn_adisyon.BackColor = Color.GreenYellow;
            }
            
            dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            pos_masa_menu_sec p = new pos_masa_menu_sec(Convert.ToInt32(dt_adisyon.Rows[0]["adisyon_id"]));
            p.FormClosing += P_FormClosing;
            p.ShowDialog();
        }
    }
}
