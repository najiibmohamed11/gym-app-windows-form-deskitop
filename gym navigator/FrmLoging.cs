using gym_management_system;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class FrmLoging : Form
    {
        Conclass connected = new Conclass();

        public FrmLoging()
        {
            InitializeComponent();
        }

        // ...

        // ... (existing code)

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password, name;
            username = txtUserName.Text;
            password = txtPassword.Text;
            name = "";
            byte[] imageBytes = null; // Initialize the 'imageBytes' variable

            try
            {
                using (SqlConnection conn = connected.connect())
                {
                    string query = "SELECT name, userName, password, images FROM [users] WHERE userName = @userName AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        name = dt.Rows[0]["name"].ToString();

                        // Retrieve the 'images' column as byte array
                        if (dt.Rows[0]["images"] != DBNull.Value)
                        {
                            imageBytes = (byte[])dt.Rows[0]["images"];
                        }

                        index newindex = new index(name, imageBytes);
                        newindex.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login data", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Any cleanup code if needed
            }
        }

        // ... (existing code)


        // ...


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
