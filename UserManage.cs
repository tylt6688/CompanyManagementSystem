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
    public partial class UserManage : Form
    {
        public UserManage()
        {
            InitializeComponent();
        }

        public void Init()
        {
            listView1.Items.Clear();
            string sql = "SELECT * FROM person";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                string a, b, c, d, f, g;
                a = mdr["id"].ToString();
                b = mdr["number"].ToString();
                c = mdr["truename"].ToString();
                d = mdr["phone"].ToString();
                f = mdr["status"].ToString();
                g = mdr["mark"].ToString();

                var item = new ListViewItem(a);
                item.SubItems.Add(b);
                item.SubItems.Add(c);
                item.SubItems.Add(d);
                item.SubItems.Add(f);
                item.SubItems.Add(g);
                listView1.Items.Add(item);
            }
        }
        private string Execu(string sql)
        {
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            return msg;
        }
        private void UserManage_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = listView1.FocusedItem.SubItems[0].Text.ToString();
            Console.WriteLine("删除id=" + id);
            string sql = "DELETE  FROM person  WHERE id = '" + id + "'";
            var notify = Execu(sql);
            MessageBox.Show(notify);
            Init();
        }

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = listView1.FocusedItem.SubItems[0].Text.ToString();
            var form = new UserProfile(id);
            form.Owner = this;
            form.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
