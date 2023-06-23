using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            // SQL 서버 연결
            string cs = @"server=192.168.0.53;userid=root;password=1111;database=test_db";
            var con = new MySqlConnection(cs);

            try
            {
                con.Open();
                string stm = "select * from test1_hr where userid =@Userid AND userpw =@Userpw";
                    //"select name,password from log WHERE name =@Name AND password =@Password";
                var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@Userid", user_name.Text); // user name 입력칸
                cmd.Parameters.AddWithValue("@Userpw", password.Text);  // password 입력칸
                cmd.ExecuteReader();
                main_form();

            } catch (Exception ex)
            {
                Console.WriteLine("login failed");
            }
            con.Close();
        }
        private void main_form()
        {
            this.Hide();
            main frm = new main();
            frm.ShowDialog();
            this.Close();
        }
    }
}
