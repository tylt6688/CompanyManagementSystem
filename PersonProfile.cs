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

namespace tylt6688
{
    public partial class PersonProfile : Form
    {
        public PersonProfile(string truename)
        {
            InitializeComponent();
            txt_truename.Text = truename;
  
        }
        private void Init()
        {
            string sql = "SELECT username,password,age,sex,phone FROM person WHERE truename = '" + txt_truename.Text + "' ";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {

                txt_username.Text = mdr["username"].ToString();
                txt_password.Text = mdr["password"].ToString();
                txt_tel.Text = mdr["phone"].ToString();
                txt_age.Text = mdr["age"].ToString();
 
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sex;
            if (rad_man.Checked)
            {
                sex = rad_man.Text;

            }
            else
            {
                sex = rad_women.Text;

            }
            string sql = "update person set username='" + txt_username.Text + "',password= '" + txt_password.Text + "',age='" + txt_age.Text + "',sex='" + sex + "',phone='" + txt_tel.Text + "' where truename= '" + txt_truename.Text + "'";
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            MessageBox.Show(msg);
            var form = new Login();
            form.Show();
            this.Close();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_age_TextChanged(object sender, EventArgs e)
        {

        }

        private void rad_man_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PersonProfile_Load_1(object sender, EventArgs e)
        {
            Init();
        }

        private void rad_women_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
