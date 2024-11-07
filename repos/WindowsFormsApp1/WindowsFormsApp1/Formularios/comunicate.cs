using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1.Formularios
    {
        public partial class comunicate : Form
        {
            public comunicate()
            {
                InitializeComponent();
            }

            private void guna2Button1_Click(object sender, EventArgs e)
            {
                EjecutarScriptPython();
            }

            private void EjecutarScriptPython()
            {
                try
                {
                    // Ruta al intérprete de Python
                    string pythonPath = @"C:\Users\HP\AppData\Local\Programs\Python\Python312\python.exe"; // Cambia esta ruta a la ubicación de tu Python

                    // Ruta al script de Python
                    string scriptPath = @"C:\Users\HP\Desktop\Proyecto_de_la_feria\lengua_señas.py"; // Cambia esta ruta a la ubicación de tu script

                    // Crear el proceso de ejecución
                    ProcessStartInfo start = new ProcessStartInfo
                    {
                        FileName = pythonPath,
                        Arguments = $"{scriptPath} argumento1", // Puedes pasar argumentos aquí
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    };

                    // Iniciar el proceso
                    using (Process process = Process.Start(start))
                    {
                        // Leer la salida estándar del proceso
                        using (System.IO.StreamReader reader = process.StandardOutput)
                        {
                            string result = reader.ReadToEnd();
                            MessageBox.Show(result);
                        }

                        // Leer los errores (si los hay)
                        using (System.IO.StreamReader errorReader = process.StandardError)
                        {
                            string error = errorReader.ReadToEnd();
                            if (!string.IsNullOrEmpty(error))
                            {
                                MessageBox.Show($"Error: {error}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }

            private void comunicate_Load(object sender, EventArgs e)
            {

            }
        }
    }