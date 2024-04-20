using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class frmexpenserepo : Form
    {
        public frmexpenserepo()
        {
            InitializeComponent();
        }

        private void frmexpenserepo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GYMDataSet3.expenses' table. You can move, or remove it, as needed.
            this.expensesTableAdapter.Fill(this.GYMDataSet3.expenses);

            this.reportViewer1.RefreshReport();
        }
    }
}
