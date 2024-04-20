using System;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class revenueReport : Form
    {
        public revenueReport()
        {
            InitializeComponent();
        }

        private void revenueReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GYMDataSet2.reveniu' table. You can move, or remove it, as needed.
            this.reveniuTableAdapter.Fill(this.GYMDataSet2.reveniu);

            this.reportViewer1.RefreshReport();
        }
    }
}
