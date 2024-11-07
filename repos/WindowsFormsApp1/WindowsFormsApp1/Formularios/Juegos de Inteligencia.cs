using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formularios
{
    public partial class Juegos : Form
    {
        public Juegos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void inicio_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void equiposTeams1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void equiposTeams2_Load(object sender, EventArgs e)
        {
            piedra piedra = new piedra();
            piedra.Show(this);

            
        }

        private void equiposTeams1_Load_1(object sender, EventArgs e)
        {

        }

        private void equiposTeams1_Click(object sender, EventArgs e)
        {
            piedra piedra
                = new piedra();

            // Mostrar Formulario 2 como modal
            piedra.Show(this);
            this.Hide();
        }

        private void equiposTeams1_Click_1(object sender, EventArgs e)
        {
            piedra piedra
                = new piedra();

            // Mostrar Formulario 2 como modal
            piedra.Show(this);
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            piedra piedra = new piedra();

            // Mostrar Formulario 2 como modal
            piedra.Show(this);
            
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Chip1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2WinProgressIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Chip1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            memoria memoria = new memoria();

            // Mostrar Formulario 2 como modal
            memoria.Show(this);
            this.Hide();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            piedra piedra= new piedra();

            // Mostrar Formulario 2 como modal
            piedra.Show(this);
            this.Hide();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            simondice simondice = new simondice();

            // Mostrar Formulario 2 como modal
            simondice.Show(this);
            this.Hide();
        }
    }
}
