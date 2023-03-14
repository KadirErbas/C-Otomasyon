namespace Pansiyon_Otomasyonu
{
    partial class FrmOdalar
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnOda101 = new System.Windows.Forms.Button();
            this.BtnOda102 = new System.Windows.Forms.Button();
            this.BtnOda103 = new System.Windows.Forms.Button();
            this.BtnOda104 = new System.Windows.Forms.Button();
            this.BtnOda105 = new System.Windows.Forms.Button();
            this.BtnOda106 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(29, 261);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(725, 130);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Müşteri Adı";
            this.columnHeader2.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Müşteri Soyadı";
            this.columnHeader3.Width = 152;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giriş Tarihi";
            this.columnHeader4.Width = 128;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Çıkış Tarihi";
            this.columnHeader5.Width = 123;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Oda No";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Kalan Gün";
            this.columnHeader7.Width = 76;
            // 
            // BtnOda101
            // 
            this.BtnOda101.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnOda101.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOda101.Location = new System.Drawing.Point(96, 26);
            this.BtnOda101.Name = "BtnOda101";
            this.BtnOda101.Size = new System.Drawing.Size(93, 77);
            this.BtnOda101.TabIndex = 2;
            this.BtnOda101.Text = "Oda101";
            this.BtnOda101.UseVisualStyleBackColor = false;
            // 
            // BtnOda102
            // 
            this.BtnOda102.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnOda102.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOda102.Location = new System.Drawing.Point(349, 26);
            this.BtnOda102.Name = "BtnOda102";
            this.BtnOda102.Size = new System.Drawing.Size(93, 77);
            this.BtnOda102.TabIndex = 3;
            this.BtnOda102.Text = "Oda102";
            this.BtnOda102.UseVisualStyleBackColor = false;
            // 
            // BtnOda103
            // 
            this.BtnOda103.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnOda103.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOda103.Location = new System.Drawing.Point(570, 26);
            this.BtnOda103.Name = "BtnOda103";
            this.BtnOda103.Size = new System.Drawing.Size(93, 77);
            this.BtnOda103.TabIndex = 4;
            this.BtnOda103.Text = "Oda103";
            this.BtnOda103.UseVisualStyleBackColor = false;
            // 
            // BtnOda104
            // 
            this.BtnOda104.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnOda104.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOda104.Location = new System.Drawing.Point(96, 162);
            this.BtnOda104.Name = "BtnOda104";
            this.BtnOda104.Size = new System.Drawing.Size(93, 77);
            this.BtnOda104.TabIndex = 5;
            this.BtnOda104.Text = "Oda104";
            this.BtnOda104.UseVisualStyleBackColor = false;
            // 
            // BtnOda105
            // 
            this.BtnOda105.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnOda105.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOda105.Location = new System.Drawing.Point(349, 162);
            this.BtnOda105.Name = "BtnOda105";
            this.BtnOda105.Size = new System.Drawing.Size(93, 77);
            this.BtnOda105.TabIndex = 6;
            this.BtnOda105.Text = "Oda105";
            this.BtnOda105.UseVisualStyleBackColor = false;
            // 
            // BtnOda106
            // 
            this.BtnOda106.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnOda106.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOda106.Location = new System.Drawing.Point(570, 162);
            this.BtnOda106.Name = "BtnOda106";
            this.BtnOda106.Size = new System.Drawing.Size(93, 77);
            this.BtnOda106.TabIndex = 7;
            this.BtnOda106.Text = "Oda106";
            this.BtnOda106.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(179)))), ((int)(((byte)(38)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(29, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 35);
            this.button4.TabIndex = 31;
            this.button4.Text = "Geri";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FrmOdalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BtnOda106);
            this.Controls.Add(this.BtnOda105);
            this.Controls.Add(this.BtnOda104);
            this.Controls.Add(this.BtnOda103);
            this.Controls.Add(this.BtnOda102);
            this.Controls.Add(this.BtnOda101);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.Name = "FrmOdalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odalar";
            this.Load += new System.EventHandler(this.FrmOdalar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnOda101;
        private System.Windows.Forms.Button BtnOda102;
        private System.Windows.Forms.Button BtnOda103;
        private System.Windows.Forms.Button BtnOda104;
        private System.Windows.Forms.Button BtnOda105;
        private System.Windows.Forms.Button BtnOda106;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button button4;
    }
}