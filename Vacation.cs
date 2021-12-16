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
    public partial class Vacation : Form
    {
        public Vacation(string username)
        {
            InitializeComponent();
            txt_user.Text = username;
        }

        private void Vacation_Load(object sender, EventArgs e)
        {
            txt_initime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string truename = txt_user.Text;
            string inittime = txt_initime.Text;
            string finaltime = txt_finaltime.Text.ToString();
            string reason = "";
            string status = "待审批";

            if (radioButton1.Checked)
            {
                reason = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                reason = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                reason = radioButton3.Text;
            }
            else
            {
                MessageBox.Show("请选择请假原因！");
            }
            string sql = "INSERT INTO vacation(truename,reason,inittime,finaltime,status) VALUES('" + truename + "','" + reason + "','" + inittime + "','" + finaltime + "','" + status + "')";
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            MessageBox.Show(msg);
            tools.getClose();
            this.Close();

        }
    }
}
