using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace TCP_Server
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        void Login()
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter your username.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            //mysql 연동
            MySqlConnection conn;
            string strconn = "Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;";
            conn = new MySqlConnection(strconn);

            try
            {
                conn.Open();
                string insertQuery = "INSERT INTO user(id,name) VALUES(erty157,'손준영')";

                string strSelect = "SELECT * from user where UserName=" + txtUserName.Text;
                MySqlCommand cmd = new MySqlCommand(strSelect, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    if (rdr["Password"].ToString() == txtPassword.Text)
                    {
                        using (Form1 frm = new Form1())
                        {
                            this.Hide();
                            frm.ShowDialog();


                        }
                    }
                    else
                    {

                        MetroFramework.MetroMessageBox.Show(this, "Your username and password don't match.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter your name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            //mysql 연동
            MySqlConnection conn;
            string strconn = "Server=localhost;Database=user_sch;port=3305;Uid=root;Pwd=root;";
            conn = new MySqlConnection(strconn);

            try
            {
                conn.Open();
                string strSelect = "SELECT * from new_table where name= '" + txtUserName.Text + "' and pw = '" + txtPassword.Text + "'";
                MySqlCommand cmd = new MySqlCommand(strSelect, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    if (rdr["pw"].ToString() == txtPassword.Text)
                    {
                        using (Form1 frm = new Form1())
                        {
                           
                            this.Hide();
                            frm.ShowDialog();


                        }
                    }
                    else
                    {
                        MessageBox.Show("아이디 또는 비밀번호 확인해주세요");
                        //MetroFramework.MetroMessageBox.Show(this, "Your name and password don't match.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form3 a1 = new Form3();
            a1.Show();
        }
    }
   }

