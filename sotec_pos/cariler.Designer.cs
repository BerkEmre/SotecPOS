namespace sotec_pos
{
    partial class cariler
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
            this.button2 = new System.Windows.Forms.Button();
            this.btn_log_out = new System.Windows.Forms.Button();
            this.grid_cariler = new DevExpress.XtraGrid.GridControl();
            this.gv_cariler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cariler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_cariler)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.GreenYellow;
            this.button2.Image = global::sotec_pos.Properties.Resources.icon_people;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(14, 582);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 105);
            this.button2.TabIndex = 21;
            this.button2.Text = "CARİ EKLE";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.btn_log_out.Location = new System.Drawing.Point(957, 14);
            this.btn_log_out.Margin = new System.Windows.Forms.Padding(5);
            this.btn_log_out.Name = "btn_log_out";
            this.btn_log_out.Size = new System.Drawing.Size(150, 105);
            this.btn_log_out.TabIndex = 17;
            this.btn_log_out.UseVisualStyleBackColor = false;
            this.btn_log_out.Click += new System.EventHandler(this.btn_log_out_Click);
            // 
            // grid_cariler
            // 
            this.grid_cariler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_cariler.Location = new System.Drawing.Point(14, 127);
            this.grid_cariler.MainView = this.gv_cariler;
            this.grid_cariler.Name = "grid_cariler";
            this.grid_cariler.Size = new System.Drawing.Size(1093, 447);
            this.grid_cariler.TabIndex = 22;
            this.grid_cariler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_cariler});
            this.grid_cariler.DoubleClick += new System.EventHandler(this.grid_cariler_DoubleClick);
            this.grid_cariler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_cariler_KeyDown);
            // 
            // gv_cariler
            // 
            this.gv_cariler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5});
            this.gv_cariler.GridControl = this.grid_cariler;
            this.gv_cariler.Name = "gv_cariler";
            this.gv_cariler.OptionsBehavior.Editable = false;
            this.gv_cariler.OptionsView.ShowAutoFilterRow = true;
            this.gv_cariler.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cari ID";
            this.gridColumn3.FieldName = "cari_id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cari Adı";
            this.gridColumn1.FieldName = "cari_adi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tip";
            this.gridColumn2.FieldName = "deger";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Telefon";
            this.gridColumn4.FieldName = "telefon";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Bakiye";
            this.gridColumn5.DisplayFormat.FormatString = "c2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "bakiye";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // cariler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 701);
            this.Controls.Add(this.grid_cariler);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_log_out);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cariler";
            this.Text = "cariler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cariler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_cariler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_cariler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_log_out;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.GridControl grid_cariler;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_cariler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}