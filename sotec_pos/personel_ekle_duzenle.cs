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
    public partial class personel_ekle_duzenle : Form
    {
        int personel_id;

        public personel_ekle_duzenle(int personel_id)
        {
            this.personel_id = personel_id;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personel_ekle_duzenle_Load(object sender, EventArgs e)
        {
            DataTable dt_cinsiyet = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'cinsiyet'");
            cmb_cinsiyet.Properties.DataSource = dt_cinsiyet;
            cmb_cinsiyet.EditValue = dt_cinsiyet.Rows[0]["parametre_id"];

            DataTable dt_personel_tipi = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'personel_tipi'");
            cmb_personel_tipi.Properties.DataSource = dt_personel_tipi;
            cmb_personel_tipi.EditValue = dt_personel_tipi.Rows[0]["parametre_id"];

            if (personel_id != 0)
            {
                btn_log_out.Text = "Düzenle";

                DataTable dt = SQL.get("SELECT * FROM kullanicilar WHERE kullanici_id = " + personel_id);
                tb_ad.Text = dt.Rows[0]["ad"].ToString();
                tb_soyad.Text = dt.Rows[0]["soyad"].ToString();
                tb_tc_kimilk_no.Text = dt.Rows[0]["tc_kimlik_no"].ToString();
                tb_sgk_no.Text = dt.Rows[0]["sgk_no"].ToString();
                tb_dogum_yeri.Text = dt.Rows[0]["dogum_yeri"].ToString();
                try { dt_dogum_tarihi.Value = Convert.ToDateTime(dt.Rows[0]["dogum_tarihi"]); } catch { }
                tb_anne_adi.Text = dt.Rows[0]["anne_adi"].ToString();
                tb_baba_adi.Text = dt.Rows[0]["baba_adi"].ToString();
                cmb_cinsiyet.EditValue = dt.Rows[0]["cinsiyet_parametre_id"];
                try { dt_ise_giris_tarihi.Value = Convert.ToDateTime(dt.Rows[0]["ise_giris_tarihi"]); } catch { }
                try { dt_isten_cikis_tarihi.Value = Convert.ToDateTime(dt.Rows[0]["isten_cikis_tarihi"]); } catch { }
                try { cb_isten_ayrildi.Checked = Convert.ToInt32(dt.Rows[0]["isten_ciktimi"]) == 1 ? true : false; } catch { }
                tb_cep_telefonu.Text = dt.Rows[0]["cep_telefonu"].ToString();
                tb_ev_telefonu.Text = dt.Rows[0]["ev_telefonu"].ToString();
                tb_eposta.Text = dt.Rows[0]["eposta"].ToString();
                tb_adres.Text = dt.Rows[0]["adres"].ToString();
                tb_acil_durum_kisisi.Text = dt.Rows[0]["acil_durum_kisisi"].ToString();
                tb_acil_durum_tel.Text = dt.Rows[0]["acil_durum_telefon"].ToString();
                tb_banka.Text = dt.Rows[0]["banka"].ToString();
                tb_sube.Text = dt.Rows[0]["sube"].ToString();
                tb_hesap_no.Text = dt.Rows[0]["hesap_no"].ToString();
                tb_iban.Text = dt.Rows[0]["iban"].ToString();
                tb_maas.Value = Convert.ToDecimal(dt.Rows[0]["maas"]);
                tb_sifre.Text = dt.Rows[0]["sifre"].ToString();
                cmb_personel_tipi.EditValue = dt.Rows[0]["personel_tipi_parametre_id"];
            }

            dt_isten_cikis_tarihi.Visible = label11.Visible = cb_isten_ayrildi.Checked;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(tb_ad.Text.Length <= 0)
            {
                new mesaj("Ad Giriniz!").ShowDialog();
                return;
            }
            if (tb_soyad.Text.Length <= 0)
            {
                new mesaj("Soyad Giriniz!").ShowDialog();
                return;
            }

            if(Convert.ToInt32(SQL.get("SELECT COUNT(*) FROM kullanicilar WHERE silindi = 0 AND sifre = '" + tb_sifre.Text + "' AND kullanici_id != " + personel_id).Rows[0][0]) != 0 && tb_sifre.Text != "")
            {
                new mesaj("Şifre başka kullanıcı tarafında kullanılmaktadır!").ShowDialog();
                return;
            }

            if (personel_id == 0)
                SQL.set("INSERT INTO kullanicilar " +
                    " ([ad], [soyad], [sifre], [maas], [tc_kimlik_no], [sgk_no], [dogum_yeri], [dogum_tarihi], [baba_adi], [anne_adi], [cinsiyet_parametre_id], [ise_giris_tarihi], [isten_cikis_tarihi], " +
                    " [isten_ciktimi], [cep_telefonu], [ev_telefonu], [eposta], [adres], [acil_durum_kisisi], [acil_durum_telefon], [banka], [sube], [hesap_no], [iban], [personel_tipi_parametre_id]) " + 
                    " VALUES ('" + tb_ad.Text + "', '" + tb_soyad.Text + "', '" + tb_sifre.Text + "', " + tb_maas.Value.ToString().Replace(',', '.') + ", '" + tb_tc_kimilk_no.Text + "', " + 
                    " '" + tb_sgk_no.Text + "', '" + tb_dogum_yeri.Text + "', '" + dt_dogum_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + tb_baba_adi.Text + "', " + 
                    " '" + tb_anne_adi.Text + "', " + cmb_cinsiyet.EditValue + ", '" + dt_ise_giris_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + dt_dogum_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + 
                    " " + (cb_isten_ayrildi.Checked ? "1":"0") + ", '" + tb_cep_telefonu.Text + "', '" + tb_ev_telefonu.Text + "', '" + tb_eposta.Text + "', '" + tb_adres.Text + "', " + 
                    " '" + tb_acil_durum_kisisi.Text + "', '" + tb_acil_durum_tel.Text + "', '" + tb_banka.Text + "', '" + tb_sube.Text + "', '" + tb_hesap_no.Text + "', '" + tb_iban.Text + "', " + cmb_personel_tipi.EditValue + ")");
            else
                SQL.set("UPDATE kullanicilar SET " + 
                    "ad = '" + tb_ad.Text + "', " + 
                    "soyad = '" + tb_soyad.Text + "', " + 
                    "sifre = '" + tb_sifre.Text + "', " + 
                    "maas = " + tb_maas.Value.ToString().Replace(',', '.') + ", " +
                    "[tc_kimlik_no] = '" + tb_tc_kimilk_no.Text + "', " +
                    "[sgk_no] = '" + tb_sgk_no.Text + "', " +
                    "[dogum_yeri] = '" + tb_dogum_yeri.Text + "', " +
                    "[dogum_tarihi] = '" + dt_dogum_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
                    "[baba_adi] = '" + tb_baba_adi.Text + "', " +
                    "[anne_adi] = '" + tb_anne_adi.Text + "', " +
                    "[cinsiyet_parametre_id] = " + cmb_cinsiyet.EditValue + ", " +
                    "[ise_giris_tarihi] = '" + dt_ise_giris_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
                    "[isten_cikis_tarihi] = '" + dt_dogum_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
                    "[isten_ciktimi] = " + (cb_isten_ayrildi.Checked ? "1" : "0") + ", " +
                    "[cep_telefonu] = '" + tb_cep_telefonu.Text + "', " +
                    "[ev_telefonu] = '" + tb_ev_telefonu.Text + "', " +
                    "[eposta] = '" + tb_eposta.Text + "', " +
                    "[adres] = '" + tb_adres.Text + "', " +
                    "[acil_durum_kisisi] = '" + tb_acil_durum_kisisi.Text + "', " +
                    "[acil_durum_telefon] = '" + tb_acil_durum_tel.Text + "', " +
                    "[banka] = '" + tb_banka.Text + "', " +
                    "[sube] = '" + tb_sube.Text + "', " +
                    "[hesap_no] = '" + tb_hesap_no.Text + "', " +
                    "[iban] = '" + tb_iban.Text + "', " +
                    "[personel_tipi_parametre_id] = " + cmb_personel_tipi.EditValue + " " +
                    "WHERE kullanici_id = " + personel_id);

            this.Close();
        }

        private void cb_isten_ayrildi_CheckedChanged(object sender, EventArgs e)
        {
            dt_isten_cikis_tarihi.Visible = label11.Visible = cb_isten_ayrildi.Checked;
        }
    }
}
