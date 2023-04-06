using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FerreteriaProyectoFinal.Factura;
using Logica.Clientes;
using Modelos.Clientes;

namespace FerreteriaProyectoFinal.Clientes
{
    public partial class FrmClientes : Form
    {
        
        ClientesBs clientes = new ClientesBs();
        public FrmClientes()
        {
            InitializeComponent();
            dgvClientes.DataSource = clientes.ConsultaDT();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmVentanaPrincipal home = new FrmVentanaPrincipal();
            home.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistrarCliente regisrar = new FrmRegistrarCliente();
            regisrar.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            //con esto se obtiene el datble asociado al dgv
            DataTable inv = (DataTable)dgvClientes.DataSource;

            inv.DefaultView.RowFilter = String.Format("nombre LIKE '%{0}%'", txtBuscar.Text);
            txtBuscar.Text = "";

            dgvClientes.DataSource = inv;
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
            

            if (e.RowIndex >= 0 && e.RowIndex < dgvClientes.Rows.Count)
            {
               
                  
                // Obtener los valores de la fila seleccionada
                string cedula = dgvClientes.Rows[e.RowIndex].Cells["cedula"].Value.ToString();

                string nombre = dgvClientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string apellidos = dgvClientes.Rows[e.RowIndex].Cells["apellidos"].Value.ToString();
                string telefono = dgvClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                string correo = dgvClientes.Rows[e.RowIndex].Cells["correo"].Value.ToString();

               


                FrmEditarCliente editar = new FrmEditarCliente();
               
                editar.txtNombre.Text = nombre;
                editar.txtApellido.Text = apellidos;
                editar.txtTelefono.Text = telefono;
                editar.txtCedula.Text = cedula;
                editar.txtCorreo.Text = correo;
                editar.Show();
                this.Close();
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = clientes.ConsultaDT();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila seleccionada
            DataGridViewRow row = dgvClientes.Rows[e.RowIndex];

            // Convertir la fila en un DataRowView
            DataRowView rowView = row.DataBoundItem as DataRowView;

            // Obtener la fila subyacente
            DataRow rowCliente = rowView.Row;

            // Convertir la fila en un ClienteModel
            ClienteModel cliente = new ClienteModel
            {
                Nombre = rowCliente["nombre"].ToString(),
                Apellidos = rowCliente["apellidos"].ToString(),
                Cedula = rowCliente["cedula"].ToString(),
                Telefono = rowCliente["telefono"].ToString(),
                Correo = rowCliente["correo"].ToString()
            };

            // Abrir el formulario de asignar productos y pasar el cliente seleccionado
            FrmAsignarProd asignarProductosForm = new FrmAsignarProd(cliente);
            asignarProductosForm.Show();
            this.Close();

            asignarProductosForm.txtCedula.Text = rowCliente["cedula"].ToString();



        }
    }
}
