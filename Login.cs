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
    public partial class Login : Form //继承Form
    {


        public Login()
        {
            InitializeComponent();
        }

        public string Execu(string sql)
        {
            SQLtools tools = new SQLtools();
            tools.getConn();
            string str = tools.getSelect(sql);
            return str;
        }
        public string userLogin()
        {
            string user = comboBox1.Text;
            if (user == "管理员")
            {
                string sql = "select * from admin where username='" + txt_username.Text + "'and password='" + txt_password.Text + "'";
                if (Execu(sql) == "True")
                {

                    timer1.Start();
                    return "admin";
                }
                else
                {
                    MessageBox.Show("未选择角色或账号密码错误！");
                    return "error";
                }
            }
            else if (user == "用户")
            {
                string sql = "select * from person where username='" + txt_username.Text + "'and password='" + txt_password.Text + "'";

                if (Execu(sql) == "True")
                {

                    timer1.Start();
                    return "person";
                }
                else
                {
                    MessageBox.Show("未选择角色或账号密码错误！");
                    return "error";
                }

            }
            else
            {
                MessageBox.Show("非法操作，未选择角色或未输入数据！");
                return "error";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 270 )
            {
                this.txt_username.Visible = false;
                this.txt_password.Visible = false;
                this.label1.Visible = false;
                this.label2.Visible = false;
                this.label3.Visible = false;
                this.label4.Visible = false;
                this.label5.Visible = false;
                this.label6.Visible = false;
                this.comboBox1.Visible = false;
                this.btn_register.Visible = false;
                this.btn_login.Visible = false;
                this.lbl_userlen.Visible = false;
                this.lbl_password.Visible = false;

                pictureBox1.Location = new Point(pictureBox1.Location.X + 15, pictureBox1.Location.Y+5);

            }

            else if (userLogin() == "admin")
            {
                timer1.Stop();
                var form = new AdminHome(txt_username.Text);
                form.Show();
                this.Close();

            }
            else if (userLogin() == "person")
            {
                timer1.Stop();
                string sql = "SELECT truename FROM person WHERE username = '"+ txt_username.Text + "'and password='" + txt_password.Text + "'";
                SQLtools tool = new SQLtools();
                MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    string truename = mdr["truename"].ToString();
                    var form = new UserHome(truename);
                    form.Show();
                    this.Close();
                }              

            }
            else
            {
                timer1.Stop();
            }

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            userLogin();

        }


        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            lbl_userlen.Text = txt_username.Text.Count().ToString();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            lbl_password.Text = txt_password.Text.Count().ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                notify.ShowBalloonTip(1000, "小提示", "双击重新启动", ToolTipIcon.Info);
                this.Hide();
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            var form = new Register();
            form.Show();
            this.Close();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_userlen_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (userLogin() == "admin")
            {
                timer1.Stop();
                var form = new AdminHome(txt_username.Text);
                form.Show();
                this.Close();

            }
            else if (userLogin() == "person")
            {
                timer1.Stop();
                string sql = "SELECT truename FROM person WHERE username = '" + txt_username.Text + "'and password='" + txt_password.Text + "'";
                SQLtools tool = new SQLtools();
                MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    string truename = mdr["truename"].ToString();
                    var form = new UserHome(truename);
                    form.Show();
                    this.Close();
                }

            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
