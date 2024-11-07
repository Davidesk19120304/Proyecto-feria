using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using AxWMPLib;



namespace WindowsFormsApp1.Formularios
{
    public partial class Mùsica : Form
    {
        private string connectionString = "Server=localhost;Database=niños;Uid=root;pwd=;";

        public Mùsica()
        {
            InitializeComponent();
            LoadMusicList();
            axWindowsMediaPlayer1.uiMode = "full"; // Modo completo con controles
            axWindowsMediaPlayer1.stretchToFit = true; // Aj
        }
        private void LoadMusicList()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre_musica FROM musica";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        listBox1.Items.Clear(); // Limpiar lista antes de agregar nuevos ítems
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader["nombre_musica"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de música: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedMusic = listBox1.SelectedItem.ToString();
                PlayMedia(selectedMusic);
            }
        }
        private void PlayMedia(string mediaName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT contenido FROM musica WHERE nombre_musica = @nombre_musica";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre_musica", mediaName);
                        byte[] fileData = (byte[])command.ExecuteScalar();

                        if (fileData == null || fileData.Length == 0)
                        {
                            MessageBox.Show("No se encontró el archivo en la base de datos o está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Establecer la extensión correcta para el archivo
                        string tempFilePath = Path.Combine(Path.GetTempPath(), mediaName);
                        string tempFilePathWithExtension = Path.ChangeExtension(tempFilePath, ".mp4");

                        File.WriteAllBytes(tempFilePathWithExtension, fileData);

                        if (File.Exists(tempFilePathWithExtension))
                        {
                            axWindowsMediaPlayer1.URL = tempFilePathWithExtension;
                            axWindowsMediaPlayer1.Ctlcontrols.play();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el archivo temporal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
           
            catch (Exception ex)
            {
                MessageBox.Show("Error al reproducir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void MUSICA_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
           


            
        }

      

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedMusic = listBox1.SelectedItem.ToString();
                PlayMedia(selectedMusic);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un archivo de la lista primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
