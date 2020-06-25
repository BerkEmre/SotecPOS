namespace sotec_pos
{
    partial class pos_masa_sicak_satis
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition5 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition6 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition5 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition6 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan3 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan4 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.grid_masalar = new DevExpress.XtraGrid.GridControl();
            this.tv_masalar = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.urun_id = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.urun = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.miktar = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.olcu_birimi = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.btn_adisyona_ekle = new System.Windows.Forms.Button();
            this.btn_iptal = new System.Windows.Forms.Button();
            this.secim = new DevExpress.XtraGrid.Columns.TileViewColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_masalar)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_masalar
            // 
            this.grid_masalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_masalar.Location = new System.Drawing.Point(12, 12);
            this.grid_masalar.MainView = this.tv_masalar;
            this.grid_masalar.Name = "grid_masalar";
            this.grid_masalar.Size = new System.Drawing.Size(905, 496);
            this.grid_masalar.TabIndex = 20;
            this.grid_masalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tv_masalar});
            this.grid_masalar.Click += new System.EventHandler(this.grid_masalar_Click);
            // 
            // tv_masalar
            // 
            this.tv_masalar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tv_masalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.urun_id,
            this.urun,
            this.miktar,
            this.olcu_birimi,
            this.secim});
            this.tv_masalar.ColumnSet.CheckedColumn = this.secim;
            this.tv_masalar.GridControl = this.grid_masalar;
            this.tv_masalar.Name = "tv_masalar";
            this.tv_masalar.OptionsTiles.IndentBetweenGroups = 51;
            this.tv_masalar.OptionsTiles.IndentBetweenItems = 15;
            this.tv_masalar.OptionsTiles.ItemSize = new System.Drawing.Size(200, 100);
            this.tv_masalar.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tv_masalar.OptionsTiles.Padding = new System.Windows.Forms.Padding(15);
            this.tv_masalar.OptionsTiles.RowCount = 0;
            this.tv_masalar.TileColumns.Add(tableColumnDefinition4);
            this.tv_masalar.TileColumns.Add(tableColumnDefinition5);
            this.tv_masalar.TileColumns.Add(tableColumnDefinition6);
            this.tv_masalar.TileRows.Add(tableRowDefinition4);
            this.tv_masalar.TileRows.Add(tableRowDefinition5);
            this.tv_masalar.TileRows.Add(tableRowDefinition6);
            tableSpan3.ColumnSpan = 3;
            tableSpan3.RowSpan = 2;
            tableSpan4.ColumnSpan = 2;
            tableSpan4.RowIndex = 2;
            this.tv_masalar.TileSpans.Add(tableSpan3);
            this.tv_masalar.TileSpans.Add(tableSpan4);
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            tileViewItemElement4.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement4.Column = this.urun;
            tileViewItemElement4.ColumnIndex = 1;
            tileViewItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.RowIndex = 1;
            tileViewItemElement4.Text = "urun";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.Appearance.Normal.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            tileViewItemElement5.Appearance.Normal.ForeColor = System.Drawing.Color.YellowGreen;
            tileViewItemElement5.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement5.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement5.Column = this.olcu_birimi;
            tileViewItemElement5.ColumnIndex = 2;
            tileViewItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement5.RowIndex = 2;
            tileViewItemElement5.Text = "olcu_birimi";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.Column = this.miktar;
            tileViewItemElement6.ColumnIndex = 1;
            tileViewItemElement6.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement6.RowIndex = 2;
            tileViewItemElement6.Text = "miktar";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tv_masalar.TileTemplate.Add(tileViewItemElement4);
            this.tv_masalar.TileTemplate.Add(tileViewItemElement5);
            this.tv_masalar.TileTemplate.Add(tileViewItemElement6);
            // 
            // urun_id
            // 
            this.urun_id.Caption = "Ürün ID";
            this.urun_id.FieldName = "urun_id";
            this.urun_id.Name = "urun_id";
            this.urun_id.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.urun_id.Visible = true;
            this.urun_id.VisibleIndex = 0;
            // 
            // urun
            // 
            this.urun.Caption = "Ürün";
            this.urun.FieldName = "urun_adi";
            this.urun.Name = "urun";
            this.urun.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.urun.Visible = true;
            this.urun.VisibleIndex = 1;
            // 
            // miktar
            // 
            this.miktar.Caption = "Miktar";
            this.miktar.DisplayFormat.FormatString = "n2";
            this.miktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.miktar.FieldName = "miktar";
            this.miktar.Name = "miktar";
            this.miktar.Visible = true;
            this.miktar.VisibleIndex = 2;
            // 
            // olcu_birimi
            // 
            this.olcu_birimi.Caption = "Ölçü Birimi";
            this.olcu_birimi.FieldName = "olcu_birimi";
            this.olcu_birimi.Name = "olcu_birimi";
            this.olcu_birimi.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.olcu_birimi.Visible = true;
            this.olcu_birimi.VisibleIndex = 3;
            // 
            // btn_adisyona_ekle
            // 
            this.btn_adisyona_ekle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_adisyona_ekle.BackColor = System.Drawing.Color.GreenYellow;
            this.btn_adisyona_ekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_adisyona_ekle.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_adisyona_ekle.FlatAppearance.BorderSize = 5;
            this.btn_adisyona_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adisyona_ekle.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_adisyona_ekle.ForeColor = System.Drawing.Color.DimGray;
            this.btn_adisyona_ekle.Location = new System.Drawing.Point(296, 516);
            this.btn_adisyona_ekle.Margin = new System.Windows.Forms.Padding(5);
            this.btn_adisyona_ekle.Name = "btn_adisyona_ekle";
            this.btn_adisyona_ekle.Size = new System.Drawing.Size(619, 50);
            this.btn_adisyona_ekle.TabIndex = 98;
            this.btn_adisyona_ekle.Text = "ADİSYONA EKLE";
            this.btn_adisyona_ekle.UseVisualStyleBackColor = false;
            this.btn_adisyona_ekle.Click += new System.EventHandler(this.btn_adisyona_ekle_Click);
            // 
            // btn_iptal
            // 
            this.btn_iptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_iptal.BackColor = System.Drawing.Color.GreenYellow;
            this.btn_iptal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_iptal.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_iptal.FlatAppearance.BorderSize = 5;
            this.btn_iptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iptal.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_iptal.ForeColor = System.Drawing.Color.DimGray;
            this.btn_iptal.Location = new System.Drawing.Point(12, 516);
            this.btn_iptal.Margin = new System.Windows.Forms.Padding(5);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(274, 50);
            this.btn_iptal.TabIndex = 99;
            this.btn_iptal.Text = "İPTAL";
            this.btn_iptal.UseVisualStyleBackColor = false;
            this.btn_iptal.Click += new System.EventHandler(this.btn_iptal_Click);
            // 
            // secim
            // 
            this.secim.Caption = "Seçim";
            this.secim.FieldName = "secim";
            this.secim.Name = "secim";
            this.secim.Visible = true;
            this.secim.VisibleIndex = 4;
            // 
            // pos_masa_sicak_satis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(929, 580);
            this.Controls.Add(this.btn_iptal);
            this.Controls.Add(this.btn_adisyona_ekle);
            this.Controls.Add(this.grid_masalar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_masa_sicak_satis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_masa_sicak_satis";
            this.Load += new System.EventHandler(this.pos_masa_sicak_satis_Load);
            this.Click += new System.EventHandler(this.pos_masa_sicak_satis_Click);
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv_masalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_masalar;
        private DevExpress.XtraGrid.Views.Tile.TileView tv_masalar;
        private DevExpress.XtraGrid.Columns.TileViewColumn urun_id;
        private DevExpress.XtraGrid.Columns.TileViewColumn urun;
        private DevExpress.XtraGrid.Columns.TileViewColumn miktar;
        private DevExpress.XtraGrid.Columns.TileViewColumn olcu_birimi;
        private System.Windows.Forms.Button btn_adisyona_ekle;
        private System.Windows.Forms.Button btn_iptal;
        private DevExpress.XtraGrid.Columns.TileViewColumn secim;
    }
}