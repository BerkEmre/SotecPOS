namespace sotec_pos
{
    partial class personel_yetki
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
            this.tl_yetkiler = new DevExpress.XtraTreeList.TreeList();
            this.tlc_yetki_adi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lbl_kullanici_adi = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tl_yetkiler)).BeginInit();
            this.SuspendLayout();
            // 
            // tl_yetkiler
            // 
            this.tl_yetkiler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tl_yetkiler.CheckBoxFieldName = "kullanici_yetki";
            this.tl_yetkiler.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn1,
            this.tlc_yetki_adi});
            this.tl_yetkiler.KeyFieldName = "yetki_id";
            this.tl_yetkiler.Location = new System.Drawing.Point(12, 54);
            this.tl_yetkiler.Name = "tl_yetkiler";
            this.tl_yetkiler.OptionsSelection.MultiSelect = true;
            this.tl_yetkiler.OptionsView.ShowCheckBoxes = true;
            this.tl_yetkiler.ParentFieldName = "ust_yetki_id";
            this.tl_yetkiler.Size = new System.Drawing.Size(868, 525);
            this.tl_yetkiler.TabIndex = 0;
            // 
            // tlc_yetki_adi
            // 
            this.tlc_yetki_adi.Caption = "Yetki Adı";
            this.tlc_yetki_adi.FieldName = "yetki_adi";
            this.tlc_yetki_adi.MinWidth = 34;
            this.tlc_yetki_adi.Name = "tlc_yetki_adi";
            this.tlc_yetki_adi.OptionsColumn.AllowEdit = false;
            this.tlc_yetki_adi.Visible = true;
            this.tlc_yetki_adi.VisibleIndex = 0;
            // 
            // lbl_kullanici_adi
            // 
            this.lbl_kullanici_adi.AutoSize = true;
            this.lbl_kullanici_adi.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullanici_adi.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_kullanici_adi.Location = new System.Drawing.Point(5, 9);
            this.lbl_kullanici_adi.Name = "lbl_kullanici_adi";
            this.lbl_kullanici_adi.Size = new System.Drawing.Size(114, 42);
            this.lbl_kullanici_adi.TabIndex = 4;
            this.lbl_kullanici_adi.Text = "ADİSYON";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button3.FlatAppearance.BorderSize = 5;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Bahnschrift Condensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.GreenYellow;
            this.button3.Location = new System.Drawing.Point(14, 587);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(866, 94);
            this.button3.TabIndex = 30;
            this.button3.Text = "KAYDET";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Yetki ID";
            this.treeListColumn1.FieldName = "yetki_id";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Kullanici Yetki";
            this.treeListColumn2.FieldName = "kullanici_yetki";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // personel_yetki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 695);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbl_kullanici_adi);
            this.Controls.Add(this.tl_yetkiler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "personel_yetki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Yetki";
            this.Load += new System.EventHandler(this.personel_yetki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tl_yetkiler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tl_yetkiler;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlc_yetki_adi;
        private System.Windows.Forms.Label lbl_kullanici_adi;
        private System.Windows.Forms.Button button3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}