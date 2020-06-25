namespace sotec_pos
{
    partial class personel_gec_mesai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_ad_soyad = new System.Windows.Forms.Label();
            this.grid_personeller = new DevExpress.XtraGrid.GridControl();
            this.gv_personeller = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_tarih = new System.Windows.Forms.DateTimePicker();
            this.cmb_tip = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_dakika = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_log_out = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_personeller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_personeller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_tip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_dakika)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ad_soyad
            // 
            this.lbl_ad_soyad.AutoSize = true;
            this.lbl_ad_soyad.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_ad_soyad.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_ad_soyad.Location = new System.Drawing.Point(12, 9);
            this.lbl_ad_soyad.Name = "lbl_ad_soyad";
            this.lbl_ad_soyad.Size = new System.Drawing.Size(96, 33);
            this.lbl_ad_soyad.TabIndex = 34;
            this.lbl_ad_soyad.Text = "Ad Soyad";
            // 
            // grid_personeller
            // 
            this.grid_personeller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_personeller.Location = new System.Drawing.Point(12, 45);
            this.grid_personeller.MainView = this.gv_personeller;
            this.grid_personeller.Name = "grid_personeller";
            this.grid_personeller.Size = new System.Drawing.Size(816, 354);
            this.grid_personeller.TabIndex = 35;
            this.grid_personeller.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_personeller});
            this.grid_personeller.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_personeller_KeyDown);
            // 
            // gv_personeller
            // 
            this.gv_personeller.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gv_personeller.GridControl = this.grid_personeller;
            this.gv_personeller.Name = "gv_personeller";
            this.gv_personeller.OptionsBehavior.Editable = false;
            this.gv_personeller.OptionsView.ShowAutoFilterRow = true;
            this.gv_personeller.OptionsView.ShowFooter = true;
            this.gv_personeller.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Geç Mesai ID";
            this.gridColumn4.FieldName = "gec_mesai_id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tarih";
            this.gridColumn1.FieldName = "tarih";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Durum";
            this.gridColumn2.FieldName = "tip";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Dakika";
            this.gridColumn3.FieldName = "dakika";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dakika", "{0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(204, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 33);
            this.label6.TabIndex = 37;
            this.label6.Text = "Tarih";
            // 
            // dt_tarih
            // 
            this.dt_tarih.CalendarFont = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dt_tarih.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dt_tarih.Location = new System.Drawing.Point(276, 405);
            this.dt_tarih.Name = "dt_tarih";
            this.dt_tarih.Size = new System.Drawing.Size(272, 40);
            this.dt_tarih.TabIndex = 36;
            // 
            // cmb_tip
            // 
            this.cmb_tip.Location = new System.Drawing.Point(276, 451);
            this.cmb_tip.Name = "cmb_tip";
            this.cmb_tip.Properties.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_tip.Properties.Appearance.Options.UseFont = true;
            this.cmb_tip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_tip.Properties.DisplayMember = "deger";
            this.cmb_tip.Properties.ValueMember = "parametre_id";
            this.cmb_tip.Properties.View = this.gridLookUpEdit1View;
            this.cmb_tip.Size = new System.Drawing.Size(272, 40);
            this.cmb_tip.TabIndex = 45;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Parametre ID";
            this.gridColumn6.FieldName = "parametre_id";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tip";
            this.gridColumn7.FieldName = "deger";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(188, 454);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 33);
            this.label9.TabIndex = 46;
            this.label9.Text = "Durum";
            // 
            // tb_dakika
            // 
            this.tb_dakika.DecimalPlaces = 2;
            this.tb_dakika.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_dakika.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tb_dakika.Location = new System.Drawing.Point(276, 497);
            this.tb_dakika.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tb_dakika.Name = "tb_dakika";
            this.tb_dakika.Size = new System.Drawing.Size(272, 40);
            this.tb_dakika.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(186, 499);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 33);
            this.label4.TabIndex = 49;
            this.label4.Text = "Dakika";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(556, 444);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 41);
            this.button1.TabIndex = 51;
            this.button1.Text = "İPTAL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_log_out
            // 
            this.btn_log_out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_log_out.BackColor = System.Drawing.Color.DimGray;
            this.btn_log_out.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_log_out.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_log_out.FlatAppearance.BorderSize = 5;
            this.btn_log_out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log_out.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_log_out.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_log_out.Location = new System.Drawing.Point(556, 495);
            this.btn_log_out.Margin = new System.Windows.Forms.Padding(5);
            this.btn_log_out.Name = "btn_log_out";
            this.btn_log_out.Size = new System.Drawing.Size(272, 41);
            this.btn_log_out.TabIndex = 50;
            this.btn_log_out.Text = "EKLE";
            this.btn_log_out.UseVisualStyleBackColor = false;
            this.btn_log_out.Click += new System.EventHandler(this.btn_log_out_Click);
            // 
            // personel_gec_mesai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_log_out);
            this.Controls.Add(this.tb_dakika);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_tip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dt_tarih);
            this.Controls.Add(this.grid_personeller);
            this.Controls.Add(this.lbl_ad_soyad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "personel_gec_mesai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Geç/Mesai";
            this.Load += new System.EventHandler(this.personel_gec_mesai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_personeller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_personeller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_tip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_dakika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ad_soyad;
        private DevExpress.XtraGrid.GridControl grid_personeller;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_personeller;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_tarih;
        private DevExpress.XtraEditors.GridLookUpEdit cmb_tip;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown tb_dakika;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_log_out;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}