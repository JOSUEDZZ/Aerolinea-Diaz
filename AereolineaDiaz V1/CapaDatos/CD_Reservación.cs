using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reservación
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxAccess"].ToString();


        //METODO PARA LOS ASIENTOS NO DISPONIBLES EN EL AVIÓN
      

        public List<CE_Reservación> AsientosNoDisponiblesPrueba(CE_Reservación Re)
        {
            List<CE_Reservación> mostrar = new List<CE_Reservación>();

            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();
                string CdAccess = "SELECT R.numAsiento AS AsientoNoDisponible\r\nFROM Reservación R INNER JOIN Vuelos V ON R.idVueloF = V.IdVuelos \r\nWHERE R.idVueloF = ?";

                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {
                          Cmd.Parameters.AddWithValue("", Re.idVueloF);

                    using (OleDbDataReader reader = Cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CE_Reservación vuelo = new CE_Reservación();
                            vuelo.numAsiento = reader["AsientoNoDisponible"].ToString();
                            mostrar.Add(vuelo);
                        }
                    }
                }
                Cnx.Close();
            }
            return mostrar;
        }


        //METODO PARA SABER EL ID DE LA RESERVACIÓN
        public List<CE_Reservación> MostrarIDReservación(CE_Reservación Vu)
        {
            List<CE_Reservación> mostrar = new List<CE_Reservación>();

            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();
                string CdAccess = "SELECT MAX(R.IdReservación) + 1 AS IdReser\r\nFROM Reservación R";
                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {

                    using (OleDbDataReader reader = Cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CE_Reservación re = new CE_Reservación();
                            re.idReservación = int.Parse(reader["IdReser"].ToString());
                            mostrar.Add(re);
                        }
                    }
                }
                Cnx.Close();
            }

            return mostrar;
        }


        //INSERTAR LA RESERVACIÓN
        public void GenerarReservación(CE_Reservación Re)
        {
            using (OleDbConnection Cnx = new OleDbConnection(CdCnx))
            {
                Cnx.Open();

                string CdAccess = "INSERT INTO Reservación (IdReservación, idClienteF, idVueloF, FechaReservación, numAsiento) " +
                                  "VALUES (?, ?, ?, ?, ?)";

                using (OleDbCommand Cmd = new OleDbCommand(CdAccess, Cnx))
                {
                    Cmd.Parameters.AddWithValue("", Re.idReservación);
                    Cmd.Parameters.AddWithValue("", Re.idClienteF);
                    Cmd.Parameters.AddWithValue("", Re.idVueloF);
                    Cmd.Parameters.AddWithValue("", Re.FechaReservación);
                    Cmd.Parameters.AddWithValue("", Re.numAsiento);

                    Cmd.ExecuteNonQuery();
                }

                Cnx.Close();
            }
        }



       


    }
}
