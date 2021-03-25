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
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
       
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MessageBox.Show("이름을 입력해주세요");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String strConn = "Server=localhost;Database=user_sch;port=3305;Uid=root;Pwd=root;";
            string sele = "";
            MySqlDataAdapter mySqlDataAdapter;
            MySqlConnection conn;
            try { 
            conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
                
            comm.CommandText = "SELECT * FROM new_table where name = @name'"+ name.Text + "'";
            //comm.Parameters.AddWithValue("@name", name.Text);
             MySqlDataReader rdr = comm.ExecuteReader();
            
               
            while (rdr.Read())
            {
                    sele = rdr["name"] as string;
                    
                }
                metroTextBox2.Text = sele;
                rdr.Close();
           }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
    }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            String strConn = "Server=localhost;Database=user_sch;port=3305;Uid=root;Pwd=root;";
            MySqlConnection con = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand("select * from new_table where name = '" + name.Text +"'", con);
            
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable a1 = new DataTable();
                sda.Fill(a1);
                BindingSource bs = new BindingSource();
                bs.DataSource = a1;
                lode_table.DataSource = a1;
                sda.Update(a1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
