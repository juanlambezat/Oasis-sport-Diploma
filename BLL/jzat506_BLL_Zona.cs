using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class jzat506_BLL_Zona
    {
        private readonly jzat506_DAL_Zona jzat506_dalZona = new jzat506_DAL_Zona();

        public List<jzat506_ZonaCobertura> jzat506_ListarZonas()
        {
            return jzat506_dalZona.jzat506_ListarZonas();
        }
    }
}
