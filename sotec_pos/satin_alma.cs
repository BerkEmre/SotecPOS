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
    public partial class satin_alma : Form
    {
        public satin_alma()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(18))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            finans_satin_alma_fatura f = new finans_satin_alma_fatura();
            f.FormClosing += F_FormClosing;
            f.ShowDialog();
        }

        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = SQL.get("SELECT s.siparis_id, siparis_durum = siparis_durumu.deger, s.tahmini_teslim_tarihi, sk.siparis_kalem_id, u.urun_adi, sk.miktar, olcu_birimi = olcu_birimi.deger, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id) FROM urunler_siparis s INNER JOIN urunler_siparis_kalem sk ON sk.siparis_id = s.siparis_id AND sk.silindi = 0 AND sk.kapandi = 0 INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler olcu_birimi ON olcu_birimi.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler siparis_durumu ON siparis_durumu.parametre_id = s.durum_parametre_id WHERE s.silindi = 0 AND s.durum_parametre_id IN (18, 19)");
            grid_urunler.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(19))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urunler_irsaliye i = new urunler_irsaliye();
            i.FormClosing += F_FormClosing;
            i.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!SQL.yetki_kontrol(20))
            {
                new mesaj("Yetkiniz Yok!").ShowDialog();
                return;
            }

            urunler_siparis s = new urunler_siparis();
            s.FormClosing += F_FormClosing;
            s.ShowDialog();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void satin_alma_Load(object sender, EventArgs e)
        {
            DataTable dt = SQL.get("SELECT c.cari_adi, s.siparis_id, siparis_durum = siparis_durumu.deger, s.tahmini_teslim_tarihi, sk.siparis_kalem_id, u.urun_adi, sk.miktar, olcu_birimi = olcu_birimi.deger, gelen_miktar = (SELECT SUM(miktar) FROM urunler_irsaliye_kalem ik WHERE ik.silindi = 0 AND ik.referans_siparis_kalem_id = sk.siparis_kalem_id) FROM urunler_siparis s INNER JOIN urunler_siparis_kalem sk ON sk.siparis_id = s.siparis_id AND sk.silindi = 0 AND sk.kapandi = 0 INNER JOIN urunler u ON u.urun_id = sk.urun_id INNER JOIN parametreler olcu_birimi ON olcu_birimi.parametre_id = u.olcu_birimi_parametre_id INNER JOIN parametreler siparis_durumu ON siparis_durumu.parametre_id = s.durum_parametre_id INNER JOIN cariler c ON c.cari_id = s.cari_id WHERE s.silindi = 0 AND s.durum_parametre_id IN (18, 19)");
            grid_urunler.DataSource = dt;
        }
    }
}
