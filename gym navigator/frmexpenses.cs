using gym_management_system;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class frmexpenses : Form
    {
        Conclass connected = new Conclass();
        string salaryorothers;
        string expenseId;

        public frmexpenses()
        {
            InitializeComponent();
            namesdisplay();
            salaryDisplay();
        }

        public void namesdisplay()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select name, CoachID from Coaches", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Add "others" as a custom value to the DataTable
                DataRow othersRow = dt.NewRow();
                othersRow["name"] = "others";
                othersRow["CoachID"] = -1; // You can set this to any value that represents "others"
                dt.Rows.InsertAt(othersRow, 0);

                comboBoxname.DisplayMember = "name";
                comboBoxname.ValueMember = "CoachID";
                comboBoxname.DataSource = dt;
                display();

                // Handle the SelectedIndexChanged event for comboBoxname
                comboBoxname.SelectedIndexChanged += ComboBoxname_SelectedIndexChanged;
            }
        }
        public void display()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from expenses", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        public void salaryDisplay()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select CoachID, salary from Coaches", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Add a custom row for "others" with a default salary value (e.g., 0)
                DataRow othersRow = dt.NewRow();
                othersRow["CoachID"] = -1; // Match the value set for "others" in comboBoxname
                othersRow["salary"] = 0; // Set the default salary value for "others"
                dt.Rows.InsertAt(othersRow, 0);

                compsalary.DisplayMember = "salary";
                compsalary.ValueMember = "CoachID";
                compsalary.DataSource = dt;
            }
        }

        private void frmexpenses_Load(object sender, EventArgs e)
        {

        }

        private void ComboBoxname_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected coach's ID
            int selectedCoachId;
            if (int.TryParse(comboBoxname.SelectedValue.ToString(), out selectedCoachId))
            {
                // If "others" is selected, enable the TextBox for custom salary entry
                if (selectedCoachId == -1)
                {
                    txtCustomSalary.Enabled = true;
                    txtCustomSalary.Text = ""; // Clear any previous value
                    compsalary.SelectedIndex = 0; // Set the ComboBox to the default value
                }
                else
                {
                    // Find the corresponding index in compsalary and set the selected item
                    for (int i = 0; i < compsalary.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)compsalary.Items[i];
                        if (Convert.ToInt32(drv["CoachID"]) == selectedCoachId)
                        {
                            compsalary.SelectedIndex = i;
                            break;
                        }
                    }

                    // Disable the TextBox when a coach other than "others" is selected
                    txtCustomSalary.Enabled = false;
                    txtCustomSalary.Text = ""; // Clear any previous value
                }
            }
        }

        private void txtCustomSalary_TextChanged(object sender, EventArgs e)
        {
            // Set the custom salary value when the user enters a value in the TextBox
            if (int.TryParse(txtCustomSalary.Text, out int customSalary))
            {
                // Set the custom salary value in the compsalary ComboBox
                compsalary.SelectedValue = -1; // Set the CoachID corresponding to "others"
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (string.IsNullOrEmpty(comboBoxname.Text) ||
                    string.IsNullOrEmpty(compsalary.Text) || string.IsNullOrEmpty(txtdescription.Text))
                {
                    MessageBox.Show("Please fill in all the required fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxname.Text == "others")
                {
                    salaryorothers = txtCustomSalary.Text;
                }
                else
                {
                    salaryorothers = compsalary.Text;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspExpense";
                cmd.Parameters.AddWithValue("@id", "");  // Assuming you want to pass an empty string for the id, adjust accordingly
                cmd.Parameters.AddWithValue("@nameorother", comboBoxname.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@salaryorother", salaryorothers);
                cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                cmd.Parameters.AddWithValue("@Type", "insert");  // Add the Type parameter and set it to 'insert'

                cmd.ExecuteNonQuery();

                MessageBox.Show("Transaction completed", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();

                ClearTextBox();
            }
        }

        // Assuming ClearTextBox method also clears salary and description controls
        private void ClearTextBox()
        {
            compsalary.Text = string.Empty;
            txtdescription.Text = string.Empty;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (string.IsNullOrEmpty(comboBoxname.Text) ||
                    string.IsNullOrEmpty(compsalary.Text) || string.IsNullOrEmpty(txtdescription.Text))
                {
                    MessageBox.Show("Please fill in all the required fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxname.Text == "others")
                {
                    salaryorothers = txtCustomSalary.Text;
                }
                else
                {
                    salaryorothers = compsalary.Text;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspExpense";
                cmd.Parameters.AddWithValue("@id", expenseId);  // Use the expenseId obtained from the DataGridView
                cmd.Parameters.AddWithValue("@nameorother", comboBoxname.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@salaryorother", salaryorothers);
                cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                cmd.Parameters.AddWithValue("@Type", "update");  // Set Type to 'update' for update operation

                cmd.ExecuteNonQuery();

                MessageBox.Show("Transaction completed", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();

                ClearTextBox();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                expenseId = row.Cells["Id"].Value.ToString(); // Assuming the column name is "Id"

                comboBoxname.Text = row.Cells["NameOrOther"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                string salaryOrOther = row.Cells["SalaryOrOther"].Value.ToString();

                if (comboBoxname.Text == "others")
                {
                    txtCustomSalary.Enabled = true;
                    txtCustomSalary.Text = salaryOrOther;
                    compsalary.SelectedIndex = 0;
                }
                else
                {
                    txtCustomSalary.Enabled = false;
                    txtCustomSalary.Text = "";
                    compsalary.Text = salaryOrOther;
                }

                txtdescription.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(expenseId))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (comboBoxname.Text == "others")
                    {
                        salaryorothers = txtCustomSalary.Text;
                    }
                    else
                    {
                        salaryorothers = compsalary.Text;
                    }
                    using (SqlConnection conn = connected.connect())
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "UspExpense";
                        cmd.Parameters.AddWithValue("@id", expenseId);  // Use the expenseId obtained from the DataGridView
                        cmd.Parameters.AddWithValue("@nameorother", comboBoxname.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@salaryorother", salaryorothers);
                        cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                        cmd.Parameters.AddWithValue("@Type", "delete");  // Set Type to 'update' for update operation

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Transaction completed", "delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        display();

                        ClearTextBox();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
