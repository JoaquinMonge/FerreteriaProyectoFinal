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
            this.btnAsignar = new System.Windows.Forms.Button();
            this.Asignar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgvProductos.Size = new System.Drawing.Size(847, 213);
            this.dgvProductos.TabIndex = 0;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(516, 329);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(86, 28);
            this.btnAsignar.TabIndex = 1;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
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
            // FrmAsignarProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 450);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FrmAsignarProd";
            this.Text = "FrmAsignarProd";
            this.Load += new System.EventHandler(this.FrmAsignarProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Asignar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}