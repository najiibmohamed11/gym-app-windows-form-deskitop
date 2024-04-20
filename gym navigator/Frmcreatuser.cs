using gym_management_system;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class Frmcreatuser : Form
    {
        private string userId;
        Conclass connected = new Conclass();

        public Frmcreatuser()
        {
            InitializeComponent();
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                pictureBox1.Region = new Region(path);
            }
            display();
        }

        public void display()
        {
            using (SqlConnection conn = connected.connect())
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from users", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the image without creating a new Bitmap
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void brows_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the image without creating a new Bitmap
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connected.connect())
            {
                if (string.IsNullOrEmpty(txtname.Text) || string.IsNullOrEmpty(txtemail.Text) ||
                    string.IsNullOrEmpty(txtusernam.Text) || string.IsNullOrEmpty(txtpassword.Text) ||
                    pictureBox1.Image == null)
                {
                    MessageBox.Show("Please fill in all the required fields", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspUser";

                cmd.Parameters.AddWithValue("@userId", "");
                cmd.Parameters.AddWithValue("@userName", txtusernam.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);

                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    cmd.Parameters.AddWithValue("@images", ms.ToArray());
                }

                cmd.Parameters.AddWithValue("@Type", "insert");

                cmd.ExecuteNonQuery();

                MessageBox.Show("User created successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                ClearInputs();
            }
        }

        private void ClearInputs()
        {
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtusernam.Text = string.Empty;
            txtpassword.Text = string.Empty;

            string imagePath = @"C:\Users\NAJIIB\Downloads\genral daud gym\updated_gym_code mcc\updated_gym_code\gym navigator\gym navigator\Resources\cloud-2044823_1280.png";

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Image file is missing!");
            }
        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                userId = dataGridView1.CurrentRow.Cells["userId"].Value.ToString();
                string userName = dataGridView1.CurrentRow.Cells["userName"].Value.ToString();
                string password = dataGridView1.CurrentRow.Cells["password"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells["name"].Value.ToString();

                txtusernam.Text = userName;
                txtpassword.Text = password;
                txtemail.Text = email;
                txtname.Text = name;

                byte[] imageData = dataGridView1.CurrentRow.Cells["images"].Value as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = connected.connect())
                {
                    if (string.IsNullOrEmpty(txtusernam.Text) || string.IsNullOrEmpty(txtpassword.Text) ||
                        string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtname.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UspUser";

                    // User ID
                    cmd.Parameters.AddWithValue("@userId", userId);

                    // Other user details
                    cmd.Parameters.AddWithValue("@userName", txtusernam.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@name", txtname.Text);

                    // Image handling
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Save the image to MemoryStream
                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                            // Add the image as a parameter
                            cmd.Parameters.AddWithValue("@images", ms.ToArray());
                        }
                    }
                    else
                    {
                        // If no image is selected, set the parameter to DBNull.Value
                        cmd.Parameters.AddWithValue("@images", DBNull.Value);
                    }

                    // Specify the update operation
                    cmd.Parameters.AddWithValue("@Type", "update");

                    // Check if the image is being updated
                    if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
                    {
                        // Include the image update in the SQL statement
                        cmd.CommandText += ", profile_image = @images";
                    }

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the data in the DataGridView
                    display();

                    // Clear input fields
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please change the image if you want to update the users data ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Please select a user to delete", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = connected.connect())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UspUser";

                    cmd.Parameters.AddWithValue("@userId", userId);

                    if (pictureBox1.Image != null && pictureBox1.ImageLocation != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            cmd.Parameters.AddWithValue("@images", ms.ToArray());
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add("@images", SqlDbType.VarBinary).Value = DBNull.Value;
                    }

                    cmd.Parameters.AddWithValue("@userName", txtusernam.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Type", "delete");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    display();
                    ClearInputs();
                }
            }
        }

        private void Frmcreatuser_Load(object sender, EventArgs e)
        {
            // You can add additional initialization logic here if needed
        }

        private void Frmcreatuser_Load_1(object sender, EventArgs e)
        {
            // You can add additional initialization logic here if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = connected.connect())
                {
                    if (string.IsNullOrEmpty(txtusernam.Text) || string.IsNullOrEmpty(txtpassword.Text) ||
                        string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtname.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UspUser";

                    // User ID
                    cmd.Parameters.AddWithValue("@userId", userId);

                    // Other user details
                    cmd.Parameters.AddWithValue("@userName", txtusernam.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@name", txtname.Text);

                    // Image handling
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Save the image to MemoryStream
                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                            // Add the image as a parameter
                            cmd.Parameters.AddWithValue("@images", ms.ToArray());
                        }
                    }
                    else
                    {
                        // If no image is selected, set the parameter to DBNull.Value
                        cmd.Parameters.AddWithValue("@images", DBNull.Value);
                    }

                    // Specify the update operation
                    cmd.Parameters.AddWithValue("@Type", "update");

                    // Check if the image is being updated
                    if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
                    {
                        // Include the image update in the SQL statement
                        cmd.CommandText += ", profile_image = @images";
                    }

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User updated successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the data in the DataGridView
                    display();

                    // Clear input fields
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
