using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace sotec_pos
{
    public partial class rp_hedefte_yazdir : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_hedefte_yazdir(int adisyon_id, int hedef_id)
        {
            InitializeComponent();

            DataTable dt_adisyon_kalem = SQL.get(
                "SELECT " + 
                "   a.kayit_tarihi, " + 
                "   kullanici = k.ad + ' ' + k.soyad, " + 
                "   ak.aciklama, " + 
                "   ak.adisyon_id, " + 
                "   m.masa_adi, " + 
                "   ak.adisyon_kalem_id, " + 
                "   u.urun_adi, " + 
                "   ak.miktar, " + 
                "   ak.ikram_miktar, " + 
                "   tutar = (ak.miktar - ak.ikram_miktar) * u.fiyat, " + 
                "   olcu_birimi = p.deger, " + 
                "   ak.durum_parametre_id, " + 
                "   durum = dr.deger, " +
                "   sicak_satis = '<ul>' + STUFF(ISNULL((SELECT '<li ' + (CASE ISNULL(uh.urun_id, 0) WHEN 0 THEN 'style=''text-decoration: line-through;''' ELSE '' END) + ' >' + (CASE ISNULL(uh.urun_id, 0) WHEN 0 THEN '(-)' ELSE '' END) + u1.urun_adi + '</li>' FROM urunler_recete ur INNER JOIN urunler u1 ON u1.urun_id = ur.recete_urunu_id LEFT OUTER JOIN urunler_hareket uh ON uh.silindi = 0 AND uh.referans_id = ak.adisyon_kalem_id AND uh.urun_id = u1.urun_id WHERE ur.silindi = 0 AND ur.receteli_urun_id = u.urun_id FOR XML PATH (''), TYPE).value('.', 'VARCHAR(max)'), ''), 1, 0, '') + '</ul>', " +
                "   kurye = kurye.ad + ' ' + kurye.soyad, " + 
                "   a.ad_soyad, " +
                "   adres_id = a.adres, " +
                "   mst.adres, " +
                "   mst.adres_2, " +
                "   mst.adres_3, " +
                "   mst.telefon " +
                "FROM " + 
                "   adisyon_kalem ak " + 
                "   INNER JOIN urunler u ON u.urun_id = ak.urun_id " + "" +
                "   INNER JOIN parametreler p ON p.parametre_id = u.olcu_birimi_parametre_id " + 
                "   INNER JOIN parametreler dr ON dr.parametre_id = ak.durum_parametre_id " +
                "   INNER JOIN adisyon a ON a.adisyon_id = ak.adisyon_id " + 
                "   LEFT OUTER JOIN masalar m ON m.masa_id = a.masa_id " + 
                "   INNER JOIN kullanicilar k ON k.kullanici_id = ak.kaydeden_kullanici_id " + 
                "   LEFT OUTER JOIN kullanicilar kurye ON kurye.kullanici_id = a.kurye_kullanici_id " +
                "   LEFT OUTER JOIN musteri mst ON mst.musteri_id = a.musteri_id " +
                "WHERE " + 
                "   ak.silindi = 0 " + 
                "   AND ak.durum_parametre_id = 51 " + "" +
                "   AND ak.adisyon_id = " + adisyon_id + 
                "   AND u.hedef_id = " + hedef_id);
            this.DataSource = dt_adisyon_kalem;

            lbl_fis_acilis_tarihi.Text = dt_adisyon_kalem.Rows[0]["kayit_tarihi"].ToString();
            lbl_masa_adi.Text = dt_adisyon_kalem.Rows[0]["masa_adi"].ToString();
            lbl_acan_kullanici.Text = dt_adisyon_kalem.Rows[0]["kullanici"].ToString();
            lbl_siparis_giren.Text = dt_adisyon_kalem.Rows[0]["kullanici"].ToString();
            lbl_siparis_saati.Text = DateTime.Now.ToShortTimeString();

            lbl_adres_bilgileri.Text =
                (dt_adisyon_kalem.Rows[0]["kurye"].ToString().Length > 2 ? "KURYE : " + dt_adisyon_kalem.Rows[0]["kurye"].ToString() + "\n" : "") +
                (dt_adisyon_kalem.Rows[0]["ad_soyad"].ToString().Length > 2 ? "İSİM : " + dt_adisyon_kalem.Rows[0]["ad_soyad"].ToString() + "\n" : "") +
                (dt_adisyon_kalem.Rows[0]["telefon"].ToString().Length > 2 ? "TEL : " + dt_adisyon_kalem.Rows[0]["telefon"].ToString() + "\n" : "") +
                (dt_adisyon_kalem.Rows[0][(dt_adisyon_kalem.Rows[0]["adres_id"].ToString() == "1" ? "adres" : "adres_" + dt_adisyon_kalem.Rows[0]["adres_id"].ToString())].ToString().Length > 0 ? "ADRES : " + dt_adisyon_kalem.Rows[0][(dt_adisyon_kalem.Rows[0]["adres_id"].ToString() == "1" ? "adres" : "adres_" + dt_adisyon_kalem.Rows[0]["adres_id"].ToString())].ToString() + "\n" : "");

            XRBinding binding0 = new XRBinding("Text", this.DataSource, "urun_adi", "");
            tc_urun_adi.DataBindings.Add(binding0);
            XRBinding binding1 = new XRBinding("Text", this.DataSource, "miktar", "x {0:0.##}");
            tc_miktar.DataBindings.Add(binding1);
            XRBinding binding2 = new XRBinding("Text", this.DataSource, "aciklama", "");
            lbl_siparis_notu.DataBindings.Add(binding2);
            XRBinding binding3 = new XRBinding("Html", this.DataSource, "sicak_satis", "");
            tb_sicak_satis.DataBindings.Add(binding3);
        }
    }
}
