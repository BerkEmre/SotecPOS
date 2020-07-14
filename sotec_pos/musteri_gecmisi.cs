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
    public partial class musteri_gecmisi : Form
    {
        int musteri_id;
        public musteri_gecmisi(int musteri_id)
        {
            InitializeComponent();

            this.musteri_id = musteri_id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void musteri_gecmisi_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT * FROM musteri WHERE musteri_id = " + musteri_id);
            label1.Text = dt.Rows[0]["ad_soyad"].ToString();

            dt = SQL.get("SELECT a.ad_soyad, u.urun_adi, a.kayit_tarihi, ak.miktar FROM adisyon a INNER JOIN adisyon_kalem ak ON ak.adisyon_id = a.adisyon_id AND ak.silindi = 0 INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE a.silindi = 0 AND a.musteri_id = " + musteri_id);
            grid_urunler.DataSource = dt;
        }
    }
}
