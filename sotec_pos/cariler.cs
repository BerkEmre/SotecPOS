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
    public partial class cariler : Form
    {
        public cariler()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cari_ekle_duzenle c = new cari_ekle_duzenle(0);
            c.FormClosing += C_FormClosing;
            c.ShowDialog();
        }

        private void C_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = SQL.get("SELECT c.cari_id, c.cari_adi, p.deger, c.telefon, bakiye = ISNULL((SELECT SUM(cb.miktar) FROM cari_bakiye cb WHERE cb.silindi = 0 AND cb.cari_id = c.cari_id), 0.0000) FROM cariler c INNER JOIN parametreler p ON p.parametre_id = c.cari_tipi_parametre_id WHERE c.silindi = 0");
            grid_cariler.DataSource = dt;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cariler_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT c.cari_id, c.cari_adi, p.deger, c.telefon, bakiye = ISNULL((SELECT SUM(cb.miktar) FROM cari_bakiye cb WHERE cb.silindi = 0 AND cb.cari_id = c.cari_id), 0.0000) FROM cariler c INNER JOIN parametreler p ON p.parametre_id = c.cari_tipi_parametre_id WHERE c.silindi = 0");
            grid_cariler.DataSource = dt;
        }

        private void grid_cariler_DoubleClick(object sender, EventArgs e)
        {
            if (gv_cariler.SelectedRowsCount <= 0)
                return;

            cari_ekle_duzenle c = new cari_ekle_duzenle(Convert.ToInt32(gv_cariler.GetDataRow(gv_cariler.GetSelectedRows()[0])["cari_id"]));
            c.FormClosing += C_FormClosing;
            c.ShowDialog();
        }

        private void grid_cariler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE cariler SET silindi = 1 WHERE cari_id = " + gv_cariler.GetDataRow(gv_cariler.GetSelectedRows()[0])["cari_id"].ToString());
                    DataTable dt = SQL.get("SELECT c.cari_id, c.cari_adi, p.deger FROM cariler c INNER JOIN parametreler p ON p.parametre_id = c.cari_tipi_parametre_id WHERE c.silindi = 0");
                    grid_cariler.DataSource = dt;
                }
            }
        }
    }
}
