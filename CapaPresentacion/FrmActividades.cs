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
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmActividades : MetroFramework.Forms.MetroForm
    {
        NDetalle objdet = new NDetalle();
        string Operacion = "Insertar";
        public FrmActividades()
        {
            InitializeComponent();
            MostrarDetalle();
            Cargo();
            txtEmpleado.Text = DCabhe.Nombre + " " + DCabhe.Apellido;
            txtEmpleado.Enabled = false;
            txtCargo.Enabled = false;
            MostrarCb();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
            Close();
            
        }

        private void MostrarDetalle()
        {
            NDetalle obj = new NDetalle();
            dataListado.DataSource = obj.Listar();
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[8].Visible = false;

        }

        private void MostrarCb()
        {
            NCausa obj = new NCausa();
            cbRol.DataSource = obj.Listar();
            cbRol.DisplayMember = "ROL";
            cbRol.ValueMember="ROL";
        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtObservacion.Text = "";
            txtTribunal.Text = "";
            
        }
        private void Cargo()
        {
            if (DCabhe.Idcargo == 1)
            {
                txtCargo.Text = "Administrador";
            }
            else
            {
                if (DCabhe.Idcargo == 2)
                {
                    txtCargo.Text = "Procurador";
                    
                }
                else
                {
                    if (DCabhe.Idcargo == 3)
                    {
                        txtCargo.Text = "Abogado";
                        
                    }
                    else
                    {
                        if (DCabhe.Idcargo == 4)
                        {
                            txtCargo.Text = "Jefe Departamento";
                            
                        }
                        else
                        {
                            if (DCabhe.Idcargo == 5)
                            {
                                txtCargo.Text = "Gerencia";
                                
                            }
                            else
                            {
                                if (DCabhe.Idcargo == 5)
                                {
                                    txtCargo.Text = "Asistente Dpto. Legal";
                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtObservacion.Text)||
                string.IsNullOrEmpty(txtTribunal.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Campos Sin rellenar", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Operacion == "Insertar")
                {
                    objdet.Insertar(dtRegistro.Value,
                        txtObservacion.Text.ToUpper(),
                        cbRol.SelectedValue.ToString(),
                        DCabhe.Idempleado,
                        txtTribunal.Text.ToUpper());
                    Limpiar();
                    MostrarDetalle();
                    MetroFramework.MetroMessageBox.Show(this, "Registro Insertado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Operacion == "Editar")
                {
                    objdet.Editar(
                        Convert.ToInt32(txtId.Text),
                        dtRegistro.Value,
                        txtObservacion.Text.ToUpper(),
                        cbRol.SelectedValue.ToString(),
                        DCabhe.Idempleado,
                        txtTribunal.Text.ToUpper());
                    Limpiar();
                    MostrarDetalle();
                    MetroFramework.MetroMessageBox.Show(this, "Registro Editado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                objdet.Eliminar(Convert.ToInt32(dataListado.CurrentRow.Cells[0].Value));
                MostrarDetalle();
                MessageBox.Show("Registro eliminado");

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
                txtId.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                dtRegistro.Text = dataListado.CurrentRow.Cells[5].Value.ToString();
                txtTribunal.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                txtObservacion.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                cbRol.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                MostrarDetalle();
                              

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
                txtId.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                dtRegistro.Text = dataListado.CurrentRow.Cells[5].Value.ToString();
                txtTribunal.Text = dataListado.CurrentRow.Cells[3].Value.ToString();
                txtObservacion.Text = dataListado.CurrentRow.Cells[4].Value.ToString();
                cbRol.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
                MostrarDetalle();
                
               

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
    }
}
