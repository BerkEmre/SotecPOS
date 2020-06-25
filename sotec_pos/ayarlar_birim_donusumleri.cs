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
    public partial class ayarlar_birim_donusumleri : Form
    {
        int donusum_id = 0;
        public ayarlar_birim_donusumleri(int donusum_id)
        {
            InitializeComponent();

            this.donusum_id = donusum_id;
        }

        private void ayarlar_birim_donusumleri_Load(object sender, EventArgs e)
        {
            DataTable dt_cinsiyet = SQL.get("SELECT * FROM parametreler WHERE silindi = 0 AND tip = 'olcu_birimi'");
            cmb_kaynak_birim.Properties.DataSource = dt_cinsiyet;
            cmb_kaynak_birim.EditValue = dt_cinsiyet.Rows[0]["parametre_id"];
            cmb_hedef_birim.Properties.DataSource = dt_cinsiyet;
            cmb_hedef_birim.EditValue = dt_cinsiyet.Rows[0]["parametre_id"];

            if(donusum_id != 0)
            {
                DataTable dt_donusum = SQL.get("SELECT * FROM katsayi_donusum WHERE donusum_id = " + donusum_id);
                cmb_kaynak_birim.EditValue = dt_donusum.Rows[0]["parametre_1_id"].ToString();
                cmb_hedef_birim.EditValue = dt_donusum.Rows[0]["parametre_2_id"].ToString();
                tb_katsayi.Value = Convert.ToDecimal(dt_donusum.Rows[0]["katsayi"]);
            }
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            DataTable dt_control = SQL.get("SELECT * FROM katsayi_donusum WHERE silindi = 0 AND parametre_1_id = " + cmb_kaynak_birim.EditValue + " AND parametre_2_id = " + cmb_hedef_birim.EditValue + " AND donusum_id != " + donusum_id);
            if(dt_control.Rows.Count > 0)
            {
                new mesaj("Girdiğiniz dönüşüm daha önceden tanımlanmıştır!").ShowDialog();
                return;
            }

            if (donusum_id != 0)
                SQL.set("UPDATE katsayi_donusum SET parametre_1_id = " + cmb_kaynak_birim.EditValue + ", parametre_2_id = " + cmb_hedef_birim.EditValue + ", katsayi = " + tb_katsayi.Value.ToString().Replace(',', '.') + " WHERE donusum_id = " + donusum_id);
            else
                SQL.set("INSERT INTO katsayi_donusum (kaydeden_kullanici_id, parametre_1_id, parametre_2_id, katsayi) VALUES (" + SQL.kullanici_id + ", " + cmb_kaynak_birim.EditValue + ", " + cmb_hedef_birim.EditValue + ", " + tb_katsayi.Value.ToString().Replace(',', '.') + ")");
            this.Close();
        }
    }
}
