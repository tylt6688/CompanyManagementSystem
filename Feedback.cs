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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            lst_view.Items.Clear();
        }

        private void lst_view_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            string data = txt_add.Text;
            lst_view.Items.Add(data);
            string sql = "INSERT INTO feedback(suggesstion) VALUES('" + data + "')";
            SQLtools tools = new SQLtools();
            tools.getConn();
            var msg = tools.getExecu(sql);
            MessageBox.Show(msg);
            tools.getClose();
           
           
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            lst_view.Items.Clear();
        }
    }
}
