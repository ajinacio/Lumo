using Lumo.Domain;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmCadastro : Form
    {
        Usuario usuario;
        public FrmCadastro(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void btnVoltar_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void btnUsuario_Click(object sender, System.EventArgs e)
        {
            FrmCadUsuario frm = new FrmCadUsuario(usuario);
            frm.ShowDialog();
        }

        private void btnOrgao_Click(object sender, System.EventArgs e)
        {
            FrmCadOrgao frm = new FrmCadOrgao();
            frm.ShowDialog();
        }
    }
}
