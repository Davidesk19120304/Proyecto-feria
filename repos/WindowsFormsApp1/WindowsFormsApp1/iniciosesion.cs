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
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=niños;Uid=root;pwd=;");
        public Form1()
        {
       
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                
                conexion.Close();
            }

            catch
            {
                MessageBox.Show("Error");

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "USUARIO")
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

       
            if (string.IsNullOrWhiteSpace(textBox2.Text) || textBox2.Text == "CONTRASEÑA")
            {
                MessageBox.Show("Por favor, ingrese una contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=niños;Uid=root;pwd=;");
            MySqlCommand cm = new MySqlCommand("select usuario,contraseña from registro where usuario='" + textBox1.Text + "' and contraseña='" + textBox2.Text + "'", conexion);
            conexion.Open();
            MySqlDataReader dr = cm.ExecuteReader();
            
                if (dr.Read())
            {
                Form5 formulario5 = new Form5();

                // Mostrar Formulario 2 como modal
                formulario5.Show(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Verifica si tu contraseña o el usuario, son correctos");

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.LightGray;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA";
                textBox2.ForeColor = Color.DimGray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_3(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 formulario3 = new Form3();

            // Mostrar Formulario 2 como modal
            formulario3.Show(this);
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle myRectangle = button2.ClientRectangle;
            myRectangle.Inflate(0, 30);
            buttonPath.AddEllipse(myRectangle);
            button2.Region = new Region(buttonPath);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form5 formulario5 = new Form5();

            // Mostrar Formulario 2 como modal
            formulario5.Show(this);
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show(this);
            this.Hide();
        }
    }





}
