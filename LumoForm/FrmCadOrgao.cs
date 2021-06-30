using Lumo.App;
using Lumo.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmCadOrgao : Form
    {
        Orgao orgao;
        List<Orgao> orgaos;
        OrgaoApp orgaoApp = new OrgaoApp();
        int time = 0;

        public FrmCadOrgao()
        {
            InitializeComponent();
        }

        private void FrmCadOrgao_Load(object sender, EventArgs e)
        {
            orgaos = orgaoApp.listAll();
            cbbDescricao.Items.Clear();
            foreach (Orgao org in orgaos)
            {
                cbbDescricao.Items.Add(org.Descricao);
            }
            cbbDescricao.Focus();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
            cbbDescricao.Text = "";
            cbbDescricao.Items.Clear();
            foreach (Orgao org in orgaos)
            {
                cbbDescricao.Items.Add(org.Descricao);
            }

        }

        private void rbtEstadual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEstadual.Checked)
            {
                lblUFResp.Enabled = true;
                cbbUFResp.Enabled = true;
            }
            else
            {
                lblUFResp.Enabled = false;
                cbbUFResp.Enabled = false;
            }
        }

        private void rbtMunicipal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMunicipal.Checked)
            {

                lblMunicipioResp.Enabled = true;
                txbMunicipioResp.Enabled = true;
            }
            else
            {
                lblMunicipioResp.Enabled = false;
                txbMunicipioResp.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbbDescricao.Text))
            {
                orgao = orgaoApp.oneDescricao(cbbDescricao.Text);
                orgao.Descricao = cbbDescricao.Text;
                orgao.Sigla = txbSigla.Text;

                if (txbCNPJ.Text.Length < 18)
                {
                    orgao.CNPJ = "";
                    txbCNPJ.Text = "";
                }
                else
                    orgao.CNPJ = txbCNPJ.Text;

                orgao.Endereco = txbEndereco.Text;
                orgao.Complemento = txbComplemento.Text;
                orgao.CEP = txbCEP.Text;
                orgao.Cidade = txbCidade.Text;
                orgao.UF = cbbUF.Text;
                orgao.Telefone1 = txbTelefone1.Text;
                orgao.Telefone2 = txbTelefone2.Text;
                orgao.EstadoResp = cbbUFResp.Text;
                orgao.MunicipioResp = txbMunicipioResp.Text;
                if (cbbDescricao.Text.Length > 3)
                {
                    if (cbbDescricao.Text.Substring(0, 4).ToUpper() == "PREF") orgao.Tipo = "P";
                    if (cbbDescricao.Text.Substring(0, 4).ToUpper() == "CÂMA") orgao.Tipo = "C";
                }
                if (String.IsNullOrEmpty(orgao.Tipo)) orgao.Tipo = "O";
                orgaoApp.save(orgao);
                orgaos = orgaoApp.listAll();
                mensagem("Dados salvos com sucesso.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbbDescricao.Text))
            {
                orgao = orgaoApp.oneDescricao(cbbDescricao.Text);
                orgaoApp.delete(orgao);
                orgaos = orgaoApp.listAll();
                limpar();
                cbbDescricao.Text = "";
                cbbDescricao.Items.Clear();
                mensagem("Órgão excluído com sucesso.");
                foreach (Orgao org in orgaos)
                {
                    cbbDescricao.Items.Add(org.Descricao);
                }
            }
        }

        private void txbCNPJ_Leave(object sender, EventArgs e)
        {
            if (txbCNPJ.Text.Length > 13 && txbCNPJ.Text.Length < 19)
            {
                if (txbCNPJ.Text.Substring(2, 1) != ".")
                    txbCNPJ.Text = txbCNPJ.Text.Substring(0, 2) + "." +
                        txbCNPJ.Text.Substring(2, txbCNPJ.Text.Length - 2);

                if (txbCNPJ.Text.Substring(6, 1) != ".")
                    txbCNPJ.Text = txbCNPJ.Text.Substring(0, 6) + "." +
                        txbCNPJ.Text.Substring(6, txbCNPJ.Text.Length - 6);

                if (txbCNPJ.Text.Length > 10)
                {
                    if (txbCNPJ.Text.Substring(10, 1) != @"/")
                        txbCNPJ.Text = txbCNPJ.Text.Substring(0, 10) + @"/" +
                            txbCNPJ.Text.Substring(10, txbCNPJ.Text.Length - 10);
                }

                if (txbCNPJ.Text.Length > 15)
                {
                    if (txbCNPJ.Text.Substring(15, 1) != @"-")
                        txbCNPJ.Text = txbCNPJ.Text.Substring(0, 15) + @"-" +
                            txbCNPJ.Text.Substring(15, txbCNPJ.Text.Length - 15);
                }

                if (txbCNPJ.Text.Length > 18)
                {
                   txbCNPJ.Text = txbCNPJ.Text.Substring(0, 18);
                }
            }

            if (!String.IsNullOrEmpty(txbCNPJ.Text) && txbCNPJ.Text.Length > 18)
            {
                
                orgao = orgaoApp.oneCNPJ(txbCNPJ.Text);
                if (orgao.Id > 0)
                {
                    cbbDescricao.Text = orgao.Descricao;
                    txbSigla.Text = orgao.Sigla;
                    txbEndereco.Text = orgao.Endereco;
                    txbComplemento.Text = orgao.Complemento;
                    txbCEP.Text = orgao.CEP;
                    txbCidade.Text = orgao.Cidade;
                    cbbUF.Text = orgao.UF;
                    txbTelefone1.Text = orgao.Telefone1;
                    txbTelefone2.Text = orgao.Telefone2;
                    cbbUFResp.Text = orgao.EstadoResp;
                    txbMunicipioResp.Text = orgao.MunicipioResp;
                }
            }
        }

        private void cbbDescricao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                txbSigla.Focus();

            if (e.KeyCode == Keys.Down)
                txbCNPJ.Focus();

            if ((e.KeyValue > 47 && e.KeyValue < 58) || (e.KeyValue > 64 && e.KeyValue < 91)
                || (e.KeyValue > 96 && e.KeyValue < 123) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                cbbDescricao.Items.Clear();
                foreach (Orgao org in orgaos)
                {
                    if (String.IsNullOrEmpty(cbbDescricao.Text))
                        cbbDescricao.Items.Add(org.Descricao);
                    else
                        if (org.Descricao.ToUpper().Contains(cbbDescricao.Text.ToUpper()))
                            cbbDescricao.Items.Add(org.Descricao);
                }
                cbbDescricao.Select(cbbDescricao.Text.Length, 1);
            }
        }

        private void txbSigla_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                cbbDescricao.Focus();

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txbCNPJ.Focus();
        }

        private void txbCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txbEndereco.Focus();

            if (e.KeyCode == Keys.Up)
                cbbDescricao.Focus();
        }

        private void txbEndereco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txbComplemento.Focus();

            if (e.KeyCode == Keys.Up)
                txbCNPJ.Focus();
        }

        private void txbComplemento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txbCEP.Focus();

            if (e.KeyCode == Keys.Up)
                txbEndereco.Focus();
        }

        private void txbCEP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                txbCidade.Focus();

            if (e.KeyCode == Keys.Down)
                txbTelefone1.Focus();

            if (e.KeyCode == Keys.Up)
                txbComplemento.Focus();
        }

        private void txbCidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                cbbUF.Focus();

            if (e.KeyCode == Keys.Down)
                txbTelefone2.Focus();

            if (e.KeyCode == Keys.Up)
                txbComplemento.Focus();

             if (e.KeyCode == Keys.Left)
                txbCEP.Focus();
        }

        private void cbbUF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txbTelefone1.Focus();

            if (e.KeyCode == Keys.Up)
                txbComplemento.Focus();

            if (e.KeyCode == Keys.Right)
                btnSalvar.Focus();

            if (e.KeyCode == Keys.Left)
                txbCidade.Focus();
        }

        private void txbTelefone1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                txbTelefone2.Focus();

            if (e.KeyCode == Keys.Up)
                txbCEP.Focus();

            if (e.KeyCode == Keys.Down)
                rbtEstadual.Focus();
        }

        private void txbTelefone2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rbtEstadual.Focus();

            if (e.KeyCode == Keys.Right)
                btnSalvar.Focus();


            if (e.KeyCode == Keys.Left)
                txbTelefone1.Focus();

            if (e.KeyCode == Keys.Up)
                txbCidade.Focus();

            if (e.KeyCode == Keys.Down)
                cbbUFResp.Focus();
        }

        private void rbtEstadual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                cbbUFResp.Focus();

            if (e.KeyCode == Keys.Down)
                rbtMunicipal.Focus();

            if (e.KeyCode == Keys.Up)
                txbTelefone1.Focus();
        }

        private void cbbUFResp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rbtMunicipal.Focus();

            if (e.KeyCode == Keys.Down)
               txbMunicipioResp.Focus();

            if (e.KeyCode == Keys.Up)
                txbTelefone2.Focus();

            if (e.KeyCode == Keys.Left)
                rbtEstadual.Focus();

            if (e.KeyCode == Keys.Right)
                btnSalvar.Focus();
        }

        private void rbtMunicipal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                txbMunicipioResp.Focus();

            if (e.KeyCode == Keys.Up)
                rbtEstadual.Focus();
        }

        private void txbMunicipioResp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
                btnSalvar.Focus();

            if (e.KeyCode == Keys.Up)
                cbbUFResp.Focus();

            if (e.KeyCode == Keys.Left)
                rbtMunicipal.Focus();
        }

        private void limpar()
        {
            txbSigla.Text = "";
            txbEndereco.Text = "";
            txbComplemento.Text = "";
            txbCNPJ.Text = "";
            txbCEP.Text = "";
            txbCidade.Text = "";
            cbbUF.Text = "";
            txbTelefone1.Text = "";
            txbTelefone2.Text = "";
            cbbUFResp.Text = "";
            txbMunicipioResp.Text = "";
            rbtEstadual.Checked = false;
            rbtMunicipal.Checked = false;
        }

        private void cbbDescricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            preencher();
        }

        private void cbbDescricao_Leave(object sender, EventArgs e)
        {
            preencher();
        }

        private void preencher()
        {
            limpar();
            if (!String.IsNullOrEmpty(cbbDescricao.Text))
            {
                orgao = orgaoApp.oneDescricao(cbbDescricao.Text);
                if (orgao.Id > 0)
                {
                    txbSigla.Text = orgao.Sigla;
                    txbCNPJ.Text = orgao.CNPJ;
                    txbEndereco.Text = orgao.Endereco;
                    txbComplemento.Text = orgao.Complemento;
                    txbCEP.Text = orgao.CEP;
                    txbCidade.Text = orgao.Cidade;
                    cbbUF.Text = orgao.UF;
                    txbTelefone1.Text = orgao.Telefone1;
                    txbTelefone2.Text = orgao.Telefone2;
                    cbbUFResp.Text = orgao.EstadoResp;
                    txbMunicipioResp.Text = orgao.MunicipioResp;
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
            lblMensagem.Location = new System.Drawing.Point((456 - lblMensagem.Size.Width)/2 + 20, 60);
            tmrMensagem.Enabled = true;
            time = 0;
        }
    }
}
