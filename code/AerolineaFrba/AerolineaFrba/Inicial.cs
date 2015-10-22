using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Login;
using Configuracion;

namespace AerolineaFrba
{
    public partial class Inicial : Form
    {
        public Inicial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ingreso a terminal Autoservicio
            SharedData.Instance().currentUserId = 0;
            SharedData.Instance().currentRolId = SharedData.Instance().guestRolId;
            Login.Menu _menu = new Login.Menu();
            _menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ingreso al sistema como Administrador via login
            Login.IngresoLogin ingreso = new Login.IngresoLogin();
            ingreso.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
