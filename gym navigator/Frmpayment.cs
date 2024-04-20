using System;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class Frmpayment : Form
    {
        public Frmpayment()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            revenue newrev = new revenue();
            newrev.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmexpenses neexpene = new frmexpenses();
            neexpene.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
