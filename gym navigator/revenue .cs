using gym_management_system;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class revenue : Form
    {
        Conclass connected = new Conclass();
        public string revenueid;

        public revenue()
        {
            InitializeComponent();
            namesdisplay();
            display();
            numericamount.Maximum = 300;
            numericamount.ValueChanged += numericAmount_ValueChanged;

        }
        private decimal lastValue = 0; // Class-level variable to store the last value

        private void numericAmount_ValueChanged(object sender, EventArgs e)
        {
            decimal currentValue = numericamount.Value;

            if (Math.Abs(currentValue - lastValue) < 25)
            {
                numericamount.Value = currentValue > lastValue ? lastValue + 25 : lastValue - 25;
            }

            lastValue = numericamount.Value;
        }

        public void namesdisplay()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select name from members", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxname.DisplayMember = "name";
                comboBoxname.ValueMember = "memberId";
                comboBoxname.DataSource = dt;
            }
        }
        public void display()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from reveniu", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (numericamount.Value == 0)
                {
                    MessageBox.Show("Amount cannot be zero.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(combopayment.Text) && numericamount.Value == 0)
                {
                    MessageBox.Show("please fill the plank places", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SqlCommand cmd = new SqlCommand("insert into members(name,phone,sex,address,reason) values(@name,@phone,@sex,@adress,@reason) ",conn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Uspreveviu";
                cmd.Parameters.AddWithValue("@id", "");  // Assuming you want to pass an empty string for the id, adjust accordingly
                cmd.Parameters.AddWithValue("@name", comboBoxname.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);  // Use Value.Date to get the date part only
                cmd.Parameters.AddWithValue("@PaymentMethod", combopayment.Text);
                cmd.Parameters.AddWithValue("@Amount", numericamount.Value.ToString());
                cmd.Parameters.AddWithValue("@Type", "insert");  // Add the Type parameter and set it to 'insert'

                cmd.ExecuteNonQuery();

                MessageBox.Show("transection completed ", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();

                ClearTextBox();
                // btnsave.Enabled = true;
                // btnupdate.Enabled = false;
                // btndelete.Enabled = false;
            }
        }

        private void ClearTextBox()
        {
            numericamount.Value = 0;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void revenue_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Assuming your columns are in order: id, name, date, PaymentMethod, Amount
            revenueid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string date = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string paymentMethod = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string amount = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            // Assuming you have controls named TxtId, TxtName, dateTimePicker1, combopayment, and numericamount

            comboBoxname.Text = name;
            dateTimePicker1.Text = date;
            combopayment.Text = paymentMethod;
            numericamount.Value = decimal.Parse(amount);

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (string.IsNullOrEmpty(combopayment.Text) && numericamount.Value == 0)
                {
                    MessageBox.Show("please fill the plank places", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SqlCommand cmd = new SqlCommand("insert into members(name,phone,sex,address,reason) values(@name,@phone,@sex,@adress,@reason) ",conn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Uspreveviu";
                cmd.Parameters.AddWithValue("@id", revenueid);  // Assuming you want to pass an empty string for the id, adjust accordingly
                cmd.Parameters.AddWithValue("@name", comboBoxname.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);  // Use Value.Date to get the date part only
                cmd.Parameters.AddWithValue("@PaymentMethod", combopayment.Text);
                cmd.Parameters.AddWithValue("@Amount", numericamount.Value.ToString());
                cmd.Parameters.AddWithValue("@Type", "update");  // Add the Type parameter and set it to 'insert'

                cmd.ExecuteNonQuery();

                MessageBox.Show("transection completed ", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();

                ClearTextBox();
                // btnsave.Enabled = true;
                // btnupdate.Enabled = false;
                // btndelete.Enabled = false;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (string.IsNullOrEmpty(combopayment.Text) && numericamount.Value == 0)
                {
                    MessageBox.Show("please fill the plank places", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SqlCommand cmd = new SqlCommand("insert into members(name,phone,sex,address,reason) values(@name,@phone,@sex,@adress,@reason) ",conn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Uspreveviu";
                cmd.Parameters.AddWithValue("@id", revenueid);  // Assuming you want to pass an empty string for the id, adjust accordingly
                cmd.Parameters.AddWithValue("@name", comboBoxname.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);  // Use Value.Date to get the date part only
                cmd.Parameters.AddWithValue("@PaymentMethod", combopayment.Text);
                cmd.Parameters.AddWithValue("@Amount", numericamount.Value.ToString());
                cmd.Parameters.AddWithValue("@Type", "delete");  // Add the Type parameter and set it to 'insert'

                cmd.ExecuteNonQuery();

                MessageBox.Show("transection deleted ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                display();

                ClearTextBox();
                // btnsave.Enabled = true;
                // btnupdate.Enabled = false;
                // btndelete.Enabled = false;
            }

        }
    }
}
