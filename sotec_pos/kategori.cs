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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            kategori_ekle_duzenle k = new kategori_ekle_duzenle(0, 0);
            k.FormClosing += K_FormClosing1;
            k.ShowDialog();
        }

        private void K_FormClosing1(object sender, FormClosingEventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = 0");
            grid_ust_kategori.DataSource = dt;

            if (gv_ust_kategori.SelectedRowsCount <= 0)
                return;

            DataTable dt2 = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = " + Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]));
            grid_kategoriler.DataSource = dt2;
        }

        private void K_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gv_ust_kategori.SelectedRowsCount <= 0)
                return;

            DataTable dt2 = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = " + Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]));
            grid_kategoriler.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategori_ekle_duzenle k = new kategori_ekle_duzenle(Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]), 0);
            k.FormClosing += K_FormClosing;
            k.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kategori_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = 0");
            grid_ust_kategori.DataSource = dt;
        }

        private void grid_ust_kategori_Click(object sender, EventArgs e)
        {
            if (gv_ust_kategori.SelectedRowsCount <= 0)
                return;

            DataTable dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = " + Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]));
            grid_kategoriler.DataSource = dt;
        }

        private void grid_ust_kategori_DoubleClick(object sender, EventArgs e)
        {
            if (gv_ust_kategori.SelectedRowsCount <= 0)
                return;
            
            kategori_ekle_duzenle k = new kategori_ekle_duzenle(0, Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]));
            k.FormClosing += K_FormClosing1;
            k.ShowDialog();
        }

        private void grid_kategoriler_DoubleClick(object sender, EventArgs e)
        {
            if (gv_kategoriler.SelectedRowsCount <= 0)
                return;

            kategori_ekle_duzenle k = new kategori_ekle_duzenle(0, Convert.ToInt32(gv_kategoriler.GetDataRow(gv_kategoriler.GetSelectedRows()[0])["kategori_id"]));
            k.FormClosing += K_FormClosing;
            k.ShowDialog();
        }

        private void grid_ust_kategori_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                int kategori_id = Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]);

                DataTable dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = " + kategori_id);
                if (dt.Rows.Count > 0)
                {
                    new mesaj("Alt kategorileri silmeden silemezsiniz...").ShowDialog();
                    return; 
                }
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE kategoriler SET silindi = 1 WHERE kategori_id = " + kategori_id);
                }
                dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = 0");
                grid_ust_kategori.DataSource = dt;
            }
        }

        private void grid_kategoriler_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                int kategori_id = Convert.ToInt32(gv_kategoriler.GetDataRow(gv_kategoriler.GetSelectedRows()[0])["kategori_id"]);
                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SQL.set("UPDATE kategoriler SET silindi = 1 WHERE kategori_id = " + kategori_id);
                }

                if (gv_ust_kategori.SelectedRowsCount <= 0)
                    return;

                DataTable dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND ust_kategori_id = " + Convert.ToInt32(gv_ust_kategori.GetDataRow(gv_ust_kategori.GetSelectedRows()[0])["kategori_id"]));
                grid_kategoriler.DataSource = dt;
            }
        }
    }
}
