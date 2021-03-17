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
namespace TCP_Client
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }


        void isChecked(bool Checked)
        {
            if (Checked)
            {
                metroCheckBox1.Enabled = true;
                
            }
            else
            {
                metroCheckBox1.Enabled = false;
             
            }

        }
        void lnitCombo()
        {
            string myConnection = "datasource = localhost; port=3305; username=root; password=root";
            string Query = "select * from demo.new_table;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            //SelectCommand 에 해당 sql문을 지정하여 실행
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);

            // 연결모드로 데이터를 서버에 가져옴
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string str_name = myReader.GetString("name");

                    if (NameBox.Text == str_name)
                    {
                        MessageBox.Show("이미 존재하는 아이디 입니다.");
                        return;
                    }
                    else if (NameBox.Text == "")
                    {
                        MessageBox.Show("아이디를 입력해주세요.");
                        return;
                    }
                    else 
                    {
                        MessageBox.Show("존재하지 않는 아이디 입니다.");
                        return;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            lnitCombo();

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;");
            //칼럼에 추가하는 커리문 insertQuery
            string insertQuery = "INSERT INTO new_table(name,pw,id) VALUES('" + NameBox.Text + "'," + PwBox.Text + "," + IDBox.Text + ")";
            /* 추가한다    테이블 member_tb 테이블에  name 과 age 라는 항목의 값을 그값은 NameBox.Text 와  AgeBox.Text 에입력
             된 값이다*/

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try//예외 처리
            {
                if (metroCheckBox1.Checked == false)
            {
                MessageBox.Show("중복 검사를 해주세요");
                    return;
            }
            
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
            
            


            connection.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;");


            try
            {
                string myCon = "datasource=localhost;port=3305;username=root;password=root";
                MySqlConnection myConn = new MySqlConnection(myCon);
                MySqlDataAdapter mydata = new MySqlDataAdapter();
                mydata.SelectCommand = new MySqlCommand("SELECT * database.demo;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(mydata);
                DataSet ds = new DataSet();
                MessageBox.Show("DB 연결되었습니다");
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            lnitCombo();
            isChecked(metroCheckBox1.Checked);
        }

        private void PW_Click(object sender, EventArgs e)
        {

        }

       
    }
}

