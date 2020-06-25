namespace sotec_pos
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_enter = new System.Windows.Forms.Button();
            this.btn_0 = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_9 = new System.Windows.Forms.Button();
            this.btn_8 = new System.Windows.Forms.Button();
            this.btn_7 = new System.Windows.Forms.Button();
            this.btn_6 = new System.Windows.Forms.Button();
            this.btn_5 = new System.Windows.Forms.Button();
            this.btn_4 = new System.Windows.Forms.Button();
            this.btn_3 = new System.Windows.Forms.Button();
            this.btn_2 = new System.Windows.Forms.Button();
            this.btn_1 = new System.Windows.Forms.Button();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.lbl_versiyon = new System.Windows.Forms.Label();
            this.lbl_baglanti = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btn_enter);
            this.panel1.Controls.Add(this.btn_0);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.btn_9);
            this.panel1.Controls.Add(this.btn_8);
            this.panel1.Controls.Add(this.btn_7);
            this.panel1.Controls.Add(this.btn_6);
            this.panel1.Controls.Add(this.btn_5);
            this.panel1.Controls.Add(this.btn_4);
            this.panel1.Controls.Add(this.btn_3);
            this.panel1.Controls.Add(this.btn_2);
            this.panel1.Controls.Add(this.btn_1);
            this.panel1.Controls.Add(this.tb_pass);
            this.panel1.Location = new System.Drawing.Point(626, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 494);
            this.panel1.TabIndex = 0;
            // 
            // btn_enter
            // 
            this.btn_enter.BackgroundImage = global::sotec_pos.Properties.Resources.icon_checked;
            this.btn_enter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_enter.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_enter.FlatAppearance.BorderSize = 5;
            this.btn_enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_enter.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_enter.Location = new System.Drawing.Point(275, 398);
            this.btn_enter.Margin = new System.Windows.Forms.Padding(5);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(125, 90);
            this.btn_enter.TabIndex = 12;
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // btn_0
            // 
            this.btn_0.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_0.FlatAppearance.BorderSize = 5;
            this.btn_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_0.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_0.Location = new System.Drawing.Point(140, 398);
            this.btn_0.Margin = new System.Windows.Forms.Padding(5);
            this.btn_0.Name = "btn_0";
            this.btn_0.Size = new System.Drawing.Size(125, 90);
            this.btn_0.TabIndex = 11;
            this.btn_0.Text = "0";
            this.btn_0.UseVisualStyleBackColor = true;
            this.btn_0.Click += new System.EventHandler(this.btn_0_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackgroundImage = global::sotec_pos.Properties.Resources.icon_cancel;
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_clear.FlatAppearance.BorderSize = 5;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_clear.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_clear.Location = new System.Drawing.Point(5, 398);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(5);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(125, 90);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_9
            // 
            this.btn_9.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_9.FlatAppearance.BorderSize = 5;
            this.btn_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_9.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_9.Location = new System.Drawing.Point(275, 298);
            this.btn_9.Margin = new System.Windows.Forms.Padding(5);
            this.btn_9.Name = "btn_9";
            this.btn_9.Size = new System.Drawing.Size(125, 90);
            this.btn_9.TabIndex = 9;
            this.btn_9.Text = "9";
            this.btn_9.UseVisualStyleBackColor = true;
            this.btn_9.Click += new System.EventHandler(this.btn_9_Click);
            // 
            // btn_8
            // 
            this.btn_8.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_8.FlatAppearance.BorderSize = 5;
            this.btn_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_8.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_8.Location = new System.Drawing.Point(140, 298);
            this.btn_8.Margin = new System.Windows.Forms.Padding(5);
            this.btn_8.Name = "btn_8";
            this.btn_8.Size = new System.Drawing.Size(125, 90);
            this.btn_8.TabIndex = 8;
            this.btn_8.Text = "8";
            this.btn_8.UseVisualStyleBackColor = true;
            this.btn_8.Click += new System.EventHandler(this.btn_8_Click);
            // 
            // btn_7
            // 
            this.btn_7.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_7.FlatAppearance.BorderSize = 5;
            this.btn_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_7.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_7.Location = new System.Drawing.Point(5, 298);
            this.btn_7.Margin = new System.Windows.Forms.Padding(5);
            this.btn_7.Name = "btn_7";
            this.btn_7.Size = new System.Drawing.Size(125, 90);
            this.btn_7.TabIndex = 7;
            this.btn_7.Text = "7";
            this.btn_7.UseVisualStyleBackColor = true;
            this.btn_7.Click += new System.EventHandler(this.btn_7_Click);
            // 
            // btn_6
            // 
            this.btn_6.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_6.FlatAppearance.BorderSize = 5;
            this.btn_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_6.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_6.Location = new System.Drawing.Point(275, 198);
            this.btn_6.Margin = new System.Windows.Forms.Padding(5);
            this.btn_6.Name = "btn_6";
            this.btn_6.Size = new System.Drawing.Size(125, 90);
            this.btn_6.TabIndex = 6;
            this.btn_6.Text = "6";
            this.btn_6.UseVisualStyleBackColor = true;
            this.btn_6.Click += new System.EventHandler(this.btn_6_Click);
            // 
            // btn_5
            // 
            this.btn_5.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_5.FlatAppearance.BorderSize = 5;
            this.btn_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_5.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_5.Location = new System.Drawing.Point(140, 198);
            this.btn_5.Margin = new System.Windows.Forms.Padding(5);
            this.btn_5.Name = "btn_5";
            this.btn_5.Size = new System.Drawing.Size(125, 90);
            this.btn_5.TabIndex = 5;
            this.btn_5.Text = "5";
            this.btn_5.UseVisualStyleBackColor = true;
            this.btn_5.Click += new System.EventHandler(this.btn_5_Click);
            // 
            // btn_4
            // 
            this.btn_4.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_4.FlatAppearance.BorderSize = 5;
            this.btn_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_4.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_4.Location = new System.Drawing.Point(5, 198);
            this.btn_4.Margin = new System.Windows.Forms.Padding(5);
            this.btn_4.Name = "btn_4";
            this.btn_4.Size = new System.Drawing.Size(125, 90);
            this.btn_4.TabIndex = 4;
            this.btn_4.Text = "4";
            this.btn_4.UseVisualStyleBackColor = true;
            this.btn_4.Click += new System.EventHandler(this.btn_4_Click);
            // 
            // btn_3
            // 
            this.btn_3.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_3.FlatAppearance.BorderSize = 5;
            this.btn_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_3.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_3.Location = new System.Drawing.Point(275, 98);
            this.btn_3.Margin = new System.Windows.Forms.Padding(5);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(125, 90);
            this.btn_3.TabIndex = 3;
            this.btn_3.Text = "3";
            this.btn_3.UseVisualStyleBackColor = true;
            this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
            // 
            // btn_2
            // 
            this.btn_2.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_2.FlatAppearance.BorderSize = 5;
            this.btn_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_2.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_2.Location = new System.Drawing.Point(140, 98);
            this.btn_2.Margin = new System.Windows.Forms.Padding(5);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(125, 90);
            this.btn_2.TabIndex = 2;
            this.btn_2.Text = "2";
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // btn_1
            // 
            this.btn_1.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btn_1.FlatAppearance.BorderSize = 5;
            this.btn_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_1.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_1.Location = new System.Drawing.Point(5, 98);
            this.btn_1.Margin = new System.Windows.Forms.Padding(5);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(125, 90);
            this.btn_1.TabIndex = 1;
            this.btn_1.Text = "1";
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // tb_pass
            // 
            this.tb_pass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_pass.ForeColor = System.Drawing.Color.GreenYellow;
            this.tb_pass.Location = new System.Drawing.Point(5, 5);
            this.tb_pass.Margin = new System.Windows.Forms.Padding(5);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.PasswordChar = '*';
            this.tb_pass.Size = new System.Drawing.Size(395, 83);
            this.tb_pass.TabIndex = 0;
            this.tb_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_pass_KeyDown);
            this.tb_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pass_KeyPress);
            // 
            // lbl_versiyon
            // 
            this.lbl_versiyon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_versiyon.AutoSize = true;
            this.lbl_versiyon.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_versiyon.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_versiyon.Location = new System.Drawing.Point(12, 761);
            this.lbl_versiyon.Name = "lbl_versiyon";
            this.lbl_versiyon.Size = new System.Drawing.Size(37, 13);
            this.lbl_versiyon.TabIndex = 17;
            this.lbl_versiyon.Text = "0.0.0.0";
            // 
            // lbl_baglanti
            // 
            this.lbl_baglanti.AutoSize = true;
            this.lbl_baglanti.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_baglanti.ForeColor = System.Drawing.Color.LawnGreen;
            this.lbl_baglanti.Location = new System.Drawing.Point(12, 9);
            this.lbl_baglanti.Name = "lbl_baglanti";
            this.lbl_baglanti.Size = new System.Drawing.Size(68, 13);
            this.lbl_baglanti.TabIndex = 18;
            this.lbl_baglanti.Text = "Bağlantı Yok";
            this.lbl_baglanti.Click += new System.EventHandler(this.lbl_baglanti_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::sotec_pos.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(15, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(561, 582);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.BackgroundImage = global::sotec_pos.Properties.Resources.icon_sing_out;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(932, 699);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 75);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(979, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "SotecMedia";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1044, 788);
            this.Controls.Add(this.lbl_baglanti);
            this.Controls.Add(this.lbl_versiyon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.Button btn_0;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_9;
        private System.Windows.Forms.Button btn_8;
        private System.Windows.Forms.Button btn_7;
        private System.Windows.Forms.Button btn_6;
        private System.Windows.Forms.Button btn_5;
        private System.Windows.Forms.Button btn_4;
        private System.Windows.Forms.Button btn_3;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_versiyon;
        private System.Windows.Forms.Label lbl_baglanti;
        private System.Windows.Forms.Label label2;
    }
}

