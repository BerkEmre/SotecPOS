namespace sotec_pos
{
    partial class pos_gecmis
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan2 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tvc_durum = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tvc_masa_adi = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.btn_log_out = new System.Windows.Forms.Button();
            this.grid_masalar = new DevExpress.XtraGrid.GridControl();
            this.tv_masalar = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tvc_masa_id = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_masalar)).BeginInit();
            this.SuspendLayout();
            // 
            // tvc_durum
            // 
            this.tvc_durum.Caption = "Durum";
            this.tvc_durum.FieldName = "durum";
            this.tvc_durum.Name = "tvc_durum";
            this.tvc_durum.Visible = true;
            this.tvc_durum.VisibleIndex = 2;
            // 
            // tvc_masa_adi
            // 
            this.tvc_masa_adi.Caption = "Masa Adı";
            this.tvc_masa_adi.FieldName = "masa_adi";
            this.tvc_masa_adi.Name = "tvc_masa_adi";
            this.tvc_masa_adi.Visible = true;
            this.tvc_masa_adi.VisibleIndex = 1;
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "Kayıt Tarihi";
            this.tileViewColumn1.DisplayFormat.FormatString = "dd.MM.yyyy hh:mm";
            this.tileViewColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tileViewColumn1.FieldName = "kayit_tarihi";
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 4;
            // 
            // btn_log_out
            // 
            this.btn_log_out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_log_out.BackColor = System.Drawing.Color.DimGray;
            this.btn_log_out.BackgroundImage = global::sotec_pos.Properties.Resources.icon_sing_out;
            this.btn_log_out.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_log_out.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_log_out.FlatAppearance.BorderSize = 5;
            this.btn_log_out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_log_out.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_log_out.Location = new System.Drawing.Point(798, 14);
            this.btn_log_out.Margin = new System.Windows.Forms.Padding(5);
            this.btn_log_out.Name = "btn_log_out";
            this.btn_log_out.Size = new System.Drawing.Size(150, 105);
            this.btn_log_out.TabIndex = 21;
            this.btn_log_out.UseVisualStyleBackColor = false;
            this.btn_log_out.Click += new System.EventHandler(this.btn_log_out_Click);
            // 
            // grid_masalar
            // 
            this.grid_masalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_masalar.Location = new System.Drawing.Point(12, 14);
            this.grid_masalar.MainView = this.tv_masalar;
            this.grid_masalar.Name = "grid_masalar";
            this.grid_masalar.Size = new System.Drawing.Size(778, 547);
            this.grid_masalar.TabIndex = 22;
            this.grid_masalar.ToolTipController = this.toolTipController1;
            this.grid_masalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tv_masalar});
            this.grid_masalar.DoubleClick += new System.EventHandler(this.grid_masalar_DoubleClick);
            // 
            // tv_masalar
            // 
            this.tv_masalar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tv_masalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tvc_masa_id,
            this.tvc_masa_adi,
            this.tvc_durum,
            this.tileViewColumn4,
            this.tileViewColumn1,
            this.tileViewColumn2});
            this.tv_masalar.ColumnSet.CheckedColumn = this.tvc_durum;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.tvc_durum;
            gridFormatRule1.ColumnApplyTo = this.tvc_durum;
            gridFormatRule1.Name = "kapali";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.DimGray;
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.tv_masalar.FormatRules.Add(gridFormatRule1);
            this.tv_masalar.GridControl = this.grid_masalar;
            this.tv_masalar.Name = "tv_masalar";
            this.tv_masalar.OptionsTiles.IndentBetweenGroups = 0;
            this.tv_masalar.OptionsTiles.IndentBetweenItems = 0;
            this.tv_masalar.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tv_masalar.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tv_masalar.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            this.tv_masalar.OptionsTiles.RowCount = 0;
            this.tv_masalar.TileColumns.Add(tableColumnDefinition1);
            this.tv_masalar.TileColumns.Add(tableColumnDefinition2);
            this.tv_masalar.TileColumns.Add(tableColumnDefinition3);
            this.tv_masalar.TileRows.Add(tableRowDefinition1);
            this.tv_masalar.TileRows.Add(tableRowDefinition2);
            this.tv_masalar.TileRows.Add(tableRowDefinition3);
            tableSpan1.ColumnSpan = 3;
            tableSpan1.RowIndex = 1;
            tableSpan2.ColumnSpan = 2;
            this.tv_masalar.TileSpans.Add(tableSpan1);
            this.tv_masalar.TileSpans.Add(tableSpan2);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            tileViewItemElement1.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.DimGray;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Column = this.tvc_masa_adi;
            tileViewItemElement1.ColumnIndex = 1;
            tileViewItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.RowIndex = 1;
            tileViewItemElement1.Text = "tvc_masa_adi";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.YellowGreen;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Column = this.tvc_durum;
            tileViewItemElement2.ColumnIndex = 2;
            tileViewItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 2;
            tileViewItemElement2.Text = "tvc_durum";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Italic;
            tileViewItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.DimGray;
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement3.Column = this.tileViewColumn1;
            tileViewItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.Text = "tileViewColumn1";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tv_masalar.TileTemplate.Add(tileViewItemElement1);
            this.tv_masalar.TileTemplate.Add(tileViewItemElement2);
            this.tv_masalar.TileTemplate.Add(tileViewItemElement3);
            this.tv_masalar.ItemCustomize += new DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventHandler(this.tv_masalar_ItemCustomize);
            // 
            // tvc_masa_id
            // 
            this.tvc_masa_id.Caption = "Masa ID";
            this.tvc_masa_id.FieldName = "masa_id";
            this.tvc_masa_id.Name = "tvc_masa_id";
            this.tvc_masa_id.Visible = true;
            this.tvc_masa_id.VisibleIndex = 0;
            // 
            // tileViewColumn4
            // 
            this.tileViewColumn4.Caption = "Adisyon ID";
            this.tileViewColumn4.FieldName = "adisyon_id";
            this.tileViewColumn4.Name = "tileViewColumn4";
            this.tileViewColumn4.Visible = true;
            this.tileViewColumn4.VisibleIndex = 3;
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.Caption = "Kapandı";
            this.tileViewColumn2.FieldName = "kapandi";
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 5;
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // pos_gecmis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 573);
            this.Controls.Add(this.grid_masalar);
            this.Controls.Add(this.btn_log_out);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_gecmis";
            this.Text = "pos_gecmis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.pos_gecmis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_masalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_log_out;
        private DevExpress.XtraGrid.GridControl grid_masalar;
        private DevExpress.XtraGrid.Views.Tile.TileView tv_masalar;
        private DevExpress.XtraGrid.Columns.TileViewColumn tvc_masa_id;
        private DevExpress.XtraGrid.Columns.TileViewColumn tvc_masa_adi;
        private DevExpress.XtraGrid.Columns.TileViewColumn tvc_durum;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn4;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}