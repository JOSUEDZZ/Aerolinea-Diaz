using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Vuelos
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxAccess"].ToString();


        public DataTable MostrarV(CE_Vuelos Vu)
        {
            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();
                string CdAccess = "SELECT V.IdVuelos, V.Numero, V.Aereolinea, V.IdAereopuertoSalidaF, V.IdAereopuertoLlegadaF, V.fechaSalida, V.fechaLlegada, V.precio " +
                                  "FROM Vuelos V INNER JOIN Aereopuertos A2 ON V.IdAereopuertoSalidaF = A2.idAereopuerto " +
                                  "WHERE V.IdAereopuertoSalidaF = ? and V.idAereopuertoLlegadaF";

                using (OleDbCommand comandoMCL = new OleDbCommand(CdAccess, Cnx))
                {
                    comandoMCL.Parameters.AddWithValue("", Vu.idAereopuertoSalidaF);
                    comandoMCL.Parameters.AddWithValue("", Vu.idAereopuertoLlegadaF);

                    OleDbDataReader leerMCL = comandoMCL.ExecuteReader();
                    DataTable tablaMCL = new DataTable();
                    tablaMCL.Load(leerMCL);

                    Cnx.Close();
                    return tablaMCL;
                }
            }
        }

        //METODO PARA VER LOS VUELOS DISPONIBLES DE ORIGEN
        public List<CE_Vuelos> VuelosDisponiblesOrigen()
        {
            List<CE_Vuelos> mostrar = new List<CE_Vuelos>();
            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();

                string CdAccess = "SELECT DISTINCT A2.Ubicación as Nombre, V.IdAereopuertoSalidaF AS NombreSalida\r\nFROM Vuelos V INNER JOIN Aereopuertos A2 ON V.IdAereopuertoSalidaF  = A2.idAereopuerto";

                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {
                    OleDbDataReader leer;
                    leer = Cmd.ExecuteReader();
                    while (leer.Read())
                    {
                        CE_Vuelos vu = new CE_Vuelos();
                        vu.Nombre = leer["Nombre"].ToString();
                        vu.idAereopuertoSalidaF = leer["NombreSalida"].ToString();
                        mostrar.Add(vu);
                    }
                }
                Cnx.Close();
            }
            return mostrar;
        }

        //METODO PARA VER LOS VUELOS DISPONIBLES DE LLEGADA
        public List<CE_Vuelos> VuelosDisponiblesLlegada()
        {
            List<CE_Vuelos> mostrar = new List<CE_Vuelos>();

            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();

                string CdAccess = "SELECT DISTINCT A2.Ubicación as Nombre, V.idAereopuertoLlegadaF AS NombreLlegada\r\nFROM Vuelos V INNER JOIN Aereopuertos A2 ON V.idAereopuertoLlegadaF = A2.idAereopuerto";

                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {
                    OleDbDataReader leer;
                    leer = Cmd.ExecuteReader();
                    while (leer.Read())
                    {
                        CE_Vuelos vu = new CE_Vuelos();
                        vu.Nombre = leer["Nombre"].ToString();
                        vu.idAereopuertoLlegadaF = leer["NombreLlegada"].ToString();
                        mostrar.Add(vu);

                    }
                }
                Cnx.Close();
            }
            return mostrar;
        }




    }
}
