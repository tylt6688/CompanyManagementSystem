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
    public partial class Officework : Form
    {
        public Officework()
        {
            InitializeComponent();
        }

        private void Init()
        {
            string sql = "SELECT * FROM vacation";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                string a, b, c, d, f, g;
                a = mdr["id"].ToString();
                b = mdr["truename"].ToString();
                c = mdr["reason"].ToString();
                d = mdr["inittime"].ToString().Remove(9,7);
                f = mdr["finaltime"].ToString().Remove(9,7);
                g = mdr["status"].ToString();

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
        private void Officework_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string id = listView1.FocusedItem.SubItems[0].Text.ToString();
            Console.WriteLine(id);
            string msg = "通过审批";
            string sql = "UPDATE vacation SET status ='" + msg + "' WHERE id = '" + id + "'";
            var notify = Execu(sql);
            MessageBox.Show(notify);
            listView1.Items.Clear();
            Init();
            

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string id = listView1.FocusedItem.SubItems[0].Text.ToString();
            Console.WriteLine(id);
            string msg = "拒绝审批";
            string sql = "UPDATE vacation SET status ='" + msg + "' WHERE id = '" + id + "'";
            var notify = Execu(sql);
            MessageBox.Show(notify);
            listView1.Items.Clear();
            Init();
        }
    }
}
