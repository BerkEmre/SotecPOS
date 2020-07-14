using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sotec_pos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tb_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }

            // only allow one decimal point
            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            tb_pass.Text += "0";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_pass.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { pictureBox1.ImageLocation = "firma_logo.png"; } catch { }

            float y = (Convert.ToInt32(this.Height) - Convert.ToInt32(panel1.Height)) / 2;
            panel1.Location = new Point(x: Convert.ToInt32(panel1.Location.X), y: Convert.ToInt32(y));
            y = (Convert.ToInt32(this.Height) - Convert.ToInt32(pictureBox1.Height)) / 2;
            pictureBox1.Location = new Point(x: Convert.ToInt32(pictureBox1.Location.X), y: Convert.ToInt32(y));

            if (SQL.baglanti_test())
            {
                lbl_baglanti.Text = "Bağlantı Var";
                lbl_baglanti.ForeColor = Color.GreenYellow;
            }
            else
            {
                lbl_baglanti.Text = "Bağlantı Yok";
                lbl_baglanti.ForeColor = Color.Red;
            }

            label2.Text = Program.GetMacAddress();

            try {
                lbl_versiyon.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.Major.ToString();
                lbl_versiyon.Text += ".";
                lbl_versiyon.Text += ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor.ToString();
                lbl_versiyon.Text += ".";
                lbl_versiyon.Text += ApplicationDeployment.CurrentDeployment.CurrentVersion.Build.ToString();
                lbl_versiyon.Text += ".";
                lbl_versiyon.Text += ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision.ToString();
            } catch { lbl_versiyon.Text = "DEBUG"; }
        }

        private void tb_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        public void login()
        {
            if (tb_pass.Text.Length <= 0)
            {
                new mesaj("Şifre Giriniz!").ShowDialog();
                return;
            }

            DataTable dt;
            try
            {
                dt = SQL.get("SELECT * FROM kullanicilar WHERE silindi = 0 AND sifre = '" + tb_pass.Text + "'");
            } catch { new mesaj("Veri tabanı bağlantısında sorun var!").ShowDialog(); return; }

            if (dt.Rows.Count <= 0)
            {
                new mesaj("Yanlış Şifre!").ShowDialog();
                return;
            }

            SQL.kullanici_id = Convert.ToInt32(Convert.ToInt32(dt.Rows[0]["kullanici_id"]));
            SQL.ad = dt.Rows[0]["ad"].ToString();
            SQL.soyad = dt.Rows[0]["soyad"].ToString();

            tb_pass.Text = "";

            menu m = new menu();
            m.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SQLCon s = new SQLCon();
            s.ShowDialog();
        }

        private void lbl_baglanti_Click(object sender, EventArgs e)
        {
            if (SQL.baglanti_test())
            {
                lbl_baglanti.Text = "Bağlantı Var";
                lbl_baglanti.ForeColor = Color.GreenYellow;
            }
            else
            {
                lbl_baglanti.Text = "Bağlantı Yok";
                lbl_baglanti.ForeColor = Color.Red;
            }
        }
    }
}
