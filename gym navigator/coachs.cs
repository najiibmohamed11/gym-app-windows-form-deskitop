using gym_management_system;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class UserControl2 : UserControl
    {
        Conclass connected = new Conclass();
        public string CoachID;

        public UserControl2()
        {
            InitializeComponent();
            display();
            numericUpDown1salary.Minimum = 200;
            numericUpDown1salary.Maximum = 300;

            TxtPhonec.KeyPress += TxtPhonec_KeyPress;
            TxtNamecoach.KeyPress += TxtNamecoach_KeyPress;


        }
        private void TxtNamecoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only alphabetic input and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only alphabetic characters are allowed in this field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtPhonec_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only numeric input and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed in this field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

     


        public void display()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Coaches", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewCoach.DataSource = dt;
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void BtnSavecoach_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (TxtNamecoach.Text == "" || TxtPhonec.Text == "" || CmboxSexCoach.Text == "" || TxtAddressCoach.Text == "" || dateTimePickercoach.Text == "" || numericUpDown1salary.Value == 0)
                {
                    MessageBox.Show("Please fill in all the required fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspCOACHES";
                cmd.Parameters.AddWithValue("@CoachID", "");
                cmd.Parameters.AddWithValue("@Name", TxtNamecoach.Text);
                cmd.Parameters.AddWithValue("@Sex", CmboxSexCoach.Text);
                cmd.Parameters.AddWithValue("@Phone", TxtPhonec.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddressCoach.Text);
                cmd.Parameters.AddWithValue("@HireDate", dateTimePickercoach.Text);
                cmd.Parameters.AddWithValue("@Salary", numericUpDown1salary.Value.ToString());
                cmd.Parameters.AddWithValue("@Type", "insert");
                cmd.ExecuteNonQuery();

                MessageBox.Show("New member has been added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearTextBox();
                display();
            }
        }

        private void ClearTextBox()
        {
            TxtNamecoach.Clear();
            CmboxSexCoach.Text = "";
            TxtPhonec.Clear();
            TxtAddressCoach.Clear();

        }

        private void BtnUpdatecoach_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (TxtNamecoach.Text == "" || TxtPhonec.Text == "" || CmboxSexCoach.Text == "" || TxtAddressCoach.Text == "" || dateTimePickercoach.Text == "" || numericUpDown1salary.Value == 0)
                {
                    MessageBox.Show("Please fill in all the required fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspCOACHES";
                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                cmd.Parameters.AddWithValue("@Name", TxtNamecoach.Text);
                cmd.Parameters.AddWithValue("@Sex", CmboxSexCoach.Text);
                cmd.Parameters.AddWithValue("@Phone", TxtPhonec.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddressCoach.Text);
                cmd.Parameters.AddWithValue("@HireDate", dateTimePickercoach.Text);
                cmd.Parameters.AddWithValue("@Salary", numericUpDown1salary.Value.ToString());
                cmd.Parameters.AddWithValue("@Type", "update");
                cmd.ExecuteNonQuery();

                MessageBox.Show("Member has been updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearTextBox();
                display();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewCoach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CoachID = dataGridViewCoach.CurrentRow.Cells[0].Value.ToString();
            TxtNamecoach.Text = dataGridViewCoach.CurrentRow.Cells[1].Value.ToString();
            CmboxSexCoach.Text = dataGridViewCoach.CurrentRow.Cells[2].Value.ToString();
            TxtPhonec.Text = dataGridViewCoach.CurrentRow.Cells[3].Value.ToString();
            TxtAddressCoach.Text = dataGridViewCoach.CurrentRow.Cells[4].Value.ToString();
            dateTimePickercoach.Text = dataGridViewCoach.CurrentRow.Cells[5].Value.ToString();
            numericUpDown1salary.Value = decimal.Parse(dataGridViewCoach.CurrentRow.Cells[6].Value.ToString());

       
        }

        private void BtnDeletecoach_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (TxtNamecoach.Text == "" || TxtPhonec.Text == "" || CmboxSexCoach.Text == "" || TxtAddressCoach.Text == "" || dateTimePickercoach.Text == "" || numericUpDown1salary.Value == 0)
                {
                    MessageBox.Show("Please fill in all the required fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspCOACHES";
                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                cmd.Parameters.AddWithValue("@Name", TxtNamecoach.Text);
                cmd.Parameters.AddWithValue("@Sex", CmboxSexCoach.Text);
                cmd.Parameters.AddWithValue("@Phone", TxtPhonec.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddressCoach.Text);
                cmd.Parameters.AddWithValue("@HireDate", dateTimePickercoach.Text);
                cmd.Parameters.AddWithValue("@Salary", numericUpDown1salary.Value.ToString());
                cmd.Parameters.AddWithValue("@Type", "delete");
                cmd.ExecuteNonQuery();

                MessageBox.Show("Member has been deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                ClearTextBox();
            }
        }
    }
}
