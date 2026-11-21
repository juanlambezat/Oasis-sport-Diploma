using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Serializar
    {
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public void jzat506_Serializar(List<jzat506_Cliente> clientes, string ruta)
        {
            string formato;

            if (Path.GetExtension(ruta).ToLower() == ".json")
            {
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                opciones.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                File.WriteAllText(ruta, JsonSerializer.Serialize(clientes, opciones));
                formato = "JSON";
            }
            else
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<jzat506_Cliente>));
                using (StreamWriter archivo = new StreamWriter(ruta))
                {
                    serializador.Serialize(archivo, clientes);
                }
                formato = "XML";
            }

            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Clientes",
                Descripcion = "Serializacion de " + clientes.Count + " clientes a " + formato,
                Fecha = System.DateTime.Now,
                Criticidad = 2
            });
        }
    }
}
