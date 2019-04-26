using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
//regex kütüphanesinin tanımmlanlası
using System.Text.RegularExpressions; // Güvenli paralo oluşturmayı sağlayan hazır kodları barındırır.
// giriş çıkış işlemleri için
using System.IO; // klasör işlemleri kullanacağımızdan - bir klasör var mı yok mu işlemleri.

namespace CS_Staff_Track
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // Veri tabanı dosya yolu ve  provider  nesnesinin belirlenmesi.
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=staff.mdb");

//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)METHODS(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)

        private void show_users() // yeni kullanıcı eklediğimde sildiğimde formda aktif olarak hareketleri izleyeceğiz //
        {
            try
            {
                connection.Open();
                OleDbDataAdapter list_users = new OleDbDataAdapter
                    ("Select tcno AS[Personal Identity Number],name AS[NAME],surname AS[SURNAME],authority AS[AUTHORITY],username AS[USER NAME],password AS[PASSWORD] from users Order By name ASC", connection);
                DataSet dsmemory = new DataSet();
                list_users.Fill(dsmemory);
                dataGridView1.DataSource = dsmemory.Tables[0]; // sorgu sonucunda gelen ilk tabloyu data source'ye aktarıyoruz //
                connection.Close();
            }
            catch (Exception explanation)
            {
                MessageBox.Show(explanation.Message, "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void show_staff()


        {
            try
            {
                connection.Open();
                OleDbDataAdapter list_staff = new OleDbDataAdapter("select tcno AS[Personal Identity],name AS [NAME],surname AS [SURNAME], gender AS[GENDER],graduation AS [GRADUATION],birth AS [Day of Birth],duty AS[DUTY], duty_place AS [Place of Working], salary AS [SALARY] From workers Order By name ASC", connection);
                DataSet dsmemory = new DataSet();
                list_staff.Fill(dsmemory);
                dataGridView2.DataSource = dsmemory.Tables[0];
                connection.Close();
            }
            catch (Exception explanation)
            {
                MessageBox.Show(explanation.Message, "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void topPage1_clear()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
        private void topPage2_clear()
        {
            pictureBox2.Image = null;
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)METHODS(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {

//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)FORM(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)
            
            // FORM 2 AYARLARI
            pictureBox1.Height = 150;
            pictureBox1.Height = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)FORM(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)

//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)IMAGE(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\userphoto\\" + Form1.tcno + ".jpg");
            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\userphoto\\nophoto.jpg");
            }

//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)IMAGE(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)

            //KULLANICI İŞLEMLERİ SEKMESİ

            this.Text = "MANAGER MOVEMENTS";
            label11.ForeColor = Color.DarkRed;
            label11.Text = Form1.name + " " + Form1.surname;
            textBox2.MaxLength = 11;
            textBox5.MaxLength = 8;
            toolTip1.SetToolTip(this.textBox2, "Max lenght is 11 characters."); // tooltip maus ile üstüne gelince uyarı verir    ((O))
            radioButton1.Checked = true;

            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox4.CharacterCasing = CharacterCasing.Upper;
            textBox6.MaxLength = 10;
            textBox7.MaxLength = 10;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            show_users();

            //PERSONEL İŞLEMLERİ SEKMESİ

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Width = 100;
            pictureBox2.Height = 100;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            maskedTextBox1.Mask = "00000000000";   // ((!)) 0 ZORUNLU RAKAM GİRİŞİ DEMEK ZORUNLU OLARAK 11 RAKAM GİRECEK //           ((O))
            maskedTextBox2.Mask = "LL???????????????";  // ((!)) 2 TANE KESİN İSİM HARFİ GİRİLECEK SONRASI GİRİLMESE DE OLUR L' O ANLAMA GELİR ((O))
            maskedTextBox3.Mask = "LL???????????????";
            maskedTextBox4.Mask = "0000";
            maskedTextBox4.Text = "0";
            maskedTextBox2.Text.ToUpper();
            maskedTextBox3.Text.ToUpper();

            comboBox1.Items.Add("Primary Education");
            comboBox1.Items.Add("Middle School");
            comboBox1.Items.Add("Collage");
            comboBox1.Items.Add("University");

            comboBox2.Items.Add("Manager");
            comboBox2.Items.Add("Worker");
            comboBox2.Items.Add("Driver");
            comboBox2.Items.Add("Officer");

            comboBox3.Items.Add("ARGE");
            comboBox3.Items.Add("IT");
            comboBox3.Items.Add("Production");
            comboBox3.Items.Add("Delivery");
            comboBox3.Items.Add("Packaging");
            comboBox3.Items.Add("Accounting");

            DateTime time = DateTime.Now;                   // bugünkü tarih neyse onun yılını aldık 
            int year = int.Parse(time.ToString("yyyy"));
            int month = int.Parse(time.ToString("MM"));
            int day = int.Parse(time.ToString("dd"));

            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime( year - 18,month,day);  // günümüzden hesaplayarak 18 yaş altındakilerin çalışamayacağı
            dateTimePicker1.Format = DateTimePickerFormat.Short;

            radioButton3.Checked = true;
            show_staff();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if( textBox2.Text.Length < 11 )
            
                errorProvider1.SetError(textBox2, "This Text box needs to be 11 characters."); 
                else
                errorProvider1.Clear();
            
        }
//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)KEY PRESS(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)
                                                //Klavyeden her tuşa bastığımızda burası tetiklenecek
                          //Asky karakterlere bakarak numaralandırma metoduyla karşılıklarını bilmemiz gerekiyor
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //((0))\\         //e.key char klavyeden basılan tuş bilgisini almamızı sağlar 
            if (((int)e.KeyChar >= 48 && e.KeyChar <= 57) || (int)e.KeyChar == 8)  // 8 backspace tuşuna karşılık gelir silme işlemi
                e.Handled = false; // diyerek bu tuşlara basılmasına izin veriyoruz.
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //klavyeden basılan tuş karakterse ||Eğer back space tuşuna basılmışsa || boşluk tuşuna basılmışsa
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;

        }
       
//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)KEY PRESS(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length != 8)
                errorProvider1.SetError(textBox5, "User name needs to be 8 characters.");
            else
                errorProvider1.Clear();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar)==true||char.IsControl(e.KeyChar)==true||char.IsDigit(e.KeyChar)==true) // Digit yani sayıyıya basılmışsa
                e.Handled = false;
            else
            e.Handled = true;
        }
        int password_score = 0;
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Tanımlamalar ////////////////////////////////////////////////////////////////////////////////////////////////
            string password_level = "";
            int lower_case_score = 0;
            int upper_case_score = 0;
            int symbol_score = 0;
            int digit_score = 0;                        //     Rakam skoru // 
            string password = textBox6.Text;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Regex kütüphanesi İngilizce karakterleri baz alır. Bu yüzden password ifadesindeki Türkçe...
            //...karakterleri ingilizce karakterlere çevirmemiz gerekiyor. //////////////////////////////

            string rebuilt_password = "";
            rebuilt_password = password;
            rebuilt_password = rebuilt_password.Replace('İ', 'i');
            rebuilt_password = rebuilt_password.Replace('ı', 'i');
            rebuilt_password = rebuilt_password.Replace('Ç', 'C'); // Tb ye girilen metin başta şifre değişkeninde saklandı
            rebuilt_password = rebuilt_password.Replace('ç', 'c'); //
            rebuilt_password = rebuilt_password.Replace('Ş', 'S');
            rebuilt_password = rebuilt_password.Replace('ş', 's');
            rebuilt_password = rebuilt_password.Replace('Ğ', 'G');
            rebuilt_password = rebuilt_password.Replace('ğ', 'g');
            rebuilt_password = rebuilt_password.Replace('Ü', 'U');
            rebuilt_password = rebuilt_password.Replace('ü', 'u');
            rebuilt_password = rebuilt_password.Replace('Ö', 'O');
            rebuilt_password = rebuilt_password.Replace('ö', 'o');

            if (password != rebuilt_password) // değişiklik yapıldığı için değiştiriyoruz 
            {
                password = rebuilt_password; // değişiklik yapılmış halini aktarıyoruz 
                textBox6.Text = password;
                MessageBox.Show("Turkish digits has been changed to English digits");
            }
//((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))

            // 1 küçük harf = 10 puan || 2 ve üzeri 20 puan 
            int az_character_number = password.Length - Regex.Replace(password, "[a-z]", "").Length;
            // yukarısı: küçük harfleri şifreden çıkarır ve küçük harf sayısını bulur.
            lower_case_score = Math.Min(2, az_character_number) * 10;
            //maks 20 puan alabilir ||2 ile az karakter sayısı arasındaki değeri buluyor ve 10 ile çarpıyor.
            //  2 mi daha küçük yoksa küçük harf sayısı mı daha küçük ona bakar 10 ile çarpar.  ((=))

//((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))((=))

            // büyük harfler için skor verme işlemi 2 tnaesi 20 puan

            int AZ_character_number = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
            upper_case_score = Math.Min(2, AZ_character_number) * 10;

            // 1 rakam 10 puan 2 ve üzeri 20 puan

            int digit_number = password.Length - Regex.Replace(password, "[0-9]", "").Length;
            digit_score = Math.Min(2, digit_number) * 10;

            // sembolller 2 ve üzeri 20 puan 

            int symbol_number = password.Length - az_character_number - AZ_character_number - digit_number;
            symbol_score = Math.Min(2, symbol_number) * 10;

            password_score = lower_case_score + upper_case_score + digit_score + symbol_score;
            if(password.Length == 9)
            {
                password_score += 10;
            }
            else if (password.Length == 10)         // 100 e tamamladık pass leveli.
            {
                password_score += 20;
            }

            if (lower_case_score == 0 || upper_case_score == 0 || digit_score == 0 || symbol_score == 0)
                label22.Text = "Using Upper case, lower case, symbol and digit is must!";
            if(lower_case_score != 0 && upper_case_score!=0 && digit_score != 0 && symbol_score !=0)
                label22.Text= "";
            if (password_score < 70)
                password_level = "Can no be Accepted";
            else if (password_score == 70 || password_score == 80)
                password_level = "Strong.";
            else if (password_score == 90 || password_score == 100)
                password_level = "Very Strong.";

            label9.Text = "%" + Convert.ToString(password_score);
            label10.Text = password_level;

            progressBar1.Value = password_score;


                 
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != textBox6.Text)
                errorProvider1.SetError(textBox7, "Passwords does not match!");
            else
                errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string authorisation = "";
            bool saveControl = false;  // false çünü bir kayıt yaparken dhaa önceden böyle bir kullanıcı kaydı var mı diye kontrol edeceğiz
                                       // eğer daha önceden kayıt varsa kullanıcıyı uyaracağız.
                                       // başlangıç olarak aynı kayıt olmadığını farz ederek FALSE; diyoruz!!;

            connection.Open();
            OleDbCommand selectQuery = new OleDbCommand("Select * from users where tcno='" + textBox2.Text + "'", connection);
            OleDbDataReader saveReader = selectQuery.ExecuteReader(); // burada değerleri aktarıyoruz 

            while (saveReader.Read()) // bu şekilde bir kayıt var mı ona bakıyoruz ve varsa :
            {
                saveControl = true;
                break;
            }
            connection.Close();

            if(saveControl == false)
            {
                // Tc kimlik no kontrolü
                if(textBox2.Text.Length < 11 ||textBox2.Text == "")
                {
                    label1.ForeColor = Color.Red;
                    
                }
                else
                    label1.ForeColor = Color.Black;

                // Adı ver kontrolü
                if (textBox3.Text.Length < 2 || textBox3.Text == "")
                {
                    label2.ForeColor = Color.Red;

                }
                else
                    label2.ForeColor = Color.Black;

                // Soyad kontrolü

                if (textBox4.Text.Length < 2 || textBox4.Text == "")
                {
                    label3.ForeColor = Color.Red;

                }
                else
                    label3.ForeColor = Color.Black;

                //Kullanıcı adı veri kontrolü

                if (textBox5.Text.Length !=8 || textBox5.Text == "")
                {
                    label5.ForeColor = Color.Red;

                }
                else
                    label5.ForeColor = Color.Black;

                // Parola veri kontrolü

                if (password_score < 70 || textBox6.Text == "")
                {
                    label6.ForeColor = Color.Red;

                }
                else
                    label6.ForeColor = Color.Black;

                //Parola tekrar veri kontrolü

                if (textBox6.Text != textBox7.Text || textBox7.Text == "")
                {
                    label7.ForeColor = Color.Red;

                }
                else
                    label7.ForeColor = Color.Black;

                if (textBox2.Text.Length == 11 && textBox2.Text != "" && textBox3.Text != "" && textBox3.Text.Length > 1 && textBox4.Text != "" && textBox4.Text.Length > 1 &&
                    textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox6.Text == textBox7.Text &&
                    password_score >= 70)
                {
                    if (radioButton1.Checked == true)
                        authorisation = "Manager";
                    else if (radioButton2.Checked == true)
                        authorisation = "User";

                    try
                    {
                        connection.Open();
                        OleDbCommand addcommand = new OleDbCommand("insert into users values ('" + textBox2.Text + "','" + textBox3.Text +
                            "','" + textBox4.Text + "','" + authorisation + "','" + textBox5.Text + "','" + textBox6.Text + "')", connection);
                        addcommand.ExecuteNonQuery(); ///////////////// sonuçları access tablosuna işle ////////////////////////////
                        connection.Close();
                        MessageBox.Show("New user has been created", "Staff track program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        show_users();
                        topPage1_clear();
                    }
                    catch (Exception explanation)
                    {

                        MessageBox.Show(explanation.Message);
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Consider the Red labels again.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
            else
            {
                MessageBox.Show("The value that you entered on Personal Identity number is already been registered.",
                    "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool register_searching_state = false; // access tablosunda herhangi bir kayıt olup olmadığını değerlendirecek.


            if (textBox2.Text.Length == 11)
            {
                connection.Open();
                OleDbCommand selectQuert = new OleDbCommand("Select * from users where tcno= '" + textBox2.Text + "'", connection);
                OleDbDataReader registerRead = selectQuert.ExecuteReader();

                while (registerRead.Read())
                {
                    register_searching_state = true;
                    textBox3.Text = registerRead.GetValue(1).ToString(); // accestten çekilen verileri stringe dönüştürmek gerek
                    textBox4.Text = registerRead.GetValue(2).ToString();
                    // radio buttondan değeri alıcaz bunun için if bloğundan faydalandık.
                    if (registerRead.GetValue(3).ToString() == "Manager")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                        radioButton2.Checked = true;
                    textBox5.Text = registerRead.GetValue(4).ToString();
                    textBox6.Text = registerRead.GetValue(5).ToString();
                    textBox7.Text = registerRead.GetValue(5).ToString();
                    break;
                }
                if(register_searching_state == false)

                    MessageBox.Show("Registery could not found.", "Staff Track program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
            }
            else
            {
                MessageBox.Show("Please enter 11 characters Identity Number", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topPage1_clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string authorisation = " ";
         

            // Tc kimlik no kontdrolüf
            if (textBox2.Text.Length < 11 || textBox2.Text == "")
                {
                label1.ForeColor = Color.Red;

                }
                else
                    label1.ForeColor = Color.Black;

                // Adı ver kontrolü
                if (textBox3.Text.Length < 2 || textBox3.Text == "")
                {
                    label2.ForeColor = Color.Red;

                }
                else
                    label2.ForeColor = Color.Black;

                // Soyad kontrolü

                if (textBox4.Text.Length < 2 || textBox4.Text == "")
                {
                    label3.ForeColor = Color.Red;

                }
                else
                    label3.ForeColor = Color.Black;

                //Kullanıcı adı veri kontrolü

                if (textBox5.Text.Length != 8 || textBox5.Text == "")
                {
                    label5.ForeColor = Color.Red;

                }
                else
                    label5.ForeColor = Color.Black;

                // Parola veri kontrolü

                if (password_score < 70 || textBox6.Text == "")
                {
                    label6.ForeColor = Color.Red;

                }
                else
                    label6.ForeColor = Color.Black;

                //Parola tekrar veri kontrolü

                if (textBox6.Text != textBox7.Text || textBox7.Text == "")
                {
                    label7.ForeColor = Color.Red;

                }
                else
                    label7.ForeColor = Color.Black;

                if (textBox2.Text.Length == 11 && textBox2.Text != "" && textBox3.Text != "" && textBox3.Text.Length > 1 && textBox4.Text != "" && textBox4.Text.Length > 1 &&
                    textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox6.Text == textBox7.Text &&
                    password_score >= 70)
                {
                    if (radioButton1.Checked == true)
                        authorisation = "Manager";
                    else if (radioButton2.Checked == true)
                        authorisation = "User";

                    try
                    {
                        connection.Open();
                    OleDbCommand updateCommand = new OleDbCommand( "update users set name='" + textBox3.Text + "', surname='" + textBox4.Text + "', authority='" + authorisation +"', username='" + textBox5.Text + "', password='" + textBox6.Text + "' where tcno='"+ textBox2.Text + "'",connection);
                        updateCommand.ExecuteNonQuery(); ///////////////// sonuçları access tablosuna işle ////////////////////////////
                        connection.Close();
                        MessageBox.Show("User informations has been Updated.", "Staff track program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    show_users();
                    }
                    catch (Exception explanation)
                    {

                        MessageBox.Show(explanation.Message,"Staff Track Program",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Consider the Red labels again.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 11)
            {
                bool register_searching_state = false;
                connection.Open();
                OleDbCommand selectQuery = new OleDbCommand("select * from users where tcno='" + textBox2.Text + "'", connection);
                OleDbDataReader registeryRead = selectQuery.ExecuteReader();
                while (registeryRead.Read())
                {
                    register_searching_state = true;
                    OleDbCommand deleteQuery = new OleDbCommand("delete from users where tcno = '" + textBox2.Text + "'", connection);
                    deleteQuery.ExecuteNonQuery();
                    MessageBox.Show("User informations have been deleted", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    show_users();
                    topPage1_clear();
                    break;
                }
                if (register_searching_state == false)
                    MessageBox.Show("Registry Could Not Be Found To Delete.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                topPage1_clear();
            }
            else
                MessageBox.Show("Please enter a 11 character Identity number here.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            topPage1_clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog pickPhoto = new OpenFileDialog(); // openfile dialog nesnesinin bütün özellikklerini barındıran  resimseç isminde openfine dialog newsnesi oluşturuyoruz.//
            pickPhoto.Title = "Pick a Staff Photograph.";
            pickPhoto.Filter = "JPG Files (*.jpg) | *.jpg"; // Sayesinde kullanıcı sadece .jpeg türündeki fotoları görebilecek. Word dosyalarını göremeyecek
            if (pickPhoto.ShowDialog() == DialogResult.OK) // eğer kullanıcıya gösterilmişse resim başarılı bir şekilde seçilmişse:
            {
                this.pictureBox2.Image = new Bitmap(pickPhoto.OpenFile()); // This| formu niteler. bunun resim özelliği = orda seçilen resmin picture boxa yüklenmesi.
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool registryControl = false;
            // Eğer daha önceden benzer bir kayıt varsa kullanıcıyı bilgilendireceğiz.

            connection.Open();
            OleDbCommand selectQuery = new OleDbCommand("select * from workers where tcno ='" + maskedTextBox1.Text + // access tablosunda daha önceden masked textboxa girilen değerde bir kayıt var mı diye baktık eğer varsa: kayıt kontrolü true yaptık ve kapattık
                "'", connection); // eşit olan kayıtları getir
            OleDbDataReader registryRead = selectQuery.ExecuteReader(); // az önce yazdığımız sorguların sonuçları ile
            //kayıt okuma alanımızın doldurulmasını sağlıyoruz.
            while (registryRead.Read() == true)
            {
                // eğer yukardaki sorgu sonucunda kayıt okuma işlemi gerçekleşmişse :
                registryControl = true;
                break;
            }
            connection.Close();

            if(registryControl == false) // eğer masked text box a girilen TC numarasında daha önce bir kayıt yoksa: Kayıt işlemlerini gerçekleştiricez.
            {
                if (pictureBox2.Image == null)
                {
                    button6.ForeColor = Color.Red;
                }
                else
                    button6.ForeColor = Color.Black;

                if (maskedTextBox1.MaskCompleted == false) // yani form loaddaki masked textbox 1 komutuna uyulmamışsa/maske tamamlanmamışsa:
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (maskedTextBox2.MaskCompleted == false) 
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;

                if (maskedTextBox3.MaskCompleted == false) 
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;

                if (comboBox1.Text == "")

                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;

                if (comboBox2.Text == "")

                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;

                if (comboBox3.Text == "")

                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;

                if (maskedTextBox4.MaskCompleted == false)
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;
                
                if (int.Parse(maskedTextBox4.Text)<1000)
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;

                if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false // kayıt işlemleri için gerekli koşullar
                    && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox4.MaskCompleted != false)
                {
                    if (radioButton3.Checked == true)
                        gender = "Male";
                    else if (radioButton4.Checked == true)
                        gender = "Female";

                    try
                    {
                        connection.Open();
                        OleDbCommand addCommand = new OleDbCommand("insert into workers values('" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text +
                            "','" + gender + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + maskedTextBox4.Text + "')", connection);
                        addCommand.ExecuteNonQuery(); // sorgunun sonuçlarını access'e işliyoruz değişiklik yapılmasını sağlıyoruz.
                        connection.Close();
                        if (!Directory.Exists(Application.StartupPath + "\\staffphoto"))  // Bin'deki Debug klasöründe staffphoto diye bir klasör yoksa
                            Directory.CreateDirectory(Application.StartupPath + "\\staffphoto");
                            pictureBox2.Image.Save(Application.StartupPath + "\\staffphoto\\" +
                                maskedTextBox1.Text + ".jpg");                                           //ismin tc kimlik no su ve jpg uzantılı olarak kaydedilmesini sağlıyoruz.
                        MessageBox.Show("New Staff Entry has been created.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        show_staff();
                        topPage2_clear();
                        maskedTextBox4.Text = "0";


                    }
                    catch (Exception explenation)
                    {
                        MessageBox.Show(explenation.Message, "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Please Consider again the Red Label areas.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
                MessageBox.Show("The Identity Number that You entered is already registered.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool register_searching_state = false;

            if (maskedTextBox1.Text.Length == 11)
            {
                connection.Open();
                OleDbCommand selectQuery = new OleDbCommand("select * from workers where tcno='" + maskedTextBox1.Text + "'", connection);
                OleDbDataReader registerRead = selectQuery.ExecuteReader(); // veri okuma nesnesi tanımladık || bu datareader nesnesinin hangi sorgunun sonuçlarıyla dolacağını belirliyoruz.

                while (registerRead.Read()) // kayıt bulunmuş ve bu kayıtta tanımladığımız kayıt okuma isimli datareader nesnesine aktarılmışsa
                {
                    register_searching_state = true;
                    try                                                     // Resmin yansıtılmasını sağlayacağız.
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\staffphoto\\" + registerRead.GetValue(0).ToString() + ".jpg");
                        //Bulunan kaydın 0. alanı (tc nosu) bu bilgiyi stringe dönüştürdüm.
                    }
                    catch (Exception)
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\staffphoto\\nophoto.jpg");
                    }

                    maskedTextBox2.Text = registerRead.GetValue(1).ToString();
                    maskedTextBox3.Text = registerRead.GetValue(2).ToString();

                    if (registerRead.GetValue(3).ToString() == "Male")
                        radioButton3.Checked = true;
                    else
                        radioButton4.Checked = true;

                    comboBox1.Text = registerRead.GetValue(4).ToString();
                    dateTimePicker1.Text = registerRead.GetValue(5).ToString();
                    comboBox2.Text = registerRead.GetValue(6).ToString();
                    comboBox3.Text = registerRead.GetValue(7).ToString();
                    maskedTextBox4.Text = registerRead.GetValue(8).ToString();
                    break;
                }
                if (register_searching_state == false)
                    MessageBox.Show("Registration that you are looking for could not been found.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                connection.Close();
            }
            else
                MessageBox.Show("Please enter 11 characters Personal Identity numer.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string gender = "";


                if (pictureBox2.Image == null)               
                    button6.ForeColor = Color.Red;
                else
                    button6.ForeColor = Color.Black;

                if (maskedTextBox1.MaskCompleted == false) // yani form loaddaki masked textbox 1 komutuna uyulmamışsa/maske tamamlanmamışsa:
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (maskedTextBox2.MaskCompleted == false)
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;

                if (maskedTextBox3.MaskCompleted == false)
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;

                if (comboBox1.Text == "")

                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;

                if (comboBox2.Text == "")

                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;

                if (comboBox3.Text == "")

                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;

                if (maskedTextBox4.MaskCompleted == false)
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;

                if (int.Parse(maskedTextBox4.Text) < 1000)
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;

                if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false // kayıt işlemleri için gerekli koşullar
                    && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && maskedTextBox4.MaskCompleted != false)
                {
                    if (radioButton3.Checked == true)
                        gender = "Male";
                    else if (radioButton4.Checked == true)
                        gender = "Female";

                    try
                    {
                        connection.Open();
                        OleDbCommand updateCommand = new OleDbCommand("update workers set name='" + maskedTextBox2.Text + "',surname='" + maskedTextBox3.Text +
                            "',gender='" + gender + "',graduation='" + comboBox1.Text + "',birth='" + dateTimePicker1.Text + "',duty='" + comboBox2.Text + "',duty_place='" +
                            comboBox3.Text + "',salary='" + maskedTextBox4.Text + "' where tcno='" + maskedTextBox1.Text+"'", connection);
                        updateCommand.ExecuteNonQuery(); // sorgunun sonuçlarını access'e işliyoruz değişiklik yapılmasını sağlıyoruz.
                        connection.Close();
                        show_staff();

                        maskedTextBox4.Text = "0";
                    }
                    catch (Exception explenation)
                    {
                        MessageBox.Show(explenation.Message, "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }
                }
               
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.MaskCompleted == true)
            {
                bool registration_control_state = false;
                connection.Open();
                // access tablosunda böyle bir kayıt var mı diye bakacağız.
                OleDbCommand search_query = new OleDbCommand("select * from workers where tcno='" + maskedTextBox1.Text+"'", connection);
                OleDbDataReader registerRead = search_query.ExecuteReader(); // gelen sonuçların dataReadere aktarılması
                while (registerRead.Read())
                {
                    registration_control_state = true;
                    OleDbCommand deleteQuery = new OleDbCommand("delete from workers where tcno='" + maskedTextBox1.Text + "'", connection);
                    deleteQuery.ExecuteNonQuery(); // sonuçları access veri tabanına işle
                    break;
                }
                if (registration_control_state == false)
                {
                    MessageBox.Show("Could not Found Registery to Delete.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
                show_staff();
                topPage2_clear();
                maskedTextBox4.Text = "0";
            }
            else
            {
                MessageBox.Show("Please enter 11 characters Personal Identity Number.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topPage2_clear();
                maskedTextBox4.Text = "0";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            topPage2_clear();
        }
    }
}
