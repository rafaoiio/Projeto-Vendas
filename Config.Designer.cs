namespace Aula_l_01_04
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Servidor = new System.Windows.Forms.TextBox();
            this.txt_Porta = new System.Windows.Forms.TextBox();
            this.txt_NomeBD = new System.Windows.Forms.TextBox();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.txt_Senha = new System.Windows.Forms.TextBox();
            this.btn_Gravar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans", 11.25F);
            this.label1.Location = new System.Drawing.Point(264, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Porta -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 11.25F);
            this.label2.Location = new System.Drawing.Point(25, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuário -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans", 11.25F);
            this.label3.Location = new System.Drawing.Point(22, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Servidor -";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans", 11.25F);
            this.label4.Location = new System.Drawing.Point(22, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nome Banco de Dados -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Sans", 11.25F);
            this.label5.Location = new System.Drawing.Point(226, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Senha -";
            // 
            // txt_Servidor
            // 
            this.txt_Servidor.Location = new System.Drawing.Point(95, 66);
            this.txt_Servidor.Multiline = true;
            this.txt_Servidor.Name = "txt_Servidor";
            this.txt_Servidor.Size = new System.Drawing.Size(146, 20);
            this.txt_Servidor.TabIndex = 5;
            // 
            // txt_Porta
            // 
            this.txt_Porta.Location = new System.Drawing.Point(325, 66);
            this.txt_Porta.Multiline = true;
            this.txt_Porta.Name = "txt_Porta";
            this.txt_Porta.Size = new System.Drawing.Size(105, 20);
            this.txt_Porta.TabIndex = 6;
            // 
            // txt_NomeBD
            // 
            this.txt_NomeBD.Location = new System.Drawing.Point(204, 126);
            this.txt_NomeBD.Multiline = true;
            this.txt_NomeBD.Name = "txt_NomeBD";
            this.txt_NomeBD.Size = new System.Drawing.Size(226, 20);
            this.txt_NomeBD.TabIndex = 7;
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(103, 172);
            this.txt_Usuario.Multiline = true;
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(109, 20);
            this.txt_Usuario.TabIndex = 8;
            // 
            // txt_Senha
            // 
            this.txt_Senha.Location = new System.Drawing.Point(292, 172);
            this.txt_Senha.Multiline = true;
            this.txt_Senha.Name = "txt_Senha";
            this.txt_Senha.Size = new System.Drawing.Size(138, 20);
            this.txt_Senha.TabIndex = 9;
            // 
            // btn_Gravar
            // 
            this.btn_Gravar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Gravar.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Gravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Gravar.Font = new System.Drawing.Font("Rubik", 8.25F);
            this.btn_Gravar.Location = new System.Drawing.Point(303, 223);
            this.btn_Gravar.Name = "btn_Gravar";
            this.btn_Gravar.Size = new System.Drawing.Size(127, 25);
            this.btn_Gravar.TabIndex = 10;
            this.btn_Gravar.Text = "Gravar";
            this.btn_Gravar.UseVisualStyleBackColor = false;
            this.btn_Gravar.Click += new System.EventHandler(this.btn_Gravar_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 263);
            this.Controls.Add(this.btn_Gravar);
            this.Controls.Add(this.txt_Senha);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.txt_NomeBD);
            this.Controls.Add(this.txt_Porta);
            this.Controls.Add(this.txt_Servidor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Servidor;
        private System.Windows.Forms.TextBox txt_Porta;
        private System.Windows.Forms.TextBox txt_NomeBD;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.TextBox txt_Senha;
        private System.Windows.Forms.Button btn_Gravar;
    }
}