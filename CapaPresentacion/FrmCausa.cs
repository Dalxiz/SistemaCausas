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
    public partial class FrmCausa : MetroFramework.Forms.MetroForm
    {
        string Operacion = "Insertar";
        NCausa objcausa = new NCausa();
        public FrmCausa()
        {
            InitializeComponent();
            ListarTipoCausa();
            ListarRazon();
            ListarEstado();
            Mostrar();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
            Close();
        }


        private void ListarTipoCausa()
        {
            NTipoCausa obj = new NTipoCausa();
            cbTipoCausa.DataSource = obj.Listar();
            cbTipoCausa.DisplayMember = "TIPO CAUSA";
            cbTipoCausa.ValueMember = "ID";
        }

        private void ListarRazon()
        {
            NCliente obj = new NCliente();
            cbRazonSocial.DataSource = obj.Mostrar();
            cbRazonSocial.DisplayMember = "NRAZON";
            cbRazonSocial.ValueMember = "RUT";
        }

        private void ListarEstado()
        {
            NEstado obj = new NEstado();
            cbEstado.DataSource = obj.Listar();
            cbEstado.DisplayMember = "NOMBRE ESTADO";
            cbEstado.ValueMember = "ID";
        }

        private void Mostrar()
        {
            NCausa obj = new NCausa();
            dataListado.DataSource = obj.Listar();
            dataListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataListado.Columns[6].Visible = false;
            dataListado.Columns[7].Visible = false;
            dataListado.Columns[8].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtRol.Text)||
                string.IsNullOrEmpty(txtDescripcion.Text)||
                string.IsNullOrEmpty(txtCaratulado.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Campos Sin rellenar", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (Operacion == "Insertar")
                {

                    objcausa.Insertar(txtRol.Text.ToUpper(),
                        Convert.ToInt32(cbTipoCausa.SelectedValue),
                        txtCaratulado.Text.ToUpper(),
                        cbRazonSocial.SelectedValue.ToString(),
                        dtFecha.Value,
                        Convert.ToInt32(cbEstado.SelectedValue),
                        txtDescripcion.Text.ToUpper());
                    Limpiar();
                    ListarTipoCausa();
                    ListarRazon();
                    ListarEstado();
                    Mostrar();
                    MetroFramework.MetroMessageBox.Show(this, "Registro Insertado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Operacion == "Editar")
                {

                    objcausa.Editar(txtRol.Text.ToUpper(),
                        Convert.ToInt32(cbTipoCausa.SelectedValue),
                        txtCaratulado.Text.ToUpper(),
                        cbRazonSocial.SelectedValue.ToString(),
                        dtFecha.Value,
                        Convert.ToInt32(cbEstado.SelectedValue),
                        txtDescripcion.Text.ToUpper());
                    Limpiar();
                    ListarTipoCausa();
                    ListarRazon();
                    ListarEstado();
                    Mostrar();
                    MetroFramework.MetroMessageBox.Show(this, "Registro Editado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                objcausa.Eliminar(dataListado.CurrentRow.Cells[0].Value.ToString());
                Mostrar();
                MessageBox.Show("Registro eliminado");
               
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtRol.Enabled = false;
                txtRol.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                cbTipoCausa.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                txtCaratulado.Text = dataListado.CurrentRow.Cells[2].Value.ToString();
                cbRazonSocial.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                dtFecha.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                txtDescripcion.Text = dataListado.CurrentRow.Cells[5].Value.ToString();
                cbEstado.Text = dataListado.CurrentRow.Cells[9].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        

        private void Limpiar()
        {
            cbEstado.DataSource = null;
            cbEstado.Items.Clear();
            cbRazonSocial.DataSource = null;
            cbRazonSocial.Items.Clear();
            cbTipoCausa.DataSource = null;
            cbTipoCausa.Items.Clear();
            txtCaratulado.Text = "";
            txtDescripcion.Text = "";
            txtRol.Text = "";
        }

        private void FrmCausa_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmCausa_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                txtRol.Enabled = false;
                txtRol.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                cbTipoCausa.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                txtCaratulado.Text = dataListado.CurrentRow.Cells[2].Value.ToString();
                cbRazonSocial.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                dtFecha.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                txtDescripcion.Text = dataListado.CurrentRow.Cells[5].Value.ToString();
                cbEstado.Text = dataListado.CurrentRow.Cells[9].Value.ToString();

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
                txtRol.Enabled = false;
                txtRol.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                cbTipoCausa.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                txtCaratulado.Text = dataListado.CurrentRow.Cells[2].Value.ToString();
                cbRazonSocial.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                dtFecha.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                txtDescripcion.Text = dataListado.CurrentRow.Cells[5].Value.ToString();
                cbEstado.Text = dataListado.CurrentRow.Cells[9].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
    }
}
