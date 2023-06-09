﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Ventas;
using Modelos.Interfaces.Ventas;
using Modelos.Factura;

namespace FerreteriaProyectoFinal.Factura
{
    public partial class FrmEditarFactura : Form
    {

        VentasBs ventas = new VentasBs();
        public FrmEditarFactura()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmFacturas facturas= new FrmFacturas();

            facturas.Show();

            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminarlo?", "Some Title", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ventas.EliminarFactura(Convert.ToInt32( txtIdProducto.Text),Convert.ToInt32(txtCantActual.Text));

                MessageBox.Show("Eliminado con exito");

                Clientes.FrmClientes clientes = new Clientes.FrmClientes();

                clientes.Show();

                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            FacturaModel modelo = new FacturaModel();

            modelo.Precio = Convert.ToInt32( txtPrecioUnit.Text);
            modelo.Cedula = txtCedula.Text;
            modelo.Codigo = Convert.ToInt32(txtIdProducto.Text);
            modelo.PrecioTotal = Convert.ToInt32(txtPrecioTot.Text)* Convert.ToInt32(txtCantidadNueva.Text) ;
            modelo.Estado = "pendiente";
            modelo.Cantidad = Convert.ToInt32(txtCantidadNueva.Text);

            int cantidadActualizada = 0;

            if(Convert.ToInt32(txtCantidadNueva.Text) >= Convert.ToInt32(txtCantActual.Text))
            {
                 cantidadActualizada = -Convert.ToInt32(txtCantidadNueva.Text) + Convert.ToInt32(txtCantActual.Text);
            }else if(Convert.ToInt32(txtCantidadNueva.Text) <= Convert.ToInt32(txtCantActual.Text))
            {
                cantidadActualizada = Convert.ToInt32(txtCantActual.Text) - Convert.ToInt32(txtCantidadNueva.Text);
            }

            bool actualizar = ventas.ActualizarFactura(modelo, Convert.ToInt32(txtIdProducto.Text), cantidadActualizada);

            if (actualizar)
            {
                MessageBox.Show("Editado con exito");

                FrmFacturas fact = new FrmFacturas();
                fact.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay suficiente stock");
            }

           
        }

        private void FrmEditarFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
