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
    public partial class SQLCon : Form
    {
        public SQLCon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "58040613")
                return;

            string dosya_yolu = @"constr.txt";

            if (File.Exists(dosya_yolu))
                File.Delete(dosya_yolu);

            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(textBox1.Text);
            sw.Flush();
            sw.Close();
            fs.Close();

            MessageBox.Show("Bağlantı Cümlesi Kaydedildi");
            this.Close();
        }

        private void SQLCon_Load(object sender, EventArgs e)
        {
            string text;
            try { text = System.IO.File.ReadAllText(@"constr.txt"); } catch { text = ""; }
            textBox1.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "58040613")
                return;

            DialogResult dialogResult = MessageBox.Show("Emin misin?", "Veri Tabanı Temizlenecek!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SQL.set("DELETE FROM adisyon");
                SQL.set("DELETE FROM adisyon_kalem");
                SQL.set("DELETE FROM cari_bakiye");
                SQL.set("DELETE FROM cariler");
                SQL.set("DELETE FROM cariler");
                SQL.set("DELETE FROM finans_hareket");
                SQL.set("DELETE FROM finans_tahsilat");
                SQL.set("DELETE FROM hedef");
                SQL.set("DELETE FROM kategoriler");
                SQL.set("DELETE FROM kullanicilar");
                SQL.set("DELETE FROM kullanicilar_gec_mesai");
                SQL.set("DELETE FROM kullanicilar_maas_odeme");
                SQL.set("DELETE FROM kullanicilar_yetki");
                SQL.set("DELETE FROM masalar");
                SQL.set("DELETE FROM masalar_kategori");
                SQL.set("DELETE FROM urunler");
                SQL.set("DELETE FROM urunler_fatura");
                SQL.set("DELETE FROM urunler_fatura_kalem");
                SQL.set("DELETE FROM urunler_hareket");
                SQL.set("DELETE FROM urunler_irsaliye");
                SQL.set("DELETE FROM urunler_irsaliye_kalem");
                SQL.set("DELETE FROM urunler_recete");
                SQL.set("DELETE FROM urunler_siparis");
                SQL.set("DELETE FROM urunler_siparis_kalem");
                SQL.set("DELETE FROM urunler_stok_sayim");

                SQL.set("INSERT INTO kullanicilar ([ad],[soyad],[sifre],[maas],[tc_kimlik_no],[sgk_no],[dogum_yeri],[dogum_tarihi],[baba_adi],[anne_adi],[cinsiyet_parametre_id],[ise_giris_tarihi],[isten_cikis_tarihi]," +
                    " [isten_ciktimi],[cep_telefonu],[ev_telefonu],[eposta],[adres],[acil_durum_kisisi],[acil_durum_telefon],[banka],[sube],[hesap_no],[iban]) " +
                    " VALUES ('ADMİN','','1234',0.0000,'','','','','','','',GETDATE(),GETDATE(),0,'','','','','','','','','','')");

                MessageBox.Show("Bütün veriler temizlendi!, kullanıcı girişi 1234");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "58040613")
                return;

            if (Convert.ToInt32(SQL.get("SELECT COUNT(*) FROM kullanicilar WHERE silindi = 0 AND sifre = '" + tb_admin_sifresi.Text + "'").Rows[0][0]) != 0)
            {
                new mesaj("Şifre başka kullanıcı tarafında kullanılmaktadır!").ShowDialog();
                return;
            }

            SQL.set("INSERT INTO kullanicilar ([ad],[soyad],[sifre],[maas],[tc_kimlik_no],[sgk_no],[dogum_yeri],[dogum_tarihi],[baba_adi],[anne_adi],[cinsiyet_parametre_id],[ise_giris_tarihi],[isten_cikis_tarihi]," +
                    " [isten_ciktimi],[cep_telefonu],[ev_telefonu],[eposta],[adres],[acil_durum_kisisi],[acil_durum_telefon],[banka],[sube],[hesap_no],[iban]) " +
                    " VALUES ('ADMİN','','" + tb_admin_sifresi.Text + "',0.0000,'','','','','','','',GETDATE(),GETDATE(),0,'','','','','','','','','','')");

            MessageBox.Show("ADMİN kullanıcı girişi " + tb_admin_sifresi.Text);
            this.Close();
        }
    }
}
