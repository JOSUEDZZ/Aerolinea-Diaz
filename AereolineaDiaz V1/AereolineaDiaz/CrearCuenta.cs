using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AereolineaDiaz
{
    public partial class CrearCuenta : Form
    {
        public int idClient = 0; 
        CL_Cliente Client = new CL_Cliente();

    public CrearCuenta()
        {
            InitializeComponent();
          
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                CE_Cliente EntidadCliente = null;

                EntidadCliente = new CE_Cliente
                {
                    idCliente = int.Parse(lblidCliente.Text),
                    Nombre = txtNombre.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Correo = txtCorreo.Text,
                    Contraseña = txtContraseña.Text,
                    Celular = Convert.ToInt64(txtCelular.Text),

                };

                if (txtNombre.Text == "" || txtEdad.Text == "" || txtCorreo.Text == "" || txtContraseña.Text == "" || txtCelular.Text == "")
                {
                    MessageBox.Show("Debes ingresar todos los datos");
                }
                else
                {

                    Client.NuevoCliente(EntidadCliente);
                    MessageBox.Show("Creado");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Debes ingresar todos los datos");
            }
            
                
                
               
               




            
           
        }


        public void Limpiar()
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            txtCelular.Text = "";
            txtNombre.Focus();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal regreso = new Principal();
            this.Hide();
            regreso.ShowDialog();
        }

        private void CrearCuenta_Load(object sender, EventArgs e)
        {
            CE_Cliente EntidadCliente = null;
            try
            {
                EntidadCliente = new CE_Cliente
                {
                    idCliente = idClient,
              

                };


                List<CE_Cliente> idClienteMostrar = Client.IDClienteThis();

                foreach (CE_Cliente c in idClienteMostrar)
                {
                    idClient = c.idCliente;
                }

                lblidCliente.Text = idClient.ToString();



            }
            catch (Exception ex)
            {

                MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado"));

            }
            
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            

        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
           

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
