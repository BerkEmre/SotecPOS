namespace sotec_pos
{
    partial class pos_masa_kurye_sec
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
            this.button4 = new System.Windows.Forms.Button();
            this.grid_masalar = new DevExpress.XtraGrid.GridControl();
            this.gv_masalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_masalar)).BeginInit();
            this.SuspendLayout();
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
            this.button4.Location = new System.Drawing.Point(711, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 75);
            this.button4.TabIndex = 36;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // grid_masalar
            // 
            this.grid_masalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_masalar.Location = new System.Drawing.Point(12, 14);
            this.grid_masalar.MainView = this.gv_masalar;
            this.grid_masalar.Name = "grid_masalar";
            this.grid_masalar.Size = new System.Drawing.Size(691, 424);
            this.grid_masalar.TabIndex = 37;
            this.grid_masalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_masalar});
            this.grid_masalar.DoubleClick += new System.EventHandler(this.grid_masalar_DoubleClick);
            // 
            // gv_masalar
            // 
            this.gv_masalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5});
            this.gv_masalar.GridControl = this.grid_masalar;
            this.gv_masalar.Name = "gv_masalar";
            this.gv_masalar.OptionsBehavior.Editable = false;
            this.gv_masalar.OptionsView.ShowColumnHeaders = false;
            this.gv_masalar.OptionsView.ShowGroupPanel = false;
            this.gv_masalar.RowHeight = 40;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kullanıcı ID";
            this.gridColumn3.FieldName = "kullanici_id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridColumn5.AppearanceCell.ForeColor = System.Drawing.Color.DimGray;
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn5.Caption = "Personel";
            this.gridColumn5.FieldName = "ad_soyad";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // pos_masa_kurye_sec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid_masalar);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_masa_kurye_sec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_masa_kurye_sec";
            this.Load += new System.EventHandler(this.pos_masa_kurye_sec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_masalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_masalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private DevExpress.XtraGrid.GridControl grid_masalar;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_masalar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}