using Newtonsoft.Json;
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
    public partial class FormCliente : Form
    {
        private Cliente objCliente;
        public FormCliente()
        {
            InitializeComponent();
            objCliente = new Cliente();
        }

        private void FormCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = "https://viacep.com.br/ws/" + txtCep.Text + "/json/";
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();
            var res = JsonConvert.DeserializeObject<CEPJSON>(strResponse);
            txtRua.Text = res.logradouro;
            txtComple.Text = res.complemento;
            txtBairro.Text = res.bairro;
            txtEstado.Text = res.uf;
            txtCidade.Text = res.localidade;
        }

        public class CEPJSON
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }

        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtCelular.Clear();
            txtRg.Clear();
            txtCpf.Clear();
            txtCep.Clear();
            txtRua.Clear();
            txtNume.Clear();
            txtComple.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();

            btn_Cadastrar.Enabled = true;
            btn_Excluir.Enabled = false;
            btn_Alterar.Enabled = false;

            dataGridView1.DataSource = objCliente.ListaCliente();
        }

        private void telaPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }

        private void sairDoSistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fazerLogoffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void fazerLogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduto frmProduto = new FormProduto();
            frmProduto.Show();
            this.Hide();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Cadastrar este Cliente?", "Configuração", MessageBoxButtons.YesNo
          , MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objCliente.Nome = txtNome.Text;
                objCliente.Email = txtEmail.Text;
                objCliente.Rg = txtRg.Text;
                objCliente.Telefone = txtCelular.Text;
                objCliente.Cpf =txtCpf.Text;
                objCliente.Cep = (int)Convert.ToInt64(txtCep.Text);
                objCliente.Rua = txtRua.Text;
                objCliente.Numero = txtNume.Text;
                objCliente.Complemento = txtComple.Text;
                objCliente.Bairro = txtBairro.Text;
                objCliente.Cidade = txtCidade.Text;
                objCliente.Uf = txtEstado.Text;


                objCliente.InserirCliente();
                LimparCampos();

            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja AlTERAR produto?", "Configuração", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objCliente.Nome = txtNome.Text;
                objCliente.Email = txtEmail.Text;
                objCliente.Rg = txtRg.Text;
                objCliente.Telefone = txtCelular.Text;
                objCliente.Cpf = txtCpf.Text;
                objCliente.Cep = (int)Convert.ToInt64(txtCep.Text);
                objCliente.Rua = txtRua.Text;
                objCliente.Numero = txtNume.Text;
                objCliente.Complemento = txtComple.Text;
                objCliente.Bairro = txtBairro.Text;
                objCliente.Cidade = txtCidade.Text;
                objCliente.Uf = txtEstado.Text;

                objCliente.AlterarCliente();
                LimparCampos();
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" Desja realmente EXCLUIR produto? ", "Configuração", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objCliente.Nome = txtNome.Text;
                objCliente.ExcluirCliente();

                LimparCampos();
            }
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            objCliente.Nome = txtNome.Text;

            if (objCliente.ConsultaCliente())
            {
                txtNome.Text = objCliente.Nome.ToString();
                txtCelular.Text = objCliente.Telefone.ToString();
                txtEmail.Text = objCliente.Email.ToString();
                txtRg.Text = objCliente.Rg.ToString();
                txtCpf.Text = objCliente.Cpf.ToString();
                txtCep.Text = objCliente.Cep.ToString();
                txtRua.Text = objCliente.Rua.ToString();
                txtNume.Text = objCliente.Numero.ToString();
                txtComple.Text = objCliente.Complemento.ToString();
                txtBairro.Text = objCliente.Bairro.ToString();
                txtCidade.Text = objCliente.Cidade.ToString();
                txtEstado.Text = objCliente.Uf.ToString();

                btn_Cadastrar.Enabled = false;
                btn_Alterar.Enabled = true;
                btn_Excluir.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objCliente.Nome = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();

            if (objCliente.ConsultaCliente())
            {
                txtNome.Text = objCliente.Nome.ToString();
                txtCelular.Text = objCliente.Telefone.ToString();
                txtEmail.Text = objCliente.Email.ToString();
                txtRg.Text = objCliente.Rg.ToString();
                txtCpf.Text = objCliente.Cpf.ToString();
                txtCep.Text = objCliente.Cep.ToString();
                txtRua.Text = objCliente.Rua.ToString();
                txtNume.Text = objCliente.Numero.ToString();
                txtComple.Text = objCliente.Complemento.ToString();
                txtBairro.Text = objCliente.Bairro.ToString();
                txtCidade.Text = objCliente.Cidade.ToString();
                txtEstado.Text = objCliente.Uf.ToString();



                btn_Cadastrar.Enabled = false;
                btn_Alterar.Enabled = true;
                btn_Excluir.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não foi possível", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objCliente.ListaCliente();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroLogin usuario = new CadastroLogin();
            usuario.Show();
            this.Hide();
        }

        private void limpar_table_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendas formVenda = new FormVendas();
            formVenda.Show(); this.Hide();
        }
    }
}
