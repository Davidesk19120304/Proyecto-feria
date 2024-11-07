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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        public void algo()
        {
            Thread.Sleep(4000);

        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            Task oTask = new Task(algo);
           oTask.Start();
            await oTask;
            Form3 formulario3 = new Form3();

            formulario3.Show(this);
            this.Hide();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
