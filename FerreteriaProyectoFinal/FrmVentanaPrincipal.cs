using System;
using System.Windows.Forms;

namespace FerreteriaProyectoFinal
{
    public partial class FrmVentanaPrincipal : Form
    {
        
        public FrmVentanaPrincipal()
        {
            InitializeComponent();
            
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes.FrmClientes cliente=new Clientes.FrmClientes();
            cliente.Show();
            this.Close();


        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario.FrmInventario inventario = new Inventario.FrmInventario();
            inventario.Show();
            this.Close();
        }

        private void MnuSesion_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mensaje = "";
            Properties.Settings.Default.Save();
            txtUsuario.Text = "";
            this.Close();
            FrmLogin login = new FrmLogin();
            login.Show();

        }

        private void MnuMiCuenta_Click(object sender, EventArgs e)
        {
            Usuario.FrmAutenticarParaEditar editar = new Usuario.FrmAutenticarParaEditar();
            editar.txtUsuario.Text = txtUsuario.Text;
            string mensaje = Properties.Settings.Default.Mensaje;
            txtUsuario.Text = mensaje;
            editar.Show();
            this.Close();
        }

        private void FrmVentanaPrincipal_Load(object sender, EventArgs e)
        {
            string mensaje = Properties.Settings.Default.Mensaje;
            if (!string.IsNullOrEmpty(mensaje))
            {
                txtUsuario.Text = mensaje;
                Console.WriteLine("Valor guardado: " + mensaje);
            }



        }

        private void FrmVentanaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            string mensaje = txtUsuario.Text;
            Properties.Settings.Default.Mensaje = mensaje;
            Properties.Settings.Default.Save();
            Console.WriteLine("Guardando valor: " + mensaje);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Factura.FrmFacturas facturas = new Factura.FrmFacturas();
            facturas.Show();
            this.Close();
        }
    }
}
