using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmLogin : MetroFramework.Forms.MetroForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        NEmpleado obj = new NEmpleado();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtContraseña.Text != "") { }
                else MensajeError("Ingrese contraseña ");

            }
            else
            {
                MensajeError("Ingrese Usuario");

            }
            if (txtContraseña.Text != "" && txtContraseña.Text != "")
            {
                lblMsgError.Visible = false;
                if (obj.Login(txtUsuario.Text, txtContraseña.Text) == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Sesión  Iniciada", "Mod Clean", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    new FrmPrincipal().Show();

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Datos de usuario o contraseña invalidos", "Mod Clean", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                }
            }
        }
        public void Limpiar()
        {
            txtContraseña.Text = "";
            txtUsuario.Text = "";
        }
        private void MensajeError(string msg)
        {
            lblMsgError.Text = "      " + msg;
            lblMsgError.Visible = true;
        }
    }
}
