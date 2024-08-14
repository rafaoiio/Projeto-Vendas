using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula_l_01_04
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void btn_Gravar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.servidor = txt_Servidor.Text;
            Properties.Settings.Default.porta = txt_Porta.Text;
            Properties.Settings.Default.banco = txt_NomeBD.Text;
            Properties.Settings.Default.usuario = txt_Usuario.Text;
            Properties.Settings.Default.senha = txt_Senha.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            txt_Servidor.Text = Properties.Settings.Default.servidor;
            txt_Porta.Text =    Properties.Settings.Default.porta;
            txt_NomeBD.Text =   Properties.Settings.Default.banco;
            txt_Usuario.Text =  Properties.Settings.Default.usuario;
            txt_Senha.Text =    Properties.Settings.Default.senha;
        }
    }
}
