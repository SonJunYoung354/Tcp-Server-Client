using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace TCP_Client
{
   
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;");
       


        public frmLogin()
        {
            InitializeComponent();

        }

       


        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {


                    string myConnection = "datasource=localhost;port=3305;username=root;password=root";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataADapter = new MySqlDataAdapter();
                    myDataADapter.SelectCommand = new MySqlCommand("SELECT * database.edata;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataADapter);
                    myConn.Open();
                    DataSet ds = new DataSet();
                    MessageBox.Show("연결되었습니다");
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //칼럼에 추가하는 커리문 insertQuery
            string insertQuery = "INSERT INTO new_table(name,id) VALUES('" + NameBox.Text + "'," + AgeBox.Text + ")";
            /* 추가한다    테이블 member_tb 테이블에  name 과 age 라는 항목의 값을 그값은 NameBox.Text 와  AgeBox.Text 에입력
             된 값이다*/

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try//예외 처리
            {
                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                   MessageBox.Show("정상적으로 갔다");
                }
                else
                {
                    MessageBox.Show("비정상 이당");
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


                   //connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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
            string strconn = "Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;";
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
                        MetroFramework.MetroMessageBox.Show(this, "아이디 또는 비밀번호 확인해주세요");
                        MetroFramework.MetroMessageBox.Show(this, "Your name and password don't match.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
          
        }
    }
   }

