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
    public partial class frmnetincom : Form
    {
        public frmnetincom()
        {
            InitializeComponent();
        }

        private void frmnetincom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GYMDataSet4.reveniu' table. You can move, or remove it, as needed.
            this.reveniuTableAdapter.Fill(this.GYMDataSet4.reveniu);

            this.reportViewer1.RefreshReport();
        }
    }
}
