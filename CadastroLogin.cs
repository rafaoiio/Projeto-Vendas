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
    public partial class CadastroLogin : Form
    {
        private Login objLogin;
        public CadastroLogin()
        {
            InitializeComponent();
            objLogin = new Login();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Cadastrar Usuário ?", "Configuração", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objLogin.Usuario = txtUsua.Text;
                objLogin.Senha = Util.geraSHA1(txtSenha.Text);
                objLogin.Nome = txtNome.Text;
                objLogin.Email = txtEmail.Text;
                objLogin.InserirLogin();
                LimparCampos();
            }

        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(" Deseja Alterar Usuário?", "Configuração", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {

            objLogin.Id = Convert.ToInt32(txtCodigo.Text);

            objLogin.Nome = txtNome.Text;
            objLogin.Email = txtEmail.Text;
            objLogin.Senha = Util.geraSHA1(txtSenha.Text);

            objLogin.AlterarLogin();
            LimparCampos();

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" Desja REALMENTE EXCLUIR USUÁRIOO???","Configuração", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                objLogin.Id = Convert.ToInt32(txtCodigo.Text);
                objLogin.ExcluirLogin();
                LimparCampos();
            }
        }

        public void LimparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtUsua.Clear();

            btn_cadastro.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            dataGridView1.DataSource = objLogin.ListaLogin();
        }

        private void txtUsua_Leave(object sender, EventArgs e)
        {
            objLogin.Usuario = txtUsua.Text;

            if(objLogin.ConsultaUsuario() == true)
            {
                txtCodigo.Text = objLogin.Id.ToString();
                txtEmail.Text = objLogin.Email;
                txtNome.Text = objLogin.Nome;

                btn_cadastro.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }


        private void CadastroLogin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objLogin.ListaLogin();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // ao clicar na célula ele faz alguma coisa
        {
            objLogin.Usuario = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();

            if (objLogin.ConsultaUsuario())
            {
                txtCodigo.Text = objLogin.Id.ToString();
                txtEmail.Text = objLogin.Email;
                txtUsua.Text = objLogin.Usuario;
                txtNome.Text = objLogin.Nome;


                btn_cadastro.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não foi Possível", "Alterar", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fazerLogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void telaPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduto fmproduto = new FormProduto();
            fmproduto.Show();
            this.Hide();
        }

        private void limpar_table_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void CadastroLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente cliente = new FormCliente();
            cliente.Show();
            this.Hide();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendas formVenda = new FormVendas();
            formVenda.Show(); this.Hide();
        }

    }
}
