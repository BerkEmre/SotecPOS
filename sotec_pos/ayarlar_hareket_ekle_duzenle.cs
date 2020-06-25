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
    public partial class ayarlar_hareket_ekle_duzenle : Form
    {
        int hedef_id;

        public ayarlar_hareket_ekle_duzenle(int hedef_id)
        {
            InitializeComponent();

            this.hedef_id = hedef_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ayarlar_hareket_ekle_duzenle_Load(object sender, EventArgs e)
        {
            if (hedef_id != 0)
            {
                DataTable dt = SQL.get("SELECT * FROM hedef WHERE silindi = 0 AND hedef_id = " + hedef_id);

                tb_kategori_adi.Text = dt.Rows[0]["hedef"].ToString();
                tb_yazici.Text = dt.Rows[0]["yazici"].ToString();
                cb_hedefte_yazdir.Checked = Convert.ToInt32(dt.Rows[0]["hedefte_yazdir"].ToString()) == 1 ? true : false;

                btn_log_out.Text = "Düzenle";
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_kategori_adi.Text.Length <= 0)
            {
                new mesaj("Hedef Adı giriniz!").ShowDialog();
                return;
            }

            if (hedef_id == 0)
                SQL.set("INSERT INTO hedef (hedef, yazici, hedefte_yazdir) VALUES ('" + tb_kategori_adi.Text + "', '" + tb_yazici.Text + "', " + (cb_hedefte_yazdir.Checked ? 1 : 0) + ")");
            else
                SQL.set("UPDATE hedef SET hedef = '" + tb_kategori_adi.Text + "', yazici = '" + tb_yazici.Text + "', hedefte_yazdir = " + (cb_hedefte_yazdir.Checked ? 1 : 0) + " WHERE hedef_id = " + hedef_id);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form = new ayarlar_yazici_sec(true))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tb_yazici.Text = form.yazici;
                }
            }
        }
    }
}
