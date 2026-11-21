using System;
using System.Collections.Generic;

namespace Entidades
{
    public class jzat506_AnalisisVentas
    {
        public DateTime jzat506_Desde { get; set; }
        public DateTime jzat506_Hasta { get; set; }
        public DateTime jzat506_DesdeAnterior { get; set; }
        public DateTime jzat506_HastaAnterior { get; set; }
        public List<jzat506_IndicadorAnalisis> jzat506_Indicadores { get; set; } = new List<jzat506_IndicadorAnalisis>();
        public List<string> jzat506_Conclusiones { get; set; } = new List<string>();
    }
}
