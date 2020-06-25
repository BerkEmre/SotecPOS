using DevExpress.XtraGrid.Views.Tile.ViewInfo;
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
    public partial class pos_gecmis : Form
    {
        public pos_gecmis()
        {
            InitializeComponent();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pos_gecmis_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT a.kayit_tarihi, a.adisyon_id, a.kapandi, a.masa_id, m.masa_adi, durum = CASE a.kapandi WHEN 1 THEN 'Kapalı' WHEN 0 THEN 'Açık' END FROM adisyon a INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE a.silindi = 0 AND a.kapandi = 1 AND a.kayit_tarihi BETWEEN Convert(date, DATEADD(DAY, -1, getdate())) AND DATEADD(DAY, 1, Convert(date, getdate())) ORDER by kayit_tarihi DESC");
            grid_masalar.DataSource = dt;
        }

        private void tv_masalar_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            DataRow dr = tv_masalar.GetDataRow(e.RowHandle);
            if (dr["kapandi"].ToString() != "0")
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.BlanchedAlmond;
            }
        }

        private void grid_masalar_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = tv_masalar.GetDataRow(tv_masalar.GetSelectedRows()[0]);

            DialogResult dialogResult = MessageBox.Show("Kapanmış masayı tekrar açmak istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if(SQL.get("SELECT * FROM adisyon a WHERE a.silindi = 0 AND a.kapandi = 0 AND a.masa_id = " + dr["masa_id"]).Rows.Count > 0)
                {
                    new mesaj("Masada aktif işlem var\naktif masayı başka masaya taşıyın\nsonra tekrar deneyin!").ShowDialog();
                    return;
                }

                SQL.set("UPDATE adisyon SET kapandi = 0 WHERE adisyon_id = " + dr["adisyon_id"]);

                DataTable dt = SQL.get("SELECT a.kayit_tarihi, a.adisyon_id, a.kapandi, a.masa_id, m.masa_adi, durum = CASE a.kapandi WHEN 1 THEN 'Kapalı' WHEN 0 THEN 'Açık' END FROM adisyon a INNER JOIN masalar m ON m.masa_id = a.masa_id WHERE a.silindi = 0 AND a.kayit_tarihi BETWEEN Convert(date, DATEADD(DAY, -1, getdate())) AND DATEADD(DAY, 1, Convert(date, getdate())) ORDER by kayit_tarihi DESC");
                grid_masalar.DataSource = dt;
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl == grid_masalar)
            {
                TileViewHitInfo hi = tv_masalar.CalcHitInfo(e.ControlMousePosition);
                if (hi.HitTest == DevExpress.XtraEditors.TileControlHitTest.Item)
                {
                    foreach (TileViewElementInfo elemInfo in hi.ItemInfo.Elements)
                    {
                        string val = "";
                        decimal top_tutar = 0, odenen = 0;
                        
                        if (tv_masalar.GetDataRow(hi.RowHandle)["adisyon_id"].ToString() != "0")
                        {
                            DataTable dt_adisyon_kalem = SQL.get("SELECT ak.adisyon_kalem_id, u.urun_adi, ak.miktar, ak.ikram_miktar, tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, olcu_birimi = p.deger, ak.durum_parametre_id, durum = dr.deger FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + tv_masalar.GetDataRow(hi.RowHandle)["adisyon_id"]);
                            for (int i = 0; i < dt_adisyon_kalem.Rows.Count; i++)
                            {
                                val += dt_adisyon_kalem.Rows[i]["urun_adi"].ToString() + " x " + Convert.ToDecimal(dt_adisyon_kalem.Rows[i]["miktar"]).ToString("n2") + " = " + Convert.ToDecimal(dt_adisyon_kalem.Rows[i]["tutar"]).ToString("c2") + "\n";
                            }

                            DataTable dt_adisyon_fiyat = SQL.get("SELECT top_tutar = ISNULL(SUM((ak.miktar - ak.ikram_miktar) * u.fiyat), 0.0000) FROM adisyon_kalem ak INNER JOIN urunler u ON u.urun_id = ak.urun_id WHERE ak.silindi = 0 AND ak.adisyon_id = " + tv_masalar.GetDataRow(hi.RowHandle)["adisyon_id"]);
                            top_tutar = Convert.ToDecimal(dt_adisyon_fiyat.Rows[0]["top_tutar"]);
                            DataTable dt_finans = SQL.get("SELECT top_tutar = ISNULL(SUM(miktar), 0.0000) FROM finans_hareket WHERE silindi = 0 AND hareket_tipi_parametre_id IN (25, 26, 27, 59) AND referans_id = " + tv_masalar.GetDataRow(hi.RowHandle)["adisyon_id"]);
                            odenen = Convert.ToDecimal(dt_finans.Rows[0]["top_tutar"]);
                            val += "\n--------------------------------------------------------------------------------------\nTop: " + (odenen).ToString("c2");
                        }
                        /*if (elemInfo.TextBounds.Contains(e.ControlMousePosition))
                        {*/
                        e.Info = new DevExpress.Utils.ToolTipControlInfo(elemInfo, val);
                        /*break;
                    }*/
                    }
                }
            }
        }
    }
}
