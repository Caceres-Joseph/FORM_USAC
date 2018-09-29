namespace _COMPI_Proyecto1.GUI.Preguntas
{
    partial class frmNota
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
            this.lblRequerido = new System.Windows.Forms.Label();
            this.lblSugerir = new System.Windows.Forms.Label();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRequerido
            // 
            this.lblRequerido.AutoSize = true;
            this.lblRequerido.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRequerido.Location = new System.Drawing.Point(43, 122);
            this.lblRequerido.Name = "lblRequerido";
            this.lblRequerido.Size = new System.Drawing.Size(56, 13);
            this.lblRequerido.TabIndex = 31;
            this.lblRequerido.Text = "Requerido";
            // 
            // lblSugerir
            // 
            this.lblSugerir.AutoSize = true;
            this.lblSugerir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugerir.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblSugerir.Location = new System.Drawing.Point(43, 95);
            this.lblSugerir.Name = "lblSugerir";
            this.lblSugerir.Size = new System.Drawing.Size(51, 16);
            this.lblSugerir.TabIndex = 30;
            this.lblSugerir.Text = "Sugerir";
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiqueta.Location = new System.Drawing.Point(43, 55);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(69, 20);
            this.lblEtiqueta.TabIndex = 29;
            this.lblEtiqueta.Text = "Etiqueta";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(21, 183);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(73, 23);
            this.btnAnterior.TabIndex = 28;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(401, 219);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 27;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // frmNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 270);
            this.Controls.Add(this.lblRequerido);
            this.Controls.Add(this.lblSugerir);
            this.Controls.Add(this.lblEtiqueta);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSiguiente);
            this.Name = "frmNota";
            this.Text = "frmNota";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRequerido;
        private System.Windows.Forms.Label lblSugerir;
        private System.Windows.Forms.Label lblEtiqueta;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
    }
}