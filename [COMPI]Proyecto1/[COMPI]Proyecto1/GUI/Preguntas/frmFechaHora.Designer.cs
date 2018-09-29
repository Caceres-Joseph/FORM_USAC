namespace _COMPI_Proyecto1.GUI.Preguntas
{
    partial class frmFechaHora
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblRequerido = new System.Windows.Forms.Label();
            this.lblSugerir = new System.Windows.Forms.Label();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // lblRequerido
            // 
            this.lblRequerido.AutoSize = true;
            this.lblRequerido.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRequerido.Location = new System.Drawing.Point(32, 80);
            this.lblRequerido.Name = "lblRequerido";
            this.lblRequerido.Size = new System.Drawing.Size(56, 13);
            this.lblRequerido.TabIndex = 17;
            this.lblRequerido.Text = "Requerido";
            // 
            // lblSugerir
            // 
            this.lblSugerir.AutoSize = true;
            this.lblSugerir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugerir.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblSugerir.Location = new System.Drawing.Point(32, 53);
            this.lblSugerir.Name = "lblSugerir";
            this.lblSugerir.Size = new System.Drawing.Size(51, 16);
            this.lblSugerir.TabIndex = 16;
            this.lblSugerir.Text = "Sugerir";
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiqueta.Location = new System.Drawing.Point(32, 24);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(61, 18);
            this.lblEtiqueta.TabIndex = 15;
            this.lblEtiqueta.Text = "Etiqueta";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(30, 160);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(73, 23);
            this.btnAnterior.TabIndex = 14;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(349, 160);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 13;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // frmFechaHora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 255);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblRequerido);
            this.Controls.Add(this.lblSugerir);
            this.Controls.Add(this.lblEtiqueta);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSiguiente);
            this.Name = "frmFechaHora";
            this.Text = "Fecha y Hora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblRequerido;
        private System.Windows.Forms.Label lblSugerir;
        private System.Windows.Forms.Label lblEtiqueta;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
    }
}