namespace FerreteriaProyectoFinal.Factura
{
    partial class FrmAsignarProd
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Asignar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnConfirmarCompra = new System.Windows.Forms.Button();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Asignar,
            this.Cantidad});
            this.dgvProductos.Location = new System.Drawing.Point(19, 62);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(847, 277);
            this.dgvProductos.TabIndex = 0;
            // 
            // Asignar
            // 
            this.Asignar.HeaderText = "Asignar";
            this.Asignar.Name = "Asignar";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnAsignar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAsignar.Location = new System.Drawing.Point(608, 375);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(115, 37);
            this.btnAsignar.TabIndex = 1;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnConfirmarCompra
            // 
            this.btnConfirmarCompra.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnConfirmarCompra.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarCompra.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmarCompra.Location = new System.Drawing.Point(160, 375);
            this.btnConfirmarCompra.Name = "btnConfirmarCompra";
            this.btnConfirmarCompra.Size = new System.Drawing.Size(115, 37);
            this.btnConfirmarCompra.TabIndex = 2;
            this.btnConfirmarCompra.Text = "Facturar";
            this.btnConfirmarCompra.UseVisualStyleBackColor = false;
            this.btnConfirmarCompra.Click += new System.EventHandler(this.btnConfirmarCompra_Click);
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(19, 12);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(133, 20);
            this.txtCedula.TabIndex = 73;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnVolver.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnVolver.Location = new System.Drawing.Point(780, 7);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(86, 28);
            this.btnVolver.TabIndex = 75;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmAsignarProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(878, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.btnConfirmarCompra);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FrmAsignarProd";
            this.Text = "FrmAsignarProd";
            this.Load += new System.EventHandler(this.FrmAsignarProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Asignar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Button btnConfirmarCompra;
        public System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Button btnVolver;
    }
}