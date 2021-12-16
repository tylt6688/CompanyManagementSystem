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
    public delegate void clickHander(string flag);
    public partial class Setnumber : Form
    {
        public event clickHander clickhander;
        public Setnumber(string id)
        {
            InitializeComponent();
            textBox1.Text = id;

        }
        private string Execu(string sql)
        {
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            return msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            Console.WriteLine(textBox1.Text);
            string number = num.Text;
            string depart = dep.Text;
            string sql = "UPDATE person SET number='" + number + "',status ='"+ depart+"' WHERE id = '" + textBox1.Text + "'";
            var notify = Execu(sql);
            MessageBox.Show(notify);
            clickhander(notify);
            this.Close();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
