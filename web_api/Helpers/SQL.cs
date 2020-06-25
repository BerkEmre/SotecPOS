using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web_api.Helpers
{
    public static class SQL
    {
        public static string ad, soyad;
        public static int kullanici_id;

        static string text;// = System.IO.File.ReadAllText(@"constr.txt");
        static SqlConnection con;// = new SqlConnection(@text);

        public static bool baglanti_test()
        {

            try
            {
                text = System.IO.File.ReadAllText(@"C:\constr.txt");
                con = new SqlConnection(@text);
                SQL.get("SELECT * FROM kullanicilar"); return true;
            }
            catch { return false; }
        }

        public static DataTable get(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.Close();
            return dt;
        }

        public static void set(string query)
        {
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static bool yetki_kontrol(int yetki_id)
        {
            if (ad == "ADMİN" && soyad == "")
                return true;

            DataTable dt = SQL.get("SELECT COUNT(*) FROM kullanicilar_yetki WHERE silindi = 0 AND kullanici_id = " + kullanici_id + " AND yetki_id = " + yetki_id);
            if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                return false;
            else
                return true;
        }
    }
}