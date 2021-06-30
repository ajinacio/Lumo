using Lumo.Domain;
using System;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmMain : Form
    {
        Usuario usuario;

        public FrmMain(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void btnLancamento_Click(object sender, EventArgs e)
        {
            FrmAvaliacao frm = new FrmAvaliacao(usuario, this.Location.X, this.Location.Y);
            frm.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            FrmCadastro frm = new FrmCadastro(usuario);
            frm.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnLancamento.Focus();
        }
    }
}
