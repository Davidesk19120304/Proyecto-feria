using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Globalization;
using System.Drawing;
using System.Runtime.InteropServices;
namespace WindowsFormsApp1
{
    public partial class ia : Form

    {

        static RespuestasDiccionario diccionario = new RespuestasDiccionario();
   
        public ia()
        {
            InitializeComponent();
            CargarDiccionarioDesdeXML();
            guna2TextBox1.Text += "Prof.Nataly: ¡Hola! Querido estudiante, soy la profesora Nataly. ¿En qué puedo ayudarte?\r\n";
            guna2TextBox1.Text += "Prof.Nataly: Puedes preguntarme sobre diferentes temas o escribir /salir para finalizar.\r\n";
            guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
            guna2TextBox1.ScrollToCaret();







        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);











        static void CargarDiccionarioDesdeXML()
        {
            if (File.Exists("diccionario.xml"))
            {
                try
                {
                    using (var reader = new StreamReader("diccionario.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(RespuestasDiccionario));
                        diccionario = (RespuestasDiccionario)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    MessageBox.Show("Error al deserializar el diccionario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static void AgregarRespuestaAlDiccionario(string pregunta, string respuesta)
        {
            diccionario.Respuestas.Add(new RespuestasDiccionario.RespuestaItem { Pregunta = pregunta, Respuesta = respuesta });
        }




        static bool BuscarRespuestaEnDiccionario(string pregunta, out string respuesta)
        {
            pregunta = NormalizarPregunta(pregunta);
            respuesta = null;
            foreach (var item in diccionario.Respuestas)
            {
                string preguntaDiccionario = NormalizarPregunta(item.Pregunta);
                if (item.Pregunta.Contains("{a}") && item.Pregunta.Contains("{b}"))
                {
                    if (TryMatchMatchQuestion(pregunta, preguntaDiccionario, out respuesta))
                    {
                        return true;
                    }
                }
                else if (pregunta == preguntaDiccionario)
                {
                    respuesta = item.Respuesta;
                    return true;
                }
            }
            return false;
        }






        static bool TryMatchMatchQuestion(string pregunta, string preguntaDiccionario, out string respuesta)
        {
            // Define a regex pattern for capturing the mathematical operation
            var regex = new Regex(@"(suma|resta|multiplicacion|division) de (\d+) y (\d+)", RegexOptions.IgnoreCase);
            var match = regex.Match(pregunta);

            // Check if the regex match was successful
            if (match.Success)
            {
                // Extract the captured groups: operation, first number (a), and second number (b)
                string operacion = match.Groups[1].Value.ToLower();  // Ensure lowercase for switch matching
                int a = int.Parse(match.Groups[2].Value);
                int b = int.Parse(match.Groups[3].Value);

                // Initialize the result variable
                double resultado = 0;

                // Perform the operation based on the type captured
                switch (operacion)
                {
                    case "suma":
                        resultado = a + b;
                        break;
                    case "resta":
                        resultado = a - b;
                        break;
                    case "multiplicacion":
                        resultado = a * b;
                        break;
                    case "division":
                        // Handle division and avoid division by zero
                        if (b == 0)
                        {
                            respuesta = "No se puede dividir entre cero.";
                            return false;
                        }
                        resultado = (double)a / b;
                        break;
                    default:
                        respuesta = "Operación desconocida.";
                        return false;
                }

                // Prepare the response by replacing placeholders with actual values
                respuesta = preguntaDiccionario
                    .Replace("{a}", a.ToString())
                    .Replace("{b}", b.ToString())
                    .Replace("{resultado}", resultado.ToString("G", CultureInfo.InvariantCulture)); // Use general formatting to handle decimals

                return true; // Return true indicating that the operation was successful
            }

            // If no match, return false and null response
            respuesta = null;
            return false;
        }







        static string NormalizarPregunta(string pregunta)
        {
            pregunta = Regex.Replace(pregunta, @"[^,\w\s]", "");
            pregunta = RemoveDiacritics(pregunta);
            pregunta = pregunta.ToLowerInvariant();
            return pregunta;
        }





        static string RemoveDiacritics(string text)
        {
            string normalizedText = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in normalizedText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }





        static void GuardarDiccionarioEnXML()
        {
            try
            {
                using (var writer = new StreamWriter("diccionario.xml"))
                {
                    var serializer = new XmlSerializer(typeof(RespuestasDiccionario));
                    serializer.Serialize(writer, diccionario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el diccionario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.ToLower();
            if (string.IsNullOrWhiteSpace(input))
                return;

            guna2TextBox1.Text += "Usuario: " + textBox1.Text + "\r\n"; // Agregar entrada de usuario
            guna2TextBox1.Clear();

            if (input == "/salir")
            {
                GuardarDiccionarioEnXML();  // Guardar antes de salir
                this.Close();
                return;
            }

            string preguntaNormalizada = NormalizarPregunta(input);
            if (BuscarRespuestaEnDiccionario(preguntaNormalizada, out string respuesta))
            {
                guna2TextBox1.Text += "Prof.Nataly: " + respuesta + "\r\n";
            }
            else
            {
                guna2TextBox1.Text += "Prof.Nataly: Lo siento, no sé cómo responder a eso. ¿Puedes proporcionar una respuesta?\r\n";


                string nuevaRespuesta = Microsoft.VisualBasic.Interaction.InputBox("Por favor, proporciona una respuesta para la pregunta:", "Respuesta no encontrada", "");

                if (!string.IsNullOrWhiteSpace(nuevaRespuesta))
                {
                    AgregarRespuestaAlDiccionario(preguntaNormalizada, nuevaRespuesta);
                    guna2TextBox1.Text += "Prof.Nataly: Gracias por enseñarme algo nuevo.\r\n";
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.ToLower();
            if (string.IsNullOrWhiteSpace(input))
                return;
            guna2TextBox1.Text = ""; // Borra el contenido anterior

            guna2TextBox1.Text += "Usuario: " + textBox1.Text + "\r\n";
           

            if (input == "/salir")
            {
                GuardarDiccionarioEnXML();  // Guardar antes de salir
                this.Close();
                return;


            }

            string preguntaNormalizada = NormalizarPregunta(input);
            if (BuscarRespuestaEnDiccionario(preguntaNormalizada, out string respuesta))
            {
                guna2TextBox1.Text += "Prof.Nataly: " + respuesta + "\r\n";
            }
            else
            {
                guna2TextBox1.Text += "Prof.Nataly: Lo siento, no sé cómo responder a eso. ¿Puedes proporcionar una respuesta?\r\n";

                string nuevaRespuesta = Microsoft.VisualBasic.Interaction.InputBox("Por favor, proporciona una respuesta para la pregunta:", "Respuesta no encontrada", "");

                if (!string.IsNullOrWhiteSpace(nuevaRespuesta))
                {
                    AgregarRespuestaAlDiccionario(preguntaNormalizada, nuevaRespuesta);
                    guna2TextBox1.Text += "Prof.Nataly: Gracias por enseñarme algo nuevo.\r\n";
                
            }
            }
            textBox1.Clear();

            // Desplaza al inicio para mostrar la última respuesta al usuario.
            guna2TextBox1.SelectionStart = 0;
            guna2TextBox1.ScrollToCaret(); // Asegúrate de que esto esté al final del método
        }

        private void ia_Load(object sender, EventArgs e)
        {
            


        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
           




        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ia_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }


    public class RespuestasDiccionario
    {
        public List<RespuestaItem> Respuestas { get; set; } = new List<RespuestaItem>();

        public class RespuestaItem
        {
            public string Pregunta { get; set; }
            public string Respuesta { get; set; }
        }
    }








