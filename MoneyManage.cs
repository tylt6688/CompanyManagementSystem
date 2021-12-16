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
    public partial class MoneyManage : Form
    {
        public MoneyManage()
        {
            InitializeComponent();
        }

        public void Init()
        {
            string sql = "select * from money";
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();
            while (mdr.Read())
            {
                string a, b, c;
                a = mdr["id"].ToString();
                b = mdr["money"].ToString();
                c = mdr["company"].ToString();
                string[] str = { a, b, c };
                dataGridView1.Rows.Add(str);
            }
        }
        public void Select(string sql)
        {
            SQLtools tool = new SQLtools();
            MySqlCommand cmd = new MySqlCommand(sql, tool.getConn());
            MySqlDataReader mdr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();
            while (mdr.Read())
            {
                string a, b, c;
                a = mdr["id"].ToString();
                b = mdr["money"].ToString();
                c = mdr["company"].ToString();
                string[] str = { a, b, c };
                dataGridView1.Rows.Add(str);
            }
        }
        public void Execu(string sql)
        {
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            MessageBox.Show(msg);
            tools.getClose();
            //this.Hide();
            //var form = new MoneyManage();
            //this.Close();
            //form.ShowDialog();
        }
        private void MoneyManage_Load(object sender, EventArgs e)
        {

            
            Init();

            }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Insert into money(money,company) values('" + txt_money.Text + "','" + txt_company.Text + "')";
            Execu(sql);
            Init();

        }

        private void txt_company_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from money where company='" + txt_delcom.Text + "'";
            Execu(sql);
            Init();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from money where company='" + txt_selcom.Text + "'";
            Select(sql);
            
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
