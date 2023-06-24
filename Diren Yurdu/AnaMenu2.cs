using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diren_Yurdu
{

    public partial class AnaMenu2 : Form
    {
        public AnaMenu2()
        {
            InitializeComponent();
        }
        SqlConnection ba = new SqlConnection(@"Data Source=LAPTOP-V6IKIGAQ; Initial Catalog=DerinYurt; Integrated Security=True");
        SqlDataAdapter da;
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox4.Text != "") && (comboBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != ""))
            {
                if ((dateTimePicker1.Value) < (dateTimePicker2.Value)) {
                    if (comboBox4.Text == "Öğrenciler")
                    {

                        SqlCommand izin = new SqlCommand("insert Izinler(ogrno,Aciklama,Numara,Bas_Tar,Bit_Tar) values(@ogrno,@Aciklama,@Numara,@tarih,@bit_tarih)", ba);// başlangıç ve bititş tarihleri
                        izin.Parameters.AddWithValue("@ogrno", comboBox5.Text.ToString());
                        izin.Parameters.AddWithValue("@aciklama", textBox6.Text.ToString());
                        izin.Parameters.AddWithValue("@numara", textBox7.Text.ToString());
                        izin.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                        izin.Parameters.AddWithValue("@bit_tarih", dateTimePicker1.Value);
                        ba.Open();
                        izin.ExecuteNonQuery();
                        ba.Close();
                        MessageBox.Show("İzin alındı...");
                    }
                    else if (comboBox4.Text == "Personel")
                    {
                        SqlCommand izin = new SqlCommand("insert Izinler(Personel_ID,Aciklama,Numara,Bas_Tar,Bit_Tar) values(@ogrno,@Aciklama,@Numara,@tarih,@bit_tarih)", ba);// başlangıç ve bititş tarihleri
                        izin.Parameters.AddWithValue("@ogrno", comboBox5.Text.ToString());
                        izin.Parameters.AddWithValue("@aciklama", textBox6.Text.ToString());
                        izin.Parameters.AddWithValue("@numara", textBox7.Text.ToString());
                        izin.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                        izin.Parameters.AddWithValue("@bit_tarih", dateTimePicker1.Value);
                        ba.Open();
                        izin.ExecuteNonQuery();
                        ba.Close();
                        MessageBox.Show("İzin Eklendi...");
                    }
                }
                else
                {
                    MessageBox.Show("Başlangıç Tarihi Bitiş Tarihinden Küçük Olmalıdır...");
                    }
            }
            else
            {
                MessageBox.Show("Boş Alan Bıraktınız...");
            }

        }

        private void button5_Click(object sender, EventArgs e)
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



        private void AnaMenu2_Load(object sender, EventArgs e)
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

            ba.Open();
            da = new SqlDataAdapter("select ogrno,ad,soyad,telno,kayıt_tar,tc,B_ID,S_ID from ogrenciler", ba);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgwTablo.DataSource = tablo;
            ba.Close();
            ba.Open();
            SqlCommand cmb = new SqlCommand("select Personel_ID from personel", ba);
            SqlDataReader okub = cmb.ExecuteReader();
            while (okub.Read())
            {
                comboBox3.Items.Add(okub[0].ToString());

            }
            ba.Close();

            ba.Open();
            SqlCommand cmc = new SqlCommand("select B_Isim from bolum", ba);
            SqlDataReader okuc = cmc.ExecuteReader();
            while (okuc.Read())
            {
                comboBox6.Items.Add(okuc[0].ToString());


            }
            ba.Close();




            ba.Open();
            SqlCommand cme = new SqlCommand("select G_Isim from Gorev", ba);
            SqlDataReader okue = cme.ExecuteReader();
            while (okue.Read())
            {
                comboBox8.Items.Add(okue[0].ToString());

            }
            ba.Close();
            //--Oda numaralrını çekme
            ba.Open();
            SqlCommand cmf = new SqlCommand("select * from Odalar", ba);
            SqlDataReader okuf = cmf.ExecuteReader();
            while (okuf.Read())
            {
                comboBox7.Items.Add(okuf[1].ToString());
                // comboBox10.Items.Add(okuf[1].ToString()); alıcam....

            }
            ba.Close();
            ////---Ekle sil kısmına çekme
            // select odano,count(odano) from ogrenciler group by odano odaya göre sayısını getircek
            ba.Open();
            SqlCommand cmg = new SqlCommand("select OdaNo from Odalar where odano not in (select odano from ogrenciler group by odano having count(odano)>=4 )", ba);
            SqlDataReader okug = cmg.ExecuteReader();
            while (okug.Read())
            {

                comboBox10.Items.Add(okug[0].ToString());

            }
            ba.Close();

            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }
        private void guncel2()
        {
            ba.Open();
            da = new SqlDataAdapter("select ogrno,ad,soyad,telno,kayıt_tar,tc,B_ID,S_ID from ogrenciler order by ogrno desc", ba);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgwTablo.DataSource = tablo;
            ba.Close();
        }
        private void guncel()
        {
            comboBox10.Text = " ";
            comboBox10.Items.Clear();
            comboBox10.Text = " ";
            ba.Open();
            SqlCommand cmg = new SqlCommand("select OdaNo from Odalar where odano not in (select odano from ogrenciler group by odano having count(OdaNo)>=4 )", ba);
            SqlDataReader okug = cmg.ExecuteReader();
            while (okug.Read())
            {

                comboBox10.Items.Add(okug[0].ToString());

            }
            ba.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text != "") && (textBox3.Text != "") && (comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox10.Text != ""))
            {
                try
                {

                    SqlCommand ogrgir = new SqlCommand("insert ogrenciler(ad,soyad,tc,telno,S_ID,B_ID,odano) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", ba);
                    ogrgir.Parameters.AddWithValue("@p1", textBox1.Text.ToString());
                    ogrgir.Parameters.AddWithValue("@p2", textBox2.Text.ToString());
                    ogrgir.Parameters.AddWithValue("@p3", textBox4.Text.ToString());
                    ogrgir.Parameters.AddWithValue("@p4", textBox3.Text.ToString());
                    ogrgir.Parameters.AddWithValue("@p5", comboBox1.SelectedIndex + 1);
                    ogrgir.Parameters.AddWithValue("@p6", comboBox2.SelectedIndex + 1);
                    ogrgir.Parameters.AddWithValue("@p7", comboBox10.Text);
                    ba.Open();

                    ogrgir.ExecuteNonQuery();
                    ba.Close();
                    MessageBox.Show("Kayıt başarıyla eklenmiştir");

                }
                catch (Exception)
                {
                    ba.Close();
                    MessageBox.Show("hatalı giriş yaptınız...");
                }
                guncel();
                guncel2();
            }
            else
            {
                MessageBox.Show("Boş Alan bırakılmamalıdır...");
            }

        }






        private void dgwTablo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            // select ogrno,ad,soyad,telno,kayıt_tar,tc,odano,B_ID,S_ID from ogrenciler
            textBox5.Text = dgwTablo.CurrentRow.Cells[0].Value.ToString();//id
            textBox1.Text = dgwTablo.CurrentRow.Cells[1].Value.ToString();//adı
            textBox2.Text = dgwTablo.CurrentRow.Cells[2].Value.ToString();//soyadı
            textBox3.Text = dgwTablo.CurrentRow.Cells[3].Value.ToString();//telno
            textBox4.Text = dgwTablo.CurrentRow.Cells[5].Value.ToString();//tc
            comboBox1.Text = comboBox1.Items[(Convert.ToInt32(dgwTablo.CurrentRow.Cells[6].Value.ToString()))-1].ToString();//bid
            comboBox2.Text = comboBox2.Items[(Convert.ToInt32(dgwTablo.CurrentRow.Cells[7].Value.ToString()))-1].ToString();//sId
           // comboBox10.Text = dgwTablo.CurrentRow.Cells[6].Value.ToString();// oda





        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Text = "";
            comboBox5.Items.Clear();
            if (comboBox4.Text == "Öğrenciler")
            {
                ba.Open();
                SqlCommand cm = new SqlCommand("select * from Ogrenciler", ba);
                SqlDataReader oku = cm.ExecuteReader();
                while (oku.Read())
                {
                    comboBox5.Items.Add(oku[0].ToString());

                }
                ba.Close();
            }

            else if (comboBox4.Text == "Personel")
            {
                ba.Open();
                SqlCommand cm = new SqlCommand("select Personel_ID from personel", ba);
                SqlDataReader oku = cm.ExecuteReader();
                while (oku.Read())
                {
                    comboBox5.Items.Add(oku[0].ToString());

                }
                ba.Close();
            }
            else
            {
                comboBox5.Text = "Lütfen İzin Türünü Seçiniz...";
            }
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
            }
            catch
            {
                ba.Close();
                MessageBox.Show("Hatalı Giriş Yaptınız...");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m3Kayit_Click(object sender, EventArgs e)
        {
            SqlCommand ogrsil = new SqlCommand("delete from Ogrenciler where ogrno=@p1", ba);
            ogrsil.Parameters.AddWithValue("@p1", textBox5.Text.ToString());
            ba.Open();
            ogrsil.ExecuteNonQuery();
            ba.Close();
            MessageBox.Show("Öğrenci Silindi");
            guncel();
            guncel2();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((comboBox6.Text.ToString() == "") && (textBox8.Text == "") && (comboBox7.Text.ToString() == ""))
            {
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler", ba);
                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();

            }
            else if ((comboBox6.Text != "") && (textBox8.Text == "") && (comboBox7.Text == ""))
            {
                //select* from Ogrenciler where bolum = @p1
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where B_ID=@p1", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", comboBox6.SelectedIndex + 1);
                da = new SqlDataAdapter(rprOgrenci);

                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();


            }
            else if ((comboBox6.Text == "") && (textBox8.Text != "") && (comboBox7.Text == ""))
            {
                //select* from Ogrenciler where Ad = @p1
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where Ad =@p1", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", textBox8.Text.ToString());

                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();
            }
            else if ((comboBox6.Text == "") && (textBox8.Text == "") && (comboBox7.Text != ""))
            {
                //select* from Ogrenciler where Odano = @p1
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where OdaNo =@p1", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", comboBox7.Text);
                ;
                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();
            }
            else if ((comboBox6.Text != "") && (textBox8.Text != "") && (comboBox7.Text == ""))
            {
                //select* from Ogrenciler where Odano = @p1
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where B_ID=@p1 and Ad=@p2 ", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", comboBox6.SelectedIndex + 1);
                rprOgrenci.Parameters.AddWithValue("@p2", textBox8.Text.ToString());

                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();
            }
            else if ((comboBox6.Text == "") && (textBox8.Text != "") && (comboBox7.Text != ""))
            {
                //select* from Ogrenciler where Odano = @p1
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where Ad=@p1 and OdaNO=@p2", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", textBox8.Text.ToString());
                rprOgrenci.Parameters.AddWithValue("@p2", comboBox7.Text);

                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();

            }
            else if ((comboBox6.Text != "") && (textBox8.Text == "") && (comboBox7.Text != ""))
            {
                //select* from Ogrenciler where Odano = @p1
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where B_ID=@p1 and OdaNo=@p2", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", comboBox6.SelectedIndex + 1);
                rprOgrenci.Parameters.AddWithValue("@p2", comboBox7.Text);

                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();
            }
            else
            {
                ba.Open();
                SqlCommand rprOgrenci = new SqlCommand("select * from Ogrenciler where B_ID=@p1 and Ad=@p2 and OdaNo=@p3", ba);
                rprOgrenci.Parameters.AddWithValue("@p1", comboBox6.SelectedIndex + 1);
                rprOgrenci.Parameters.AddWithValue("@p2", textBox8.Text.ToString());
                rprOgrenci.Parameters.AddWithValue("@p3", comboBox7.Text);
                da = new SqlDataAdapter(rprOgrenci);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporogr.DataSource = tablo;
                ba.Close();

            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (comboBox8.Text != "")
            {
                ba.Open();
                SqlCommand rprpersonel = new SqlCommand("select * from Personel where G_ID=@p1 and Bas_Tar<=@p2 ", ba);
                rprpersonel.Parameters.AddWithValue("@p1", comboBox8.SelectedIndex + 1);
                rprpersonel.Parameters.AddWithValue("@p2", dateTimePicker3.Value);

                da = new SqlDataAdapter(rprpersonel);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporper.DataSource = tablo;
                ba.Close();
            }
            else
            {
                ba.Open();
                SqlCommand rprpersonel = new SqlCommand("select * from Personel where  Bas_Tar<=@p2 ", ba);

                rprpersonel.Parameters.AddWithValue("@p2", dateTimePicker3.Value);

                da = new SqlDataAdapter(rprpersonel);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporper.DataSource = tablo;
                ba.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox9.Text == "Öğrenciler")
            {
                ba.Open();
                //oğrenciler tablosundan silinenleri getircez...
                SqlCommand silinogr = new SqlCommand("select ogrno,Ad,Soyad from silindi where ogrno>1 order by ogrno desc ", ba);
                da = new SqlDataAdapter(silinogr);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporsil.DataSource = tablo;
                ba.Close();
            }
            else if (comboBox9.Text == "Personel")
            {
                //
                ba.Open();
                //oğrenciler tablosundan silinenleri getircez...
                SqlCommand silinperson = new SqlCommand("select Personel_ID,Ad,Soyad from silindi where Personel_ID>1 order by Personel_ID desc ", ba);
                da = new SqlDataAdapter(silinperson);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dgwraporsil.DataSource = tablo;
                ba.Close();
            }
            else
            {
                comboBox9.Text = "Lütfen Tablo Seçiniz...";
                MessageBox.Show("Tablo Seçmediniz !!!");

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}