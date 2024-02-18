using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;
using System.Configuration;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace AereolineaDiaz
{
    public partial class Principal : Form
    {
        CL_Cliente Client = new CL_Cliente();
        public int idClient = 0;
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        
        }

        
        private void btnIniciar_Click(object sender, EventArgs e)
        {

            try
            {


                //METODO PARA LOGEAR AL CLIENTE
                CE_Cliente EntidadCliente = null;

                EntidadCliente = new CE_Cliente
                {
                    idCliente = idClient,
                    Correo = txtCorreo.Text,
                    Contraseña = txtContraseña.Text

                };

                //PARA SABER EL IDE DEL CLIENTE INGRESADO

                List<CE_Cliente> idClienteMostrar = Client.idClienteIngresado(EntidadCliente);

                foreach (CE_Cliente c in idClienteMostrar)
                {
                    idClient = c.idCliente;
                    //PARA LOGEAR AL CLIENTE Y SABER SU ID
                    if (Client.LogearCliente(EntidadCliente))
                    {
                        MessageBox.Show("Bienvenido " + c.Nombre);
                        Vuelo VueloM = new Vuelo(idClient);
                        this.Hide();
                        VueloM.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Algo estas haciendo mal");
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado"));

            }



        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void lblInvitado_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCrearC_Click(object sender, EventArgs e)
        {
            CrearCuenta nuevoCliente = new CrearCuenta();
            this.Hide();
            nuevoCliente.ShowDialog();
        }
    }
}
