using Lumo.App;
using Lumo.Domain;
using System;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmLogin : Form
    {
        FrmMain frmMain;
        UsuarioApp app = new UsuarioApp();
        Usuario user = new Usuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CONFIRMAtextBox.Visible = false;
            CONFIRMAlabel.Visible = false;
        }

        private void LOGINtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {

                if (LOGINtextBox.Text != "")
                {
                    user = app.oneLogin(LOGINtextBox.Text);
                    SENHAtextBox.Focus();
                }
            }
        }

        private void CANCELARbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ENTRARbutton_Click(object sender, EventArgs e)
        {
            if (LOGINtextBox.Text != "" & SENHAtextBox.Text != "")
            {
                if (CONFIRMAtextBox.Visible)
                {
                    if (CONFIRMAtextBox.Text != "")
                    {
                        if (SENHAtextBox.Text == CONFIRMAtextBox.Text)
                        {
                            user.Senha = SENHAtextBox.Text;
                            app.save(user);
                            frmMain = new FrmMain(user);
                            frmMain.Show();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Confirmação da senha diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CONFIRMAtextBox.Focus();
                        }
                    }
                }
                else
                {
                    if (user.Senha == SENHAtextBox.Text)
                    {
                        frmMain = new FrmMain(user);
                        frmMain.Show();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha não cadastrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SENHAtextBox.Text = "";
                        LOGINtextBox.Text = "";
                        LOGINtextBox.Focus();
                    }
                }
            }
        }

        private void SENHAtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (LOGINtextBox.Text == "")
                {
                    MessageBox.Show("Usuário em branco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SENHAtextBox.Text = "";
                    LOGINtextBox.Text = "";
                    LOGINtextBox.Focus();
                }
                else
                {
                    if (SENHAtextBox.Text == "")
                    {
                        MessageBox.Show("Senha em branco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SENHAtextBox.Text = "";
                        LOGINtextBox.Text = "";
                        LOGINtextBox.Focus();
                    }
                    else
                    {
                        if (CONFIRMAtextBox.Visible) CONFIRMAtextBox.Focus();
                        else
                        {
                            user = app.oneLogin(LOGINtextBox.Text);
                            if (user.Senha == SENHAtextBox.Text)
                            {
                                frmMain = new FrmMain(user);
                                frmMain.Show();
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Login ou senha não cadastrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SENHAtextBox.Text = "";
                                LOGINtextBox.Text = "";
                                LOGINtextBox.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void CONFIRMAtextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (SENHAtextBox.Text == CONFIRMAtextBox.Text)
                {
                    user.Senha = SENHAtextBox.Text;
                    app.save(user);
                    frmMain = new FrmMain(user);
                    frmMain.Show();
                    this.Dispose();
                }
                else
                    MessageBox.Show("Confirmação de senha diferente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LOGINtextBox_Leave(object sender, EventArgs e)
        {
            user = app.oneLogin(LOGINtextBox.Text);
            if (user.Id > 0 & user.Senha == "")
            {
                CONFIRMAlabel.Visible = true;
                CONFIRMAtextBox.Visible = true;
            }
        }
    }
}
