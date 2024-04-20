using gym_management_system;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class Members : UserControl
    {
        Conclass connected = new Conclass();
        public string studemtID;
        public Members()
        {
            InitializeComponent();
            display();
            txtphone.KeyPress += txtphone_KeyPress;
            txtname.KeyPress += txtname_KeyPress;


        }
        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only alphabetic input and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only alphabetic characters are allowed in this field.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
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
                SqlDataAdapter da = new SqlDataAdapter("select * from members", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            // btnsave.Enabled = true;
            //btnupdate.Enabled = false;
            //btndelete.Enabled = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (txtname.Text == "" || txtphone.Text == "" || txtsex.Text == "" || txtaddress.Text == "" || txtreason.Text == "")
                {
                    MessageBox.Show("please fill the plank places", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SqlCommand cmd = new SqlCommand("insert into members(name,phone,sex,address,reason) values(@name,@phone,@sex,@adress,@reason) ",conn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspAddmember";
                cmd.Parameters.AddWithValue("@id", "");
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@sex", txtsex.Text);
                cmd.Parameters.AddWithValue("@adress", txtaddress.Text);
                cmd.Parameters.AddWithValue("@reason", txtreason.Text);
                cmd.Parameters.AddWithValue("@Type", "insert");
                cmd.ExecuteNonQuery();
                MessageBox.Show("new member has been added ", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();

                ClearTextBox();
                // btnsave.Enabled = true;
                // btnupdate.Enabled = false;
                // btndelete.Enabled = false;
            }
        }

        private void ClearTextBox()
        {
            txtname.Clear();
            txtphone.Clear();
            txtsex.Text = "";
            txtaddress.Clear();
            txtreason.Clear();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            studemtID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtphone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtsex.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtaddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtreason.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            btnsave.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (txtname.Text == "" || txtphone.Text == "" || txtsex.Text == "" || txtaddress.Text == "" || txtreason.Text == "")
                {
                    MessageBox.Show("please fill the plank places", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SqlCommand cmd = new SqlCommand("insert into members(name,phone,sex,address,reason) values(@name,@phone,@sex,@adress,@reason) ",conn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspAddmember";
                cmd.Parameters.AddWithValue("@id", studemtID);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@sex", txtsex.Text);
                cmd.Parameters.AddWithValue("@adress", txtaddress.Text);
                cmd.Parameters.AddWithValue("@reason", txtreason.Text);
                cmd.Parameters.AddWithValue("@Type", "update");
                cmd.ExecuteNonQuery();
                MessageBox.Show("new member has been updated ", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();

                ClearTextBox();
                //btnsave.Enabled = true;
                //btnupdate.Enabled = false;
                //btndelete.Enabled = false;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (txtname.Text == "" || txtphone.Text == "" || txtsex.Text == "" || txtaddress.Text == "" || txtreason.Text == "")
                {
                    MessageBox.Show("please fill the plank places", "input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SqlCommand cmd = new SqlCommand("insert into members(name,phone,sex,address,reason) values(@name,@phone,@sex,@adress,@reason) ",conn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspAddmember";
                cmd.Parameters.AddWithValue("@id", studemtID);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@sex", txtsex.Text);
                cmd.Parameters.AddWithValue("@adress", txtaddress.Text);
                cmd.Parameters.AddWithValue("@reason", txtreason.Text);
                cmd.Parameters.AddWithValue("@Type", "delete");
                cmd.ExecuteNonQuery();
                MessageBox.Show("new member has been deleted ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                display();

                ClearTextBox();
                // btnsave.Enabled = true;
                //btnupdate.Enabled = false;
                //btndelete.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
