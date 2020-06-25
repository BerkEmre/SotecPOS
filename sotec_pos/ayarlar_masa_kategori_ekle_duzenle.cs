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
    public partial class ayarlar_masa_kategori_ekle_duzenle : Form
    {
        int masa_kategori_id;

        public ayarlar_masa_kategori_ekle_duzenle(int masa_kategori_id)
        {
            InitializeComponent();

            this.masa_kategori_id = masa_kategori_id;
        }

        private void ayarlar_masa_kategori_ekle_duzenle_Load(object sender, EventArgs e)
        {
            if (masa_kategori_id != 0)
            {
                DataTable dt = SQL.get("SELECT * FROM masalar_kategori WHERE silindi = 0 AND masa_kategori_id = " + masa_kategori_id);

                tb_kategori_adi.Text = dt.Rows[0]["masa_kategori"].ToString();

                btn_log_out.Text = "Düzenle";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_kategori_adi.Text.Length <= 0)
            {
                new mesaj("Kategori Adı giriniz!").ShowDialog();
                return;
            }

            if (masa_kategori_id == 0)
                SQL.set("INSERT INTO masalar_kategori (masa_kategori) VALUES ('" + tb_kategori_adi.Text + "')");
            else
                SQL.set("UPDATE masalar_kategori SET masa_kategori = '" + tb_kategori_adi.Text + "' WHERE masa_kategori_id = " + masa_kategori_id);
            this.Close();
        }
    }
}
