using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CL_Vuelos
    {

        private CD_Vuelos Vuelos = new CD_Vuelos();

        public readonly StringBuilder Mensaje = new StringBuilder();

        //public bool ValidarVuelos(CE_Vuelos Vu)
        //{
        //    Mensaje.Clear();
        //    if (string.IsNullOrEmpty(Vu.idAereopuertoLlegadaF))
        //        Mensaje.Append("El campo de correo no puede estar vacio");
        //    if (string.IsNullOrEmpty(Vu.idAereopuertoSalidaF))
        //        Mensaje.Append("El campo de contraseña no puede estar vacio");

        //    return Mensaje.Length == 0;
        //}

        //public void VuelosDisponibles(CE_Vuelos Cl, string Llegada, string Salida)
        //{
            
        //        Vuelos.VuelosDisponibles(Llegada, Salida);

        //}

        public DataTable MostrarVuelos(CE_Vuelos Vu)
        {
            return Vuelos.MostrarV(Vu);
        }

        //METODOS PARA SABER EL ID DE ORIGEN Y DESTINO
        public List<CE_Vuelos> VuelosDisponiblesOrigen()
        {
            return Vuelos.VuelosDisponiblesOrigen();
        }

        public List<CE_Vuelos> VuelosDisponiblesDestino()
        {
            return Vuelos.VuelosDisponiblesLlegada();
        }



    }
}
