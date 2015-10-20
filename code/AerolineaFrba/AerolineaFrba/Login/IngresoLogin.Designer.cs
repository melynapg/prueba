namespace AerolineaFrba.Login
{
    partial class IngresoLogin
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
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.labUsuario = new System.Windows.Forms.Label();
            this.labContrasenia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(43, 197);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 0;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(156, 197);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(43, 66);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(188, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(43, 136);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.Size = new System.Drawing.Size(188, 20);
            this.txtContrasenia.TabIndex = 3;
            // 
            // labUsuario
            // 
            this.labUsuario.AutoSize = true;
            this.labUsuario.Location = new System.Drawing.Point(43, 47);
            this.labUsuario.Name = "labUsuario";
            this.labUsuario.Size = new System.Drawing.Size(43, 13);
            this.labUsuario.TabIndex = 4;
            this.labUsuario.Text = "Usuario";
            // 
            // labContrasenia
            // 
            this.labContrasenia.AutoSize = true;
            this.labContrasenia.Location = new System.Drawing.Point(40, 120);
            this.labContrasenia.Name = "labContrasenia";
            this.labContrasenia.Size = new System.Drawing.Size(61, 13);
            this.labContrasenia.TabIndex = 5;
            this.labContrasenia.Text = "Contraseña";
            // 
            // IngresoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labContrasenia);
            this.Controls.Add(this.labUsuario);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnIngresar);
            this.Name = "IngresoLogin";
            this.Text = "Ingreso";
            this.Load += new System.EventHandler(this.Ingreso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label labUsuario;
        private System.Windows.Forms.Label labContrasenia;
    }
}