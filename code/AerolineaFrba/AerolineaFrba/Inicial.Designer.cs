namespace AerolineaFrba
{
    partial class Inicial
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAutoservicio = new System.Windows.Forms.Button();
            this.ingresoUsuario = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutoservicio
            // 
            this.btnAutoservicio.Location = new System.Drawing.Point(38, 97);
            this.btnAutoservicio.Name = "btnAutoservicio";
            this.btnAutoservicio.Size = new System.Drawing.Size(81, 59);
            this.btnAutoservicio.TabIndex = 0;
            this.btnAutoservicio.Text = "Autoservicio";
            this.btnAutoservicio.UseVisualStyleBackColor = true;
            this.btnAutoservicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // ingresoUsuario
            // 
            this.ingresoUsuario.Location = new System.Drawing.Point(161, 97);
            this.ingresoUsuario.Name = "ingresoUsuario";
            this.ingresoUsuario.Size = new System.Drawing.Size(82, 59);
            this.ingresoUsuario.TabIndex = 1;
            this.ingresoUsuario.Text = "Ingreso Usuario";
            this.ingresoUsuario.UseVisualStyleBackColor = true;
            this.ingresoUsuario.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(99, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ingresoUsuario);
            this.Controls.Add(this.btnAutoservicio);
            this.Name = "Inicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AerolineasFRBA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ingresoUsuario;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAutoservicio;

    }
}

