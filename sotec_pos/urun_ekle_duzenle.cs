using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sotec_pos
{
    public partial class urun_ekle_duzenle : Form
    {
        int urun_id;
        
        string tasinacakDosya = "", tasinacakDosyaIsmi = "", dosyaninTasinacagiKlasor = "";

        public urun_ekle_duzenle(int urun_id)
        {
            this.urun_id = urun_id;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void urun_ekle_duzenle_Load(object sender, EventArgs e)
        {
            DataTable dt_cinsiyet = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'olcu_birimi'");
            cmb_olcu_birimi.Properties.DataSource = dt_cinsiyet;
            cmb_olcu_birimi.EditValue = dt_cinsiyet.Rows[0]["parametre_id"];

            DataTable dt_hedef = SQL.get("SELECT * FROM hedef WHERE silindi = 0");
            if (dt_hedef.Rows.Count > 0)
                cmb_hedef.Properties.DataSource = dt_hedef;
            else
            {
                new mesaj("Hedef girmeden, ürün tanımlayamazsınız!").ShowDialog();
                this.Close();
            }
            cmb_hedef.EditValue = dt_hedef.Rows[0]["hedef_id"];

            DataTable dt = SQL.get("SELECT k.kategori_id, ust_kategori_adi = uk.kategori_adi, k.kategori_adi FROM kategoriler k INNER JOIN kategoriler uk ON k.ust_kategori_id = uk.kategori_id AND uk.silindi = 0 WHERE k.silindi = 0");
            cmb_kategori_id.Properties.DataSource = dt;
            if(dt.Rows.Count > 0)
                cmb_kategori_id.EditValue = dt.Rows[0]["kategori_id"];
            else
            {
                new mesaj("Kategori girmeden, ürün tanımlayamazsınız!").ShowDialog();
                this.Close();
            }

            DataTable kdv = SQL.get("SELECT kdv = 0 UNION ALL SELECT kdv = 1 UNION ALL SELECT kdv = 8 UNION ALL SELECT kdv = 18");
            cmb_kdv.Properties.DataSource = kdv;
            cmb_kdv.EditValue = kdv.Rows[0]["kdv"];

            if(urun_id != 0)
            {
                DataTable dt_urun = SQL.get("SELECT * FROM urunler WHERE urun_id = " + urun_id);
                tb_urun_adi.Text = dt_urun.Rows[0]["urun_adi"].ToString();
                cmb_kategori_id.EditValue = dt_urun.Rows[0]["kategori_id"];
                tb_fiyat.Value = Convert.ToDecimal(dt_urun.Rows[0]["fiyat"]);
                pb_resim.ImageLocation = "urun_resimleri/" + dt_urun.Rows[0]["resim"].ToString();
                tb_stok_kodu.Text = dt_urun.Rows[0]["stok_kodu"].ToString();
                tb_barkod.Text = dt_urun.Rows[0]["barkod"].ToString();
                cmb_olcu_birimi.EditValue = dt_urun.Rows[0]["olcu_birimi_parametre_id"];
                tb_min_stok.Value = Convert.ToDecimal(dt_urun.Rows[0]["minimum_stok"]);
                tb_max_stok.Value = Convert.ToDecimal(dt_urun.Rows[0]["maksimum_stok"]);
                tb_alis_fiyat.Value = Convert.ToDecimal(dt_urun.Rows[0]["alis_fiyat"]);
                cb_menude_goster.Checked = Convert.ToInt32(dt_urun.Rows[0]["menu_aktif"]) == 1 ? true : false;
                cb_receteli.Checked = Convert.ToInt32(dt_urun.Rows[0]["receteli_urun"]) == 1 ? true : false;
                cb_recete_malzemesi.Checked = Convert.ToInt32(dt_urun.Rows[0]["recete_malzemesi"]) == 1 ? true : false;
                cmb_kdv.EditValue = Convert.ToDecimal(dt_urun.Rows[0]["kdv"]);
                cmb_hedef.EditValue = Convert.ToDecimal(dt_urun.Rows[0]["hedef_id"]);
                tb_sira.Value = Convert.ToDecimal(dt_urun.Rows[0]["sira"]);
                cb_sicak_satis.Checked = Convert.ToInt32(dt_urun.Rows[0]["sicak_satis"]) == 1 ? true : false;

                btn_log_out.Text = "Düzenle";
            }
        }

        private void cb_receteli_CheckedChanged(object sender, EventArgs e)
        {
            cb_sicak_satis.Enabled = cb_receteli.Checked;
            if (!cb_receteli.Checked) cb_sicak_satis.Checked = false;
        }

        private void btn_resim_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Resim Dosyası (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pb_resim.ImageLocation = of.FileName;

                tasinacakDosyaIsmi = of.SafeFileName.ToString();
                tasinacakDosya = of.FileName.ToString();
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(tb_urun_adi.Text.Length <= 0)
            {
                new mesaj("Ürün Adı giriniz!").ShowDialog();
                return;
            }

            if(tb_fiyat.Value <= 0)
            {
                new mesaj("Satış fiyatı giriniz!").ShowDialog();
                return;
            }

            if (Convert.ToInt32(SQL.get("SELECT COUNT(*) FROM urunler WHERE silindi = 0 AND barkod = '" + tb_barkod.Text + "' AND urun_id != " + urun_id).Rows[0][0]) != 0 && tb_barkod.Text != "")
            {
                new mesaj("Barkod başka üründe kullanılmaktadır!").ShowDialog();
                return;
            }

            if (Convert.ToInt32(SQL.get("SELECT COUNT(*) FROM urunler WHERE silindi = 0 AND stok_kodu = '" + tb_stok_kodu.Text + "' AND urun_id != " + urun_id).Rows[0][0]) != 0 && tb_stok_kodu.Text != "")
            {
                new mesaj("Stok Kodu başka üründe kullanılmaktadır!").ShowDialog();
                return;
            }

            Random rand = new Random(DateTime.Now.Second);
            string random = rand.Next(0, 99999999).ToString() + "-" + rand.Next(0, 99999999).ToString();
            if (tasinacakDosya.Length > 0)
            {
                if (!Directory.Exists("urun_resimleri"))
                    Directory.CreateDirectory("urun_resimleri");

                dosyaninTasinacagiKlasor = "urun_resimleri";
                if (!File.Exists(dosyaninTasinacagiKlasor + @"\" + tasinacakDosyaIsmi))
                    File.Copy(tasinacakDosya, dosyaninTasinacagiKlasor + @"\" + random + ".png");
            }


            if (urun_id == 0)
                SQL.set("INSERT INTO urunler (urun_adi, kategori_id, fiyat, resim, [stok_kodu], [barkod], [olcu_birimi_parametre_id], [minimum_stok], [maksimum_stok], [alis_fiyat], [menu_aktif], receteli_urun, recete_malzemesi, kdv, hedef_id, sira, sicak_satis) " +
                    " VALUES ('" + tb_urun_adi.Text + "', " + cmb_kategori_id.EditValue + ", " + tb_fiyat.Value.ToString().Replace(',', '.') + ", '" + random + ".png" + "', '" + tb_stok_kodu.Text + "', " +
                    "'" + tb_barkod.Text + "', " + cmb_olcu_birimi.EditValue + ", " + tb_min_stok.Value.ToString().Replace(',', '.') + ", " + tb_max_stok.Value.ToString().Replace(',', '.') + ", " +
                    " " + tb_alis_fiyat.Value.ToString().Replace(',', '.') + ", " + (cb_menude_goster.Checked ? "1" : "0") + ", " + (cb_receteli.Checked ? "1" : "0") + ", " + (cb_recete_malzemesi.Checked ? "1" : "0") + ", " +
                    " " + cmb_kdv.EditValue.ToString().Replace(',', '.') + ", " + cmb_hedef.EditValue + ", " + tb_sira.Value.ToString().Replace(',', '.') + ", " + (cb_sicak_satis.Checked ? "1" : "0") + " )");
            else
                SQL.set("UPDATE urunler SET " +
                    "urun_adi = '" + tb_urun_adi.Text + "', " +
                    "kategori_id = " + cmb_kategori_id.EditValue + ", " +
                    "fiyat = " + tb_fiyat.Value.ToString().Replace(',', '.') + (tasinacakDosya.Length > 0 ? ", " +
                    "resim = '" + random + ".png'" : "") + ", " +
                    "[stok_kodu] = '" + tb_stok_kodu.Text + "', " +
                    "[barkod] = '" + tb_barkod.Text + "', " +
                    "[olcu_birimi_parametre_id] = " + cmb_olcu_birimi.EditValue + ", " +
                    "[minimum_stok] = " + tb_min_stok.Value.ToString().Replace(',', '.') + ", " +
                    "[maksimum_stok] = " + tb_max_stok.Value.ToString().Replace(',', '.') + ", " +
                    "[alis_fiyat] = " + tb_alis_fiyat.Value.ToString().Replace(',', '.') + ", " +
                    "[menu_aktif] = " + (cb_menude_goster.Checked ? "1" : "0") + ", " +
                    "receteli_urun = " + (cb_receteli.Checked ? "1" : "0") + ", " +
                    "recete_malzemesi = " + (cb_recete_malzemesi.Checked ? "1" : "0") + ", " +
                    "kdv = " + cmb_kdv.EditValue.ToString().Replace(',', '.') + ", " +
                    "hedef_id = " + cmb_hedef.EditValue + ", " +
                    "sira = " + tb_sira.Value.ToString().Replace(',', '.') + ", " +
                    "sicak_satis = " + (cb_sicak_satis.Checked ? "1" : "0") + " " +
                    "WHERE urun_id = " + urun_id);
            this.Close();
        }
    }
}
