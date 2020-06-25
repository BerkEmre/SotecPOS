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
    public partial class pos_masa_kurye_sec : Form
    {
        int adisyon_id = 0;
        public pos_masa_kurye_sec(int adisyon_id)
        {
            InitializeComponent();

            this.adisyon_id = adisyon_id;
        }

        private void pos_masa_kurye_sec_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT kullanici_id, ad_soyad = ad + ' ' + soyad FROM kullanicilar WHERE silindi = 0 AND personel_tipi_parametre_id = 64");
            grid_masalar.DataSource = dt;
        }

        private void grid_masalar_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gv_masalar.GetFocusedDataRow();

            SQL.set("UPDATE adisyon SET kurye_kullanici_id = " + dr["kullanici_id"] + " WHERE adisyon_id = " + adisyon_id);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
