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
    public partial class urunler_receteli_uretimler : Form
    {
        public urunler_receteli_uretimler()
        {
            InitializeComponent();
        }

        private void urunler_receteli_uretimler_Load(object sender, EventArgs e)
        {
            DataTable dt_hedef = SQL.get("SELECT olcu_birimi = olcu.deger, miktar = 0.0000, u.urun_id, u.urun_adi, resim = 'urun_resimleri/' + u.resim, u.fiyat, k.kategori_adi, ust_kategori_adi = uk.kategori_adi FROM urunler u INNER JOIN kategoriler k ON k.kategori_id = u.kategori_id INNER JOIN kategoriler uk ON uk.kategori_id = k.ust_kategori_id INNER JOIN parametreler olcu ON olcu.parametre_id = u.olcu_birimi_parametre_id WHERE u.silindi = 0 AND u.receteli_urun = 1 ORDER by uk.kategori_adi, k.kategori_adi, u.urun_adi");
            if (dt_hedef.Rows.Count <= 0)
            {
                new mesaj("Reçeteli ürün girmeden reçete giremezsiniz!").ShowDialog();
                this.Close();
                return;
            }
            cmb_hedef.Properties.DataSource = dt_hedef;
            cmb_hedef.EditValue = dt_hedef.Rows[0]["urun_id"];
        }

        private void cmb_hedef_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt_recete = SQL.get("SELECT ur.recete_id, u.urun_id, u.urun_adi, miktar = (ur.miktar * " + tb_miktar.Value.ToString().Replace(',', '.') + "), olcu_birimi = p.deger FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + cmb_hedef.EditValue);
            grid_recete.DataSource = dt_recete;
        }

        private void tb_miktar_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt_recete = SQL.get("SELECT ur.recete_id, u.urun_id, u.urun_adi, miktar = (ur.miktar * " + tb_miktar.Value.ToString().Replace(',', '.') + "), olcu_birimi = p.deger FROM urunler_recete ur INNER JOIN urunler u ON u.urun_id = ur.recete_urunu_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = " + cmb_hedef.EditValue);
            grid_recete.DataSource = dt_recete;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tb_miktar.Value <= 0)
            {
                new mesaj("Miktar giriniz!").ShowDialog();
                return;
            }

            DataRow dr;

            DataTable dt_uh = SQL.get("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + cmb_hedef.EditValue + ", 15, " + tb_miktar.Value.ToString().Replace(',', '.') + ", 0, 0.0000); SELECT SCOPE_IDENTITY();");
            for (int i = 0; i < gv_recete.RowCount; i++)
            {
                dr = gv_recete.GetDataRow(i);
                if(Convert.ToDecimal(dr["miktar"]) != 0)
                {
                    SQL.set("INSERT INTO urunler_hareket (urun_id, hareket_tipi_parametre_id, miktar, referans_id, birim_fiyat) VALUES (" + dr["urun_id"] + ", 15, " + (Convert.ToDecimal(dr["miktar"]) * -1).ToString().Replace(',', '.') + ", " + dt_uh.Rows[0][0] + ", 0.0000)");
                }
            }

            this.Close();
        }
    }
}
