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
    public partial class FrmEmpleados : MetroFramework.Forms.MetroForm
    {
        NEmpleado Obj = new NEmpleado();
        string idEmpleado;
        string Operacion = "Insertar";

        public FrmEmpleados()
        {
            InitializeComponent();
            ListarCargo();
            MostrarEmpleado();
        }

        public void ListarCargo()
        {
            NCargo ObjCargo = new NCargo();
            cbCargo.DataSource = ObjCargo.Listar();
            cbCargo.DisplayMember = "NCARGO";
            cbCargo.ValueMember = "ID_CARGO";
        }

        public void MostrarEmpleado()
        {
            NEmpleado ObjEmpleado = new NEmpleado();
            dtListado.DataSource = ObjEmpleado.Mostrar();
            dtListado.Columns[4].Visible = false;
            dtListado.Columns[5].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                Obj.Insertar(
                txtNombre.Text,
                txtApellido.Text,
                txtCorreo.Text,
                txtContraseña.Text,
                Convert.ToInt32(cbCargo.SelectedValue));
                MetroFramework.MetroMessageBox.Show(this, "Registro Ingresado Correctamente", "Sistema Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                MostrarEmpleado();
            }
            else if (Operacion == "Editar")
            {
                Obj.Editar(Convert.ToInt32(idEmpleado),
                    txtNombre.Text,
                    txtApellido.Text,
                    txtCorreo.Text,
                    txtContraseña.Text,
                    Convert.ToInt32(cbCargo.SelectedValue));
                Limpiar();
                Operacion = "Insertar";
                MostrarEmpleado();
                MetroFramework.MetroMessageBox.Show(this, "Registro Editado Correctamente", "Sistema Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Limpiar()
        {
            txtNombre.Text = " ";
            txtApellido.Text = " ";
            txtCorreo.Text = " ";
            txtContraseña.Text = " ";
            

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtListado.SelectedRows.Count > 0)
            {
                txtNombre.Text = dtListado.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dtListado.CurrentRow.Cells[2].Value.ToString();
                cbCargo.Text = dtListado.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = dtListado.CurrentRow.Cells[4].Value.ToString();
                txtContraseña.Text = dtListado.CurrentRow.Cells[5].Value.ToString();
                idEmpleado = dtListado.CurrentRow.Cells[0].Value.ToString();
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
                txtNombre.Text = dtListado.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dtListado.CurrentRow.Cells[2].Value.ToString();
                cbCargo.Text = dtListado.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = dtListado.CurrentRow.Cells[4].Value.ToString();
                txtContraseña.Text = dtListado.CurrentRow.Cells[5].Value.ToString();
                idEmpleado = dtListado.CurrentRow.Cells[0].Value.ToString();
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
                Obj.Eliminar(Convert.ToInt32(dtListado.CurrentRow.Cells[0].Value));
                Limpiar();
                MostrarEmpleado();
                MessageBox.Show("Registro eliminado");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {

        }
    }
}
