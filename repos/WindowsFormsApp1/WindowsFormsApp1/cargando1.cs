using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class cargando1 : Form
    {
        public cargando1()
        {
            InitializeComponent();
        }
        public void algo()
        {
            Thread.Sleep(4000);

        }


        private async void cargando1_Load (object sender, EventArgs e)
        {
            Task oTask = new Task(algo);
            oTask.Start();
            await oTask;
            Form1 formulario1 = new Form1();

            formulario1.Show(this);
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
