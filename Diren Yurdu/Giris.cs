using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diren_Yurdu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void giris_btn_Click(object sender, EventArgs e)
        {
            if ((giris_kullaniciaditxt.Text == "admin") && (giris_sifretxt.Text == "1234"))
            {
                Form AnaMenu = new AnaMenu();
                this.Hide();
                AnaMenu.Show();
            }
            else if ((giris_kullaniciaditxt.Text == "mudur") && (giris_sifretxt.Text == "1235"))
            {
                Form AnaMenu = new AnaMenu2();
                this.Hide();
                AnaMenu.Show();

            }
            else if ((giris_kullaniciaditxt.Text == "personel") && (giris_sifretxt.Text == "1236"))
            {

                Form AnaMenu = new AnaMenu3();
                this.Hide();
                AnaMenu.Show();


            }

            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                    
            }



        }
    }
}

