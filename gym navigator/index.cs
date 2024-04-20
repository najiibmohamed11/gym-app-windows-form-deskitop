using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace gym_navigator
{
    public partial class index : Form
    {
        private string loggedInUsername;
        private byte[] loggedInUserImage; // Added variable for user image

        public index(string username, byte[] userImage)
        {
            InitializeComponent();
            loggedInUsername = username;
            loggedInUserImage = userImage; // Set the user image
            lbluser.Text = loggedInUsername;
            lbluser.Visible = true;
            // Display user image in pictureBox (assuming pictureBox is named pictureBoxUser)
            if (loggedInUserImage != null && loggedInUserImage.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(loggedInUserImage))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            userControl11.Hide();
            userControl31.Show();
            userControl12.Hide();
            userControl21.Hide();
            userControl31.BringToFront();
        }

        // ... (existing code)


        private void Form1_Load(object sender, EventArgs e)
        {
            // userControl11.Hide();

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                pictureBox1.Region = new Region(path);
            }


            // userControl11.BringToFront();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnminbers_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl12.Show();
            userControl21.Hide();
            userControl12.BringToFront();
            btnminbers.BackColor = Color.Gray;


            button1.BackColor = Color.FromArgb(0, 117, 214);
            btncoach.BackColor = Color.FromArgb(0, 117, 214);
            payment.BackColor = Color.FromArgb(0, 117, 214);
        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void btncoach_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl12.Hide();
            userControl21.Show();
            userControl21.BringToFront();

            btncoach.BackColor = Color.Gray;


            button1.BackColor = Color.FromArgb(0, 117, 214);
            btnminbers.BackColor = Color.FromArgb(0, 117, 214);
            payment.BackColor = Color.FromArgb(0, 117, 214);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Show();
            userControl12.Hide();
            userControl21.Hide();
            userControl31.BringToFront();
            button1.BackColor = Color.Gray;

            // Change the background color of other buttons to 0, 117, 214
            btnminbers.BackColor = Color.FromArgb(0, 117, 214);
            btncoach.BackColor = Color.FromArgb(0, 117, 214);
            payment.BackColor = Color.FromArgb(0, 117, 214);
          //  btnApply.BackColor = Color.FromArgb(0, 117, 214);
        }

        private void userControl12_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmLoging frmLoging = new FrmLoging();

            // Display MainForm
            frmLoging.Show();

            // Hide the current LoginForm if needed
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frmcreatuser newuserform = new Frmcreatuser();
            newuserform.Show();
        }

        private void lbluser_Click(object sender, EventArgs e)
        {
            Frmcreatuser newuserform = new Frmcreatuser();
            newuserform.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Frmpayment nwobject = new Frmpayment();
            nwobject.Show();

            payment.BackColor = Color.Gray;

            // Change the background color of other buttons to 0, 117, 214
            btnminbers.BackColor = Color.FromArgb(0, 117, 214);
            btncoach.BackColor = Color.FromArgb(0, 117, 214);
            button1.BackColor = Color.FromArgb(0, 117, 214);


        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }
    }
}