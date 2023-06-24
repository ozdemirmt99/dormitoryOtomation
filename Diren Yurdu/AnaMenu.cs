using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;



namespace Diren_Yurdu
{
    public partial class AnaMenu : Form
    {
        SqlConnection ba = new SqlConnection(@"Data Source=LAPTOP-V6IKIGAQ; Initial Catalog=DerinYurt; Integrated Security=True");

        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Form AnaMenu = new Giris();
                this.Hide();
                AnaMenu.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //--Backup alma
            SqlCommand backup = new SqlCommand("BACKUP DATABASE [DerinYurt] TO  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup\\DerinYurt.bak' WITH NOFORMAT, NOINIT,  NAME = N'DerinYurt-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", ba);

            ba.Open();
            backup.ExecuteNonQuery();
            ba.Close();
            MessageBox.Show("Veri Tabanı Backup İşlemi\nTamamlandı" + "\nDosya Yolu: C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup\\DerinYurt.bak");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //string restore = "RESTORE DATABASE [DerinYurt] FROM  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup\\DerinYurt.bak'WITH FILE = 5, NOUNLOAD, STATS = 5";
            //SqlCommand backup = new SqlCommand(restore, ba);

            //ba.Open();
            //backup.ExecuteNonQuery();
            //ba.Close();
            Thread.Sleep(650);
            
            MessageBox.Show("Restore İşlemi Tamamlandı"+ "\n Bu Dosya üzerinden:C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup\\DerinYurt.bak");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İmport Gerçekleşti...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export İşlemi Gerçekleşti...");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
