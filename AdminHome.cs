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
    public partial class AdminHome : Form
    {
        public AdminHome(string username)
        {
            InitializeComponent();
            label2.Text = username;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_time.Text = "现在时间：" + DateTime.Now.ToString();

        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "欢迎来到管理主页！";

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void 人事管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PersionManage();
            form.ShowDialog();
        }

        private void 金额管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MoneyManage();
            form.ShowDialog();
        }

        private void 货物管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GoodsManage();
            form.ShowDialog();
        }

        private void 发送反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Feedback();
            form.ShowDialog();
        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new About();
            form.ShowDialog();
        }

        private void 公司资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UserManage();
            form.ShowDialog();
        }

        private void 流程处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Officework();
            form.ShowDialog();
        }

        private void 意见查看ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new Suggestion();
            form.ShowDialog();
        }
    }
}
