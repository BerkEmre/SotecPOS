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
using System.Windows.Input;

namespace sotec_pos
{
    public partial class ayarlar : Form
    {
        string tasinacakDosya = "", tasinacakDosyaIsmi = "", dosyaninTasinacagiKlasor = "";
        public ayarlar()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gv_masa_kategori.SelectedRowsCount <= 0)
                return;

            ayarlar_masa_ekle_duzenle a = new ayarlar_masa_ekle_duzenle(0, Convert.ToInt32(gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]));
            a.FormClosing += A_FormClosing;
            a.ShowDialog();
        }

        private void A_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*DataTable dt_masa_kategori = SQL.get("SELECT masa_kategori_id, masa_kategori FROM masalar_kategori WHERE silindi = 0");
            grid_masa_kategori.DataSource = dt_masa_kategori;*/

            if (gv_masa_kategori.SelectedRowsCount <= 0)
                return;

            DataTable dt_masalar = SQL.get("SELECT masa_id, masa_adi FROM masalar WHERE silindi = 0 AND masa_kategori_id = " + gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]);
            grid_masalar.DataSource = dt_masalar;
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            string text = "";
            try { text = System.IO.File.ReadAllText(@"printer_info.txt"); } catch { text = ""; }
            tb_yazici.Text = text;

            try { text = System.IO.File.ReadAllText(@"firma_bilgi.txt"); } catch { text = ""; }
            tb_isletme.Text = text;

            try { pb_logo.ImageLocation = "firma_logo.png"; } catch { }

            DataTable dt_masa_kategori = SQL.get("SELECT masa_kategori_id, masa_kategori FROM masalar_kategori WHERE silindi = 0");
            grid_masa_kategori.DataSource = dt_masa_kategori;

            DataTable dt_hedefler = SQL.get("SELECT * FROM hedef WHERE silindi = 0");
            grid_hedef.DataSource = dt_hedefler;

            DataTable dt_donusumler = SQL.get("SELECT kaynak_birim_id = p1.parametre_id, kaynak_birim = p1.deger, hedef_birim_id = p2.parametre_id, hedef_birim = p2.deger, kd.katsayi, kd.donusum_id FROM katsayi_donusum kd INNER JOIN parametreler p1 ON p1.parametre_id = kd.parametre_1_id INNER JOIN parametreler p2 ON p2.parametre_id = kd.parametre_2_id WHERE kd.silindi = 0");
            grid_donusumler.DataSource = dt_donusumler;
        }

        private void grid_masalar_DoubleClick(object sender, EventArgs e)
        {
            if (gv_masalar.SelectedRowsCount <= 0)
                return;

            ayarlar_masa_ekle_duzenle a = new ayarlar_masa_ekle_duzenle(Convert.ToInt32(gv_masalar.GetDataRow(gv_masalar.GetSelectedRows()[0])["masa_id"]), Convert.ToInt32(gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]));
            a.FormClosing += A_FormClosing;
            a.ShowDialog();
        }

        private void grid_masa_kategori_Click(object sender, EventArgs e)
        {
            if (gv_masa_kategori.SelectedRowsCount <= 0)
                return;

            DataTable dt_masalar = SQL.get("SELECT masa_id, masa_adi FROM masalar WHERE silindi = 0 AND masa_kategori_id = " + gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]);
            grid_masalar.DataSource = dt_masalar;
        }

        private void grid_masa_kategori_DoubleClick(object sender, EventArgs e)
        {
            if (gv_masa_kategori.SelectedRowsCount <= 0)
                return;

            ayarlar_masa_kategori_ekle_duzenle a = new ayarlar_masa_kategori_ekle_duzenle(Convert.ToInt32(gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]));
            a.FormClosing += B_FormClosing;
            a.ShowDialog();
        }

        private void B_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_masa_kategori = SQL.get("SELECT masa_kategori_id, masa_kategori FROM masalar_kategori WHERE silindi = 0");
            grid_masa_kategori.DataSource = dt_masa_kategori;

            if (gv_masa_kategori.SelectedRowsCount <= 0)
                return;

            DataTable dt_masalar = SQL.get("SELECT masa_id, masa_adi FROM masalar WHERE silindi = 0 AND masa_kategori_id = " + gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]);
            grid_masalar.DataSource = dt_masalar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ayarlar_masa_kategori_ekle_duzenle a = new ayarlar_masa_kategori_ekle_duzenle(0);
            a.FormClosing += B_FormClosing;
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ayarlar_hareket_ekle_duzenle a = new ayarlar_hareket_ekle_duzenle(0);
            a.FormClosing += A_FormClosing1;
            a.ShowDialog();
        }

        private void grid_hedef_DoubleClick(object sender, EventArgs e)
        {
            if (gv_hedef.SelectedRowsCount <= 0)
                return;

            ayarlar_hareket_ekle_duzenle a = new ayarlar_hareket_ekle_duzenle(Convert.ToInt32(gv_hedef.GetDataRow(gv_hedef.GetSelectedRows()[0])["hedef_id"]));
            a.FormClosing += A_FormClosing1;
            a.ShowDialog();
        }

        private void A_FormClosing1(object sender, FormClosingEventArgs e)
        {
            DataTable dt_hedefler = SQL.get("SELECT * FROM hedef WHERE silindi = 0");
            grid_hedef.DataSource = dt_hedefler;

            DataTable dt_donusumler = SQL.get("SELECT kaynak_birim_id = p1.parametre_id, kaynak_birim = p1.deger, hedef_birim_id = p2.parametre_id, hedef_birim = p2.deger, kd.katsayi, kd.donusum_id FROM katsayi_donusum kd INNER JOIN parametreler p1 ON p1.parametre_id = kd.parametre_1_id INNER JOIN parametreler p2 ON p2.parametre_id = kd.parametre_2_id WHERE kd.silindi = 0");
            grid_donusumler.DataSource = dt_donusumler;
        }

        private void grid_hedef_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (gv_hedef.SelectedRowsCount <= 0)
                return;

            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dtu = SQL.get("SELECT * FROM urunler WHERE silindi = 0 AND hedef_id = " + gv_hedef.GetDataRow(gv_hedef.GetSelectedRows()[0])["hedef_id"].ToString());
                    if(dtu.Rows.Count > 0)
                    {
                        new mesaj("Bu hedefe gidecek ürünler var hedef silinemez!").ShowDialog();
                        return;
                    }

                    SQL.set("UPDATE hedef SET silindi = 1 WHERE hedef_id = " + gv_hedef.GetDataRow(gv_hedef.GetSelectedRows()[0])["hedef_id"].ToString());
                    DataTable dt_hedefler = SQL.get("SELECT * FROM hedef WHERE silindi = 0");
                    grid_hedef.DataSource = dt_hedefler;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ayarlar_yazici_sec a = new ayarlar_yazici_sec(false);
            a.FormClosing += A_FormClosing2;
            a.ShowDialog();
        }

        private void A_FormClosing2(object sender, FormClosingEventArgs e)
        {
            string text = "";
            try { text = System.IO.File.ReadAllText(@"printer_info.txt"); } catch { text = ""; }
            tb_yazici.Text = text;
        }

        private void grid_masalar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (gv_masalar.SelectedRowsCount <= 0)
                        return;

                    int masa_id = Convert.ToInt32(gv_masalar.GetDataRow(gv_masalar.GetSelectedRows()[0])["masa_id"]);
                    if (SQL.get("SELECT * FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id).Rows.Count > 0)
                    {
                        new mesaj("Masa açıkken silinemez!").Show();
                        return;
                    }

                    SQL.set("UPDATE masalar SET silindi = 1 WHERE masa_id = " + masa_id);

                    DataTable dt_masalar = SQL.get("SELECT masa_id, masa_adi FROM masalar WHERE silindi = 0 AND masa_kategori_id = " + gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]);
                    grid_masalar.DataSource = dt_masalar;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tasinacakDosya.Length > 0)
            {
                if (File.Exists("firma_logo.png"))
                    File.Delete("firma_logo.png");
                File.Copy(tasinacakDosya, "firma_logo.png");
            }

            string dosya_yolu = @"firma_bilgi.txt";

            if (File.Exists(dosya_yolu))
                File.Delete(dosya_yolu);

            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(tb_isletme.Text);
            sw.Flush();
            sw.Close();
            fs.Close();

            new mesaj("Firma bilgileri kaydedildi!").ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ayarlar_birim_donusumleri a = new ayarlar_birim_donusumleri(0);
            a.FormClosing += A_FormClosing1;
            a.ShowDialog();
        }

        private void grid_donusumler_DoubleClick(object sender, EventArgs e)
        {
            if (gv_hedef.SelectedRowsCount <= 0)
                return;

            ayarlar_birim_donusumleri a = new ayarlar_birim_donusumleri(Convert.ToInt32(gv_donusumler.GetDataRow(gv_donusumler.GetSelectedRows()[0])["donusum_id"]));
            a.FormClosing += A_FormClosing1;
            a.ShowDialog();
        }

        private void grid_donusumler_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (gv_donusumler.SelectedRowsCount <= 0)
                        return;

                    int donusum_id = Convert.ToInt32(gv_donusumler.GetDataRow(gv_donusumler.GetSelectedRows()[0])["donusum_id"]);

                    SQL.set("UPDATE katsayi_donusum SET silindi = 1 WHERE donusum_id = " + donusum_id);

                    DataTable dt_donusumler = SQL.get("SELECT kaynak_birim_id = p1.parametre_id, kaynak_birim = p1.deger, hedef_birim_id = p2.parametre_id, hedef_birim = p2.deger, kd.katsayi, kd.donusum_id FROM katsayi_donusum kd INNER JOIN parametreler p1 ON p1.parametre_id = kd.parametre_1_id INNER JOIN parametreler p2 ON p2.parametre_id = kd.parametre_2_id WHERE kd.silindi = 0");
                    grid_donusumler.DataSource = dt_donusumler;
                }
            }
        }

        private void grid_masa_kategori_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (gv_masa_kategori.SelectedRowsCount <= 0)
                        return;

                    int masa_kategori_id = Convert.ToInt32(gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]);
                    if (SQL.get("SELECT * FROM masalar WHERE silindi = 0 AND masa_kategori_id = " + masa_kategori_id).Rows.Count > 0)
                    {
                        new mesaj("İçinde masa bulunan kategori silinemez!").Show();
                        return;
                    }

                    SQL.set("UPDATE masalar_kategori SET silindi = 1 WHERE masa_kategori_id = " + masa_kategori_id);

                    DataTable dt_masa_kategori = SQL.get("SELECT masa_kategori_id, masa_kategori FROM masalar_kategori WHERE silindi = 0");
                    grid_masa_kategori.DataSource = dt_masa_kategori;

                    if (gv_masa_kategori.SelectedRowsCount <= 0)
                        return;

                    DataTable dt_masalar = SQL.get("SELECT masa_id, masa_adi FROM masalar WHERE silindi = 0 AND masa_kategori_id = " + gv_masa_kategori.GetDataRow(gv_masa_kategori.GetSelectedRows()[0])["masa_kategori_id"]);
                    grid_masalar.DataSource = dt_masalar;
                }
            }
        }

        private void btn_resim_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Resim Dosyası (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pb_logo.ImageLocation = of.FileName;

                tasinacakDosyaIsmi = of.SafeFileName.ToString();
                tasinacakDosya = of.FileName.ToString();
            }
        }
    }
}
