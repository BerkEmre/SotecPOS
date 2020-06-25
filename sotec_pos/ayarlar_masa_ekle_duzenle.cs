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
    public partial class ayarlar_masa_ekle_duzenle : Form
    {
        int masa_id, masa_kategori_id;

        public ayarlar_masa_ekle_duzenle(int masa_id, int masa_kategori_id)
        {
            this.masa_id = masa_id;
            this.masa_kategori_id = masa_kategori_id;

            InitializeComponent();
        }

        private void ayarlar_masa_ekle_duzenle_Load(object sender, EventArgs e)
        {
            if(masa_id != 0)
            {
                btn_log_out.Text = "Düzenle";
                DataTable dt = SQL.get("SELECT * FROM masalar WHERE masa_id = " + masa_id);
                tb_masa_adi.Text = dt.Rows[0]["masa_adi"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_masa_adi.Text.Length <= 0)
            {
                new mesaj("Masa adı girin!").ShowDialog();
                return;
            }

            DataTable dt = SQL.get("SELECT masa_id FROM masalar WHERE silindi = 0 AND masa_adi = '" + tb_masa_adi.Text + "' AND masa_id != " + masa_id);
            if(dt.Rows.Count > 0)
            {
                new mesaj("Aynı isimle bir masa kayıtlı!").ShowDialog();
                return;
            }

            if (masa_id == 0)
                SQL.set("INSERT INTO masalar (masa_adi, masa_kategori_id) VALUES ('" + tb_masa_adi.Text + "', " + masa_kategori_id + ")");
            else
                SQL.set("UPDATE masalar SET masa_adi = '" + tb_masa_adi.Text + "' WHERE masa_id = " + masa_id);

            this.Close();
        }
    }
}
