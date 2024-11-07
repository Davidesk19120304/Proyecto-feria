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
using System.Net.Sockets;
using System.IO;
using Transitions;
using System.Runtime.InteropServices;



namespace WindowsFormsApp1
{

    public partial class Cliente : Form
    {
        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();
        static private string nick = "unknown";
        private delegate void DaddItem(String s);
        private void AddItem(String s)
        {
            listBox1.Items.Add(s);
        }

        void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    this.Invoke(new DaddItem(AddItem), streamr.ReadLine());
                }
                catch
                {
                    MessageBox.Show("No se ha podido conectar al servidor");
                    Application.Exit();
                }
            }
        }
        void Conectar()
        {
            try
            {
                client.Connect("127.0.0.1", 8000);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);

                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);
                    streamr = new StreamReader(stream);

                    streamw.WriteLine(nick);
                    streamw.Flush();

                    t.Start();
                }
                else
                {
                    MessageBox.Show("Servidor no Disponible");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servidor no Disponible");
                Application.Exit();
            }

        }





        public Cliente()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Cliente_Load(object sender, EventArgs e)
        {
            btnEnviar.Location = new Point(-553,242 );
            txtMensaje.Location = new Point(-553, 242);
            listBox1.Location = new Point(-553, 30);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            streamw.WriteLine(txtMensaje.Text);
            streamw.Flush();
            txtMensaje.Clear();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            nick = txtUsuario.Text;
            Conectar();

            Transition t = new Transition(new TransitionType_EaseInEaseOut(900));
            t.add(lbTitulo, "Left", 555);
            t.add(txtUsuario, "Left", 555);
            t.add(btnConectar, "Left", 555);
            t.add(listBox1, "Left", 26);
            t.add(txtMensaje, "Left", 26);
            t.add(btnEnviar, "Left", 485);
            t.run();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Cliente_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
