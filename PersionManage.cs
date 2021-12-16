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
    public partial class PersionManage : Form
    {
        private string flag = string.Empty;
        public PersionManage()
        {
            InitializeComponent();
           
        }

        private void Init()
        {
            string sql = "SELECT * FROM person";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                string a, b, c, d, f, g, h;
                a = mdr["id"].ToString();
                b = mdr["number"].ToString();
                c = mdr["truename"].ToString();
                d = mdr["sex"].ToString();
                f = mdr["age"].ToString();
                g = mdr["phone"].ToString();
                h = mdr["status"].ToString();

                var item = new ListViewItem(a);
                item.SubItems.Add(b);
                item.SubItems.Add(c);
                item.SubItems.Add(d);
                item.SubItems.Add(f);
                item.SubItems.Add(g);
                item.SubItems.Add(h);
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

        private void Index_Load(object sender, EventArgs e)
        {
            Init();

        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            string id = listView1.FocusedItem.SubItems[0].Text.ToString();
            Console.WriteLine("id="+id);
            var form = new Setnumber(id);
            form.clickhander += new clickHander(test);
            form.ShowDialog();
        }

        public void test(string flag)
        {
            this.flag = flag;
            toolStripButton3.Text = flag;
            listView1.Items.Clear();
            Init();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string id = listView1.FocusedItem.SubItems[0].Text.ToString();
            Console.WriteLine("删除id=" + id);
            string sql = "DELETE  FROM person  WHERE id = '" + id + "'";
            var notify = Execu(sql);
            MessageBox.Show(notify);
            listView1.Items.Clear();
            Init();
        }
    }
}
