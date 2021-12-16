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
    public partial class UserHome : Form
    {
        public UserHome(string username)
        {
            InitializeComponent();
            label1.Text = username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new VacationStatus(label1.Text);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new Feedback();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Vacation(label1.Text);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new PersonProfile(label1.Text);
            form.ShowDialog();
        }
    }
}
