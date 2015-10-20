using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace AerolineaFrba.Login
{
    public partial class IngresoLogin : Form
    {
        public IngresoLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var intentos = Usuario.GetIntentos(txtUsuario.Text);
            if (intentos < 3)
            {
                Usuario _usuario = Usuario.GetByLogin(txtUsuario.Text, Usuario.SHA256Encripta(txtContrasenia.Text));
                if (_usuario != null)
                {
                    Usuario.SetIntentos(txtUsuario.Text, 0);
//                  SharedData.Instance().currentUserId = _usuario.Id;
                    Menu _menu = new Menu();
                    _menu.Show();
                    this.Hide();
                }
                else
                {
                    Usuario.SetIntentos(txtUsuario.Text, intentos + 1);
                    MessageBox.Show("Usuario o contraseña no valido");
                }
            }
            else
                MessageBox.Show("Usuario bloqueado por repetidos intentos de logueo");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Inicial prev = new Inicial();
            prev.Show();
            this.Hide();
        }

        private void Ingreso_Load(object sender, EventArgs e)
        {

        }
    }
}
