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
    public partial class hedef : Form
    {
        public hedef()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hedef_Load(object sender, EventArgs e)
        {
            DataTable dt_hedef = SQL.get("SELECT * FROM hedef WHERE silindi = 0");
            if (dt_hedef.Rows.Count > 0)
                cmb_hedef.Properties.DataSource = dt_hedef;
            else
            {
                new mesaj("Hedef girmeden, ürün tanımlayamazsınız!").ShowDialog();
                this.Close();
            }
            cmb_hedef.EditValue = dt_hedef.Rows[0]["hedef_id"];

            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (54, 55)");
            grid_adisyon.DataSource = dt_adisyon_kalem;
            DataTable dt_adisyon_kalem_2 = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (56)");
            gridControl1.DataSource = dt_adisyon_kalem_2;
        }

        private void cmb_hedef_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (54, 55)");
            grid_adisyon.DataSource = dt_adisyon_kalem;
            DataTable dt_adisyon_kalem_2 = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (56)");
            gridControl1.DataSource = dt_adisyon_kalem_2;
        }

        private void grid_adisyon_Click(object sender, EventArgs e)
        {
            if (tv_adisyon.SelectedRowsCount <= 0)
                return;

            richTextBox1.Text = tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["aciklama"].ToString();
            lbl_urun.Text = tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["urun_adi"].ToString();
            lbl_masa.Text = tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["masa_adi"].ToString();
        }

        private void grid_adisyon_DoubleClick(object sender, EventArgs e)
        {
            if (tv_adisyon.SelectedRowsCount <= 0)
                return;
            if (Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["durum_parametre_id"]) == 54)
                SQL.set("UPDATE adisyon_kalem SET durum_parametre_id = 55 WHERE adisyon_kalem_id = " + tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["adisyon_kalem_id"]);
            if (Convert.ToInt32(tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["durum_parametre_id"]) == 55)
                SQL.set("UPDATE adisyon_kalem SET durum_parametre_id = 56 WHERE adisyon_kalem_id = " + tv_adisyon.GetDataRow(tv_adisyon.GetSelectedRows()[0])["adisyon_kalem_id"]);

            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (54, 55)");
            grid_adisyon.DataSource = dt_adisyon_kalem;
            DataTable dt_adisyon_kalem_2 = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (56)");
            gridControl1.DataSource = dt_adisyon_kalem_2;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (tileView1.SelectedRowsCount <= 0)
                return;
            SQL.set("UPDATE adisyon_kalem SET durum_parametre_id = 55 WHERE adisyon_kalem_id = " + tileView1.GetDataRow(tileView1.GetSelectedRows()[0])["adisyon_kalem_id"]);

            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (54, 55)");
            grid_adisyon.DataSource = dt_adisyon_kalem;
            DataTable dt_adisyon_kalem_2 = SQL.get("SELECT ak.aciklama, m.masa_adi, ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id AND u.hedef_id = " + cmb_hedef.EditValue + " INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id AND a.kapandi = 0 INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE ak.silindi = 0 AND ak.durum_parametre_id IN (56)");
            gridControl1.DataSource = dt_adisyon_kalem_2;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (tileView1.SelectedRowsCount <= 0)
                return;

            richTextBox1.Text = tileView1.GetDataRow(tileView1.GetSelectedRows()[0])["aciklama"].ToString();
            lbl_urun.Text = tileView1.GetDataRow(tileView1.GetSelectedRows()[0])["urun_adi"].ToString();
            lbl_masa.Text = tileView1.GetDataRow(tileView1.GetSelectedRows()[0])["masa_adi"].ToString();
        }
    }
}
