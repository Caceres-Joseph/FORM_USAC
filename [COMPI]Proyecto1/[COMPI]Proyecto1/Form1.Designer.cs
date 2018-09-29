namespace _COMPI_Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarClaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramaDeClasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarFormularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verFomularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.txtConsola = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(0, 5);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(216, 36);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile1.TabIndex = 1;
            this.metroTile1.Text = "OLCCE";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.erroresToolStripMenuItem,
            this.otroToolStripMenuItem,
            this.graficarToolStripMenuItem,
            this.generarFormularioToolStripMenuItem,
            this.verFomularioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(219, 17);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.nuevoToolStripMenuItem,
            this.nuevoProyectoToolStripMenuItem,
            this.eliminarClaseToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.abrirToolStripMenuItem.Text = "Abrir Clase";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevoToolStripMenuItem.Text = "Nueva Clase";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // nuevoProyectoToolStripMenuItem
            // 
            this.nuevoProyectoToolStripMenuItem.Name = "nuevoProyectoToolStripMenuItem";
            this.nuevoProyectoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevoProyectoToolStripMenuItem.Text = "Nuevo Proyecto";
            this.nuevoProyectoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProyectoToolStripMenuItem_Click);
            // 
            // eliminarClaseToolStripMenuItem
            // 
            this.eliminarClaseToolStripMenuItem.Name = "eliminarClaseToolStripMenuItem";
            this.eliminarClaseToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarClaseToolStripMenuItem.Text = "Eliminar Clase";
            this.eliminarClaseToolStripMenuItem.Click += new System.EventHandler(this.eliminarClaseToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // erroresToolStripMenuItem
            // 
            this.erroresToolStripMenuItem.Name = "erroresToolStripMenuItem";
            this.erroresToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.erroresToolStripMenuItem.Text = "Reporte";
            this.erroresToolStripMenuItem.Click += new System.EventHandler(this.erroresToolStripMenuItem_Click);
            // 
            // otroToolStripMenuItem
            // 
            this.otroToolStripMenuItem.Name = "otroToolStripMenuItem";
            this.otroToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.otroToolStripMenuItem.Text = "Otro";
            this.otroToolStripMenuItem.Visible = false;
            this.otroToolStripMenuItem.Click += new System.EventHandler(this.otroToolStripMenuItem_Click);
            // 
            // graficarToolStripMenuItem
            // 
            this.graficarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSTToolStripMenuItem,
            this.diagramaDeClasesToolStripMenuItem});
            this.graficarToolStripMenuItem.Name = "graficarToolStripMenuItem";
            this.graficarToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.graficarToolStripMenuItem.Text = "Graficar";
            // 
            // aSTToolStripMenuItem
            // 
            this.aSTToolStripMenuItem.Name = "aSTToolStripMenuItem";
            this.aSTToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aSTToolStripMenuItem.Text = "AST";
            this.aSTToolStripMenuItem.Click += new System.EventHandler(this.aSTToolStripMenuItem_Click);
            // 
            // diagramaDeClasesToolStripMenuItem
            // 
            this.diagramaDeClasesToolStripMenuItem.Name = "diagramaDeClasesToolStripMenuItem";
            this.diagramaDeClasesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.diagramaDeClasesToolStripMenuItem.Text = "Diagrama de Clases";
            this.diagramaDeClasesToolStripMenuItem.Click += new System.EventHandler(this.diagramaDeClasesToolStripMenuItem_Click);
            // 
            // generarFormularioToolStripMenuItem
            // 
            this.generarFormularioToolStripMenuItem.Name = "generarFormularioToolStripMenuItem";
            this.generarFormularioToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.generarFormularioToolStripMenuItem.Text = "Generar Formulario";
            // 
            // verFomularioToolStripMenuItem
            // 
            this.verFomularioToolStripMenuItem.Name = "verFomularioToolStripMenuItem";
            this.verFomularioToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.verFomularioToolStripMenuItem.Text = "Ver Fomulario";
            this.verFomularioToolStripMenuItem.Click += new System.EventHandler(this.verFomularioToolStripMenuItem_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.metroTabControl1.Location = new System.Drawing.Point(280, 54);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Size = new System.Drawing.Size(1017, 660);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTabControl1.TabIndex = 6;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // txtConsola
            // 
            this.txtConsola.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtConsola.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsola.ForeColor = System.Drawing.Color.White;
            this.txtConsola.Location = new System.Drawing.Point(293, 680);
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(800, 60);
            this.txtConsola.TabIndex = 4;
            this.txtConsola.Text = "";
            this.txtConsola.Visible = false;
            this.txtConsola.TextChanged += new System.EventHandler(this.txtConsola_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(23, 74);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(233, 640);
            this.treeView1.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(0, 41);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(216, 987);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile2.TabIndex = 10;
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 737);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.txtConsola);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroTile2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresToolStripMenuItem;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.RichTextBox txtConsola;
        private System.Windows.Forms.ToolStripMenuItem otroToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagramaDeClasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoProyectoToolStripMenuItem;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.ToolStripMenuItem eliminarClaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarFormularioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verFomularioToolStripMenuItem;
    }
}

