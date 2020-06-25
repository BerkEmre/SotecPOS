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
    public partial class num_pad : Form
    {
        bool virgul = false;
        int virgulden_sonra_sifir = 0;

        public num_pad()
        {
            InitializeComponent();
        }

        public num_pad(decimal value)
        {
            InitializeComponent();
            this.tb_miktar.Value = value;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tb_miktar.Value = 0;
            virgul = false;
            virgulden_sonra_sifir = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "7");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "7");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "8");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "8");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "9");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "9");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "4");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "5");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "6");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "1");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "2");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "2");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir) + "3");
                virgul = false;
                virgulden_sonra_sifir = 0;
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "3");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (virgul)
            {
                virgulden_sonra_sifir++;
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "," + kac_tane_sifir(virgulden_sonra_sifir));
            }
            else
                tb_miktar.Value = Convert.ToDecimal(tb_miktar.Value.ToString() + "0");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (virgul) virgul = false;
            else virgul = true;
        }

        private string kac_tane_sifir(int kac_tane)
        {
            string sifir = "";
            for (int i = 0; i < kac_tane; i++)
            {
                sifir += "0";
            }
            return sifir;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 5;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 10;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 20;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 50;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 100;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tb_miktar.Value += 200;
        }

        private void num_pad_Load(object sender, EventArgs e)
        {

        }

        private void tb_miktar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
