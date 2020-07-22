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
    public partial class pos_masa_menu_sec : Form
    {
        int adisyon_id = 0;

        public pos_masa_menu_sec(int adisyon_id)
        {
            InitializeComponent();

            this.adisyon_id = adisyon_id;
        }

        private void pos_masa_menu_sec_Load(object sender, EventArgs e)
        {
            DataTable dt_menu = SQL.get("SELECT * FROM menuler WHERE silindi = 0");
            grid_menu.DataSource = dt_menu;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_menu_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            if (tv_menu.SelectedRowsCount <= 0)
                return;

            DataRow dr = tv_menu.GetFocusedDataRow();

            DataTable dt_urun_gruplari = SQL.get("SELECT mug.urun_grubu_id, mug.miktar FROM menu_urun_gruplari mug INNER JOIN urun_gruplari ug ON ug.silindi = 0 AND ug.urun_grubu_id = mug.urun_grubu_id WHERE mug.silindi = 0 AND mug.menu_id = " + dr["menu_id"]);
            bool ilk = true;
            for (int i = 0; i < dt_urun_gruplari.Rows.Count; i++)
            {
                for (int j = 0; j < Convert.ToInt32(dt_urun_gruplari.Rows[i]["miktar"]); j++)
                {
                    using (var form = new pos_masa_menu_urun_sec(Convert.ToInt32(dr["menu_id"]), Convert.ToInt32(dt_urun_gruplari.Rows[i]["urun_grubu_id"]), adisyon_id, (ilk ? Convert.ToDecimal(dr["fiyat"]) : 0)))
                    {
                        var result = form.ShowDialog();
                    }
                    ilk = false;
                }
            }

            this.Close();
        }
    }
}
