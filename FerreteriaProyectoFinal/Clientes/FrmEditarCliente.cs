using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos.Interfaces.Clientes;
using Modelos.Clientes;
using Logica.Clientes;

namespace FerreteriaProyectoFinal.Clientes
{
    public partial class FrmEditarCliente : Form
    {

        ClientesBs cliente = new ClientesBs();
        FrmClientes home = new FrmClientes();

        public FrmEditarCliente()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmClientes clientes = new FrmClientes();
            clientes.Show();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteModel modelo = new ClienteModel();
            modelo.Nombre = txtNombre.Text;
            modelo.Apellidos = txtApellido.Text;
            modelo.Telefono = txtTelefono.Text;
            modelo.Cedula = txtCedula.Text;
            modelo.Correo = txtCorreo.Text;


            cliente.ActualizarCliente(modelo, txtCedula.Text);
            MessageBox.Show("Cliente editado con exito");
            this.Close();
          
            home.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            cliente.EliminarCliente(cedula);
            MessageBox.Show("Cliente eliminado con exito");
            this.Close();
            home.Show();


        }
    }
}
