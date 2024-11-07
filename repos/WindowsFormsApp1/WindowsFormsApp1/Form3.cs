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
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 formulario4 = new Form4();

            // Mostrar Formulario 2 como modal
            formulario4.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formulario2 = new Form2();

            // Mostrar Formulario 2 como modal
            formulario2.Show(this);
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            // Mostrar Formulario 2 como modal
           cliente.Show(this);
            this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            prueba prueba = new prueba();

            // Mostrar Formulario 2 como modal
            prueba.Show(this);
            this.Hide();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cargando1 cargando1 = new cargando1();
                cargando1.Show(this);
this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
           form2.Show(this);
            this.Hide();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Cursor = Cursors.Hand;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
