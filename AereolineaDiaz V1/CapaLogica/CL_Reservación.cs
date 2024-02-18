using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CL_Reservación
    {

        private CD_Reservación Reservación = new CD_Reservación();

        public readonly StringBuilder Mensaje = new StringBuilder();



      
        public List<CE_Reservación> idReservación(CE_Reservación Re)
        {
            return Reservación.MostrarIDReservación(Re);
        }

        public void Reservar(CE_Reservación Re)
        {
            Reservación.GenerarReservación(Re);
        }

        //MOSTRAR ASIENTOS NO DISPONIBLES
        public List<CE_Reservación> AsientosNoDisponiblesPrueba(CE_Reservación Re)
        {
           return Reservación.AsientosNoDisponiblesPrueba(Re);
        }

       
    }
}
