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
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(21))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            personel_ekle_duzenle p = new personel_ekle_duzenle(0);
            p.FormClosing += P_FormClosing;
            p.ShowDialog();
        }

        private void P_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0");
            grid_personeller.DataSource = dt;
        }

        private void personel_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0");
            grid_personeller.DataSource = dt;
        }

        private void grid_personeller_DoubleClick(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(21))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if (gv_personeller.SelectedRowsCount <= 0)
                return;

            personel_ekle_duzenle p = new personel_ekle_duzenle(Convert.ToInt32(gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["kullanici_id"]));
            p.FormClosing += P_FormClosing;
            p.ShowDialog();
        }

        private void grid_personeller_KeyDown(object sender, KeyEventArgs e)
        {
            if (!SQL.yetki_kontrol(21))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if (gv_personeller.RowCount <= 1) return;

            if(e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE kullanicilar SET silindi = 1 WHERE kullanici_id = " + gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["kullanici_id"].ToString());
                    DataTable dt = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0");
                    grid_personeller.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(22))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if (gv_personeller.SelectedRowsCount <= 0)
            {
                new mesaj("Kullanıcı Seçiniz!").ShowDialog();
                return;
            }

            personel_gec_mesai p = new personel_gec_mesai(Convert.ToInt32(gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["kullanici_id"]));
            p.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(23))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            personel_maas_odeme p = new personel_maas_odeme();
            p.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(28))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            if (gv_personeller.SelectedRowsCount <= 0)
            {
                new mesaj("Kullanıcı Seçiniz!").ShowDialog();
                return;
            }

            personel_yetki y = new personel_yetki(Convert.ToInt32(gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["kullanici_id"]), gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["ad"].ToString() + " " + gv_personeller.GetDataRow(gv_personeller.GetSelectedRows()[0])["soyad"].ToString());
            y.ShowDialog();
        }
    }
}
