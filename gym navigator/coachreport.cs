using System;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class coachreport : Form
    {
        public coachreport()
        {
            InitializeComponent();
        }

        private void coachreport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GYMDataSet1.Coaches' table. You can move, or remove it, as needed.
            this.CoachesTableAdapter.Fill(this.GYMDataSet1.Coaches);

            this.reportViewer1.RefreshReport();
        }
    }
}
