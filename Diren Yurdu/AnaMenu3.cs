using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diren_Yurdu
{
    public partial class AnaMenu3 : Form
    {
        public AnaMenu3()
        {
            InitializeComponent();
        }
        SqlConnection ba = new SqlConnection(@"Data Source=LAPTOP-V6IKIGAQ; Initial Catalog=DerinYurt; Integrated Security=True");
        SqlDataAdapter da;
        private void guncel2()
        {
            ba.Open();
            da = new SqlDataAdapter("select ogrno,ad,soyad,telno,kayıt_tar,tc,odano,B_ID,S_ID from ogrenciler order by ogrno desc", ba);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgwTablo.DataSource = tablo;
            ba.Close();
        }
        private void guncel()
        {

            comboBox5.Items.Clear();
            comboBox5.Text = "";
            ba.Open();
            SqlCommand cmg = new SqlCommand("select OdaNo from Odalar where odano not in (select odano from ogrenciler group by odano having count(OdaNo)>=4 )", ba);
            SqlDataReader okug = cmg.ExecuteReader();
            while (okug.Read())
            {

                comboBox5.Items.Add(okug[0].ToString());

            }
            ba.Close();
        }
        private void AnaMenu3_Load(object sender, EventArgs e)
        {

            ba.Open();
            SqlCommand cm = new SqlCommand("select B_Isim from bolum", ba);
            SqlDataReader oku = cm.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku[0].ToString());

            }
            ba.Close();
            ba.Open();
            SqlCommand cma = new SqlCommand("select S_Isim from Sehir", ba);
            SqlDataReader okua = cma.ExecuteReader();
            while (okua.Read())
            {
                comboBox1.Items.Add(okua[0].ToString());

            }
            ba.Close();
            //-----Datagriw veri çekme---
            ba.Open();
            da = new SqlDataAdapter("select ogrno,ad,soyad,telno,kayıt_tar,tc,odano,B_ID,S_ID from ogrenciler order by ogrno desc", ba);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgwTablo.DataSource = tablo;
            ba.Close();

            ba.Open();
            da = new SqlDataAdapter("select ogrno,ad,soyad from ogrenciler", ba);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dgwtablo2.DataSource = tablo2;
            ba.Close();

            //---Duyuru personeli çekeme---
            ba.Open();
            SqlCommand cmb = new SqlCommand("select Personel_ID from personel", ba);
            SqlDataReader okub = cmb.ExecuteReader();
            while (okub.Read())
            {
                comboBox3.Items.Add(okub[0].ToString());

            }
            ba.Close();

            ba.Open();
            SqlCommand cmc = new SqlCommand("select * from Ogrenciler", ba);
            SqlDataReader okuc = cmc.ExecuteReader();
            while (okuc.Read())
            {
                comboBox4.Items.Add(okuc[0].ToString());

            }
            ba.Close();

            ba.Open();
            SqlCommand cmg = new SqlCommand("select OdaNo from Odalar where odano not in (select odano from ogrenciler group by odano having count(OdaNo)>=4 )", ba);
            SqlDataReader okug = cmg.ExecuteReader();
            while (okug.Read())
            {

                comboBox5.Items.Add(okug[0].ToString());

            }
            ba.Close();
            ///---------- Duyuru datagriw
            ///
            ba.Open();
            da = new SqlDataAdapter("select Duyuru_ID,Personel_ID,Aciklama,Tarih from Duyuru order by Duyuru_ID desc", ba);
            DataTable tablo3 = new DataTable();
            da.Fill(tablo3);
            dgwduyuru.DataSource = tablo3;
            ba.Close();

            ba.Open();
            da = new SqlDataAdapter("select Izin_ID,ogrno,Aciklama,Numara,Bas_Tar,Bit_Tar,Personel_ID from Izinler order by Izin_ID desc", ba);
            DataTable tablo4 = new DataTable();
            da.Fill(tablo4);
            dgwizinler.DataSource = tablo4;
            ba.Close();


            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void izinlerguncel()
        {
            ba.Open();
            da = new SqlDataAdapter("select Izin_ID,ogrno,Aciklama,Numara,Bas_Tar,Bit_Tar,Personel_ID from Izinler order by Izin_ID desc", ba);
            DataTable tablo4 = new DataTable();
            da.Fill(tablo4);
            dgwizinler.DataSource = tablo4;
            ba.Close();
        }
        private void duyurularguncel()
        {
            ba.Open();
            da = new SqlDataAdapter("select Duyuru_ID,Personel_ID,Aciklama,Tarih from Duyuru order by Duyuru_ID desc", ba);
            DataTable tablo3 = new DataTable();
            da.Fill(tablo3);
            dgwduyuru.DataSource = tablo3;
            ba.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void dgwTablo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // ogrno0,ad1,soyad2,telno3,kayıt_tar4,tc5,odano6,B_ID7,S_ID8
            textBox5.Text = dgwTablo.CurrentRow.Cells[0].Value.ToString();//id
            textBox1.Text = dgwTablo.CurrentRow.Cells[1].Value.ToString();//adı
            textBox2.Text = dgwTablo.CurrentRow.Cells[2].Value.ToString();//soyadı
            textBox3.Text = dgwTablo.CurrentRow.Cells[3].Value.ToString();//telno
            textBox4.Text = dgwTablo.CurrentRow.Cells[5].Value.ToString();//tc
            comboBox2.Text = comboBox2.Items[(Convert.ToInt32(dgwTablo.CurrentRow.Cells[7].Value.ToString())) - 1].ToString();//bid
            comboBox1.Text = comboBox1.Items[(Convert.ToInt32(dgwTablo.CurrentRow.Cells[8].Value.ToString())) - 1].ToString();//sId
            comboBox5.Text = dgwTablo.CurrentRow.Cells[6].Value.ToString();// oda
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand duyuru = new SqlCommand("Insert into Duyuru(Personel_ID,Aciklama) values(@perno,@ack)", ba);
                duyuru.Parameters.AddWithValue("@perno", comboBox3.Text);
                duyuru.Parameters.AddWithValue("@ack", richTextBox1.Text);
                ba.Open();
                duyuru.ExecuteNonQuery();
                ba.Close();
                MessageBox.Show("Duyuru Yayınladı...");
                duyurularguncel();
               
            }
            catch
            {
                MessageBox.Show("Hatalı Giriş Yaptınız...");
            }
        }
        // İzizn ver butonu
        private void butt_Click(object sender, EventArgs e)
        {
            if ((comboBox4.Text != "" )&& (textBox7.Text != "") && (textBox8.Text != ""))
            {
                if ((dateTimePicker1.Value) < (dateTimePicker2.Value))
                {
                    SqlCommand izin = new SqlCommand("insert Izinler(ogrno,Aciklama,Numara,Bas_Tar,Bit_Tar) values(@ogrno,@Aciklama,@Numara,@tarih,@bit_tarih)", ba);// başlangıç ve bititş tarihleri
                    izin.Parameters.AddWithValue("@ogrno", comboBox4.Text.ToString());
                    izin.Parameters.AddWithValue("@aciklama", textBox7.Text.ToString());
                    izin.Parameters.AddWithValue("@numara", textBox8.Text.ToString());
                    izin.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                    izin.Parameters.AddWithValue("@bit_tarih", dateTimePicker2.Value);
                    ba.Open();
                    izin.ExecuteNonQuery();
                    ba.Close();
                    MessageBox.Show("İzin Alındı...");
                    izinlerguncel();
                }
                else
                {
                    MessageBox.Show("Bitiş Tarihi Başlangıç Tarihinden Büyük Olmalı");
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bıraktınız...");
            }
        }

        private void dgwtablo2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboBox4.Text = dgwtablo2.CurrentRow.Cells[0].Value.ToString();
        }

        private void m3Kayit_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("Update Ogrenciler Set S_ID=@sehir,B_ID=@bolum,Ad=@adi,Soyad=@soyad,Tc=@tc,TelNo=@telno where ogrno=@id", ba);
            guncelle.Parameters.AddWithValue("@sehir", (comboBox1.SelectedIndex + 1));
            guncelle.Parameters.AddWithValue("@bolum", (comboBox2.SelectedIndex + 1));
            guncelle.Parameters.AddWithValue("@adi",textBox1.Text.ToString());
            guncelle.Parameters.AddWithValue("@soyad",textBox2.Text.ToString());
            guncelle.Parameters.AddWithValue("@tc",textBox4.Text.ToString());
            guncelle.Parameters.AddWithValue("@telno",textBox3.Text.ToString());
            guncelle.Parameters.AddWithValue("@id", textBox5.Text.ToString());
            ba.Open();
            guncelle.ExecuteNonQuery();
            ba.Close();
            MessageBox.Show("Kayıt Güncellendi...");
            

            ba.Open();
            da = new SqlDataAdapter("select ogrno,ad,soyad,telno,kayıt_tar,tc,odano,B_ID,S_ID from ogrenciler order by ogrno desc", ba);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgwTablo.DataSource = tablo;
            ba.Close();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
