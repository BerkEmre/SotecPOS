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
    public partial class kategori_ekle_duzenle : Form
    {
        int ust_kategori_id;
        int kategori_id;

        public kategori_ekle_duzenle(int ust_kategori_id, int kategori_id)
        {
            this.kategori_id = kategori_id;
            this.ust_kategori_id = ust_kategori_id;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kategori_ekle_duzenle_Load(object sender, EventArgs e)
        {
            if(kategori_id != 0)
            {
                DataTable dt = SQL.get("SELECT * FROM kategoriler WHERE silindi = 0 AND kategori_id = " + kategori_id);

                tb_kategori_adi.Text = dt.Rows[0]["kategori_adi"].ToString();
                cb_menude_goster.Checked = Convert.ToInt32(dt.Rows[0]["menude_gosterilsin"]) == 1;
                tb_maas.Value = Convert.ToInt32(dt.Rows[0]["sira"]);

                btn_log_out.Text = "Düzenle";
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(tb_kategori_adi.Text.Length <= 0)
            {
                new mesaj("Kategori Adı giriniz!").ShowDialog();
                return;
            }

            if(kategori_id == 0)
                SQL.set("INSERT INTO kategoriler (ust_kategori_id, kategori_adi, menude_gosterilsin, sira) VALUES (" + ust_kategori_id + ", '" + tb_kategori_adi.Text + "', " + (cb_menude_goster.Checked ? 1:0) + ", " + tb_maas.Value + ")");
            else
                SQL.set("UPDATE kategoriler SET kategori_adi = '" + tb_kategori_adi.Text + "', menude_gosterilsin = " + (cb_menude_goster.Checked ? 1 : 0) + ", sira = " + tb_maas.Value + " WHERE kategori_id = " + kategori_id);
            this.Close();
        }
    }
}
