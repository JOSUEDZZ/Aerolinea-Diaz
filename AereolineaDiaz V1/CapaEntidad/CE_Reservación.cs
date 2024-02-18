using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Reservación
    {
        public int idReservación { get; set; }
        public int idClienteF { get; set; }
        public int idVueloF { get; set; }
        public DateTime FechaReservación { get; set; }
        public string numAsiento { get; set; }


    }
}
