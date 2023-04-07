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
            this.menu = new System.Windows.Forms.ToolStrip();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.MnuMiCuenta = new System.Windows.Forms.ToolStripButton();
            this.MnuSesion = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.PapayaWhip;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuMiCuenta,
            this.MnuSesion});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 25);
            this.menu.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Location = new System.Drawing.Point(671, 418);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 8;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnVentas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnVentas.FlatAppearance.BorderSize = 3;
            this.btnVentas.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnVentas.Location = new System.Drawing.Point(536, 121);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(116, 162);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClientes.FlatAppearance.BorderSize = 3;
            this.btnClientes.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnClientes.Location = new System.Drawing.Point(344, 121);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(116, 162);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnInventario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnInventario.FlatAppearance.BorderSize = 3;
            this.btnInventario.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnInventario.Location = new System.Drawing.Point(143, 121);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(116, 162);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // MnuMiCuenta
            // 
            this.MnuMiCuenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MnuMiCuenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MnuMiCuenta.ForeColor = System.Drawing.Color.Green;
            this.MnuMiCuenta.Image = ((System.Drawing.Image)(resources.GetObject("MnuMiCuenta.Image")));
            this.MnuMiCuenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuMiCuenta.Name = "MnuMiCuenta";
            this.MnuMiCuenta.Size = new System.Drawing.Size(66, 22);
            this.MnuMiCuenta.Text = "Mi cuenta";
            this.MnuMiCuenta.Click += new System.EventHandler(this.MnuMiCuenta_Click);
            // 
            // MnuSesion
            // 
            this.MnuSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MnuSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MnuSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MnuSesion.ForeColor = System.Drawing.Color.Green;
            this.MnuSesion.Image = ((System.Drawing.Image)(resources.GetObject("MnuSesion.Image")));
            this.MnuSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MnuSesion.Name = "MnuSesion";
            this.MnuSesion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MnuSesion.Size = new System.Drawing.Size(85, 22);
            this.MnuSesion.Text = "Cerrar Sesion";
            this.MnuSesion.Click += new System.EventHandler(this.MnuSesion_Click);
            // 
            // FrmVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
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