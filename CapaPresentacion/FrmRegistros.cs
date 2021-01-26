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
    public partial class FrmRegistros : MetroFramework.Forms.MetroForm
    {
        
        public FrmRegistros()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmPrincipal obj = new FrmPrincipal();
            obj.Show();
            Close();
        }

        private void FrmRegistros_Load(object sender, EventArgs e)
        {            
           
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            FrmCargo frm = new FrmCargo();
            frm.Show();
            Hide();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            FrmTipoCausa frm = new FrmTipoCausa();
            frm.Show();
            Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            FrmEstado frm = new FrmEstado();
            frm.Show();
            Hide();
        }
    }
}
