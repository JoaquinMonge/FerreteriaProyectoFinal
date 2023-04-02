namespace FerreteriaProyectoFinal
{
    partial class FrmVentanaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentanaPrincipal));
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.MnuMiCuenta = new System.Windows.Forms.ToolStripButton();
            this.MnuSesion = new System.Windows.Forms.ToolStripButton();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(143, 121);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(116, 162);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(344, 121);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(116, 162);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(536, 121);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(116, 162);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuMiCuenta,
            this.MnuSesion});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 25);
            this.menu.TabIndex = 3;
            // 
            // MnuMiCuenta
            // 
            this.MnuMiCuenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MnuMiCuenta.Image = ((System.Drawing.Image)(resources.GetObject("MnuMiCuenta.Image")));
            this.MnuMiCuenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuMiCuenta.Name = "MnuMiCuenta";
            this.MnuMiCuenta.Size = new System.Drawing.Size(64, 22);
            this.MnuMiCuenta.Text = "Mi cuenta";
            this.MnuMiCuenta.Click += new System.EventHandler(this.MnuMiCuenta_Click);
            // 
            // MnuSesion
            // 
            this.MnuSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MnuSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MnuSesion.Image = ((System.Drawing.Image)(resources.GetObject("MnuSesion.Image")));
            this.MnuSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuSesion.Name = "MnuSesion";
            this.MnuSesion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MnuSesion.Size = new System.Drawing.Size(80, 22);
            this.MnuSesion.Text = "Cerrar Sesion";
            this.MnuSesion.Click += new System.EventHandler(this.MnuSesion_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Location = new System.Drawing.Point(671, 418);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 8;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnInventario);
            this.Name = "FrmVentanaPrincipal";
            this.Text = "FrmVentanaPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentanaPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmVentanaPrincipal_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton MnuMiCuenta;
        private System.Windows.Forms.ToolStripButton MnuSesion;
        public System.Windows.Forms.TextBox txtUsuario;
    }
}