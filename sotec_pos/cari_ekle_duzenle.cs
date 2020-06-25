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
    public partial class cari_ekle_duzenle : Form
    {
        int cari_id;

        public cari_ekle_duzenle(int cari_id)
        {
            this.cari_id = cari_id;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cari_ekle_duzenle_Load(object sender, EventArgs e)
        {
            DataTable dt_p = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'cari_tip'");
            cmb_cari_tip.Properties.DataSource = dt_p;
            cmb_cari_tip.EditValue = dt_p.Rows[0]["parametre_id"];

            if(cari_id != 0)
            {
                btn_log_out.Text = "Düzenle";

                DataTable dt = SQL.get("SELECT * FROM cariler WHERE cari_id = " + cari_id);
                tb_cari_adi.Text = dt.Rows[0]["cari_adi"].ToString();
                cmb_cari_tip.EditValue = dt.Rows[0]["cari_tipi_parametre_id"];
                tb_cari_kodu.Text = dt.Rows[0]["cari_kodu"].ToString();
                tb_resmi_unvan.Text = dt.Rows[0]["resmi_unvan"].ToString();
                tb_vergi_dairesi.Text = dt.Rows[0]["vergi_dairesi"].ToString();
                tb_vergi_no.Text = dt.Rows[0]["vergi_no"].ToString();
                tb_adres.Text = dt.Rows[0]["adres"].ToString();
                tb_telefon.Text = dt.Rows[0]["telefon"].ToString();
                tb_mail.Text = dt.Rows[0]["mail"].ToString();
                tb_sorumlu_kisi.Text = dt.Rows[0]["sorumlu_kisi"].ToString();
                tb_sorumlu_telefon.Text = dt.Rows[0]["sorumlu_tel"].ToString();
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if (tb_cari_adi.Text.Length <= 0)
            {
                new mesaj("Cari Giriniz!").ShowDialog();
                return;
            }
            if (tb_vergi_no.Text.Length != 10 || tb_vergi_no.Text.Length != 10)
            {
                new mesaj("Vergi No 10 veya 11 haneli olmalıdı!").ShowDialog();
                return;
            }
            if (tb_resmi_unvan.Text.Length <= 0)
            {
                new mesaj("Resmi Ünvan Giriniz!").ShowDialog();
                return;
            }
            if (tb_vergi_dairesi.Text.Length <= 0)
            {
                new mesaj("Vergi Dairesi Giriniz!").ShowDialog();
                return;
            }
            if (tb_adres.Text.Length <= 0)
            {
                new mesaj("Adres Giriniz!").ShowDialog();
                return;
            }
            if (tb_telefon.Text.Length <= 0)
            {
                new mesaj("Telfon Giriniz!").ShowDialog();
                return;
            }

            if (cari_id == 0)
                SQL.set("INSERT INTO cariler (cari_adi, cari_tipi_parametre_id, cari_kodu, resmi_unvan, vergi_dairesi, vergi_no, adres, telefon, mail, sorumlu_kisi, sorumlu_tel) " +
                    " VALUES ('" + tb_cari_adi.Text + "', " + cmb_cari_tip.EditValue + ", '" + tb_cari_kodu.Text + "', '" + tb_resmi_unvan.Text + "', '" + tb_vergi_dairesi.Text + "', '" + tb_vergi_no.Text + "', '" + tb_adres.Text + "', '" + tb_telefon.Text + "', '" + tb_mail.Text + "', '" + tb_sorumlu_kisi.Text + "', '" + tb_sorumlu_telefon.Text + "')");
            else
                SQL.set("UPDATE cariler SET " +
                    " cari_adi = '" + tb_cari_adi.Text + "', " +
                    " cari_tipi_parametre_id = " + cmb_cari_tip.EditValue + ", " +
                    " cari_kodu = '" + tb_cari_kodu.Text + "', " +
                    " resmi_unvan = '" + tb_resmi_unvan.Text + "', " +
                    " vergi_dairesi = '" + tb_vergi_dairesi.Text + "', " +
                    " vergi_no = '" + tb_vergi_no.Text + "', " +
                    " adres = '" + tb_adres.Text + "', " +
                    " telefon = '" + tb_telefon.Text + "', " +
                    " mail = '" + tb_mail.Text + "', " +
                    " sorumlu_kisi = '" + tb_sorumlu_kisi.Text + "', " +
                    " sorumlu_tel = '" + tb_sorumlu_telefon.Text + "' " +
                    " WHERE cari_id = " + cari_id);

            this.Close();
        }
    }
}
