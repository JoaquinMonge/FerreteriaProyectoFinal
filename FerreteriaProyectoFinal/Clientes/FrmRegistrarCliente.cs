using Modelos.Clientes;
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
using Logica.Clientes;

namespace FerreteriaProyectoFinal.Clientes
{
    public partial class FrmRegistrarCliente : Form
    {
        public FrmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {


        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            ClienteModel model = new ClienteModel();
            model.Nombre = txtNombre.Text;
            model.Apellidos = txtApellido.Text;
            model.Telefono = txtTelefono.Text;
            model.Correo = txtCorreo.Text;
            model.Cedula = txtCedula.Text;

            IClientes clientes = new ClientesBs();
            bool registrado = clientes.CrearCliente(model);

            if (registrado)
            {
                MessageBox.Show("El cliente fue registrado con exito");
                FrmClientes home = new FrmClientes();
                home.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("El cliente ya existe, intentelo de nuevo.");

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmClientes clientes = new FrmClientes();
            clientes.Show();
            this.Close();
        }
    }
}
