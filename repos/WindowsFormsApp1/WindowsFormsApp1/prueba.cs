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

namespace WindowsFormsApp1
{
    public partial class prueba : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string filename = string.Empty;
        string fullFileName = string.Empty;

        // Use a connection string with connection pooling and error handling
        MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=niños;Uid=root;pwd=;");

        public prueba()
        {
            InitializeComponent();
        }

        private void prueba_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the full file name from the TextBox control
                string fullFileName = textBox1.Text;

                // Check if file exists
                if (!File.Exists(fullFileName))
                {
                    MessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Split the file name to extract the filename
                string[] fileNameParts = fullFileName.Split('\\');
                string nombre_musica = fileNameParts.Last();

                // Connection string to your SQL Server database
                string connectionString = "Server=localhost;Database=niños;Uid=root;pwd=;";

                // Create a MySqlConnection object
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Create a MySqlCommand object
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO musica (nombre_musica, contenido) VALUES (@nombre_musica, @contenido)";

                        // Add parameters for file name and content
                        command.Parameters.AddWithValue("@nombre_musica", nombre_musica);

                        // Read the file content as a byte array
                        byte[] contenido = File.ReadAllBytes(fullFileName);
                        command.Parameters.AddWithValue("@contenido", contenido);

                        // Open the connection and execute the command
                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }
    }
}

