using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // database codes.

namespace CS_Staff_Track
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=staff.mdb");

        private void show_staff()
        {
            try
            {
                connection.Open();
                OleDbDataAdapter list_staff = new OleDbDataAdapter("select tcno AS[Identity NO], name AS[NAME], surname AS[SURNAME],gender AS[GENDER], graduation AS[GRADUATION], birth AS [Date of Birth], duty AS[DUTY], duty_place AS [Work Place],salary AS [SALARY] from workers Order By name ASC", connection);
                DataSet dsmemory = new DataSet();
                list_staff.Fill(dsmemory);
                dataGridView1.DataSource = dsmemory.Tables[0];
                connection.Close();
            }
            catch (Exception explanation)
            {
                MessageBox.Show(explanation.Message, "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            show_staff();
            this.Text = "User Movements";
            label19.Text = Form1.name + " " + Form1.surname; // ((0)) \\// ((0)) \\// ((0)) \\// ((0)) \\// ((0)) \\// ((0)) \\// ((0)) \\// ((0)) \\// ((0)) \\
            pictureBox1.Height = 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            pictureBox2.Height = 150;
            pictureBox2.Height = 150;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\userphoto\\" + Form1.tcno + ".jpg");
            }
            catch (Exception)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\userphoto\\nophoto.jpg");
            }
            maskedTextBox1.Mask = "00000000000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool regist_state = false;

            if (maskedTextBox1.Text.Length == 11)
            {
                connection.Open();
                OleDbCommand selectQuery = new OleDbCommand("select * from workers where tcno='" + maskedTextBox1.Text + "'", connection);
                OleDbDataReader registRead = selectQuery.ExecuteReader(); // gelen verileri data readere aktarıyoruz 
                while (registRead.Read())
                {
                    regist_state = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\staffphoto\\" + registRead.GetValue(0) + ".jpg"); // picture box 1 in image özelliğiyle hangi resmin yükleneceğini belirledik.
                        //bu resmin yükleneceği hedef klasörünü belirledik.
                    }
                    catch (Exception)
                    {

                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\staffphoto\\nophoto.jpg");
                    }
                    label10.Text = registRead.GetValue(1).ToString();
                    label11.Text = registRead.GetValue(2).ToString();
                    if (registRead.GetValue(3).ToString() == "Male")
                        label12.Text = "Male;";
                    else
                        label12.Text = "Female";
                    label13.Text = registRead.GetValue(4).ToString();
                    label14.Text = registRead.GetValue(5).ToString();
                    label15.Text = registRead.GetValue(6).ToString();
                    label16.Text = registRead.GetValue(7).ToString();
                    label17.Text = registRead.GetValue(8).ToString();
                    break;


                }
                if (regist_state == false)
                    MessageBox.Show("Registery could not be found.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            else
                MessageBox.Show("Please enter 11 characters Personal Indentity Number.", "Staff Track Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
