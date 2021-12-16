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
    public partial class UserProfile : Form
    {
        private string userid;
        public UserProfile(string id)
        {
            InitializeComponent();
            this.userid = id;
        }
        private void Init()
        {
            string sql = "SELECT * FROM person WHERE id = '" + userid + "' ";
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

                txt_truename.Text = c;
                txt_tel.Text = d;
                txt_number.Text = b;
                txt_status.Text = f;
                txt_mark.Text = g;
            }
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update person set number='" + txt_number.Text + "',status= '" + txt_status.Text
                         + "',mark='" + txt_mark.Text + "' where truename= '" + txt_truename.Text + "'";
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            MessageBox.Show(msg);
            UserManage form = (UserManage)this.Owner;
            form.Init();
            this.Close();
        }
    }
}
