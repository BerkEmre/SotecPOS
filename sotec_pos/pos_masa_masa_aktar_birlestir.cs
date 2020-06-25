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
    public partial class pos_masa_masa_aktar_birlestir : Form
    {
        int masa_id, adisyon_kalem_id;
        public pos_masa_masa_aktar_birlestir(int masa_id, int adisyon_kalem_id)
        {
            this.masa_id = masa_id;
            this.adisyon_kalem_id = adisyon_kalem_id;

            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pos_masa_masa_aktar_birlestir_Load(object sender, EventArgs e)
        {
            DataTable dt_masalar = SQL.get("SELECT m.masa_id, m.masa_adi, acik_mi = CASE ISNULL(a.adisyon_id, 0) WHEN 0 THEN 0 ELSE 1 END FROM masalar m LEFT OUTER JOIN adisyon a ON a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = m.masa_id WHERE m.silindi = 0 AND m.masa_id <> " + masa_id + " ORDER by m.masa_adi");
            grid_masalar.DataSource = dt_masalar;

            try
            {
                DataTable dt_masa = SQL.get("SELECT masa_adi, masa_id FROM masalar WHERE masa_id = " + masa_id);
                lbl_masa.Text = masa_id == 0 ? "SELF SERVİS" : dt_masa.Rows[0]["masa_adi"].ToString();
            }
            catch
            {

            }
        }

        private void grid_masalar_DoubleClick(object sender, EventArgs e)
        {
            int aktarilacak_masa_id = Convert.ToInt32(tv_masalar.GetDataRow(tv_masalar.GetSelectedRows()[0])["masa_id"].ToString());

            DataTable dt_adisyon = SQL.get("SELECT * FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + masa_id);
            DataTable dt_adisyon_aktarilacak = SQL.get("SELECT * FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + aktarilacak_masa_id);

            if(adisyon_kalem_id == 0)
            {
                if (dt_adisyon_aktarilacak.Rows.Count <= 0)
                {
                    SQL.set("UPDATE adisyon SET masa_id = " + aktarilacak_masa_id + " WHERE adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                }
                else
                {
                    SQL.set("UPDATE adisyon_kalem SET adisyon_id =  " + dt_adisyon_aktarilacak.Rows[0]["adisyon_id"] + " WHERE adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                    SQL.set("UPDATE adisyon SET silindi = 1 WHERE adisyon_id = " + dt_adisyon.Rows[0]["adisyon_id"]);
                }
            }
            else
            {
                if (dt_adisyon_aktarilacak.Rows.Count <= 0)
                {
                    SQL.set("INSERT INTO adisyon (masa_id) VALUES (" + aktarilacak_masa_id + ")");
                    dt_adisyon_aktarilacak = SQL.get("SELECT * FROM adisyon WHERE silindi = 0 AND kapandi = 0 AND masa_id = " + aktarilacak_masa_id);
                }
                SQL.set("UPDATE adisyon_kalem SET adisyon_id =  " + dt_adisyon_aktarilacak.Rows[0]["adisyon_id"] + " WHERE adisyon_kalem_id = " + adisyon_kalem_id);
            }

            this.Close();
        }
    }
}
