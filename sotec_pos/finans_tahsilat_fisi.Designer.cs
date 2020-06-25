namespace sotec_pos
{
    partial class finans_tahsilat_fisi
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_tahsilat_tipi = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_cariler = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_tutar = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_iptal = new System.Windows.Forms.Button();
            this.btn_log_out = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_no = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_teslim_tarihi = new System.Windows.Forms.DateTimePicker();
            this.grid_tahsilat = new DevExpress.XtraGrid.GridControl();
            this.gv_tahsilat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_tahsilat_tipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_cariler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tahsilat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_tahsilat)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tutar";
            this.gridColumn14.DisplayFormat.FormatString = "n2";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "tutar";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            // 
            // cmb_tahsilat_tipi
            // 
            this.cmb_tahsilat_tipi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_tahsilat_tipi.Location = new System.Drawing.Point(310, 58);
            this.cmb_tahsilat_tipi.Name = "cmb_tahsilat_tipi";
            this.cmb_tahsilat_tipi.Properties.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_tahsilat_tipi.Properties.Appearance.Options.UseFont = true;
            this.cmb_tahsilat_tipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_tahsilat_tipi.Properties.DisplayMember = "deger";
            this.cmb_tahsilat_tipi.Properties.ValueMember = "parametre_id";
            this.cmb_tahsilat_tipi.Properties.View = this.gridLookUpEdit1View;
            this.cmb_tahsilat_tipi.Size = new System.Drawing.Size(272, 40);
            this.cmb_tahsilat_tipi.TabIndex = 38;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Parametre ID";
            this.gridColumn1.FieldName = "parametre_id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tip";
            this.gridColumn2.FieldName = "deger";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(186, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 33);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tahsilat Tipi";
            // 
            // cmb_cariler
            // 
            this.cmb_cariler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_cariler.Location = new System.Drawing.Point(310, 12);
            this.cmb_cariler.Name = "cmb_cariler";
            this.cmb_cariler.Properties.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_cariler.Properties.Appearance.Options.UseFont = true;
            this.cmb_cariler.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_cariler.Properties.DisplayMember = "cari_adi";
            this.cmb_cariler.Properties.ValueMember = "cari_id";
            this.cmb_cariler.Properties.View = this.gridView1;
            this.cmb_cariler.Size = new System.Drawing.Size(272, 40);
            this.cmb_cariler.TabIndex = 45;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cari ID";
            this.gridColumn6.FieldName = "cari_id";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cari";
            this.gridColumn7.FieldName = "cari_adi";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(254, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 33);
            this.label9.TabIndex = 46;
            this.label9.Text = "Cari";
            // 
            // tb_tutar
            // 
            this.tb_tutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_tutar.DecimalPlaces = 2;
            this.tb_tutar.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_tutar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tb_tutar.Location = new System.Drawing.Point(310, 104);
            this.tb_tutar.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tb_tutar.Name = "tb_tutar";
            this.tb_tutar.Size = new System.Drawing.Size(272, 40);
            this.tb_tutar.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(244, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 33);
            this.label1.TabIndex = 59;
            this.label1.Text = "Tutar";
            // 
            // btn_iptal
            // 
            this.btn_iptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_iptal.BackColor = System.Drawing.Color.DimGray;
            this.btn_iptal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_iptal.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_iptal.FlatAppearance.BorderSize = 5;
            this.btn_iptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iptal.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_iptal.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_iptal.Location = new System.Drawing.Point(151, 244);
            this.btn_iptal.Margin = new System.Windows.Forms.Padding(5);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(149, 41);
            this.btn_iptal.TabIndex = 61;
            this.btn_iptal.Text = "İPTAL";
            this.btn_iptal.UseVisualStyleBackColor = false;
            this.btn_iptal.Visible = false;
            this.btn_iptal.Click += new System.EventHandler(this.btn_iptal_Click);
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
            this.btn_log_out.Location = new System.Drawing.Point(310, 244);
            this.btn_log_out.Margin = new System.Windows.Forms.Padding(5);
            this.btn_log_out.Name = "btn_log_out";
            this.btn_log_out.Size = new System.Drawing.Size(272, 41);
            this.btn_log_out.TabIndex = 60;
            this.btn_log_out.Text = "EKLE";
            this.btn_log_out.UseVisualStyleBackColor = false;
            this.btn_log_out.Click += new System.EventHandler(this.btn_log_out_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(190, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 33);
            this.label7.TabIndex = 65;
            this.label7.Text = "Tahsilat No";
            // 
            // tb_no
            // 
            this.tb_no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_no.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_no.Location = new System.Drawing.Point(310, 196);
            this.tb_no.Name = "tb_no";
            this.tb_no.Size = new System.Drawing.Size(272, 40);
            this.tb_no.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(164, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 33);
            this.label6.TabIndex = 63;
            this.label6.Text = "Tahsilat Tarihi";
            // 
            // dt_teslim_tarihi
            // 
            this.dt_teslim_tarihi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_teslim_tarihi.CalendarFont = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dt_teslim_tarihi.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dt_teslim_tarihi.Location = new System.Drawing.Point(310, 150);
            this.dt_teslim_tarihi.Name = "dt_teslim_tarihi";
            this.dt_teslim_tarihi.Size = new System.Drawing.Size(272, 40);
            this.dt_teslim_tarihi.TabIndex = 62;
            // 
            // grid_tahsilat
            // 
            this.grid_tahsilat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_tahsilat.Location = new System.Drawing.Point(12, 293);
            this.grid_tahsilat.MainView = this.gv_tahsilat;
            this.grid_tahsilat.Name = "grid_tahsilat";
            this.grid_tahsilat.Size = new System.Drawing.Size(570, 271);
            this.grid_tahsilat.TabIndex = 66;
            this.grid_tahsilat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_tahsilat});
            this.grid_tahsilat.Click += new System.EventHandler(this.grid_tahsilat_Click);
            // 
            // gv_tahsilat
            // 
            this.gv_tahsilat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn12,
            this.gridColumn14});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gridColumn14;
            gridFormatRule1.ColumnApplyTo = this.gridColumn14;
            gridFormatRule1.Name = "tedarikcide";
            formatConditionRuleValue1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 19;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.gridColumn14;
            gridFormatRule2.ColumnApplyTo = this.gridColumn14;
            gridFormatRule2.Name = "kapandi";
            formatConditionRuleValue2.Appearance.FontStyleDelta = System.Drawing.FontStyle.Italic;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.LightGray;
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = 20;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gv_tahsilat.FormatRules.Add(gridFormatRule1);
            this.gv_tahsilat.FormatRules.Add(gridFormatRule2);
            this.gv_tahsilat.GridControl = this.grid_tahsilat;
            this.gv_tahsilat.Name = "gv_tahsilat";
            this.gv_tahsilat.OptionsBehavior.Editable = false;
            this.gv_tahsilat.OptionsView.ShowAutoFilterRow = true;
            this.gv_tahsilat.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tahsilat ID";
            this.gridColumn8.FieldName = "tahsilat_id";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tahsilat Tarihi";
            this.gridColumn9.FieldName = "tahsilat_tarihi";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Cari";
            this.gridColumn10.FieldName = "cari_adi";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tahsilat Tipi";
            this.gridColumn3.FieldName = "tahsilat_tipi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tahsilat No";
            this.gridColumn12.FieldName = "tahsilat_no";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(12, 572);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(570, 41);
            this.button1.TabIndex = 67;
            this.button1.Text = "KAPAT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // finans_tahsilat_fisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 627);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid_tahsilat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_no);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dt_teslim_tarihi);
            this.Controls.Add(this.btn_iptal);
            this.Controls.Add(this.btn_log_out);
            this.Controls.Add(this.tb_tutar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_cariler);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmb_tahsilat_tipi);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "finans_tahsilat_fisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tahsilat Fişi";
            this.Load += new System.EventHandler(this.finans_tahsilat_fisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_tahsilat_tipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_cariler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tahsilat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_tahsilat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit cmb_tahsilat_tipi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GridLookUpEdit cmb_cariler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown tb_tutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_iptal;
        private System.Windows.Forms.Button btn_log_out;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_no;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_teslim_tarihi;
        private DevExpress.XtraGrid.GridControl grid_tahsilat;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_tahsilat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Windows.Forms.Button button1;
    }
}