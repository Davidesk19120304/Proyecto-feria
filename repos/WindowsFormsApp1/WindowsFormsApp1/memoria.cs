using System;
using System.Collections;
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
    public partial class memoria : Form
    {
        int tamaniocolumnafilas = 4;
        int movimiento = 0;
        int cantidadcartasvolteada = 0;
        List<string> cartasnumeradas;
        List<string> cartasrevueltas;
        ArrayList cartasseleccionada;
        PictureBox cartatemporal;
        PictureBox cartatemporal2;
        int cartaactual = 0;
        public memoria()
        {
            InitializeComponent();
            iniciarjuego();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);





        public void iniciarjuego()
        {
            timer1.Enabled = false;
            timer1.Stop();
            label2.Text = "0";
            cantidadcartasvolteada = 0;
            movimiento = 0;
            panel1.Controls.Clear();
            cartasnumeradas = new List<string>();
            cartasrevueltas = new List<string>();
            cartasseleccionada = new ArrayList();
            for (int i = 0; i < 8; i++)
            {

                cartasnumeradas.Add(i.ToString());
                cartasnumeradas.Add(i.ToString());
            }
            var numeroaleatorio = new Random();
            var resultado = cartasnumeradas.OrderBy(item => numeroaleatorio.Next());
            foreach (string valorcarta in resultado)
            {
                cartasrevueltas.Add(valorcarta);

            }

            var tablapanel1 = new TableLayoutPanel();
            tablapanel1.RowCount = tamaniocolumnafilas;
            tablapanel1.ColumnCount = tamaniocolumnafilas;

            for (int i=0;i<tamaniocolumnafilas;i++)
            {
                var porcentaje = 150f / (float)tamaniocolumnafilas - 10;
                tablapanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,porcentaje));
                tablapanel1.RowStyles.Add(new RowStyle(SizeType.Percent, porcentaje));
            }
            int contadorfichas = 1;
            for(var i =0;i<tamaniocolumnafilas;i++)
            {
                for(var j=0;j<tamaniocolumnafilas;j++)
                {
                    var cartasjuego = new PictureBox();
                    cartasjuego.Name = string.Format("{0}", contadorfichas);
                    cartasjuego.Dock = DockStyle.Fill;
                    cartasjuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    cartasjuego.Image = Properties.Resources.girafa;
                    cartasjuego.Cursor = Cursors.Hand;
                    cartasjuego.Click += btnCarta_Click;
                    tablapanel1.Controls.Add(cartasjuego, j, i);
                    contadorfichas++;
                }
            }
            tablapanel1.Dock = DockStyle.Fill;
            panel1.Controls.Add(tablapanel1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void memoria_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            iniciarjuego();
        }
        private void btnCarta_Click(object sender, EventArgs e)
        {
            if (cartasseleccionada.Count < 2)
            {
                movimiento++;
                label2.Text = Convert.ToString(movimiento);
                var cartasseleccionadausuario = (PictureBox)sender;

                cartaactual = Convert.ToInt32(cartasrevueltas[Convert.ToInt32(cartasseleccionadausuario.Name) - 1]);
                cartasseleccionadausuario.Image = recuperarimagen(cartaactual);
                cartasseleccionada.Add(cartasseleccionadausuario);
                if (cartasseleccionada.Count==2)
                {
                    cartatemporal = (PictureBox)cartasseleccionada[0];
                    cartatemporal2= (PictureBox)cartasseleccionada[1];
                    int carta1=Convert.ToInt32 (cartasrevueltas[Convert.ToInt32(cartatemporal.Name)-1]);
                    int carta2 = Convert.ToInt32(cartasrevueltas[Convert.ToInt32(cartatemporal2.Name) - 1]);
                    if (carta1 != carta2)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        cantidadcartasvolteada++;
                        if(cantidadcartasvolteada>7)
                        {
    DialogResult result =  mensajebox.Show("El juego ha terminado");
                        }
                        cartatemporal.Enabled = false; cartatemporal2.Enabled = false;
                        cartasseleccionada.Clear();


                    }
                }
            }

        }
        public Bitmap recuperarimagen (int numeroimagen)
        {
            Bitmap TmpImg = new Bitmap(200, 100);
            switch (numeroimagen)
            {

                case 0: TmpImg = Properties.Resources.img11;
                        break;
                default:
                    TmpImg = (Bitmap)Properties.Resources.ResourceManager.GetObject("img"+numeroimagen);
                    break;

            }
            return TmpImg;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tiempovirarcarta = 1;
            if(tiempovirarcarta==1 ){
                cartatemporal.Image = Properties.Resources.girafa;
                cartatemporal2.Image = Properties.Resources.girafa;
                cartasseleccionada.Clear();
                tiempovirarcarta = 0;
                timer1.Stop();


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memoria_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
