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
    public partial class ayarlar_deger : Form
    {
        string tip = "";
        int parametre_id = 0;

        public ayarlar_deger(int parametre_id, string tip)
        {
            this.parametre_id = parametre_id;
            this.tip = tip;

            InitializeComponent();
        }

        private void ayarlar_deger_Load(object sender, EventArgs e)
        {
            if (parametre_id != 0)
            {
                DataTable dt = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND parametre_id = " + parametre_id);

                tb_deger.Text = dt.Rows[0]["deger"].ToString();

                btn_log_out.Text = "Düzenle";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_deger.Text.Length <= 0)
            {
                new mesaj("Değer giriniz!").ShowDialog();
                return;
            }

            if (parametre_id == 0)
                SQL.set("INSERT INTO parametreler (deger, tip) VALUES ('" + tb_deger.Text + "', '" + tip + "')");
            else
                SQL.set("UPDATE parametreler SET deger = '" + tb_deger.Text + "' WHERE parametre_id = " + parametre_id);
            this.Close();
        }
    }
}
