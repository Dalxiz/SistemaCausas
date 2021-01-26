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
    public partial class FrmPrincipal : MetroFramework.Forms.MetroForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblNombre.Text = DCabhe.Nombre +" "+DCabhe.Apellido;
            if (DCabhe.Idcargo == 1)
            {
                lblCargo.Text = "Administrador";
            }
            else
            {
                if(DCabhe.Idcargo == 2)
                {
                    lblCargo.Text = "Procurador";
                    cond();
                }
                else
                {
                    if(DCabhe.Idcargo == 3)
                    {
                        lblCargo.Text = "Abogado";
                        cond();
                    }
                    else
                    {
                        if (DCabhe.Idcargo == 4)
                        {
                            lblCargo.Text = "Jefe Departamento";
                            cond();
                        }
                        else
                        {
                            if (DCabhe.Idcargo == 5)
                            {
                                lblCargo.Text = "Gerencia";
                                cond();
                            }
                            else
                            {
                                if (DCabhe.Idcargo == 5)
                                {
                                    lblCargo.Text = "Asistente Dpto. Legal";
                                    cond();
                                }
                                else
                                {
                                    cond();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void cond()
        {
            btnMantenimiento.Enabled = false;
            btnEmpleado.Enabled = false;
            btnCliente.Enabled = false;
            btnMantenimiento.BackColor =Color.Gray;
            btnEmpleado.BackColor = Color.Gray;
            btnCliente.BackColor = Color.Gray;
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            FrmRegistros obj = new FrmRegistros();
            obj.Show();
            Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmCliente obj = new FrmCliente();
            obj.Show();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            FrmEmpleado obj = new FrmEmpleado();
            obj.Show();
            Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            FrmCausa obj = new FrmCausa();
            obj.Show();
            Close();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            FrmActividades obj = new FrmActividades();
            obj.Show();
            Close();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            FrmConsulta obj = new FrmConsulta();
            obj.Show();
            Close();
        }
    }
}
