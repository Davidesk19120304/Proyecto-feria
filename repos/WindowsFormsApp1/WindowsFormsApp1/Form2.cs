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
    public partial class Form2 : Form
      

    {
        MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=niños;Uid=root;pwd=;");
        string g;
        public Form2()
        {
            InitializeComponent();
            CustomizeComponents();

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
       
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {


                conexion.Open();
              
               conexion.Close();
            }

            catch
            {
                DialogResult= MessageBox.Show("Error");

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El campo de usuario no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (string.IsNullOrWhiteSpace(rjDatePicker1.Text))
            {
                MessageBox.Show("Por favor, seleccione una fecha.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

          
            if (!rjRadio1.Checked && !rjRadio2.Checked)
            {
                MessageBox.Show("Por favor, seleccione un género.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }







            if (rjRadio1.Checked == true) {

                g = "MASCULINO";

            }
            else
                g = "FEMENINO";

            conexion.Open();
            string Query = "INSERT INTO registro(fecha,usuario,contraseña,sexo) values ('"+this.rjDatePicker1.Text + "','" + textBox1.Text+ "','"+textBox2.Text+ "','"+g+ "' );";
            MySqlCommand comando = new MySqlCommand (Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Informacion insertada");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CustomizeComponents()
        {
            // Customize txtUsername
            textBox1.AutoSize = false;
            textBox1.Size = new Size(350, 30);
            textBox2.AutoSize = false;
           textBox2.Size = new Size(350, 30);
            textBox2.UseSystemPasswordChar = true;


        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {

            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle myRectangle = button2.ClientRectangle;
            myRectangle.Inflate(0, 30);
            buttonPath.AddEllipse(myRectangle);
            button2.Region = new Region(buttonPath);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rjDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rjDatePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form5 formulario5 = new Form5();

            // Mostrar Formulario 2 como modal
            formulario5.Show(this);
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show(this);
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show(this);
            this.Hide();
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            guna2Button1.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Cursor = Cursors.Hand;
        }
    }

}