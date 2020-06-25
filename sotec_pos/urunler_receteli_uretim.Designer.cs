namespace sotec_pos
{
    partial class urunler_receteli_uretim
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
            this.grid_kaynak = new DevExpress.XtraGrid.GridControl();
            this.gv_kaynak = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_hedef = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_recete = new DevExpress.XtraGrid.GridControl();
            this.gv_recete = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_miktar = new System.Windows.Forms.NumericUpDown();
            this.lbl_hedef_birim = new System.Windows.Forms.Label();
            this.cmb_kaynak_birim = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tb_kaynak_birim = new System.Windows.Forms.NumericUpDown();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kaynak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_kaynak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_hedef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_recete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_recete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_miktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kaynak_birim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_kaynak_birim)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_kaynak
            // 
            this.grid_kaynak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_kaynak.Location = new System.Drawing.Point(12, 58);
            this.grid_kaynak.MainView = this.gv_kaynak;
            this.grid_kaynak.Name = "grid_kaynak";
            this.grid_kaynak.Size = new System.Drawing.Size(481, 371);
            this.grid_kaynak.TabIndex = 17;
            this.grid_kaynak.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_kaynak});
            this.grid_kaynak.Click += new System.EventHandler(this.grid_kaynak_Click);
            // 
            // gv_kaynak
            // 
            this.gv_kaynak.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn17});
            this.gv_kaynak.GridControl = this.grid_kaynak;
            this.gv_kaynak.Name = "gv_kaynak";
            this.gv_kaynak.OptionsBehavior.Editable = false;
            this.gv_kaynak.OptionsView.ShowAutoFilterRow = true;
            this.gv_kaynak.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Üst Kategori";
            this.gridColumn2.FieldName = "ust_kategori_adi";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kategori";
            this.gridColumn3.FieldName = "kategori_adi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ürün ID";
            this.gridColumn1.FieldName = "urun_id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ürün Adı";
            this.gridColumn6.FieldName = "urun_adi";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ölçü Birimi";
            this.gridColumn5.FieldName = "olcu_birimi";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(924, 532);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 41);
            this.button1.TabIndex = 23;
            this.button1.Text = "KAPAT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(79, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 33);
            this.label2.TabIndex = 29;
            this.label2.Text = "Reçeteli Ürün";
            // 
            // cmb_hedef
            // 
            this.cmb_hedef.Location = new System.Drawing.Point(221, 12);
            this.cmb_hedef.Name = "cmb_hedef";
            this.cmb_hedef.Properties.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_hedef.Properties.Appearance.Options.UseFont = true;
            this.cmb_hedef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_hedef.Properties.DisplayMember = "urun_adi";
            this.cmb_hedef.Properties.ValueMember = "urun_id";
            this.cmb_hedef.Properties.View = this.gridLookUpEdit1View;
            this.cmb_hedef.Size = new System.Drawing.Size(272, 40);
            this.cmb_hedef.TabIndex = 30;
            this.cmb_hedef.EditValueChanged += new System.EventHandler(this.cmb_hedef_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn4});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Kategori ID";
            this.gridColumn7.FieldName = "kategori_id";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ust Kategori Adı";
            this.gridColumn8.FieldName = "ust_kategori_adi";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Kategori Adı";
            this.gridColumn9.FieldName = "kategori_adi";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ürün";
            this.gridColumn4.FieldName = "urun_adi";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // grid_recete
            // 
            this.grid_recete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_recete.Location = new System.Drawing.Point(499, 12);
            this.grid_recete.MainView = this.gv_recete;
            this.grid_recete.Name = "grid_recete";
            this.grid_recete.Size = new System.Drawing.Size(546, 512);
            this.grid_recete.TabIndex = 31;
            this.grid_recete.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_recete});
            this.grid_recete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_recete_KeyDown);
            // 
            // gv_recete
            // 
            this.gv_recete.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.gv_recete.GridControl = this.grid_recete;
            this.gv_recete.Name = "gv_recete";
            this.gv_recete.OptionsBehavior.Editable = false;
            this.gv_recete.OptionsView.ShowAutoFilterRow = true;
            this.gv_recete.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Recete ID";
            this.gridColumn10.FieldName = "recete_id";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Ürün ID";
            this.gridColumn12.FieldName = "urun_id";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Ürün Adı";
            this.gridColumn13.FieldName = "urun_adi";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Ölçü Birimi";
            this.gridColumn14.FieldName = "olcu_birimi";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Sarf Miktar";
            this.gridColumn15.FieldName = "miktar";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.GreenYellow;
            this.button2.Location = new System.Drawing.Point(12, 483);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(481, 41);
            this.button2.TabIndex = 32;
            this.button2.Text = "KALEM EKLE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_miktar
            // 
            this.tb_miktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_miktar.DecimalPlaces = 2;
            this.tb_miktar.Enabled = false;
            this.tb_miktar.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_miktar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tb_miktar.Location = new System.Drawing.Point(262, 435);
            this.tb_miktar.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tb_miktar.Name = "tb_miktar";
            this.tb_miktar.Size = new System.Drawing.Size(118, 40);
            this.tb_miktar.TabIndex = 52;
            // 
            // lbl_hedef_birim
            // 
            this.lbl_hedef_birim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_hedef_birim.AutoSize = true;
            this.lbl_hedef_birim.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_hedef_birim.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_hedef_birim.Location = new System.Drawing.Point(386, 443);
            this.lbl_hedef_birim.Name = "lbl_hedef_birim";
            this.lbl_hedef_birim.Size = new System.Drawing.Size(98, 25);
            this.lbl_hedef_birim.TabIndex = 51;
            this.lbl_hedef_birim.Text = "Ürün Seçiniz";
            // 
            // cmb_kaynak_birim
            // 
            this.cmb_kaynak_birim.Location = new System.Drawing.Point(136, 440);
            this.cmb_kaynak_birim.Name = "cmb_kaynak_birim";
            this.cmb_kaynak_birim.Properties.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_kaynak_birim.Properties.Appearance.Options.UseFont = true;
            this.cmb_kaynak_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_kaynak_birim.Properties.DisplayMember = "deger";
            this.cmb_kaynak_birim.Properties.ValueMember = "parametre_id";
            this.cmb_kaynak_birim.Properties.View = this.gridView1;
            this.cmb_kaynak_birim.Size = new System.Drawing.Size(120, 32);
            this.cmb_kaynak_birim.TabIndex = 53;
            this.cmb_kaynak_birim.EditValueChanged += new System.EventHandler(this.cmb_kaynak_birim_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn16});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Parametre ID";
            this.gridColumn11.FieldName = "parametre_id";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Tip";
            this.gridColumn16.FieldName = "deger";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            // 
            // tb_kaynak_birim
            // 
            this.tb_kaynak_birim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_kaynak_birim.DecimalPlaces = 2;
            this.tb_kaynak_birim.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_kaynak_birim.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tb_kaynak_birim.Location = new System.Drawing.Point(12, 435);
            this.tb_kaynak_birim.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tb_kaynak_birim.Name = "tb_kaynak_birim";
            this.tb_kaynak_birim.Size = new System.Drawing.Size(118, 40);
            this.tb_kaynak_birim.TabIndex = 54;
            this.tb_kaynak_birim.ValueChanged += new System.EventHandler(this.tb_kaynak_birim_ValueChanged);
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "olcu_birimi_id";
            this.gridColumn17.FieldName = "olcu_birimi_id";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // urunler_receteli_uretim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 587);
            this.Controls.Add(this.tb_kaynak_birim);
            this.Controls.Add(this.cmb_kaynak_birim);
            this.Controls.Add(this.tb_miktar);
            this.Controls.Add(this.lbl_hedef_birim);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.grid_recete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_hedef);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid_kaynak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "urunler_receteli_uretim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reçete Tanımı";
            this.Load += new System.EventHandler(this.urunler_receteli_uretim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kaynak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_kaynak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_hedef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_recete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_recete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_miktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_kaynak_birim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_kaynak_birim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_kaynak;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_kaynak;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GridLookUpEdit cmb_hedef;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl grid_recete;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_recete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown tb_miktar;
        private System.Windows.Forms.Label lbl_hedef_birim;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.GridLookUpEdit cmb_kaynak_birim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private System.Windows.Forms.NumericUpDown tb_kaynak_birim;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}