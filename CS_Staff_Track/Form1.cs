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

namespace CS_Staff_Track
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //--*--// Veri tabanı dosya yolu ve provider nesnesinin belirlenmesi //--*--//
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=staff.mdb");

        //--*--// Formlar arası veri aktarımında kullanılacak değişkenler //--*--//
        public static string tcno, name, surname, authority;

        //--*--// Yerel değişkenler yani sadece bu formda geçerli olan değişkenler //--*--//
        int claim = 3;
        bool status = false;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)ENTRY(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)
            if (claim != 0)
            {
                //--*--//Burada giriş hakkı 0 olmadıysa: Kullanıcılar tablosundaki tüm verileri çeken bir sorgu tanımladık. Sorgunun yürütülmesini sağladık ve sorgu sonuçlarını...
                //--*--//...bellekte bir data reader nesnesi oluşturarak oraya aktardık. Artık access tablomuzun tamamının bir klonu bellekte. While|: Eğer access tablosunu çektiğimizde...
                //--*--//... bir kayıt varsa tabloda while döngüsü çalışır.
                connection.Open();
                OleDbCommand selectcommand = new OleDbCommand("select * from users", connection);
                OleDbDataReader registryread = selectcommand.ExecuteReader();
                //--*--// Users tablosundaki tüm bilgileri getir, ve sonuçlarını registryread ismindeki datareaderinde sakladık//--*--//
                while (registryread.Read())
                {
                    if (radioButton1.Checked == true) //--*--//Her kayıt için çalışan bir döngü. Her seferinde kayıtları kıyaslayacak.
                    {
                        if (registryread["username"].ToString()==textBox1.Text&&registryread["password"].ToString()==textBox2.Text&&
                            registryread["authority"].ToString()=="Manager")
                        //--*--//Accessteki username tb1'e eşit mi diye bakacak || Daha sonra parolaya bakacak ve yönetici mi diye bakcak.
                        //--*--// ************** Kaç tane kayıt varsa tek tek satır satır bu işlemi uygulayacak. **********//--*--//
                        {
                            status = true;
                            tcno = registryread.GetValue(0).ToString(); //--*--//Kayıt okuma sağlandığı anda o kaydın 0. alanını (tcno) alıyoruz...
                            //--*--//...||0. alanı aldık ve tc no değişkenine aktardık //--*--//
                            name = registryread.GetValue(1).ToString();
                            surname = registryread.GetValue(2).ToString();
                            authority = registryread.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();
                            break; //--*--//!!!!!Artık istenen giriş yapıldığı için while döngüsü tekrar takrar çalışmasın diye break; komutuyla çıkışı sağlıyoruz!!!!!//--*--//
                        }
                    }

                    if (radioButton2.Checked == true)
                    {
                        if (registryread["username"].ToString() == textBox1.Text && registryread["password"].ToString() == textBox2.Text &&
                            registryread["authority"].ToString() == "User")
                        {
                            status = true;
                            tcno = registryread.GetValue(0).ToString();
                            name = registryread.GetValue(1).ToString();
                            surname = registryread.GetValue(2).ToString();
                            authority = registryread.GetValue(3).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3();
                            frm3.Show();
                            break;
                        }
                    }
                }
                if (status == false)
                {
                    claim--;
                    connection.Close();
                }
                
            }

            label5.Text = Convert.ToString(claim);
            if (claim == 0)
            {
                button1.Enabled = false;
                MessageBox.Show("Not Claim Left","Staff Track Program",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)ENTRY(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)FORM(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)
            this.Text = "User Entry";
            //--*--// Enter tuşuna basıldığında hangi tuşa basılmış gibi olsun//--*--//
            this.AcceptButton = button1;
            //--*--// Esc'ye basıldığında //--*--//                                                             //--*--// Form görünümü düzenleme //--*--//
            this.CancelButton = button2;
            label5.Text = Convert.ToString(claim);
            radioButton1.Checked = true;                        //--*--//Görünüm ayarlama //--*--//
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow; //--*--//Form ekranının büyütülüp küçültülmemesi //--*--//
//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)FORM(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)//(o)
        }
    }
}
