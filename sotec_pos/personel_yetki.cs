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
    public partial class personel_yetki : Form
    {
        int kullanici_id = 0;

        public personel_yetki(int kullanici_id, string kullanici_adi)
        {
            InitializeComponent();

            lbl_kullanici_adi.Text = kullanici_adi;
            this.kullanici_id = kullanici_id;
        }

        private void personel_yetki_Load(object sender, EventArgs e)
        {
            DataTable dt_yetkiler = SQL.get("SELECT y.yetki_id, y.ust_yetki_id, y.yetki_adi, kullanici_yetki = CASE ISNULL(ky.kullanici_yetki_id, 0) WHEN 0 THEN CAST(0 as BIT) ELSE CAST(1 as BIT) END FROM yetkiler y LEFT OUTER JOIN kullanicilar_yetki ky ON ky.yetki_id = y.yetki_id AND ky.silindi = 0 AND ky.kullanici_id = " + kullanici_id + " WHERE y.silindi = 0");
            tl_yetkiler.DataSource = dt_yetkiler;
            tl_yetkiler.ExpandAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr;

            for (int i = 0; i < tl_yetkiler.AllNodesCount; i++)
            {
                dr = tl_yetkiler.GetDataRow(i);

                if (Convert.ToInt32(dr["kullanici_yetki"]) == 1)
                {
                    DataTable dt = SQL.get("SELECT * FROM kullanicilar_yetki WHERE silindi = 0 AND kullanici_id = " + kullanici_id + " AND yetki_id = " + dr["yetki_id"]);
                    if(dt.Rows.Count <= 0)
                        SQL.set("INSERT INTO kullanicilar_yetki (kullanici_id, yetki_id) VALUES (" + kullanici_id + ", " + dr["yetki_id"] + ")");
                }
                else
                    SQL.set("UPDATE kullanicilar_yetki SET silindi = 1 WHERE kullanici_id = " + kullanici_id + " AND yetki_id = " + dr["yetki_id"] + " AND silindi = 0");

                this.Close();
            }
        }
    }
}
