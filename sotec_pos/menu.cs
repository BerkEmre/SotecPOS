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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            try { pictureBox1.ImageLocation = "firma_logo.png"; } catch { }

            float x = (Convert.ToInt32(this.Width) - Convert.ToInt32(pnl_center.Width)) / 2;
            float y = (Convert.ToInt32(this.Height) - Convert.ToInt32(pnl_center.Height)) / 2;

            pnl_center.Location = new Point(x: Convert.ToInt32(x), y: Convert.ToInt32(y));

            lbl_kullanici_adi.Text = SQL.ad + " " + SQL.soyad + " (" + SQL.kullanici_id.ToString() + ")";

            DataTable dt = SQL.get("SELECT ky.yetki_id FROM kullanicilar_yetki ky INNER JOIN yetkiler y ON y.yetki_id = ky.yetki_id AND y.silindi = 0 AND y.ust_yetki_id = 0 WHERE ky.silindi = 0 AND ky.kullanici_id = " + SQL.kullanici_id);
            if(dt.Rows.Count == 1)
            {
                if(Convert.ToInt32(dt.Rows[0]["yetki_id"]) == 2)
                {
                    pos p = new pos(this);
                    p.ShowDialog();
                }
            }

            DataTable dt_gun = SQL.get("SELECT * FROM gunler WHERE silindi = 0");
            if(dt_gun.Rows.Count > 0)
            {
                bt_gun.Text = "Günü Bitir";
                bt_gun.FlatAppearance.BorderColor = bt_gun.ForeColor = Color.DimGray;
                bt_gun.BackColor = Color.GreenYellow;
            }
            else
            {
                bt_gun.Text = "Günü Başlat";
                bt_gun.FlatAppearance.BorderColor = bt_gun.ForeColor = Color.GreenYellow;
                bt_gun.BackColor = Color.DimGray;
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_urun_Click(object sender, EventArgs e)
        {
            if(!SQL.yetki_kontrol(1))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urunler u = new urunler();
            u.ShowDialog();
        }

        private void btn_destek_Click(object sender, EventArgs e)
        {
            destek d = new destek();
            d.ShowDialog();
        }

        private void btn_personel_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(4))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            personel p = new personel();
            p.ShowDialog();
        }

        private void btn_stok_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(5))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            stok s = new stok();
            s.ShowDialog();
        }

        private void btn_yonetim_Click(object sender, EventArgs e)
        {
            ayarlar a = new ayarlar();
            a.ShowDialog();
        }

        private void btn_satis_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(2))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            pos p = new pos(this);
            p.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(3))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            satin_alma p = new satin_alma();
            p.ShowDialog();
        }

        private void btn_raporlar_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(6))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            raporlar r = new raporlar();
            r.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(29))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            hedef r = new hedef();
            r.ShowDialog();
        }

        private void bt_gun_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(32))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            DataTable dt_gun = SQL.get("SELECT * FROM gunler WHERE silindi = 0");
            if (dt_gun.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Günü kapatmak istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dt_masalar = SQL.get("SELECT * FROM adisyon WHERE silindi = 0 AND kapandi = 0");
                    if(dt_masalar.Rows.Count > 0)
                    {
                        new mesaj("Bütün masaları kapatmadan günü kapatamazınız!").ShowDialog();
                        return;
                    }

                    SQL.set("UPDATE gunler SET bitis_tarihi = DATEADD(MINUTE, 1, GETDATE()), silindi = 1 WHERE gun_id = " + dt_gun.Rows[0]["gun_id"]);
                    bt_gun.Text = "Günü Başlat";
                    bt_gun.FlatAppearance.BorderColor = bt_gun.ForeColor = Color.GreenYellow;
                    bt_gun.BackColor = Color.DimGray;
                }
            }
            else
            {
                SQL.set("INSERT INTO gunler (baslangic_tarihi, bitis_tarihi) VALUES (GETDATE(), GETDATE())");
                bt_gun.Text = "Günü Bitir";
                bt_gun.FlatAppearance.BorderColor = bt_gun.ForeColor = Color.DimGray;
                bt_gun.BackColor = Color.GreenYellow;
            }
        }
    }
}
