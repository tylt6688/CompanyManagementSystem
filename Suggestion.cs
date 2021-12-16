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
    public partial class Suggestion : Form
    {
        public Suggestion()
        {
            InitializeComponent();
        }
        private void Init()
        {
            string sql = "SELECT * FROM feedback";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            while (mdr.Read())
            {
                string a, b;
                a = mdr["id"].ToString();
                b = mdr["suggesstion"].ToString();


                var item = new ListViewItem(a);
                item.SubItems.Add(b);
                listView1.Items.Add(item);
            }
        }

        private void Suggestion_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
