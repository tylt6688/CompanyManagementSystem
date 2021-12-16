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
    public partial class VacationStatus : Form
    {
        public VacationStatus(string truename)
        {
            InitializeComponent();
            toolStripStatusLabel2.Text = truename;
        }
        private void Init()
        {
            Console.WriteLine(toolStripStatusLabel2.Text);
            string sql = "SELECT * FROM vacation WHERE truename = '"+ toolStripStatusLabel2.Text +"' ";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                string a, b, c, d, f, g;
                a = mdr["id"].ToString();
                b = mdr["truename"].ToString();
                c = mdr["reason"].ToString();
                d = mdr["inittime"].ToString();
                f = mdr["finaltime"].ToString();
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

        private void VacationStatus_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
