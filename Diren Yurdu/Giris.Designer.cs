
namespace Diren_Yurdu
{
    partial class Giris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.giris_kullaniciaditxt = new System.Windows.Forms.TextBox();
            this.giris_kadilbl = new System.Windows.Forms.Label();
            this.giris_sifrelbl = new System.Windows.Forms.Label();
            this.giris_sifretxt = new System.Windows.Forms.TextBox();
            this.giris_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // giris_kullaniciaditxt
            // 
            this.giris_kullaniciaditxt.Location = new System.Drawing.Point(191, 105);
            this.giris_kullaniciaditxt.Name = "giris_kullaniciaditxt";
            this.giris_kullaniciaditxt.Size = new System.Drawing.Size(125, 27);
            this.giris_kullaniciaditxt.TabIndex = 0;
            // 
            // giris_kadilbl
            // 
            this.giris_kadilbl.AutoSize = true;
            this.giris_kadilbl.Location = new System.Drawing.Point(191, 74);
            this.giris_kadilbl.Name = "giris_kadilbl";
            this.giris_kadilbl.Size = new System.Drawing.Size(92, 20);
            this.giris_kadilbl.TabIndex = 1;
            this.giris_kadilbl.Text = "Kullanıcı Adı";
            // 
            // giris_sifrelbl
            // 
            this.giris_sifrelbl.AutoSize = true;
            this.giris_sifrelbl.Location = new System.Drawing.Point(191, 162);
            this.giris_sifrelbl.Name = "giris_sifrelbl";
            this.giris_sifrelbl.Size = new System.Drawing.Size(39, 20);
            this.giris_sifrelbl.TabIndex = 2;
            this.giris_sifrelbl.Text = "Şifre";
            // 
            // giris_sifretxt
            // 
            this.giris_sifretxt.Location = new System.Drawing.Point(191, 200);
            this.giris_sifretxt.Name = "giris_sifretxt";
            this.giris_sifretxt.PasswordChar = '*';
            this.giris_sifretxt.Size = new System.Drawing.Size(125, 27);
            this.giris_sifretxt.TabIndex = 3;
            // 
            // giris_btn
            // 
            this.giris_btn.Location = new System.Drawing.Point(204, 265);
            this.giris_btn.Name = "giris_btn";
            this.giris_btn.Size = new System.Drawing.Size(94, 29);
            this.giris_btn.TabIndex = 4;
            this.giris_btn.Text = "Oturum Aç";
            this.giris_btn.UseVisualStyleBackColor = true;
            this.giris_btn.Click += new System.EventHandler(this.giris_btn_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 416);
            this.Controls.Add(this.giris_btn);
            this.Controls.Add(this.giris_sifretxt);
            this.Controls.Add(this.giris_sifrelbl);
            this.Controls.Add(this.giris_kadilbl);
            this.Controls.Add(this.giris_kullaniciaditxt);
            this.Name = "Giris";
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox giris_kullaniciaditxt;
        private System.Windows.Forms.Label giris_kadilbl;
        private System.Windows.Forms.Label giris_sifrelbl;
        private System.Windows.Forms.TextBox giris_sifretxt;
        private System.Windows.Forms.Button giris_btn;
    }
}

