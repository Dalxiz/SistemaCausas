﻿using System;
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
    public partial class FrmCargo : MetroFramework.Forms.MetroForm
    {
        public FrmCargo()
        {
            InitializeComponent();
            Mostrar();
        }

        NCargo objcargo = new NCargo();
        string operacion = "Insertar";

        public void Mostrar()
        {
            NCargo objCargo = new NCargo();
            dataListado.DataSource = objCargo.Listar();
            dataListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCargo.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Campos Sin rellenar", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(operacion == "Insertar")
                {
                    objcargo.Insertar(txtCargo.Text.ToUpper());
                    MetroFramework.MetroMessageBox.Show(this, "Registro Insertado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar();
                    Limpiar();
                }else if (operacion == "Editar")
                {
                    objcargo.Editar(Convert.ToInt32(txtId.Text),
                        txtCargo.Text.ToUpper());
                    operacion = "Insertar";
                    MetroFramework.MetroMessageBox.Show(this, "Registro Editado", "Mod-Causas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar();
                    Limpiar();
                }
            }
        }

        public void Limpiar()
        {
            txtCargo.Text = "";
            txtId.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataListado.SelectedRows.Count > 0)
            {
                operacion = "Editar";
                txtId.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                txtCargo.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
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
                operacion = "Editar";
                txtId.Text = dataListado.CurrentRow.Cells[0].Value.ToString();
                txtCargo.Text = dataListado.CurrentRow.Cells[1].Value.ToString();
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
                objcargo.Eliminar(Convert.ToInt32(dataListado.CurrentRow.Cells[0].Value));
                Limpiar();
                Mostrar();
                MessageBox.Show("Registro eliminado");

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmRegistros frm = new FrmRegistros();
            frm.Show();
            Close();
        }
    }
}
