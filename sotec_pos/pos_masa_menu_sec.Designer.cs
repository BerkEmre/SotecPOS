namespace sotec_pos
{
    partial class pos_masa_menu_sec
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grid_menu = new DevExpress.XtraGrid.GridControl();
            this.tv_menu = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_masa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_menu)).BeginInit();
            this.SuspendLayout();
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.Caption = "Menü";
            this.tileViewColumn2.FieldName = "menu";
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 1;
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.Caption = "Fiyat";
            this.tileViewColumn3.DisplayFormat.FormatString = "n2";
            this.tileViewColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tileViewColumn3.FieldName = "fiyat";
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 2;
            // 
            // grid_menu
            // 
            this.grid_menu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_menu.Location = new System.Drawing.Point(12, 118);
            this.grid_menu.MainView = this.tv_menu;
            this.grid_menu.Name = "grid_menu";
            this.grid_menu.Size = new System.Drawing.Size(976, 570);
            this.grid_menu.TabIndex = 34;
            this.grid_menu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tv_menu});
            // 
            // tv_menu
            // 
            this.tv_menu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tv_menu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn2,
            this.tileViewColumn3});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "kapali";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.DimGray;
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.tv_menu.FormatRules.Add(gridFormatRule1);
            this.tv_menu.GridControl = this.grid_menu;
            this.tv_menu.Name = "tv_menu";
            this.tv_menu.OptionsTiles.ItemSize = new System.Drawing.Size(150, 120);
            this.tv_menu.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tv_menu.OptionsTiles.RowCount = 0;
            this.tv_menu.TileColumns.Add(tableColumnDefinition1);
            this.tv_menu.TileColumns.Add(tableColumnDefinition2);
            this.tv_menu.TileColumns.Add(tableColumnDefinition3);
            this.tv_menu.TileRows.Add(tableRowDefinition1);
            this.tv_menu.TileRows.Add(tableRowDefinition2);
            this.tv_menu.TileRows.Add(tableRowDefinition3);
            tableSpan1.ColumnSpan = 3;
            tableSpan1.RowSpan = 2;
            this.tv_menu.TileSpans.Add(tableSpan1);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.DimGray;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Column = this.tileViewColumn2;
            tileViewItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "tileViewColumn2";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.YellowGreen;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Column = this.tileViewColumn3;
            tileViewItemElement2.ColumnIndex = 2;
            tileViewItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 2;
            tileViewItemElement2.Text = "tileViewColumn3";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tv_menu.TileTemplate.Add(tileViewItemElement1);
            this.tv_menu.TileTemplate.Add(tileViewItemElement2);
            this.tv_menu.ItemDoubleClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tv_menu_ItemDoubleClick);
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "Menü ID";
            this.tileViewColumn1.FieldName = "menu_id";
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
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
            this.button4.Location = new System.Drawing.Point(892, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 96);
            this.button4.TabIndex = 35;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbl_masa
            // 
            this.lbl_masa.AutoSize = true;
            this.lbl_masa.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_masa.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_masa.Location = new System.Drawing.Point(12, 14);
            this.lbl_masa.Name = "lbl_masa";
            this.lbl_masa.Size = new System.Drawing.Size(177, 58);
            this.lbl_masa.TabIndex = 36;
            this.lbl_masa.Text = "MENÜ SEÇ";
            // 
            // pos_masa_menu_sec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.lbl_masa);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.grid_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_masa_menu_sec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_masa_menu_sec";
            this.Load += new System.EventHandler(this.pos_masa_menu_sec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_menu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_menu;
        private DevExpress.XtraGrid.Views.Tile.TileView tv_menu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_masa;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
    }
}