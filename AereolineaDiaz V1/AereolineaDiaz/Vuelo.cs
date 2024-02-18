using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AereolineaDiaz
{
    public partial class Vuelo : Form
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxAccess"].ToString();

        CL_Vuelos Vuelos = new CL_Vuelos();
        string Origen;
        string Destino = "";

        string Salida = "";
        string Llegada;

        //DICCIONARIO-RELACION
        Dictionary<string, string> aeropuertos = new Dictionary<string, string>();

        int prueba = 0;
        public Vuelo(int prueba)
        {
            InitializeComponent();
            this.prueba = prueba;
        }

        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            if (cbOrigen.Text == "" && cbDestino.Text == "")
            {
                MessageBox.Show("Debes ingresar de donde a donde quieres viajar");
            }
            else
            {
                Origen = aeropuertos[cbOrigen.Text];
                Llegada = aeropuertos[cbDestino.Text];

                CE_Vuelos EntidadVuelos = null;

                EntidadVuelos = new CE_Vuelos

                {
                    idAereopuertoSalidaF = Origen,
                    idAereopuertoLlegadaF = Llegada


                };





                MostrarInfoVuelos VueloM = new MostrarInfoVuelos(Origen, Llegada, prueba);
                Reservación R2 = new Reservación(Origen, Destino, prueba);


                this.Hide();
                VueloM.ShowDialog();
            }
           
        }

        

       




        private void Vuelo_Load(object sender, EventArgs e)
        {
            lblPrueba.Text = prueba.ToString();
            try
            {



                //METODO PARA ARROJAR EL NOMBRE DEL AEREOPUERTO DE ORIGEN A DESTINO (POR ID)

                List<CE_Vuelos> ubiOrigenID = Vuelos.VuelosDisponiblesOrigen();
                List<CE_Vuelos> ubiDestinoID = Vuelos.VuelosDisponiblesDestino();


                // DESPLIEGA LA UBICACIÓN ORIGEN
                foreach (CE_Vuelos c in ubiOrigenID)
                {
                    string nombreAeropuerto = c.Nombre;
                    string idAeropuerto = c.idAereopuertoSalidaF;

                    //DICCIONARIO
                    aeropuertos[nombreAeropuerto] = idAeropuerto;

                    // Agregar el nombre al ComboBox
                    cbOrigen.Items.Add(nombreAeropuerto);
                }

                // DESPLIEGA LA UBICACIÓN DESTINO
                foreach (CE_Vuelos c2 in ubiDestinoID)
                {
                    string nombreAeropuerto = c2.Nombre; 
                    string idAeropuerto = c2.idAereopuertoLlegadaF;

                   //DICCIONARIO
                    aeropuertos[nombreAeropuerto] = idAeropuerto;

                    // Agregar el nombre al ComboBox
                    cbDestino.Items.Add(nombreAeropuerto);
                }

                cbOrigen.SelectedIndex = 0;
                cbDestino.SelectedIndex = 0;


            }
            catch (Exception ex)
            {

                MessageBox.Show(String.Format(ex.Message));

            }

        }

        private void lblVerDetalles_Click(object sender, EventArgs e)
        {
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal sesión = new Principal();
            this.Hide();
            sesión.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
