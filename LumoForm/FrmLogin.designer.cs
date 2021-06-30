namespace LumoForm
{
    partial class FrmLogin
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
            this.lblNome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LOGINtextBox = new System.Windows.Forms.TextBox();
            this.SENHAtextBox = new System.Windows.Forms.TextBox();
            this.SENHAlabel = new System.Windows.Forms.Label();
            this.ENTRARbutton = new System.Windows.Forms.Button();
            this.CANCELARbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CONFIRMAtextBox = new System.Windows.Forms.TextBox();
            this.CONFIRMAlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.LightGray;
            this.lblNome.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNome.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.Red;
            this.lblNome.Location = new System.Drawing.Point(195, 12);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(92, 31);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Acesso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Login:";
            // 
            // LOGINtextBox
            // 
            this.LOGINtextBox.Location = new System.Drawing.Point(152, 81);
            this.LOGINtextBox.Name = "LOGINtextBox";
            this.LOGINtextBox.Size = new System.Drawing.Size(181, 20);
            this.LOGINtextBox.TabIndex = 3;
            this.LOGINtextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LOGINtextBox_KeyUp);
            this.LOGINtextBox.Leave += new System.EventHandler(this.LOGINtextBox_Leave);
            // 
            // SENHAtextBox
            // 
            this.SENHAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENHAtextBox.Location = new System.Drawing.Point(152, 137);
            this.SENHAtextBox.Name = "SENHAtextBox";
            this.SENHAtextBox.PasswordChar = '*';
            this.SENHAtextBox.Size = new System.Drawing.Size(181, 22);
            this.SENHAtextBox.TabIndex = 5;
            this.SENHAtextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SENHAtextBox_KeyUp);
            // 
            // SENHAlabel
            // 
            this.SENHAlabel.AutoSize = true;
            this.SENHAlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SENHAlabel.Location = new System.Drawing.Point(149, 118);
            this.SENHAlabel.Name = "SENHAlabel";
            this.SENHAlabel.Size = new System.Drawing.Size(50, 16);
            this.SENHAlabel.TabIndex = 4;
            this.SENHAlabel.Text = "Senha:";
            // 
            // ENTRARbutton
            // 
            this.ENTRARbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ENTRARbutton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTRARbutton.Location = new System.Drawing.Point(152, 238);
            this.ENTRARbutton.Name = "ENTRARbutton";
            this.ENTRARbutton.Size = new System.Drawing.Size(75, 23);
            this.ENTRARbutton.TabIndex = 6;
            this.ENTRARbutton.Text = "Entrar";
            this.ENTRARbutton.UseVisualStyleBackColor = false;
            this.ENTRARbutton.Click += new System.EventHandler(this.ENTRARbutton_Click);
            // 
            // CANCELARbutton
            // 
            this.CANCELARbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CANCELARbutton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANCELARbutton.Location = new System.Drawing.Point(258, 238);
            this.CANCELARbutton.Name = "CANCELARbutton";
            this.CANCELARbutton.Size = new System.Drawing.Size(75, 23);
            this.CANCELARbutton.TabIndex = 7;
            this.CANCELARbutton.Text = "Cancelar";
            this.CANCELARbutton.UseVisualStyleBackColor = false;
            this.CANCELARbutton.Click += new System.EventHandler(this.CANCELARbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LumoForm.Properties.Resources.Lumo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 249);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CONFIRMAtextBox
            // 
            this.CONFIRMAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONFIRMAtextBox.Location = new System.Drawing.Point(152, 198);
            this.CONFIRMAtextBox.Name = "CONFIRMAtextBox";
            this.CONFIRMAtextBox.PasswordChar = '*';
            this.CONFIRMAtextBox.Size = new System.Drawing.Size(181, 22);
            this.CONFIRMAtextBox.TabIndex = 9;
            // 
            // CONFIRMAlabel
            // 
            this.CONFIRMAlabel.AutoSize = true;
            this.CONFIRMAlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONFIRMAlabel.Location = new System.Drawing.Point(149, 179);
            this.CONFIRMAlabel.Name = "CONFIRMAlabel";
            this.CONFIRMAlabel.Size = new System.Drawing.Size(106, 16);
            this.CONFIRMAlabel.TabIndex = 8;
            this.CONFIRMAlabel.Text = "Confirma Senha:";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(355, 273);
            this.ControlBox = false;
            this.Controls.Add(this.CONFIRMAtextBox);
            this.Controls.Add(this.CONFIRMAlabel);
            this.Controls.Add(this.CANCELARbutton);
            this.Controls.Add(this.ENTRARbutton);
            this.Controls.Add(this.SENHAtextBox);
            this.Controls.Add(this.SENHAlabel);
            this.Controls.Add(this.LOGINtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LOGINtextBox;
        private System.Windows.Forms.TextBox SENHAtextBox;
        private System.Windows.Forms.Label SENHAlabel;
        private System.Windows.Forms.Button ENTRARbutton;
        private System.Windows.Forms.Button CANCELARbutton;
        private System.Windows.Forms.TextBox CONFIRMAtextBox;
        private System.Windows.Forms.Label CONFIRMAlabel;
    }
}