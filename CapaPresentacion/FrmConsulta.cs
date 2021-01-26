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
    public partial class FrmConsulta : MetroFramework.Forms.MetroForm
    {
        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
            Close();
        }

        private void BuscarFecha()
        {
            NDetalle o = new NDetalle();
            dataListado.DataSource = o.Buscar(dtDesde.Value, dtHasta.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuscarFecha();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
