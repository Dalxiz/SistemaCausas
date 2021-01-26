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
    public partial class FrmEmpleado : MetroFramework.Forms.MetroForm
    {
        string Operacion = "Insertar";
        NEmpleado obj = new NEmpleado();
        public FrmEmpleado()
        {
            InitializeComponent();
            Mostrar();
            ListarCb();
        }

        public void Mostrar()
        {
            NEmpleado obj = new NEmpleado();
            dataListado.DataSource = obj.Mostrar2();
            dataListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[5].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
            Hide();
        }

        private void ListarCb()
        {
            NCargo obj = new NCargo();
            cbCargo.DataSource = obj.Listar();
            cbCargo.DisplayMember = "NCARGO";
            cbCargo.ValueMember = "ID_CARGO";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text)||
                string.IsNullOrEmpty(txtApellido.Text)||
                string.IsNullOrEmpty(txtCorreo.Text)||
                string.IsNullOrEmpty(txtContraseña.Text)||
                string.IsNullOrEmpty(cbCargo.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Campos Sin rellenar", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Operacion == "Insertar")
                {
                    obj.Insertar(
                        txtNombre.Text.ToUpper(),
                        txtApellido.Text.ToUpper(),
                        txtCorreo.Text,
                        txtContraseña.Text.ToUpper(),
                        Convert.ToInt32(cbCargo.SelectedValue));
                    Limpiar();
                    Mostrar();
                    MetroFramework.MetroMessageBox.Show(this, "Registro Insertado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Operacion == "Editar")
                {
                    obj.Editar(Convert.ToInt32(lblId.Text),
                        txtNombre.Text.ToUpper(),
                        txtApellido.Text.ToUpper(),
                        txtCorreo.Text,
                        txtContraseña.Text.ToUpper(),
                        Convert.ToInt32(cbCargo.SelectedValue));
                    Limpiar();
                    Mostrar();
                    Operacion = "Insertar";
                    MetroFramework.MetroMessageBox.Show(this, "Registro Editado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }
        public void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            cbCargo.DataSource = null;
            cbCargo.Items.Clear();
            ListarCb();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                lblId.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataListado.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                txtContraseña.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                cbCargo.SelectedValue= dataListado.CurrentRow.Cells[5].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                lblId.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataListado.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                txtContraseña.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                cbCargo.SelectedValue = dataListado.CurrentRow.Cells[5].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                obj.Eliminar(Convert.ToInt32(dataListado.CurrentRow.Cells[0].Value.ToString()));
                Limpiar();
                Mostrar();
                MessageBox.Show("Registro eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
    }
}
