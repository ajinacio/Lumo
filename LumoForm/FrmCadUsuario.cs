using Lumo.App;
using Lumo.Domain;
using System;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmCadUsuario : Form
    {
        Usuario usuario;
        Usuario cadUsuario;
        UsuarioApp usuarioApp = new UsuarioApp();
        int time = 0;

        public FrmCadUsuario(Usuario _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txbLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txbNome.Focus();
        }

        private void txbLogin_Leave(object sender, EventArgs e)
        {
            if (txbLogin.Text != "")
            {
                cadUsuario = usuarioApp.oneLogin(txbLogin.Text);
                if (cadUsuario.Id > 0)
                {
                    txbNome.Text = cadUsuario.Nome;
                    cbbCargo.Text = cadUsuario.Cargo;
                    txbCaminho.Text = cadUsuario.Caminho;
                }
            }
        }

        private void btnLimpaSenha_Click(object sender, EventArgs e)
        {
            if (txbLogin.Text != "" || txbNome.Text != "")
            {
                if (txbLogin.Text != "")
                {
                    cadUsuario = usuarioApp.oneLogin(txbLogin.Text);
                    if (cadUsuario.Id > 0)
                    {
                        cadUsuario.Senha = "";
                        usuarioApp.save(cadUsuario);
                    }
                }

                if (txbNome.Text != "")
                {
                    cadUsuario = usuarioApp.oneNome(txbNome.Text);
                    if (cadUsuario.Id > 0)
                    {
                        cadUsuario.Senha = "";
                        usuarioApp.save(cadUsuario);
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbLogin.Text = "";
            txbNome.Text = "";
            cbbCargo.Text = "";
            txbCaminho.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txbLogin.Text != "")
            {
                if (txbLogin.Text != "")
                {
                    cadUsuario = usuarioApp.oneLogin(txbLogin.Text);
                    if (cadUsuario.Id > 0)
                    {
                        txbNome.Text = cadUsuario.Nome;
                        cbbCargo.Text = cadUsuario.Cargo;
                        txbCaminho.Text = cadUsuario.Caminho;
                        usuarioApp.delete(cadUsuario);
                        mensagem("Usuário excluído com sucesso.");
                    }
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbLogin.Text != "" && txbNome.Text != "" && cbbCargo.Text != "")
            {
                cadUsuario = usuarioApp.oneLogin(txbLogin.Text);
                if (cadUsuario.Id == 0)
                    cadUsuario.Login = txbLogin.Text;

                cadUsuario.Nome = txbNome.Text;
                cadUsuario.Senha = "";
                cadUsuario.Cargo = cbbCargo.Text;
                cadUsuario.Caminho = txbCaminho.Text;
                usuarioApp.save(cadUsuario);
                mensagem("Dados salvos com sucesso.");
            }
        }

        private void txbNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                cbbCargo.Focus();

            if (e.KeyCode == Keys.Up) txbLogin.Focus();
        }

        private void txbNome_Leave(object sender, EventArgs e)
        {
            if (txbNome.Text != "" && txbLogin.Text == "")
            {
                cadUsuario = usuarioApp.oneNome(txbNome.Text);
                if (cadUsuario.Id > 0)
                {
                    txbLogin.Text = cadUsuario.Login;
                    cbbCargo.Text = cadUsuario.Cargo;
                    txbCaminho.Text = cadUsuario.Caminho;
                }
            }
        }

        private void tmrMensagem_Tick(object sender, EventArgs e)
        {
            if (tmrMensagem.Enabled && time == 1)
            {
                lblMensagem.Text = "";
                tmrMensagem.Enabled = false;
                time = 0;
            }
            else
                time = 1;
        }

        private void mensagem(string msg)
        {
            lblMensagem.Text = msg;
            lblMensagem.Location = new System.Drawing.Point((456 - lblMensagem.Size.Width) / 2 + 20, 60);
            tmrMensagem.Enabled = true;
            time = 0;
        }

        private void txbCaminho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) cbbCargo.Focus();
        }

        private void cbbCargo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) txbNome.Focus();
            if (e.KeyCode == Keys.Down) txbCaminho.Focus();
        }
    }
}
