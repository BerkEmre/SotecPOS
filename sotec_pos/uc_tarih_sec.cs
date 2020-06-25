using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace sotec_pos
{
    public partial class uc_tarih_sec : DevExpress.XtraEditors.XtraUserControl
    {
        public DateTime ilk_tarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime son_tarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public uc_tarih_sec()
        {
            InitializeComponent();
        }

        private void dt_ilk_tarih_EditValueChanged(object sender, EventArgs e)
        {
            ilk_tarih = dt_ilk_tarih.DateTime;
        }

        private void dt_son_tarih_EditValueChanged(object sender, EventArgs e)
        {
            son_tarih = dt_son_tarih.DateTime;
        }

        private void btn_dun_Click(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-1);
            dt_son_tarih.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dt_son_tarih.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DateTime dt_Hafta = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            switch ((int)dt_Hafta.DayOfWeek)
            {
                case 0://Haftanın ilk günü Pazar kabul edildiğinden
                    dt_ilk_tarih.EditValue = dt_Hafta.AddDays(-6).AddDays(-7); // İçinde olduğumuz haftanın başı Pazartesi
                    dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddDays(6); // Sonraki haftanın başı Pazartesi
                    break;

                default:// Gün Pazar değilse;
                    dt_ilk_tarih.EditValue = dt_Hafta.AddDays(1 - (int)dt_Hafta.DayOfWeek).AddDays(-7); // İçinde olduğumuz haftanın başı Pazartesi
                    dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddDays(6); //  Sonraki haftanın başı Pazartesi
                    break;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DateTime dt_Hafta = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            switch ((int)dt_Hafta.DayOfWeek)
            {
                case 0://Haftanın ilk günü Pazar kabul edildiğinden
                    dt_ilk_tarih.EditValue = dt_Hafta.AddDays(-6); // İçinde olduğumuz haftanın başı Pazartesi
                    dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddDays(6); // Sonraki haftanın başı Pazartesi
                    break;

                default:// Gün Pazar değilse;
                    dt_ilk_tarih.EditValue = dt_Hafta.AddDays(1 - (int)dt_Hafta.DayOfWeek); // İçinde olduğumuz haftanın başı Pazartesi
                    dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddDays(6); //  Sonraki haftanın başı Pazartesi
                    break;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1); // Ay ilk günü
            dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddMonths(1).AddDays(-1);// Ay son günü
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Ay ilk günü
            dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddMonths(1).AddDays(-1);// Ay son günü
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-1); // Yılın ilk günü
            dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddYears(1).AddDays(-1); // Yılın son günü
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = new DateTime(DateTime.Now.Year, 1, 1); // Yılın ilk günü
            dt_son_tarih.EditValue = dt_ilk_tarih.DateTime.AddYears(1).AddDays(-1); // Yılın son günü
        }

        private void uc_tarih_sec_Load(object sender, EventArgs e)
        {
            dt_ilk_tarih.EditValue = ilk_tarih;
            dt_son_tarih.EditValue = son_tarih;
        }
    }
}
