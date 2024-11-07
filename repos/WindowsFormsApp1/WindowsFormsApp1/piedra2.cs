using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class piedra2 : Form
    {
        public piedra2()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void piedra2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            if (PictureBox2.BackColor == Color.White)
            {
                PictureBox2.Image = PictureBox1.Image;
                PictureBox2.BackColor = Color.Gray;
                PictureBox1.Image = imageList1.Images[0];
                PictureBox1.BackColor = Color.White;
            }

            if (PictureBox4.BackColor == Color.White)
            {
                PictureBox4.Image = PictureBox1.Image;
                PictureBox4.BackColor = Color.Gray;
                PictureBox1.Image = imageList1.Images[0];
                PictureBox1.BackColor = Color.White;
            }
        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (PictureBox2.BackColor == Color.White)
            {
                PictureBox2.Image = PictureBox1.Image;
                PictureBox2.BackColor = Color.Gray;
                PictureBox1.Image = imageList1.Images[0];
                PictureBox1.BackColor = Color.White;
            }

            if (PictureBox4.BackColor == Color.White)
            {
                PictureBox4.Image = PictureBox1.Image;
                PictureBox4.BackColor = Color.Gray;
                PictureBox1.Image = imageList1.Images[0];
                PictureBox1.BackColor = Color.White;
            }

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (PictureBox2.BackColor == Color.White)
            {
                PictureBox2.Image = PictureBox3.Image;
                PictureBox2.BackColor = Color.Gray;
                PictureBox3.Image = imageList1.Images[0];
                PictureBox3.BackColor = Color.White;
            }

            if (PictureBox6.BackColor == Color.White)
            {
                PictureBox6.Image = PictureBox3.Image;
                PictureBox6.BackColor = Color.Gray;
                PictureBox3.Image = imageList1.Images[0];
                PictureBox3.BackColor = Color.White;
            }

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            if (PictureBox1.BackColor == Color.White)
            {
                PictureBox1.Image = PictureBox4.Image;
                PictureBox1.BackColor = Color.Gray;
                PictureBox4.Image = imageList1.Images[0];
                PictureBox4.BackColor = Color.White;
            }

            if (PictureBox5.BackColor == Color.White)
            {
                PictureBox5.Image = PictureBox4.Image;
                PictureBox5.BackColor = Color.Gray;
                PictureBox4.Image = imageList1.Images[0];
                PictureBox4.BackColor = Color.White;
            }

            if (PictureBox7.BackColor == Color.White)
            {
                PictureBox7.Image = PictureBox4.Image;
                PictureBox7.BackColor = Color.Gray;
                PictureBox4.Image = imageList1.Images[0];
                PictureBox4.BackColor = Color.White;
            }
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {
            if (PictureBox6.BackColor == Color.White)
            {
                PictureBox6.Image = PictureBox9.Image;
                PictureBox6.BackColor = Color.Gray;
                PictureBox9.Image = imageList1.Images[0];
                PictureBox9.BackColor = Color.White;
            }

            if (PictureBox8.BackColor == Color.White)
            {
                PictureBox8.Image = PictureBox9.Image;
                PictureBox8.BackColor = Color.Gray;
                PictureBox9.Image = imageList1.Images[0];
                PictureBox9.BackColor = Color.White;
            }
        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            if (PictureBox7.BackColor == Color.White)
            {
                PictureBox7.Image = PictureBox8.Image;
                PictureBox7.BackColor = Color.Gray;
                PictureBox8.Image = imageList1.Images[0];
                PictureBox8.BackColor = Color.White;
            }

            if (PictureBox5.BackColor == Color.White)
            {
                PictureBox5.Image = PictureBox8.Image;
                PictureBox5.BackColor = Color.Gray;
                PictureBox8.Image = imageList1.Images[0];
                PictureBox8.BackColor = Color.White;
            }

            if (PictureBox9.BackColor == Color.White)
            {
                PictureBox9.Image = PictureBox8.Image;
                PictureBox9.BackColor = Color.Gray;
                PictureBox8.Image = imageList1.Images[0];
                PictureBox8.BackColor = Color.White;
            }
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            if (PictureBox4.BackColor == Color.White)
            {
                PictureBox4.Image = PictureBox7.Image;
                PictureBox4.BackColor = Color.Gray;
                PictureBox7.Image = imageList1.Images[0];
                PictureBox7.BackColor = Color.White;
            }

            if (PictureBox8.BackColor == Color.White)
            {
                PictureBox8.Image = PictureBox7.Image;
                PictureBox8.BackColor = Color.Gray;
                PictureBox7.Image = imageList1.Images[0];
                PictureBox7.BackColor = Color.White;
            }
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            if (PictureBox2.BackColor == Color.White)
            {
                PictureBox2.Image = PictureBox5.Image;
                PictureBox2.BackColor = Color.Gray;
                PictureBox5.Image = imageList1.Images[0];
                PictureBox5.BackColor = Color.White;
            }

            if (PictureBox4.BackColor == Color.White)
            {
                PictureBox4.Image = PictureBox5.Image;
                PictureBox4.BackColor = Color.Gray;
                PictureBox5.Image = imageList1.Images[0];
                PictureBox5.BackColor = Color.White;
            }

            if (PictureBox6.BackColor == Color.White)
            {
                PictureBox6.Image = PictureBox5.Image;
                PictureBox6.BackColor = Color.Gray;
                PictureBox5.Image = imageList1.Images[0];
                PictureBox5.BackColor = Color.White;
            }

            if (PictureBox8.BackColor == Color.White)
            {
                PictureBox8.Image = PictureBox5.Image;
                PictureBox8.BackColor = Color.Gray;
                PictureBox5.Image = imageList1.Images[0];
                PictureBox5.BackColor = Color.White;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PictureBox1.Image = imageList1.Images[6];
            PictureBox2.Image = imageList1.Images[2];
            PictureBox3.Image = imageList1.Images[4];
            PictureBox4.Image = imageList1.Images[7];
            PictureBox5.Image = imageList1.Images[1];
            PictureBox6.Image = imageList1.Images[7];
            PictureBox7.Image = imageList1.Images[5];
            PictureBox8.Image = imageList1.Images[3];
            PictureBox9.Image = imageList1.Images[0];

            PictureBox1.BackColor = Color.Gray;
            PictureBox2.BackColor = Color.Gray;
            PictureBox3.BackColor = Color.Gray;
            PictureBox4.BackColor = Color.Gray;
            PictureBox5.BackColor = Color.Gray;
            PictureBox6.BackColor = Color.Gray;
            PictureBox7.BackColor = Color.Gray;
            PictureBox8.BackColor = Color.Gray;
            PictureBox9.BackColor = Color.White;




        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (PictureBox1.BackColor == Color.White)
            {
                PictureBox1.Image = PictureBox2.Image;
                PictureBox1.BackColor = Color.Gray;
                PictureBox2.Image = imageList1.Images[0];
                PictureBox2.BackColor = Color.White;
            }

            if (PictureBox3.BackColor == Color.White)
            {
                PictureBox3.Image = PictureBox2.Image;
                PictureBox3.BackColor = Color.Gray;
                PictureBox2.Image = imageList1.Images[0];
                PictureBox2.BackColor = Color.White;
            }

            if (PictureBox5.BackColor == Color.White)
            {
                PictureBox5.Image = PictureBox2.Image;
                PictureBox5.BackColor = Color.Gray;
                PictureBox2.Image = imageList1.Images[0];
                PictureBox2.BackColor = Color.White;
            }

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            if (PictureBox3.BackColor == Color.White)
            {
                PictureBox3.Image = PictureBox6.Image;
                PictureBox3.BackColor = Color.Gray;
                PictureBox6.Image = imageList1.Images[0];
                PictureBox6.BackColor = Color.White;
            }

            if (PictureBox5.BackColor == Color.White)
            {
                PictureBox5.Image = PictureBox6.Image;
                PictureBox5.BackColor = Color.Gray;
                PictureBox6.Image = imageList1.Images[0];
                PictureBox6.BackColor = Color.White;
            }

            if (PictureBox9.BackColor == Color.White)
            {
                PictureBox9.Image = PictureBox6.Image;
                PictureBox9.BackColor = Color.Gray;
                PictureBox6.Image = imageList1.Images[0];
                PictureBox6.BackColor = Color.White;
            }
        }

        private void piedra2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void piedra2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
    }
}
