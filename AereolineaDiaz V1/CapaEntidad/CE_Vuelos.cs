using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Vuelos:CE_Aereopuertos
    {
        public int idVuelos { get; set; }
        public int Numero { get; set; }
        public string Aerolinea { get; set; }
        public string idAereopuertoSalidaF { get; set; }
        public string idAereopuertoLlegadaF { get; set; }
        public DateTime fechaSalida { get; set; }

        public DateTime fechaLlegada { get; set; }

        public double precio { get; set; }
    }
}
