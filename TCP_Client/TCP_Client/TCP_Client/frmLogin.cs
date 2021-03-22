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

        public delegate void DataPush(string value);
        public DataPush dataSean;

        void frm2_WriteTextEvent(string text)

        {

            this.txtUserName.Text = text;
        }


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

            Form3 a1 = new Form3();
            a1.Show();
            /*//칼럼에 추가하는 커리문 insertQuery
            string insertQuery = "INSERT INTO new_table(name,id) VALUES('" + NameBox.Text + "'," + AgeBox.Text + ")";
            /* 추가한다    테이블 member_tb 테이블에  name 과 age 라는 항목의 값을 그값은 NameBox.Text 와  AgeBox.Text 에입력
             된 값이다

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


            //connection.Close();*/
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
                            frm.WriteTextEvent += new Form1.TextEventHandler(frm2_WriteTextEvent);  // 델리게이트를 통한 이벤트 등록

                            frm.received2(txtUserName.Text); //Form2로 데이터 전달
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            metroTextBox2.Text = DateTime.Now.ToString("HH:mm");


        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
           
          
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void chkRememberMe_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text == "")
            {
                MessageBox.Show("로그인 아이디를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUserName.Focus();
            }
            else if (this.txtPassword.Text == "")
            {
                MessageBox.Show("로그인 비밀번호를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPassword.Focus();
            }

            else
            {
                if(chkRememberMe.Checked)
                {
                    txtUserName.Text = Properties.Settings.Default.LoginIDsave;
                    Properties.Settings.Default.LoginIDsave = txtUserName.Text;
                    Properties.Settings.Default.Save();
                   
                    
                }
            }
        }

       
    }
   }

