using CapaEntidad;
using CapaLogica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace AereolineaDiaz
{
    public partial class Reservación : Form
    {
        CL_Reservación ReservacionC = new CL_Reservación();

        int idClienteWho;
        int idVueloWho;
        int idReservaciónWho;

        string textoBoton = "";
        bool botonSelected;
        string Origen = "";
        string Destino = "";
        int idCliente = 0;
        public Reservación(int idClienteWho, int idVueloWho)
        {
            InitializeComponent();
            this.idClienteWho = idClienteWho;
            this.idVueloWho = idVueloWho;
        }

        public Reservación(string Origen, string Destino, int idCliente)
        {
            this.Origen  = Origen;
            this.Destino = Destino;
            this.idCliente = idCliente;
        }

        private void Reservación_Load(object sender, EventArgs e)
        {

            //PRUEBA PARA MOSTRAR LOS ID QUE LLEVAN
            lbliDCliente.Text = idClienteWho.ToString();
            lblIdVuelo.Text = idVueloWho.ToString();

            CE_Reservación EntidadReservación = null;
            CE_Reservación EntidadReservación2 = null;

            try
            {
                EntidadReservación = new CE_Reservación
                {
                    idVueloF = idVueloWho,
                    idClienteF = idClienteWho

                };


                //para saber el id de reservación en el que esta
                List<CE_Reservación> idReservaciónMostrar = ReservacionC.idReservación(EntidadReservación);

                foreach (CE_Reservación id in idReservaciónMostrar)
                {

                    lblidReservación.Text = id.idReservación.ToString();
                    idReservaciónWho =  id.idReservación;


                }

                EntidadReservación2 = new CE_Reservación
                {
                    idReservación = idReservaciónWho,
                    idVueloF = idVueloWho,
                    idClienteF = idClienteWho


                };

                //PARA SABER LOS ASIENTOS QUE NO ESTAN DISPONIBLES POR VUELO


                List<CE_Reservación> asientosNoDisponibles = ReservacionC.AsientosNoDisponiblesPrueba(EntidadReservación2);

                foreach (CE_Reservación noDisponible in asientosNoDisponibles)
                {
                    string numAsientoNoDisponible = noDisponible.numAsiento;

                    string nombreBoton = numAsientoNoDisponible;

                    // PARA BUSCAR EN EL FORMULARIO
                    Control[] controles = Controls.Find(nombreBoton, true);

                    // VERIFICA SI ENCONTRO Y DESHABILITA
                    if (controles.Length > 0 && controles[0] is Button boton)
                    {
                        boton.Enabled = false;
                        boton.BackColor = Color.Gray;
                    }
                }





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Vuelo V = new Vuelo(idClienteWho);
            this.Hide();
            V.ShowDialog();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                int idR = int.Parse(lblidReservación.Text);

                CE_Reservación EntidadReservación = null;

                EntidadReservación = new CE_Reservación
                {
                    idReservación = idReservaciónWho,
                    idClienteF = idClienteWho,
                    idVueloF = idVueloWho,
                    FechaReservación = DateTime.Today,
                    numAsiento = textoBoton
                };
                if (botonSelected == true)
                {
                    ReservacionC.Reservar(EntidadReservación);
                    MessageBox.Show("Haz hecho tu reservación");
                    Vuelo V2 = new Vuelo(idClienteWho);
                    this.Hide();
                    V2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un asiento");
                }
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error en la reservación");

            }
        }

        #region EVENTOS CLICK

        private void B1_Click(object sender, EventArgs e)
        {
            botonSelected = true;

            Button botonSeleccionado = (Button)sender;

            textoBoton = botonSeleccionado.Text;


        }

        private void C1_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void E1_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;

            textoBoton = botonSeleccionado.Text;
        }

        private void A2_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void C2_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void A3_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void B3_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void C3_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void A4_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void B4_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void C4_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void A5_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void B5_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void C5_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void D1_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void F1_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void D2_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void E2_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void F2_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void D3_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void E3_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void F3_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void D4_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void E4_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void F4_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void D5_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void E5_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }

        private void F5_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }
        #endregion

        private void lblidReservación_Click(object sender, EventArgs e)
        {

        }

        private void lbliDCliente_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal sesión = new Principal();
            this.Hide();
            sesión.ShowDialog();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void A1_Click(object sender, EventArgs e)
        {
            botonSelected = true;
            Button botonSeleccionado = (Button)sender;
            textoBoton = botonSeleccionado.Text;
        }
    }
}
