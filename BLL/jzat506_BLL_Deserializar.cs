using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Deserializar
    {
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public List<jzat506_Cliente> jzat506_Deserializar(string ruta)
        {
            List<jzat506_Cliente>? clientes;
            string formato;

            if (Path.GetExtension(ruta).ToLower() == ".json")
            {
                clientes = JsonSerializer.Deserialize<List<jzat506_Cliente>>(File.ReadAllText(ruta));
                formato = "JSON";
            }
            else
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<jzat506_Cliente>));
                using (StreamReader archivo = new StreamReader(ruta))
                {
                    clientes = (List<jzat506_Cliente>?)serializador.Deserialize(archivo);
                }
                formato = "XML";
            }

            if (clientes == null)
                clientes = new List<jzat506_Cliente>();

            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Clientes",
                Descripcion = "Des-serializacion de " + clientes.Count + " clientes desde " + formato,
                Fecha = System.DateTime.Now,
                Criticidad = 2
            });

            return clientes;
        }
    }
}
