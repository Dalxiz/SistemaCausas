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
    public partial class FrmCliente : MetroFramework.Forms.MetroForm
    {
        NCliente Obj = new NCliente();
        string idEmpleado;
        string Operacion = "Insertar";

        public FrmCliente()
        {
            InitializeComponent();
            MostrarCliente();
            txtRut.Focus();
        }

        public void MostrarCliente()
        {
            NCliente objcliente = new NCliente();
            dtListado.DataSource = objcliente.Mostrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRut.Text) || string.IsNullOrEmpty(txtRazon.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtComuna.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Campos Sin rellenar", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var opcion = MetroFramework.MetroMessageBox.Show(this, "¿Desea Guardar los Datos?", "Mod-Causas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == opcion)
                {
                    if (Operacion == "Insertar")
                    {
                        Obj.Insertar(
                            txtRut.Text,
                            txtRazon.Text.ToUpper(),
                            txtDireccion.Text.ToUpper(),
                            txtComuna.Text.ToUpper(),
                            Convert.ToInt32(txtTelefono.Text));
                        Limpiar();
                        MostrarCliente();
                        MetroFramework.MetroMessageBox.Show(this, "Registro Insertado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRut.Focus();
                    }
                    else if (Operacion == "Editar")
                    {
                        txtRut.Enabled = false;
                        Obj.Editar(
                            txtRut.Text,
                            txtRazon.Text.ToUpper(),
                            txtDireccion.Text.ToUpper(),
                            txtComuna.Text.ToUpper(),
                            Convert.ToInt32(txtTelefono.Text));
                        Limpiar();
                        Operacion = "Insertar";
                        MostrarCliente();
                        MetroFramework.MetroMessageBox.Show(this, "Registro Editado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRut.Focus();
                    }
                }
            }
        }

        public void Limpiar()
        {
            txtRut.Text = "";
            txtRazon.Text = "";
            txtDireccion.Text = "";
            txtComuna.Text = "";
            txtTelefono.Text = "";
            txtRut.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtListado.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtRut.Text = dtListado.CurrentRow.Cells[0].Value.ToString();
                txtRazon.Text = dtListado.CurrentRow.Cells[1].Value.ToString();
                txtDireccion.Text = dtListado.CurrentRow.Cells[2].Value.ToString();
                txtComuna.Text = dtListado.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dtListado.CurrentRow.Cells[4].Value.ToString();
                txtRut.Focus();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            if (dtListado.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtRut.Text = dtListado.CurrentRow.Cells[0].Value.ToString();
                txtRazon.Text = dtListado.CurrentRow.Cells[1].Value.ToString();
                txtDireccion.Text = dtListado.CurrentRow.Cells[2].Value.ToString();
                txtComuna.Text = dtListado.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dtListado.CurrentRow.Cells[4].Value.ToString();
                txtRut.Focus();
                txtRut.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtListado.SelectedRows.Count > 0)
            {
                Obj.Eliminar(dtListado.CurrentRow.Cells[0].Value.ToString());
                Limpiar();
                MostrarCliente();
                MessageBox.Show("Registro eliminado");
                txtRut.Focus();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if(txtTelefono.Text.Length < 10) { }
            else
            {
                MessageBox.Show("Numero Invalido");
                txtTelefono.Clear();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            if (txtRut.Text.Length < 11) { }
            else
            {
                MessageBox.Show("Rut Invalido");
                txtRut.Clear();
            }
        }

        private void btnGuardar_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRut.Text) || string.IsNullOrEmpty(txtRazon.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtComuna.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                 MetroFramework.MetroMessageBox.Show(this, "Campos Sin rellenar", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var opcion = MetroFramework.MetroMessageBox.Show(this, "¿Desea Guardar los Datos?", "Mod-Causas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == opcion)
                {
                    if (Operacion == "Insertar")
                    {
                        Obj.Insertar(
                            txtRut.Text,
                            txtRazon.Text.ToUpper(),
                            txtDireccion.Text.ToUpper(),
                            txtComuna.Text.ToUpper(),
                            Convert.ToInt32(txtTelefono.Text));
                        Limpiar();
                        MostrarCliente();
                        MetroFramework.MetroMessageBox.Show(this, "Registro Insertado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRut.Focus();
                    }
                    else if (Operacion == "Editar")
                    {
                        txtRut.Enabled = false;
                        Obj.Editar(
                            txtRut.Text,
                            txtRazon.Text.ToUpper(),
                            txtDireccion.Text.ToUpper(),
                            txtComuna.Text.ToUpper(),
                            Convert.ToInt32(txtTelefono.Text));
                        Limpiar();
                        Operacion = "Insertar";
                        MostrarCliente();
                        MetroFramework.MetroMessageBox.Show(this, "Registro Editado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRut.Focus();
                    }
                }
            }                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmPrincipal obj = new FrmPrincipal();
            obj.Show();
            Hide();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
