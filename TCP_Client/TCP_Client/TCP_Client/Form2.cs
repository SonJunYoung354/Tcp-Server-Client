using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClassLibrary1;

namespace TCP_Client
{

   
    public partial class Form2 : Form
    {
        dllTest test = new dllTest();

        public Form2()
        {
            InitializeComponent();
            
            
        }
        

       
        public delegate void TextEventHandler(string text);

        public event TextEventHandler WriteTextEvent;

        public void received2(string str)

        {

            this.textBox2.Text = str;

            textBox2.Invalidate();

        }



        private void button1_Click(object sender, EventArgs e)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


    }

        private void Form2_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = dllTest.fn_Add();
        }
    }
}
