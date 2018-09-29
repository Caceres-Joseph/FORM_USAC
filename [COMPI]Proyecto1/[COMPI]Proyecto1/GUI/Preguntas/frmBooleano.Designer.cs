namespace _COMPI_Proyecto1.GUI.Preguntas
{
    partial class frmBooleano
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbVerdadero = new System.Windows.Forms.RadioButton();
            this.rbFalso = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRequerido
            // 
            this.lblRequerido.AutoSize = true;
            this.lblRequerido.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRequerido.Location = new System.Drawing.Point(56, 92);
            this.lblRequerido.Name = "lblRequerido";
            this.lblRequerido.Size = new System.Drawing.Size(56, 13);
            this.lblRequerido.TabIndex = 24;
            this.lblRequerido.Text = "Requerido";
            // 
            // lblSugerir
            // 
            this.lblSugerir.AutoSize = true;
            this.lblSugerir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugerir.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblSugerir.Location = new System.Drawing.Point(56, 65);
            this.lblSugerir.Name = "lblSugerir";
            this.lblSugerir.Size = new System.Drawing.Size(51, 16);
            this.lblSugerir.TabIndex = 23;
            this.lblSugerir.Text = "Sugerir";
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiqueta.Location = new System.Drawing.Point(56, 36);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(61, 18);
            this.lblEtiqueta.TabIndex = 22;
            this.lblEtiqueta.Text = "Etiqueta";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(39, 229);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(73, 23);
            this.btnAnterior.TabIndex = 21;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(413, 230);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 20;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFalso);
            this.groupBox1.Controls.Add(this.rbVerdadero);
            this.groupBox1.Location = new System.Drawing.Point(59, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 80);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione uno";
            // 
            // rbVerdadero
            // 
            this.rbVerdadero.AutoSize = true;
            this.rbVerdadero.Location = new System.Drawing.Point(22, 37);
            this.rbVerdadero.Name = "rbVerdadero";
            this.rbVerdadero.Size = new System.Drawing.Size(14, 13);
            this.rbVerdadero.TabIndex = 0;
            this.rbVerdadero.UseVisualStyleBackColor = true;
            // 
            // rbFalso
            // 
            this.rbFalso.AutoSize = true;
            this.rbFalso.Checked = true;
            this.rbFalso.Location = new System.Drawing.Point(202, 35);
            this.rbFalso.Name = "rbFalso";
            this.rbFalso.Size = new System.Drawing.Size(85, 17);
            this.rbFalso.TabIndex = 1;
            this.rbFalso.TabStop = true;
            this.rbFalso.Text = "radioButton2";
            this.rbFalso.UseVisualStyleBackColor = true;
            // 
            // frmBooleano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 282);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRequerido);
            this.Controls.Add(this.lblSugerir);
            this.Controls.Add(this.lblEtiqueta);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSiguiente);
            this.Name = "frmBooleano";
            this.Text = "Pregunta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRequerido;
        private System.Windows.Forms.Label lblSugerir;
        private System.Windows.Forms.Label lblEtiqueta;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFalso;
        private System.Windows.Forms.RadioButton rbVerdadero;
    }
}