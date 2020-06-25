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
    public partial class urunler_receteli_uretim : Form
    {
        decimal katsayi = 1;
        int olcu_birimi_id = 0;
        public urunler_receteli_uretim()
        {
            InitializeComponent();
        }

        private void urunler_receteli_uretim_Load(object sender, EventArgs e)
        {
            DataTable dt_cinsiyet = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'olcu_birimi'");
            cmb_kaynak_birim.Properties.DataSource = dt_cinsiyet;
            cmb_kaynak_birim.EditValue = dt_cinsiyet.Rows[0]["parametre_id"];

            DataTable dt_kaynak = SQL.get("SELECT olcu_birimi = olcu.deger, olcu_birimi_id = olcu.parametre_id, miktar = 0.0000, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler olcu ON olcu.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 AND u.recete_malzemesi = 1 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
            if (dt_kaynak.Rows.Count <= 0)
            {
                new mesaj("Reçete malzemesi girmeden reçete giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            grid_kaynak.DataSource = dt_kaynak;
            DataTable dt_hedef = SQL.get("SELECT olcu_birimi = olcu.deger, miktar = 0.0000, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler olcu ON olcu.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 AND u.receteli_urun = 1 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
            if(dt_hedef.Rows.Count <= 0)
            {
                new mesaj("Reçeteli ürün girmeden reçete giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            cmb_hedef.Properties.DataSource = dt_hedef;
            cmb_hedef.EditValue = dt_hedef.Rows[0]["urun_id"];

            if(dt_hedef.Rows.Count > 0)
            {
                DataTable dt_recete = SQL.get("SELECT ur.recete_id, u.urun_id, u.urun_adi, ur.miktar, olcu_birimi = p.deger, olcu_birimi_id = p.parametre_id FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + cmb_hedef.EditValue);
                grid_recete.DataSource = dt_recete;
            }
        }

        private void cmb_hedef_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt_recete = SQL.get("SELECT ur.recete_id, u.urun_id, u.urun_adi, ur.miktar, olcu_birimi = p.deger, olcu_birimi_id = p.parametre_id FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + cmb_hedef.EditValue);
            grid_recete.DataSource = dt_recete;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(gv_kaynak.SelectedRowsCount <= 0)
            {
                new mesaj("Sarf ürünü seçin!").ShowDialog();
                return;
            }

            if(cmb_hedef.EditValue == null)
            {
                new mesaj("Reçete ürünü seçin!").ShowDialog();
                return;
            }

            if(tb_miktar.Value <= 0)
            {
                new mesaj("Miktar girin!").ShowDialog();
                return;
            }

            DataRow dr = gv_kaynak.GetDataRow(gv_kaynak.GetSelectedRows()[0]);
            DataRow dr_recete;
            bool guncellendimi = false;
            for (int i = 0; i < gv_recete.RowCount; i++)
            {
                dr_recete = gv_recete.GetDataRow(i);
                if(Convert.ToInt32(dr_recete["urun_id"]) == Convert.ToInt32(dr["urun_id"]))
                {
                    SQL.set("UPDATE urunler_recete SET miktar = " + tb_miktar.Value.ToString().Replace(',', '.') + " WHERE recete_id = " + dr_recete["recete_id"]);
                    guncellendimi = true;
                }
            }

            if(!guncellendimi)
            {
                SQL.set("INSERT INTO urunler_recete ([receteli_urun_id], [recete_urunu_id], [miktar]) VALUES (" + cmb_hedef.EditValue + ", " + dr["urun_id"] + ", " + tb_miktar.Value.ToString().Replace(',', '.') + ")");
            }
            DataTable dt_recete = SQL.get("SELECT ur.recete_id, u.urun_id, u.urun_adi, ur.miktar, olcu_birimi = p.deger, olcu_birimi_id = p.parametre_id FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + cmb_hedef.EditValue);
            grid_recete.DataSource = dt_recete;

            tb_miktar.Value = 0;
        }

        private void grid_recete_KeyDown(object sender, KeyEventArgs e)
        {
            if (gv_recete.SelectedRowsCount <= 0)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE urunler_recete SET silindi = 1 WHERE recete_id = " + gv_recete.GetDataRow(gv_recete.GetSelectedRows()[0])["recete_id"].ToString());

                    DataTable dt_recete = SQL.get("SELECT ur.recete_id, u.urun_id, u.urun_adi, ur.miktar, olcu_birimi = p.deger, olcu_birimi_id = p.parametre_id FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + cmb_hedef.EditValue);
                    grid_recete.DataSource = dt_recete;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_kaynak_Click(object sender, EventArgs e)
        {
            DataRow dr = gv_kaynak.GetFocusedDataRow();
            cmb_kaynak_birim.EditValue = dr["olcu_birimi_id"].ToString();
            lbl_hedef_birim.Text = dr["olcu_birimi"].ToString();
            tb_kaynak_birim.Value = tb_miktar.Value = 1;
            katsayi = 1;
            olcu_birimi_id = Convert.ToInt32(dr["olcu_birimi_id"]);
        }

        private void cmb_kaynak_birim_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM katsayi_donusum WHERE silindi = 0 AND parametre_1_id = " + cmb_kaynak_birim.EditValue + " AND parametre_2_id = " + olcu_birimi_id);
            if (dt.Rows.Count <= 0)
            {
                dt = SQL.get("SELECT * FROM katsayi_donusum WHERE silindi = 0 AND parametre_1_id = " + olcu_birimi_id + " AND parametre_2_id = " + cmb_kaynak_birim.EditValue);
                if(dt.Rows.Count <= 0)
                    katsayi = 1;
                else
                    katsayi = 1 / Convert.ToDecimal(dt.Rows[0]["katsayi"]);

            }
            else
                katsayi = Convert.ToDecimal(dt.Rows[0]["katsayi"]);

            tb_miktar.Value = tb_kaynak_birim.Value * katsayi;
        }

        private void tb_kaynak_birim_ValueChanged(object sender, EventArgs e)
        {
            tb_miktar.Value = tb_kaynak_birim.Value * katsayi;
        }
    }
}
