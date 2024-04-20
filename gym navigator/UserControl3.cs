using gym_management_system;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class UserControl3 : UserControl
    {
        Conclass connected = new Conclass();

        public UserControl3()
        {
            InitializeComponent();
            countmembers();
            countcoaches();
            countreveniu();
            countexpense();
            calculateNetIncome();
        }

        public void countmembers()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KJ2NJQE\\SQLEXPRESS;Initial Catalog=GYM;Integrated Security=True;"))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM members", conn))
                {
                    int memberCount = (int)command.ExecuteScalar();
                    membercount.Text = memberCount.ToString();
                }
            }
        }

        public void countcoaches()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KJ2NJQE\\SQLEXPRESS;Initial Catalog=GYM;Integrated Security=True;"))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM coaches", conn))
                {
                    int coachCount = (int)command.ExecuteScalar();
                    couachcount.Text = coachCount.ToString();
                }
            }
        }

        public void countreveniu()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KJ2NJQE\\SQLEXPRESS;Initial Catalog=GYM;Integrated Security=True;"))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT SUM(CAST(Amount AS decimal)) FROM reveniu", conn))
                {
                    decimal totalAmount = (decimal)command.ExecuteScalar();
                    countincome.Text = totalAmount.ToString();
                }
            }
        }

        public void countexpense()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KJ2NJQE\\SQLEXPRESS;Initial Catalog=GYM;Integrated Security=True;"))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT SUM(CAST(salaryorother AS decimal)) FROM expenses", conn))
                {
                    decimal totalAmount = (decimal)command.ExecuteScalar();
                    countexpens.Text = totalAmount.ToString();
                }
            }
        }

        public void calculateNetIncome()
        {
            decimal revenue = Convert.ToDecimal(countincome.Text);
            decimal expenses = Convert.ToDecimal(countexpens.Text);

            decimal netIncome = revenue - expenses;

            countnetincome.Text = netIncome.ToString();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Your save button logic here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Your button1 click logic here
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            // Your UserControl3 load logic here
        }

        private void membercount_Click(object sender, EventArgs e)
        {
            Form1 memberformreport = new Form1();

            memberformreport.Show();
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            Form1 memberformreport = new Form1();

            memberformreport.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 memberformreport = new Form1();

            memberformreport.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 memberformreport = new Form1();

            memberformreport.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            coachreport couchrepo = new coachreport();
            couchrepo.Show();
        }

        private void couachcount_Click(object sender, EventArgs e)
        {
            coachreport couchrepo = new coachreport();
            couchrepo.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            coachreport couchrepo = new coachreport();
            couchrepo.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            coachreport couchrepo = new coachreport();
            couchrepo.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            revenueReport revrepo = new revenueReport();
            revrepo.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            revenueReport revrepo = new revenueReport();
            revrepo.Show();
        }

        private void countincome_Click(object sender, EventArgs e)
        {
            revenueReport revrepo = new revenueReport();
            revrepo.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmexpenserepo exprepo = new frmexpenserepo();
            exprepo.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
          
        }

        private void countexpens_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void countnetincome_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            countmembers();
            countcoaches();
            countreveniu();
            countexpense();
            calculateNetIncome();
        }
    }
}
