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

namespace tylt6688
{
    public partial class testHome : Form
    {
        public testHome()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "欢迎来到管理主页！";

        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
           // toolStripStatusLabel1.Text = "指针位置" + e.X.ToString() + " " + e.Y.ToString();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "现在时间：" + DateTime.Now.ToString();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void mnu_one_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //if (e.ClickedItem == 视图ToolStripMenuItem)
            //{
            //    MessageBox.Show("你好！");
            //    Console.WriteLine("11111");
            //}
        }




        private void 新建子窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //须父窗口开启ismedi属性
            // var form = new Form3();
            //form.MdiParent = this;
            //form.Show();

        }

        private void 人员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PersionManage();
            form.ShowDialog();
        }

        private void 个人资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var form = new UserManage();
            //form.ShowDialog();
        }

        private void 金额管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MoneyManage();
            form.ShowDialog();
        }

        private void 发送反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Feedback();
            form.ShowDialog();
        }
    }
}
