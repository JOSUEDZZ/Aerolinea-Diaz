using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data.OleDb;
using Microsoft.SqlServer.Server;
using System.Net.Sockets;

namespace CapaDatos
{
    public class CD_Cliente
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxAccess"].ToString();


        //CREAR NUEVO CLIENTE
        public void CrearCliente(CE_Cliente cl)
        {
            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();

                string CdAccess = "INSERT INTO Cliente (IdCliente, Nombre, Edad, Correo, Contraseña, Celular) " +
                                  "VALUES (?, ?, ?, ?, ?,?)";

                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {
                    Cmd.Parameters.AddWithValue("", cl.idCliente);
                    Cmd.Parameters.AddWithValue("", cl.Nombre);
                    Cmd.Parameters.AddWithValue("", cl.Edad);
                    Cmd.Parameters.AddWithValue("", cl.Correo);
                    Cmd.Parameters.AddWithValue("", cl.Contraseña);
                    Cmd.Parameters.AddWithValue("", cl.Celular);

                    Cmd.ExecuteNonQuery();
                }

                Cnx.Close();
            }
        }

        //METODO PARA INGRESAR COMO CLIENTE A RESERVAR
        public bool Logear(CE_Cliente cliente)
        {
            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = Cnx;
                command.CommandText = "SELECT COUNT(*) FROM Cliente C WHERE C.Correo = ? AND C.Contraseña = ?";
                command.Parameters.AddWithValue("", cliente.Correo);
                command.Parameters.AddWithValue("", cliente.Contraseña);
                int count = (int)command.ExecuteScalar();
                Cnx.Close();

                return count > 0;
            }
        }


        //METODO PARA SABER QUE CLIENTE FUE EL QUE INGRESO
        public List<CE_Cliente> ClienteIngresado(CE_Cliente cliente)
        {
            List<CE_Cliente> Mostrar = new List<CE_Cliente>();
            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = Cnx;
                command.CommandText = "SELECT C.IdCliente, C.Nombre FROM Cliente C WHERE C.Correo ='" + cliente.Correo + "' AND C.Contraseña = '" + cliente.Contraseña + "'";
                OleDbDataReader leer;
                leer = command.ExecuteReader();
                if (leer.Read())
                {
                    CE_Cliente cl = new CE_Cliente();
                    cl.idCliente = int.Parse(leer["IdCliente"].ToString());
                    cl.Nombre = leer["Nombre"].ToString();

                    Mostrar.Add(cl);
                }

                Cnx.Close();
            }
            return Mostrar;
        }


        //METODO PARA SABER EL ID DEL NUEVO CLIENTE
        public List<CE_Cliente> IDClienteTHIS()
        {
            List<CE_Cliente> mostrar = new List<CE_Cliente>();

            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();

                string CdAccess = "SELECT MAX(IdCliente) + 1 as idClientethis FROM Cliente";

                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {
                    OleDbDataReader leer;
                    leer = Cmd.ExecuteReader();
                    if (leer.Read())
                    {
                        CE_Cliente cl = new CE_Cliente();

                        cl.idCliente = int.Parse(leer["idClientethis"].ToString());
                        mostrar.Add(cl);
                    }
                }
                Cnx.Close();
            }
            return mostrar;
        }


    }
}
