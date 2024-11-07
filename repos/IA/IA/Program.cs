using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Globalization;

namespace IA
{
    internal class Program
    {
        // Instancia de la clase RespuestasDiccionario
        static RespuestasDiccionario diccionario = new RespuestasDiccionario();

        static void Main()
        {
            // Cargar el diccionario desde XML al iniciar
            CargarDiccionarioDesdeXML();
            Console.WriteLine("Prof.Nataly: ¡Hola! Querido estudiante, Soy la profesora Nataly. ¿En qué puedo ayudarte?");
            Console.WriteLine("Prof.Nataly: Puedes preguntarme sobre diferentes temas o escribir /salir para finalizar.");

            while (true)
            {
                Console.Write("Usuario: ");
                string input = Console.ReadLine().ToLower();
                if (input == "/salir")
                {
                    GuardarDiccionarioEnXML();  // Guardar antes de salir
                    break;
                }

                string preguntaNormalizada = NormalizarPregunta(input);
                string respuesta;
                if (BuscarRespuestaEnDiccionario(preguntaNormalizada, out respuesta))
                {
                    Console.WriteLine("Prof.Nataly: " + respuesta);
                }
                else
                {
                    Console.WriteLine("Prof.Nataly: Lo siento, no sé cómo responder a eso. ¿Puedes proporcionar una respuesta?");
                    Console.Write("Usuario: ");
                    string nuevaRespuesta = Console.ReadLine();
                    AgregarRespuestaAlDiccionario(preguntaNormalizada, nuevaRespuesta);
                    Console.WriteLine("Prof.Nataly: Gracias por enseñarme algo nuevo.");
                }
            }
        }

        static void AgregarRespuestaAlDiccionario(string pregunta, string respuesta)
        {
            diccionario.Respuestas.Add(new RespuestasDiccionario.RespuestaItem { Pregunta = pregunta, Respuesta = respuesta });
            Console.WriteLine("Debug: Respuesta añadida al diccionario.");
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
            var regex = new Regex(@"(suma|resta|multiplicacion|division) de (\d+) y (\d+)", RegexOptions.IgnoreCase);
            var match = regex.Match(pregunta);
            if (match.Success)
            {
                string operacion = match.Groups[1].Value;
                int a = int.Parse(match.Groups[2].Value);
                int b = int.Parse(match.Groups[3].Value);

                int resultado = 0;
                switch (operacion.ToLower())
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
                        resultado = a / b;
                        break;
                }

                respuesta = preguntaDiccionario
                    .Replace("{a}", a.ToString())
                    .Replace("{b}", b.ToString())
                    .Replace("{a+b}", resultado.ToString());
                return true;
            }
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

            return stringBuilder.ToString();
        }

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
                        Console.WriteLine("Debug: Diccionario cargado desde XML.");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error al deserializar el diccionario: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Debug: No se encontró el archivo diccionario.xml, se creará uno nuevo.");
            }
        }

        // Método para guardar el diccionario en XML
        static void GuardarDiccionarioEnXML()
        {
            try
            {
                using (var writer = new StreamWriter("diccionario.xml"))
                {
                    var serializer = new XmlSerializer(typeof(RespuestasDiccionario));
                    serializer.Serialize(writer, diccionario);
                }
                Console.WriteLine("Diccionario guardado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el diccionario: " + ex.Message);
            }
        }
    }

    // Clase para el diccionario
    public class RespuestasDiccionario
    {
        public List<RespuestaItem> Respuestas { get; set; } = new List<RespuestaItem>();

        public class RespuestaItem
        {
            public string Pregunta { get; set; }
            public string Respuesta { get; set; }
        }
    }
}
