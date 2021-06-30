
namespace LumoForm
{
    partial class FrmCadUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpaSenha = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txbCaminho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbCargo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrMensagem = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.lblMensagem);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnLimpaSenha);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txbCaminho);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbbCargo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbLogin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 355);
            this.panel1.TabIndex = 0;
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMensagem.Location = new System.Drawing.Point(108, 58);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(84, 16);
            this.lblMensagem.TabIndex = 41;
            this.lblMensagem.Text = "Mensagem";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(25, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 39);
            this.panel3.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(109, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cadastro de Usuários";
            // 
            // btnLimpaSenha
            // 
            this.btnLimpaSenha.BackColor = System.Drawing.Color.Maroon;
            this.btnLimpaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpaSenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpaSenha.Location = new System.Drawing.Point(25, 311);
            this.btnLimpaSenha.Name = "btnLimpaSenha";
            this.btnLimpaSenha.Size = new System.Drawing.Size(133, 26);
            this.btnLimpaSenha.TabIndex = 10;
            this.btnLimpaSenha.Text = "Limpa Senha";
            this.btnLimpaSenha.UseVisualStyleBackColor = false;
            this.btnLimpaSenha.Click += new System.EventHandler(this.btnLimpaSenha_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnFechar);
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Controls.Add(this.btnExcluir);
            this.panel2.Controls.Add(this.btnLimpar);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Location = new System.Drawing.Point(345, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 223);
            this.panel2.TabIndex = 9;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(16, 176);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(74, 26);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(16, 136);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(74, 26);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Voltar";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(16, 96);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(74, 26);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(16, 56);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(74, 26);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(16, 16);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(74, 26);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txbCaminho
            // 
            this.txbCaminho.Location = new System.Drawing.Point(25, 262);
            this.txbCaminho.Name = "txbCaminho";
            this.txbCaminho.Size = new System.Drawing.Size(291, 20);
            this.txbCaminho.TabIndex = 7;
            this.txbCaminho.Text = "C:\\";
            this.txbCaminho.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbCaminho_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Onde vão ficar os arquivos";
            // 
            // cbbCargo
            // 
            this.cbbCargo.FormattingEnabled = true;
            this.cbbCargo.Items.AddRange(new object[] {
            "Auditor",
            "Estagiário",
            "Área Meio"});
            this.cbbCargo.Location = new System.Drawing.Point(25, 212);
            this.cbbCargo.Name = "cbbCargo";
            this.cbbCargo.Size = new System.Drawing.Size(291, 21);
            this.cbbCargo.TabIndex = 5;
            this.cbbCargo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbbCargo_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cargo";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(25, 162);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(291, 20);
            this.txbNome.TabIndex = 3;
            this.txbNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbNome_KeyUp);
            this.txbNome.Leave += new System.EventHandler(this.txbNome_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // txbLogin
            // 
            this.txbLogin.Location = new System.Drawing.Point(25, 112);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(125, 20);
            this.txbLogin.TabIndex = 1;
            this.txbLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbLogin_KeyUp);
            this.txbLogin.Leave += new System.EventHandler(this.txbLogin_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // tmrMensagem
            // 
            this.tmrMensagem.Interval = 3000;
            this.tmrMensagem.Tick += new System.EventHandler(this.tmrMensagem_Tick);
            // 
            // FrmCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(488, 375);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCadUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCadUsuario";
            this.Load += new System.EventHandler(this.FrmCadUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpaSenha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txbCaminho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbCargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tmrMensagem;
    }
}