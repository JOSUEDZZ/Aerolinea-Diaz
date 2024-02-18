using CapaEntidad;
using CapaLogica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AereolineaDiaz
{
    public partial class MostrarInfoVuelos : Form
    {
        CL_Vuelos vuelos = new CL_Vuelos();

        string Origen;
        string Destino;
        int idCliente = 0;

        public string idVueloSeleccionado = "";
        public MostrarInfoVuelos(string origen, string destino, int idCliente)
        {
            InitializeComponent();
            Origen = origen;
            Destino = destino;
            this.idCliente = idCliente;



        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(idVueloSeleccionado))
            {
                //MessageBox.Show($"El nombre seleccionado es: {idVueloSeleccionado}");
                int va = int.Parse(idVueloSeleccionado);
                Reservación R = new Reservación(idCliente, va);
                this.Hide();
                R.ShowDialog();
            }
            else
            {
                // Mostrar un mensaje si no se ha seleccionado ninguna fila
                MessageBox.Show("Debes seleccionar un vuelo");
            }

        }


        private void MostrarInfoVuelos_Load(object sender, EventArgs e)
        {
            lblPrueba.Text = idCliente.ToString();

            CE_Vuelos EntidadVuelos = null;
            try
            {
                EntidadVuelos = new CE_Vuelos
                {
                    idAereopuertoSalidaF = Origen,
                    idAereopuertoLlegadaF = Destino
                   

                };

                //List<CE_Vuelos> volar = vuelos.MostrarVuelos(EntidadVuelos);
                //dgvInfoVuelos.DataSource = volar;
                dgvDetalles.DataSource = vuelos.MostrarVuelos(EntidadVuelos);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvInfoVuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;

                //CELDA SELECCIONADA(VALOR)
                object valorCelda = dataGridView.Rows[e.RowIndex].Cells["IdVuelos"].Value;
                if (valorCelda != null && !string.IsNullOrEmpty(valorCelda.ToString()))
                {
                    idVueloSeleccionado = valorCelda.ToString();
                }
                else
                {
                    idVueloSeleccionado = null; // Asignar un valor nulo si la celda está vacía o es nula
                }
            }
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal sesión = new Principal();
            this.Hide();
            sesión.ShowDialog();
        }

        private void regresarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vuelo v = new Vuelo(idCliente);
            this.Hide();
            v.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
