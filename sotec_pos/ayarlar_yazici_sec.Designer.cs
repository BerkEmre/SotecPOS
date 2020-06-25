namespace sotec_pos
{
    partial class ayarlar_yazici_sec
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
            this.grid_masa_kategori = new DevExpress.XtraGrid.GridControl();
            this.gv_masa_kategori = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_masa_kategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_masa_kategori)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_masa_kategori
            // 
            this.grid_masa_kategori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_masa_kategori.Location = new System.Drawing.Point(12, 12);
            this.grid_masa_kategori.MainView = this.gv_masa_kategori;
            this.grid_masa_kategori.Name = "grid_masa_kategori";
            this.grid_masa_kategori.Size = new System.Drawing.Size(401, 209);
            this.grid_masa_kategori.TabIndex = 35;
            this.grid_masa_kategori.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_masa_kategori});
            this.grid_masa_kategori.DoubleClick += new System.EventHandler(this.grid_masa_kategori_DoubleClick);
            // 
            // gv_masa_kategori
            // 
            this.gv_masa_kategori.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.gv_masa_kategori.GridControl = this.grid_masa_kategori;
            this.gv_masa_kategori.Name = "gv_masa_kategori";
            this.gv_masa_kategori.OptionsBehavior.Editable = false;
            this.gv_masa_kategori.OptionsView.ShowColumnHeaders = false;
            this.gv_masa_kategori.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Yazıcı";
            this.gridColumn2.FieldName = "yazici";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // ayarlar_yazici_sec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 233);
            this.Controls.Add(this.grid_masa_kategori);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ayarlar_yazici_sec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yazıcı Seç";
            this.Load += new System.EventHandler(this.ayarlar_yazici_sec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_masa_kategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_masa_kategori)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_masa_kategori;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_masa_kategori;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}