using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula_l_01_04
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private Login objLogin;
        public Form1()
        {
            InitializeComponent();
            objLogin = new Login(); // espaço na memória para o objeto login.

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            objLogin.Usuario = textUsuario.Text;
            objLogin.Senha = Util.geraSHA1(textSenha.Text); // Chama a classe util pra o método GeraSha1.

            if(objLogin.VerificarLogin() == true) 
            {
                Principal frmPrincipal = new Principal();
                frmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Burrão");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ShowDialog();
        }
    }
}
