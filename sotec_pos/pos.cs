using DevExpress.XtraGrid.Views.Tile.ViewInfo;
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
    public partial class pos : Form
    {
        int secili_masa_kategori = 0;
        menu m;

        public pos(menu m)
        {
            InitializeComponent();

            this.m = m;
        }

        private void pos_Load(object sender, EventArgs e)
        {
            lbl_kullanici_adi.Text = SQL.ad + " " + SQL.soyad;

            DataTable dt_masalar_kategori = SQL.get("SELECT masa_kategori_id = 0, masa_kategori = 'HEPSİ', adet = 9999 UNION ALL SELECT masa_kategori_id, masa_kategori, adet = (SELECT COUNT(*) FROM masalar m WHERE m.silindi = 0 AND m.masa_kategori_id = mk.masa_kategori_id) FROM masalar_kategori mk WHERE mk.silindi = 0 ORDER by adet DESC");
            if (dt_masalar_kategori.Rows.Count <= 0)
            {
                new mesaj("Masa girmeden satış yapamazsınız!").ShowDialog();
                return;
            }
            grid_masa_kategori.DataSource = dt_masalar_kategori;

            DataTable dt_masalar = SQL.get("SELECT adisyon_alindi = ISNULL(a.adisyon_alindi, 0), odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 ORDER by m.masa_adi");
            if(dt_masalar.Rows.Count <= 0)
            {
                new mesaj("Masa girmeden satış yapamazsınız!").ShowDialog();
                return;
            }
            grid_masalar.DataSource = dt_masalar;

            DataTable dt_gun = SQL.get("SELECT * FROM gunler WHERE silindi = 0");
            if (dt_gun.Rows.Count <= 0)
            {
                new mesaj("Günü açmadan satış yapamazsınız!").ShowDialog();
                this.Close();
            }

            timer1.Start();
        }

        private void grid_masalar_Click(object sender, EventArgs e)
        {
            
        }

        private void P_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_masalar = SQL.get("SELECT adisyon_alindi = ISNULL(a.adisyon_alindi, 0), odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 ORDER by m.masa_adi");
            grid_masalar.DataSource = dt_masalar;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_masa_kategori_Click(object sender, EventArgs e)
        {
            secili_masa_kategori = Convert.ToInt32(tv_masa_kategori.GetDataRow(tv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"].ToString());

            DataTable dt_masalar = SQL.get("SELECT adisyon_alindi = ISNULL(a.adisyon_alindi, 0), odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 AND (" + secili_masa_kategori + " = 0 OR m.masa_kategori_id = " + secili_masa_kategori + ") ORDER by m.masa_adi");
            grid_masalar.DataSource = dt_masalar;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DataTable dt_masalar = SQL.get("SELECT odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 AND (" + secili_masa_kategori + " = 0 OR m.masa_kategori_id = " + secili_masa_kategori + ") ORDER by m.masa_adi");
            //grid_masalar.DataSource = dt_masalar;
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl == grid_masalar)
            {
                TileViewHitInfo hi = tv_masalar.CalcHitInfo(e.ControlMousePosition);
                if (hi.HitTest == DevExpress.XtraEditors.TileControlHitTest.Item)
                {
                    foreach (TileViewElementInfo elemInfo in hi.ItemInfo.Elements)
                    {
                        string val = "";
                        decimal top_tutar = 0, odenen = 0;

                        DataTable dt_adisyon = SQL.get("SELECT adisyon_id FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + tv_masalar.GetDataRow(hi.RowHandle)["masa_id"]);
                        if (dt_adisyon.Rows.Count > 0)
                        {
                            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id WHERE ak.silindi = 0 AND ak.odendi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                            for (int i = 0; i < dt_adisyon_kalem.Rows.Count; i++)
                            {
                                val += dt_adisyon_kalem.Rows[i]["urun_adi"].ToString() + " x " + Convert.ToDecimal(dt_adisyon_kalem.Rows[i]["miktar"]).ToString("n2") + " = " + Convert.ToDecimal(dt_adisyon_kalem.Rows[i]["tutar"]).ToString("c2") + "\n";
                            }

                            DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM(CASE ak.menu_id WHEN 0 THEN (ak.miktar - ak.ikram_miktar) * u.fiyat ELSE ak.fiyat END), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                            top_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);
                            DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                            odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);
                            val += "\n--------------------------------------------------------------------------------------\nTop: " + (top_tutar - odenen).ToString("c2");
                        }
                        /*if (elemInfo.TextBounds.Contains(e.ControlMousePosition))
                        {*/
                        e.Info = new DevExpress.Utils.ToolTipControlInfo(elemInfo, val);
                            /*break;
                        }*/
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            m.Close();
        }

        private void tv_masalar_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            DataRow dr = tv_masalar.GetDataRow(e.RowHandle);
            if(dr["acik_mi"].ToString() == "0")
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.LightGreen;
            }
            else
            {
                if (dr["odeme_sayisi"].ToString() != "0")
                {
                    e.Item.AppearanceItem.Normal.BackColor = Color.Yellow;
                }
                else
                {
                    if (dr["adisyon_alindi"].ToString() != "0")
                        e.Item.AppearanceItem.Normal.BackColor = Color.PaleTurquoise;
                    else
                        e.Item.AppearanceItem.Normal.BackColor = Color.Salmon;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(31))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            pos_gecmis p = new pos_gecmis();
            p.FormClosing += P_FormClosing1;
            p.ShowDialog();
        }

        private void P_FormClosing1(object sender, FormClosingEventArgs e)
        {
            DataTable dt_masalar = SQL.get("SELECT adisyon_alindi = ISNULL(a.adisyon_alindi, 0), odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 AND (" + secili_masa_kategori + " = 0 OR m.masa_kategori_id = " + secili_masa_kategori + ") ORDER by m.masa_adi");
            grid_masalar.DataSource = dt_masalar;
        }

        private void grid_masalar_DoubleClick(object sender, EventArgs e)
        {
            /*pos_masa p = new pos_masa(Convert.ToInt32(tv_masalar.GetDataRow(tv_masalar.GetSelectedRows()[0])["masa_id"].ToString()), this, m);
            p.FormClosing += P_FormClosing;
            p.ShowDialog();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt_masalar = SQL.get("SELECT adisyon_alindi = ISNULL(a.adisyon_alindi, 0), odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 AND (" + secili_masa_kategori + " = 0 OR m.masa_kategori_id = " + secili_masa_kategori + ") AND a.kapandi = 0 ORDER by m.masa_adi");
            grid_masalar.DataSource = dt_masalar;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt_masalar = SQL.get("SELECT adisyon_alindi = ISNULL(a.adisyon_alindi, 0), odeme_sayisi = (SELECT COUNT(*) FROM finans_hareket fh WHERE fh.silindi = 0 AND fh.hareket_tipi_parametre_id IN (25, 26, 27, 59) AND fh.referans_id = ISNULL(a.adisyon_id, 0)), m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END, sure = DATEDIFF(MINUTE, ISNULL(a.kayit_tarihi, GETDATE()), GETDATE()), kullanici = (SELECT TOP 1 k.ad + ' ' + k.soyad  FROM adisyon_kalem ak INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id WHERE ak.adisyon_id = a.adisyon_id) FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 AND (" + secili_masa_kategori + " = 0 OR m.masa_kategori_id = " + secili_masa_kategori + ") ORDER by m.masa_adi");
            grid_masalar.DataSource = dt_masalar;
        }

        private void btn_self_Click(object sender, EventArgs e)
        {
            pos_masa p = new pos_masa(0, this, m);
            p.FormClosing += P_FormClosing;
            p.ShowDialog();
        }

        private void btn_paket_servis_Click(object sender, EventArgs e)
        {
            pos_masa p = new pos_masa(-1, this, m);
            p.FormClosing += P_FormClosing;
            p.ShowDialog();
        }

        private void tv_masalar_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {

        }

        private void tv_masalar_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            pos_masa p = new pos_masa(Convert.ToInt32(tv_masalar.GetDataRow(tv_masalar.GetSelectedRows()[0])["masa_id"].ToString()), this, m);
            p.FormClosing += P_FormClosing;
            p.ShowDialog();
        }
    }
}
