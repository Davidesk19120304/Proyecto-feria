using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EquiposTeams : UserControl
    {
        public string TeamName
        {
            get { return label1.Text; }
            set { label1.Text = value; }


        }
        public Color NameForeColor

        {
            get { return label1.ForeColor; }
            set { label1.ForeColor = value; }


        }
        public Image TeamImage


        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }


        }
        public EquiposTeams()
        {
            InitializeComponent();
        }

        private void EquiposTeams_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            piedra piedra


              = new piedra();

            // Mostrar Formulario 2 como modal
            piedra.Show(this);
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            piedra piedra


             = new piedra();

            // Mostrar Formulario 2 como modal
            piedra.Show(this);
            this.Hide();
        }
    }
}
