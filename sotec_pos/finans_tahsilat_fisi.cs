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
    public partial class finans_tahsilat_fisi : Form
    {
        int secili_tahsilat_id;
        public finans_tahsilat_fisi()
        {
            InitializeComponent();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            secili_tahsilat_id = 0;
            tb_no.Text = "";
            tb_tutar.Value = 0;
            btn_log_out.Text = "KAYDET";
            btn_iptal.Visible = false;
        }

        private void finans_tahsilat_fisi_Load(object sender, EventArgs e)
        {
            DataTable dt_p = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'tahsilat_tipi'");
            cmb_tahsilat_tipi.Properties.DataSource = dt_p;
            cmb_tahsilat_tipi.EditValue = dt_p.Rows[0]["parametre_id"];

            DataTable dt_cari = SQL.get("SELECT * FROM cariler WHERE silindi = 0");
            if (dt_cari.Rows.Count <= 0)
            {
                new mesaj("Cari girmeden tahsilat fişi giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            cmb_cariler.Properties.DataSource = dt_cari;
            cmb_cariler.EditValue = dt_cari.Rows[0]["cari_id"];

            DataTable dt_tahsilatlar = SQL.get("SELECT ft.tahsilat_id, ft.kayit_tarihi, ft.tahsilat_tarihi, ft.tahsilat_no, ft.tutar, c.cari_adi, tahsilat_tipi = p.deger FROM finans_tahsilat ft INNER JOIN cariler c ON c.cari_id = ft.cari_id INNER JOIN parametreler p ON p.parametre_id = ft.tahsilat_tipi_parametre_id WHERE ft.silindi = 0");
            grid_tahsilat.DataSource = dt_tahsilatlar;
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            if(tb_tutar.Value <= 0)
            {
                new mesaj("Tutar 0 girilemez!").Show();
                return;
            }

            if(secili_tahsilat_id == 0)
            {
                DataTable dt_t;
                if (Convert.ToInt32(cmb_tahsilat_tipi.EditValue) == 35)//Tahsilat
                {
                    dt_t = SQL.get("INSERT INTO finans_tahsilat (cari_id, tahsilat_tipi_parametre_id, tutar, tahsilat_tarihi, tahsilat_no) VALUES (" + cmb_cariler.EditValue + ", 35, " + tb_tutar.Value.ToString().Replace(',', '.') + ", '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + tb_no.Text + "'); SELECT SCOPE_IDENTITY();");
                    SQL.set("INSERT INTO cari_bakiye (cari_id, miktar, cari_bakiye_tipi, referans_id) VALUES (" + cmb_cariler.EditValue + ", " + (tb_tutar.Value * -1).ToString().Replace(',', '.') + ", 33, " + dt_t.Rows[0][0] + ")");
                    SQL.set("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (24, " + tb_tutar.Value.ToString().Replace(',', '.') + ", " + dt_t.Rows[0][0] + ")");
                }
                else if (Convert.ToInt32(cmb_tahsilat_tipi.EditValue) == 37)//Tediye
                {
                    dt_t = SQL.get("INSERT INTO finans_tahsilat (cari_id, tahsilat_tipi_parametre_id, tutar, tahsilat_tarihi, tahsilat_no) VALUES (" + cmb_cariler.EditValue + ", 37, " + tb_tutar.Value.ToString().Replace(',', '.') + ", '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + tb_no.Text + "'); SELECT SCOPE_IDENTITY();");
                    SQL.set("INSERT INTO cari_bakiye (cari_id, miktar, cari_bakiye_tipi, referans_id) VALUES (" + cmb_cariler.EditValue + ", " + tb_tutar.Value.ToString().Replace(',', '.') + ", 32, " + dt_t.Rows[0][0] + ")");
                    SQL.set("INSERT INTO finans_hareket (hareket_tipi_parametre_id, miktar, referans_id) VALUES (28, " + (tb_tutar.Value * -1).ToString().Replace(',', '.') + ", " + dt_t.Rows[0][0] + ")");
                }
            }
            else
            {
                if (Convert.ToInt32(cmb_tahsilat_tipi.EditValue) == 35)//Tahsilat
                {
                    SQL.set("UPDATE finans_tahsilat SET cari_id = " + cmb_cariler.EditValue + ", tutar = " + tb_tutar.Value.ToString().Replace(',', '.') + ", tahsilat_tarihi = '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', tahsilat_no = '" + tb_no.Text + "' WHERE tahsilat_id = " + secili_tahsilat_id);
                    SQL.set("UPDATE cari_bakiye SET cari_id = " + cmb_cariler.EditValue + ", miktar = " + (tb_tutar.Value * -1).ToString().Replace(',', '.') + " WHERE cari_bakiye_tipi = 33 AND referans_id = " + secili_tahsilat_id);
                    SQL.set("UPDATE finans_hareket SET miktar = " + tb_tutar.Value.ToString().Replace(',', '.') + " WHERE hareket_tipi_parametre_id = 24 AND referans_id = " + secili_tahsilat_id);
                }
                else if (Convert.ToInt32(cmb_tahsilat_tipi.EditValue) == 37)//Tediye
                {
                    SQL.set("UPDATE finans_tahsilat SET cari_id = " + cmb_cariler.EditValue + ", tutar = " + tb_tutar.Value.ToString().Replace(',', '.') + ", tahsilat_tarihi = '" + dt_teslim_tarihi.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', tahsilat_no = '" + tb_no.Text + "' WHERE tahsilat_id = " + secili_tahsilat_id);
                    SQL.set("UPDATE cari_bakiye SET cari_id = " + cmb_cariler.EditValue + ", miktar = " + tb_tutar.Value.ToString().Replace(',', '.') + " WHERE cari_bakiye_tipi = 32 AND referans_id = " + secili_tahsilat_id);
                    SQL.set("UPDATE finans_hareket SET miktar = " + (tb_tutar.Value * -1).ToString().Replace(',', '.') + " WHERE hareket_tipi_parametre_id = 28 AND referans_id = " + secili_tahsilat_id);
                }
            }

            DataTable dt_tahsilatlar = SQL.get("SELECT ft.tahsilat_id, ft.kayit_tarihi, ft.tahsilat_tarihi, ft.tahsilat_no, ft.tutar, c.cari_adi, tahsilat_tipi = p.deger FROM finans_tahsilat ft INNER JOIN cariler c ON c.cari_id = ft.cari_id INNER JOIN parametreler p ON p.parametre_id = ft.tahsilat_tipi_parametre_id WHERE ft.silindi = 0");
            grid_tahsilat.DataSource = dt_tahsilatlar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_tahsilat_Click(object sender, EventArgs e)
        {
            if (gv_tahsilat.SelectedRowsCount <= 0)
                return;

            DataTable dt_th = SQL.get("SELECT * FROM finans_tahsilat WHERE tahsilat_id = " + gv_tahsilat.GetDataRow(gv_tahsilat.GetSelectedRows()[0])["tahsilat_id"]);

            secili_tahsilat_id = Convert.ToInt32(dt_th.Rows[0]["tahsilat_id"]);
            cmb_cariler.EditValue = dt_th.Rows[0]["cari_id"];
            cmb_tahsilat_tipi.EditValue = dt_th.Rows[0]["tahsilat_tipi_parametre_id"];
            tb_tutar.Value = Convert.ToDecimal(dt_th.Rows[0]["tutar"]);
            dt_teslim_tarihi.Value = Convert.ToDateTime(dt_th.Rows[0]["tahsilat_tarihi"]);
            tb_no.Text = dt_th.Rows[0]["tahsilat_no"].ToString();

            btn_log_out.Text = "DÜZENLE";
            btn_iptal.Visible = true;
        }
    }
}
