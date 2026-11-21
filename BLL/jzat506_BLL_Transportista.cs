using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class jzat506_BLL_Transportista
    {
        private readonly jzat506_DAL_Transportista jzat506_dalTransportista = new jzat506_DAL_Transportista();

        public List<jzat506_Transportista> jzat506_ListarTransportistas()
        {
            return jzat506_dalTransportista.jzat506_ListarTransportistas();
        }

        public List<jzat506_Transportista> jzat506_ListarLibres()
        {
            List<jzat506_Transportista> libres = new List<jzat506_Transportista>();

            foreach (jzat506_Transportista transportista in jzat506_dalTransportista.jzat506_ListarTransportistas())
            {
                if (transportista.jzat506_Libre())
                    libres.Add(transportista);
            }

            return libres;
        }
    }
}
