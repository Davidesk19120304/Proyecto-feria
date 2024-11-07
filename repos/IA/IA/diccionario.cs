using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

[Serializable]
public class RespuestasDiccionario
{
    [XmlArray("Respuestas")]
    [XmlArrayItem("Respuesta")]
    public List<RespuestaItem> Respuestas { get; set; }


    public RespuestasDiccionario()
    {
        Respuestas = new List<RespuestaItem>();

    }

    [Serializable]
    public class RespuestaItem
    {
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

    }
}




