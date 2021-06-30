using System;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmRelatorio : Form
    {
        public string numeroRelat = "";

        public FrmRelatorio()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            numeroRelat = "";
            this.Dispose();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            numeroRelat = txbNomeRelat.Text;
            this.Dispose();
        }
    }
}
