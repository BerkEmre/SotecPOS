namespace sotec_pos
{
    partial class pos_masa_menu_urun_sec
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition5 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition6 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition5 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition6 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan2 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.grid_urun = new DevExpress.XtraGrid.GridControl();
            this.tv_urun = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumn7 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn8 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn9 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn26 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_urun_grubu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_urun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_urun)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_urun
            // 
            this.grid_urun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_urun.Location = new System.Drawing.Point(12, 97);
            this.grid_urun.MainView = this.tv_urun;
            this.grid_urun.Name = "grid_urun";
            this.grid_urun.Size = new System.Drawing.Size(976, 591);
            this.grid_urun.TabIndex = 34;
            this.grid_urun.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tv_urun});
            // 
            // tv_urun
            // 
            this.tv_urun.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tv_urun.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn7,
            this.tileViewColumn8,
            this.tileViewColumn9,
            this.tileViewColumn26});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "kapali";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.DimGray;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = 0;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.tv_urun.FormatRules.Add(gridFormatRule2);
            this.tv_urun.GridControl = this.grid_urun;
            this.tv_urun.Name = "tv_urun";
            this.tv_urun.OptionsTiles.ItemSize = new System.Drawing.Size(150, 120);
            this.tv_urun.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tv_urun.OptionsTiles.RowCount = 0;
            this.tv_urun.TileColumns.Add(tableColumnDefinition4);
            this.tv_urun.TileColumns.Add(tableColumnDefinition5);
            this.tv_urun.TileColumns.Add(tableColumnDefinition6);
            this.tv_urun.TileRows.Add(tableRowDefinition4);
            this.tv_urun.TileRows.Add(tableRowDefinition5);
            this.tv_urun.TileRows.Add(tableRowDefinition6);
            tableSpan2.ColumnSpan = 3;
            tableSpan2.RowSpan = 2;
            this.tv_urun.TileSpans.Add(tableSpan2);
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            tileViewItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.DarkGray;
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement3.Column = this.tileViewColumn8;
            tileViewItemElement3.ColumnIndex = 1;
            tileViewItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.RowIndex = 1;
            tileViewItemElement3.Text = "tileViewColumn8";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.GreenYellow;
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement4.Column = this.tileViewColumn9;
            tileViewItemElement4.ColumnIndex = 2;
            tileViewItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.RowIndex = 2;
            tileViewItemElement4.Text = "tileViewColumn9";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tv_urun.TileTemplate.Add(tileViewItemElement3);
            this.tv_urun.TileTemplate.Add(tileViewItemElement4);
            this.tv_urun.ItemDoubleClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tv_urun_ItemDoubleClick);
            // 
            // tileViewColumn7
            // 
            this.tileViewColumn7.Caption = "Ürün ID";
            this.tileViewColumn7.FieldName = "urun_id";
            this.tileViewColumn7.Name = "tileViewColumn7";
            this.tileViewColumn7.Visible = true;
            this.tileViewColumn7.VisibleIndex = 0;
            // 
            // tileViewColumn8
            // 
            this.tileViewColumn8.Caption = "Urun Adi";
            this.tileViewColumn8.FieldName = "urun_adi";
            this.tileViewColumn8.Name = "tileViewColumn8";
            this.tileViewColumn8.Visible = true;
            this.tileViewColumn8.VisibleIndex = 1;
            // 
            // tileViewColumn9
            // 
            this.tileViewColumn9.Caption = "Fiyat";
            this.tileViewColumn9.DisplayFormat.FormatString = "c2";
            this.tileViewColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tileViewColumn9.FieldName = "fiyat";
            this.tileViewColumn9.Name = "tileViewColumn9";
            this.tileViewColumn9.Visible = true;
            this.tileViewColumn9.VisibleIndex = 2;
            // 
            // tileViewColumn26
            // 
            this.tileViewColumn26.Caption = "Sıcak Satış";
            this.tileViewColumn26.FieldName = "sicak_satis";
            this.tileViewColumn26.Name = "tileViewColumn26";
            this.tileViewColumn26.OptionsColumn.AllowEdit = false;
            this.tileViewColumn26.Visible = true;
            this.tileViewColumn26.VisibleIndex = 3;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.DimGray;
            this.button4.BackgroundImage = global::sotec_pos.Properties.Resources.icon_sing_out;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button4.FlatAppearance.BorderSize = 5;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Bahnschrift Condensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.GreenYellow;
            this.button4.Location = new System.Drawing.Point(913, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 75);
            this.button4.TabIndex = 35;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbl_urun_grubu
            // 
            this.lbl_urun_grubu.AutoSize = true;
            this.lbl_urun_grubu.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_urun_grubu.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_urun_grubu.Location = new System.Drawing.Point(12, 14);
            this.lbl_urun_grubu.Name = "lbl_urun_grubu";
            this.lbl_urun_grubu.Size = new System.Drawing.Size(58, 29);
            this.lbl_urun_grubu.TabIndex = 36;
            this.lbl_urun_grubu.Text = "B-001";
            // 
            // pos_masa_menu_urun_sec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.lbl_urun_grubu);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.grid_urun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_masa_menu_urun_sec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_masa_menu_urun_sec";
            this.Load += new System.EventHandler(this.pos_masa_menu_urun_sec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_urun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_urun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_urun;
        private DevExpress.XtraGrid.Views.Tile.TileView tv_urun;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn7;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn8;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn9;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn26;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_urun_grubu;
    }
}