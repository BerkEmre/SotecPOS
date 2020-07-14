namespace sotec_pos
{
    partial class pos_masa_urun_iptal
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
            this.tb_miktar = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_urun = new System.Windows.Forms.Label();
            this.lbl_miktar = new System.Windows.Forms.Label();
            this.cb_hazirlandi = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb_miktar)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.GreenYellow;
            this.button2.Location = new System.Drawing.Point(12, 211);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(389, 131);
            this.button2.TabIndex = 38;
            this.button2.Text = "İPTAL ET";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_miktar
            // 
            this.tb_miktar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_miktar.DecimalPlaces = 2;
            this.tb_miktar.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_miktar.ForeColor = System.Drawing.Color.DimGray;
            this.tb_miktar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tb_miktar.Location = new System.Drawing.Point(12, 97);
            this.tb_miktar.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tb_miktar.Name = "tb_miktar";
            this.tb_miktar.Size = new System.Drawing.Size(389, 65);
            this.tb_miktar.TabIndex = 61;
            this.tb_miktar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_miktar.Click += new System.EventHandler(this.tb_miktar_Click);
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
            this.button4.Location = new System.Drawing.Point(326, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 75);
            this.button4.TabIndex = 62;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbl_urun
            // 
            this.lbl_urun.AutoSize = true;
            this.lbl_urun.Font = new System.Drawing.Font("Bahnschrift Condensed", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_urun.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_urun.Location = new System.Drawing.Point(12, 9);
            this.lbl_urun.Name = "lbl_urun";
            this.lbl_urun.Size = new System.Drawing.Size(168, 42);
            this.lbl_urun.TabIndex = 63;
            this.lbl_urun.Text = "KATEGORİLER";
            // 
            // lbl_miktar
            // 
            this.lbl_miktar.AutoSize = true;
            this.lbl_miktar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_miktar.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl_miktar.Location = new System.Drawing.Point(15, 51);
            this.lbl_miktar.Name = "lbl_miktar";
            this.lbl_miktar.Size = new System.Drawing.Size(93, 23);
            this.lbl_miktar.TabIndex = 64;
            this.lbl_miktar.Text = "KATEGORİLER";
            // 
            // cb_hazirlandi
            // 
            this.cb_hazirlandi.AutoSize = true;
            this.cb_hazirlandi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_hazirlandi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cb_hazirlandi.Location = new System.Drawing.Point(123, 168);
            this.cb_hazirlandi.Name = "cb_hazirlandi";
            this.cb_hazirlandi.Size = new System.Drawing.Size(164, 35);
            this.cb_hazirlandi.TabIndex = 65;
            this.cb_hazirlandi.Text = "Hazırlandı";
            this.cb_hazirlandi.UseVisualStyleBackColor = true;
            // 
            // pos_masa_urun_iptal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(413, 356);
            this.Controls.Add(this.cb_hazirlandi);
            this.Controls.Add(this.lbl_miktar);
            this.Controls.Add(this.lbl_urun);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tb_miktar);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_masa_urun_iptal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pos_masa_urun_iptal";
            this.Load += new System.EventHandler(this.pos_masa_urun_iptal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_miktar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown tb_miktar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_urun;
        private System.Windows.Forms.Label lbl_miktar;
        private System.Windows.Forms.CheckBox cb_hazirlandi;
    }
}