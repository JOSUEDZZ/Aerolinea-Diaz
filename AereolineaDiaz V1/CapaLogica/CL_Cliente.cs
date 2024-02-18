using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class CL_Cliente
    {
        private CD_Cliente Cliente = new CD_Cliente();
        
        public readonly StringBuilder Mensaje = new StringBuilder();

        public bool ValidarCliente(CE_Cliente cl)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(cl.Nombre))
                Mensaje.Append("El campo de Nombre no puede estar vacio");
            if (cl.Edad <= 18)
                Mensaje.Append(Environment.NewLine + "El campo Edad es obligatorio y debe ser mayor a 18");
            if (string.IsNullOrEmpty(cl.Correo))
                Mensaje.Append("El campo de Correo no puede estar vacio");
            if (string.IsNullOrEmpty(cl.Contraseña))
                Mensaje.Append("El campo de Correo no puede estar vacio");
            if (cl.Celular <= 0)
                Mensaje.Append(Environment.NewLine + "El campo numero es obligatorio");
            return Mensaje.Length == 0;
        }

      

        public bool LogearCliente(CE_Cliente Cl)
        {

            if (ValidarCliente(Cl))
            {
            }

            return Cliente.Logear(Cl);


        }

        public List<CE_Cliente> idClienteIngresado(CE_Cliente cl)
        {
           return Cliente.ClienteIngresado(cl);
        }

        public void NuevoCliente(CE_Cliente cl)
        {
            
            Cliente.CrearCliente(cl);
        }



        //METODO PARA EL ID
        public List<CE_Cliente> IDClienteThis()
        {
            return Cliente.IDClienteTHIS();
        }

    }
}
