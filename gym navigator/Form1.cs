using System;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GYMDataSet.members' table. You can move, or remove it, as needed.
            this.membersTableAdapter.Fill(this.GYMDataSet.members);

            this.reportViewer1.RefreshReport();
        }
    }
}
