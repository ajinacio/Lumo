using Lumo.App;
using Lumo.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LumoForm
{
    public partial class FrmAvaliacao : Form
    {
        Usuario usuario;
        int localX;
        int localY;
        Orgao orgao;
        OrgaoApp orgaoApp = new OrgaoApp();
        Periodo periodo;
        List<Periodo> lperiodo;
        PeriodoApp periodoApp = new PeriodoApp();
        OrgaoItem orgaoItem;
        List<OrgaoItem> lorgaoItems;
        OrgaoItemApp orgaoItemApp = new OrgaoItemApp();
        Item item;
        List<Item> litem;
        ItemApp itemApp = new ItemApp();
        List<OrgaoPessoa> orgaoPessoas = new List<OrgaoPessoa>();
        OrgaoPessoaApp orgaoPessoaApp = new OrgaoPessoaApp();
        PessoaApp pessoaApp = new PessoaApp();
        Pessoa pessoa;
        ConfigApp configApp = new ConfigApp();
        Config config;

        public FrmAvaliacao(Usuario _usuario, int x, int y)
        {
            InitializeComponent();
            usuario = _usuario;
            localX = x;
            localY = y;
            config = configApp.configuracao();
        }

        private void FrmAvaliacao_Load(object sender, EventArgs e)
        {
            cbbOrgao.Items.Clear();
            foreach (Orgao orgao in orgaoApp.listAll())
                cbbOrgao.Items.Add(orgao.Descricao);

            this.Size = new Size(600, 200);
            panel1.Size = new Size(580, 180);
            this.Location = new Point(localX + 14, localY - 20);
            panel1.Controls.Remove(tbcAvaliacao);
            cbbDescrAnalise.Enabled = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(600, 200);
            panel1.Size = new Size(580, 180);
            this.Location = new Point(localX + 14, localY - 20);
            panel1.Controls.Remove(tbcAvaliacao);
            btnAnalisar.Enabled = true;
            cbbOrgao.Enabled = true;
            cbbDescrAnalise.Enabled = true;
            limpar();
        }

        private void limpar()
        {
            cbbOrgao.Text = "";
            cbbDescrAnalise.Text = "";
            chbRepres.Checked = false;

            rdb0101Sim.Checked = false;
            rdb0101Nao.Checked = false;
            rdb0102Sim.Checked = false;
            rdb0102Nao.Checked = false;
            rdb0103Sim.Checked = false;
            rdb0103Nao.Checked = false;
            rdb0104Sim.Checked = false;
            rdb0104Nao.Checked = false;

            rdb0201Sim.Checked = false;
            rdb0201Nao.Checked = false;
            rdb0202Sim.Checked = false;
            rdb0202Nao.Checked = false;
            rdb0203Sim.Checked = false;
            rdb0203Nao.Checked = false;

            rdb0301Sim.Checked = false;
            rdb0301Nao.Checked = false;
            rdb0302Sim.Checked = false;
            rdb0302Nao.Checked = false;
            rdb0303Sim.Checked = false;
            rdb0303Nao.Checked = false;
            rdb0304Sim.Checked = false;
            rdb0304Nao.Checked = false;
            rdb0305Sim.Checked = false;
            rdb0305Nao.Checked = false;
            rdb0306Sim.Checked = false;
            rdb0306Nao.Checked = false;
            rdb0307Sim.Checked = false;
            rdb0307Nao.Checked = false;

            rdb0401Sim.Checked = false;
            rdb0401Nao.Checked = false;
            rdb0402Sim.Checked = false;
            rdb0402Nao.Checked = false;
            rdb0403Sim.Checked = false;
            rdb0403Nao.Checked = false;
            rdb0404Sim.Checked = false;
            rdb0404Nao.Checked = false;
            rdb0405Sim.Checked = false;
            rdb0405Nao.Checked = false;
            rdb0406Sim.Checked = false;
            rdb0406Nao.Checked = false;

            rdb0501Sim.Checked = false;
            rdb0501Nao.Checked = false;
            rdb0502Sim.Checked = false;
            rdb0502Nao.Checked = false;
            rdb0503Sim.Checked = false;
            rdb0503Nao.Checked = false;
            rdb0504Sim.Checked = false;
            rdb0504Nao.Checked = false;
            rdb0505Sim.Checked = false;
            rdb0505Nao.Checked = false;
            rdb0506Sim.Checked = false;
            rdb0506Nao.Checked = false;
            rdb0507Sim.Checked = false;
            rdb0507Nao.Checked = false;
            rdb0508Sim.Checked = false;
            rdb0508Nao.Checked = false;
            rdb0509Sim.Checked = false;
            rdb0509Nao.Checked = false;

            rdb0601Sim.Checked = false;
            rdb0601Nao.Checked = false;
            rdb0602Sim.Checked = false;
            rdb0602Nao.Checked = false;
            rdb0603Sim.Checked = false;
            rdb0603Nao.Checked = false;
            rdb0604Sim.Checked = false;
            rdb0604Nao.Checked = false;
            rdb0605Sim.Checked = false;
            rdb0605Nao.Checked = false;
            rdb0606Sim.Checked = false;
            rdb0606Nao.Checked = false;
            rdb0607Sim.Checked = false;
            rdb0607Nao.Checked = false;

            rdb0701Sim.Checked = false;
            rdb0701Nao.Checked = false;
            rdb0702Sim.Checked = false;
            rdb0702Nao.Checked = false;
            rdb0703Sim.Checked = false;
            rdb0703Nao.Checked = false;

            rdb0801Sim.Checked = false;
            rdb0801Nao.Checked = false;
            rdb0802Sim.Checked = false;
            rdb0802Nao.Checked = false;
            rdb0803Sim.Checked = false;
            rdb0803Nao.Checked = false;
            rdb0804Sim.Checked = false;
            rdb0804Nao.Checked = false;
            rdb0805Sim.Checked = false;
            rdb0805Nao.Checked = false;

            rdb0901Sim.Checked = false;
            rdb0901Nao.Checked = false;
            rdb0902Sim.Checked = false;
            rdb0902Nao.Checked = false;
            rdb0903Sim.Checked = false;
            rdb0903Nao.Checked = false;

            rdb1001Sim.Checked = false;
            rdb1001Nao.Checked = false;
            rdb1002Sim.Checked = false;
            rdb1002Nao.Checked = false;
            rdb1003Sim.Checked = false;
            rdb1003Nao.Checked = false;
            rdb1004Sim.Checked = false;
            rdb1004Nao.Checked = false;
            rdb1005Sim.Checked = false;
            rdb1005Nao.Checked = false;
            rdb1006Sim.Checked = false;
            rdb1006Nao.Checked = false;
            rdb1007Sim.Checked = false;
            rdb1007Nao.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cod;
            RadioButton rdbSim;
            RadioButton rdbNao;
            if (cbbOrgao.Text != "" && cbbDescrAnalise.Text != "")
            {
                this.Size = new Size(600, 520);
                panel1.Size = new Size(580, 500);
                this.Location = new Point(localX + 14, localY - 180);
                panel1.Controls.Add(tbcAvaliacao);
                btnAnalisar.Enabled = false;
                cbbOrgao.Enabled = false;
                cbbDescrAnalise.Enabled = false;
            }

            orgao = orgaoApp.oneDescricao(cbbOrgao.Text);
            periodo = periodoApp.oneOrgaoDescricao(orgao.Id, cbbDescrAnalise.Text);

            if (periodo.Id > 0)
            {
                lorgaoItems = orgaoItemApp.listOrgaoPeriodo(orgaoApp.oneDescricao(cbbOrgao.Text).Id,
                    periodo.Id);

                foreach (OrgaoItem orgitem in lorgaoItems)
                {
                    item = itemApp.oneId(orgitem.item);

                    cod = "rdb" + item.Codigo.Substring(0, 2) + item.Codigo.Substring(3, 2) + "Sim";                 
                    rdbSim = this.Controls.Find(cod, true)[0] as RadioButton;

                    cod = "rdb" + item.Codigo.Substring(0, 2) + item.Codigo.Substring(3, 2) + "Nao";
                    rdbNao = this.Controls.Find(cod, true)[0] as RadioButton;

                    if (orgitem.Avaliacao == "S")
                        rdbSim.Checked = true;
                    else
                        rdbNao.Checked = true;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            RadioButton rdb;
            if (cbbOrgao.Text != "" && cbbDescrAnalise.Text != "")
            {
                periodo = periodoApp.oneOrgaoDescricao(orgao.Id, cbbDescrAnalise.Text);
                if (periodo.Id == 0)
                {
                    periodo.Descricao = cbbDescrAnalise.Text;
                    periodo.orgao = orgaoApp.oneId(orgao.Id);
                }

                if (chbRepres.Checked)
                    periodo.Representacao = "S";
                else
                    periodo.Representacao = "N";
                periodoApp.save(periodo);

                periodo = periodoApp.oneOrgaoDescricao(orgao.Id, cbbDescrAnalise.Text);

                litem = itemApp.listAnalitico();
                string cod;
                foreach (Item item in litem)
                {
                    cod = "rdb" + item.Codigo.Substring(0, 2) + item.Codigo.Substring(3, 2) + "Sim";

                    orgaoItem = orgaoItemApp.oneItem(item.Id, periodo.orgao.Id, periodo.Id);
                    if (orgaoItem.item == 0)
                    {
                        orgaoItem.orgao = orgao.Id;
                        orgaoItem.periodo = periodo.Id;
                        orgaoItem.item = item.Id;
                    }

                    rdb = this.Controls.Find(cod, true)[0] as RadioButton;

                    if (rdb.Checked)
                        orgaoItem.Avaliacao = "S";
                    else
                        orgaoItem.Avaliacao = "N";

                    orgaoItemApp.save(orgaoItem);
                }
            }
        }

        private void cbbOrgao_TextChanged(object sender, EventArgs e)
        {
            if (cbbOrgao.Text != "")
            {
                cbbDescrAnalise.Enabled = true;
                cbbDescrAnalise.Items.Clear();
                lperiodo = periodoApp.listOrgao(orgaoApp.oneDescricao(cbbOrgao.Text).Id);
                foreach (Periodo per in lperiodo)
                    cbbDescrAnalise.Text = per.Descricao;
            }
        }

        private void cbbOrgao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cbbDescrAnalise.Focus();
        }

    }
}
