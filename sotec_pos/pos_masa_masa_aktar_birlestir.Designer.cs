namespace sotec_pos
{
    partial class pos_masa_masa_aktar_birlestir
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
            this.tvc_acik_mi = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tvc_masa_adi = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.lbl_masa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_masalar = new DevExpress.XtraGrid.GridControl();
            this.tv_masalar = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tvc_masa_id = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_masalar)).BeginInit();
            this.SuspendLayout();
            // 
            // tvc_acik_mi
            // 
            this.tvc_acik_mi.Caption = "Açık mı?";
            this.tvc_acik_mi.FieldName = "acik_mi";
            this.tvc_acik_mi.Name = "tvc_acik_mi";
            this.tvc_acik_mi.Visible = true;
            this.tvc_acik_mi.VisibleIndex = 2;
            // 
            // tvc_masa_adi
            // 
            this.tvc_masa_adi.Caption = "Masa Adı";
            this.tvc_masa_adi.FieldName = "masa_adi";
            this.tvc_masa_adi.Name = "tvc_masa_adi";
            this.tvc_masa_adi.Visible = true;
            this.tvc_masa_adi.VisibleIndex = 1;
            // 
            // lbl_masa
            // 
            this.lbl_masa.AutoSize = true;
            this.lbl_masa.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_masa.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_masa.Location = new System.Drawing.Point(12, 9);
            this.lbl_masa.Name = "lbl_masa";
            this.lbl_masa.Size = new System.Drawing.Size(115, 58);
            this.lbl_masa.TabIndex = 2;
            this.lbl_masa.Text = "B-001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(15, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aktarılcak masayı seçiniz";
            // 
            // grid_masalar
            // 
            this.grid_masalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_masalar.Location = new System.Drawing.Point(12, 112);
            this.grid_masalar.MainView = this.tv_masalar;
            this.grid_masalar.Name = "grid_masalar";
            this.grid_masalar.Size = new System.Drawing.Size(1054, 622);
            this.grid_masalar.TabIndex = 20;
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
            this.tvc_acik_mi});
            this.tv_masalar.ColumnSet.CheckedColumn = this.tvc_acik_mi;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.tvc_acik_mi;
            gridFormatRule1.ColumnApplyTo = this.tvc_acik_mi;
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
            this.tv_masalar.OptionsFind.AlwaysVisible = true;
            this.tv_masalar.OptionsFind.FindNullPrompt = "Ara...";
            this.tv_masalar.OptionsTiles.IndentBetweenGroups = 51;
            this.tv_masalar.OptionsTiles.IndentBetweenItems = 15;
            this.tv_masalar.OptionsTiles.ItemSize = new System.Drawing.Size(250, 150);
            this.tv_masalar.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tv_masalar.OptionsTiles.Padding = new System.Windows.Forms.Padding(15);
            this.tv_masalar.OptionsTiles.RowCount = 0;
            this.tv_masalar.TileColumns.Add(tableColumnDefinition1);
            this.tv_masalar.TileColumns.Add(tableColumnDefinition2);
            this.tv_masalar.TileColumns.Add(tableColumnDefinition3);
            this.tv_masalar.TileRows.Add(tableRowDefinition1);
            this.tv_masalar.TileRows.Add(tableRowDefinition2);
            this.tv_masalar.TileRows.Add(tableRowDefinition3);
            tableSpan1.ColumnSpan = 3;
            tableSpan1.RowSpan = 3;
            this.tv_masalar.TileSpans.Add(tableSpan1);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            tileViewItemElement1.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.DarkGray;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Column = this.tvc_masa_adi;
            tileViewItemElement1.ColumnIndex = 1;
            tileViewItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.RowIndex = 1;
            tileViewItemElement1.Text = "tvc_masa_adi";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tv_masalar.TileTemplate.Add(tileViewItemElement1);
            // 
            // tvc_masa_id
            // 
            this.tvc_masa_id.Caption = "Masa ID";
            this.tvc_masa_id.FieldName = "masa_id";
            this.tvc_masa_id.Name = "tvc_masa_id";
            this.tvc_masa_id.Visible = true;
            this.tvc_masa_id.VisibleIndex = 0;
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
            this.button4.Location = new System.Drawing.Point(970, 8);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 96);
            this.button4.TabIndex = 32;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pos_masa_masa_aktar_birlestir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1078, 746);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.grid_masalar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_masa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_masa_masa_aktar_birlestir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_masa_masa_aktar_birlestir";
            this.Load += new System.EventHandler(this.pos_masa_masa_aktar_birlestir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_masalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_masa;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grid_masalar;
        private DevExpress.XtraGrid.Views.Tile.TileView tv_masalar;
        private DevExpress.XtraGrid.Columns.TileViewColumn tvc_masa_id;
        private DevExpress.XtraGrid.Columns.TileViewColumn tvc_masa_adi;
        private DevExpress.XtraGrid.Columns.TileViewColumn tvc_acik_mi;
        private System.Windows.Forms.Button button4;
    }
}