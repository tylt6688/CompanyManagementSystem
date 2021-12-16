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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
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
            string sql = "INSERT INTO person(username,password,truename,age,sex,phone) VALUES('"+ txt_username.Text+ "','"+ txt_password.Text+ "','" + txt_truename.Text + "','" + txt_age.Text + "','" + sex + "','" + txt_tel.Text+"')";
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            MessageBox.Show(msg);
            var form = new Login();
            form.Show();
            this.Close();

        }

        private void txt_truename_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_age_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rad_women_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad_man_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_username_Click(object sender, EventArgs e)
        {

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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
