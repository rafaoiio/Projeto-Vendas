using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aula_l_01_04
{
    public partial class FormVendas : Form
    {
        private Venda objVenda;
        public FormVendas()
        {
            InitializeComponent();
            objVenda = new Venda();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroLogin CadastroLg = new CadastroLogin();
            CadastroLg.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente frmCliente = new FormCliente();
            frmCliente.Show();
            this.Hide();

        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduto frmProduto = new FormProduto();
            frmProduto.Show();
            this.Hide();
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

        private void FormVendas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ConsultarCliente_Click(object sender, EventArgs e)
        {
            objVenda.Nome = txtNomeCliente.Text;

            if (objVenda.ConsultaCliente())
            {
                txtCpf.Text = objVenda.Cpf.ToString();
                txtIdCliente.Text = objVenda.Id.ToString();
            }
        }

        private void btnConsultarProduto_Click(object sender, EventArgs e)
        {
            objVenda.Id = int.Parse(txtCodigoProduto.Text);

            if (objVenda.ConsultaProduto())
            {
                txtDescricao.Text = objVenda.Descricao.ToString();
                txtUnidade.Text = objVenda.Unidade.ToString();
                txtValor.Text = objVenda.Valor.ToString();

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja Cadastrar esta Venda?", "Configuração", MessageBoxButtons.YesNo
          , MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                objVenda.CodigoProduto = int.Parse(txtCodigoProduto.Text);
                objVenda.Qtde = int.Parse(txtQuantidade.Text);
                objVenda.Valor = int.Parse(ValorTotal.Text);
                objVenda.CodigoCliente = int.Parse(txtIdCliente.Text);


                if (objVenda.VerificarCodigo())
                {
                    objVenda.InserirVendaItens();
                     btnExcluir.Enabled = true;
                     
                }
                else
                {
                    objVenda.InserirVenda();
                    objVenda.InserirVendaItens();
                     btnExcluir.Enabled = true;
                   
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show(" Deseja excluir todos os Produtos da Venda? ", "Configuração", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    objVenda.Codigovenda = int.Parse(txtCodigoVenda.Text);
                    objVenda.CodigoCliente = int.Parse(txtIdCliente.Text);
                    objVenda.CodigoProduto = int.Parse(txtCodigoProduto.Text);

                    objVenda.ExcluirVenda();
                    

                    LimparCampos();
                }
                else
                {
                    DialogResult result2 = MessageBox.Show(" Deseja excluir apenas está VENDA? ", "Configuração", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    if(result2 == DialogResult.Yes)
                    {
                        objVenda.Codigovenda = int.Parse(txtCodigoVenda.Text);
                        objVenda.CodigoCliente = int.Parse(txtIdCliente.Text);
                        objVenda.CodigoProduto = int.Parse(txtCodigoProduto.Text);

                        objVenda.ExcluirVendaIten();
                    }
                }
            }
        }

        private void limpar_table_Click(object sender, EventArgs e)
        {
            LimparCampos();

            txtNomeCliente.Enabled = false;
            ConsultarCliente.Enabled = false;
            txtCpf.Enabled = false;
            txtIdCliente.Enabled = false;

            txtCodigoProduto.Enabled = false;
            btnConsultarProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            btnCadastrar.Enabled = false;
        }

        public void LimparCampos()
        {
            txtNomeCliente.Clear();
            txtCpf.Clear();
            txtIdCliente.Clear();
            txtCodigoProduto.Clear();
            txtDescricao.Clear();
            txtUnidade.Clear();
            txtValor.Clear();
            txtQuantidade.Clear();
            txtCodigoVenda.Clear();
            ValorTotal.Clear();

            btnCadastrar.Enabled = true;
            btnExcluir.Enabled = false;
           
        }

        private void txtCodigoVenda_Leave(object sender, EventArgs e)
        {
            objVenda.Codigovenda = Convert.ToInt32(txtCodigoVenda.Text);
            

            if (objVenda.VerificarCodigo() == true)
            {
                DialogResult result = MessageBox.Show(" Já existe esta venda, deseja continuar? ", "Configuração", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    txtIdCliente.Text = objVenda.Id.ToString();
                   

                    if (objVenda.ConsultaCliente())
                    {
                        txtIdCliente.Text = objVenda.Id.ToString();
                        txtNomeCliente.Text = objVenda.Nome;
                        txtCpf.Text = objVenda.Cpf;

                        txtNomeCliente.Enabled = false;
                        txtCodigoProduto.Enabled = true;
                        btnConsultarProduto.Enabled = true;
                        txtQuantidade.Enabled = true;
                        btnCadastrar.Enabled = true;
                        btnExcluir.Enabled = true;

                        txtCodigoProduto.Clear();
                        txtDescricao.Clear();
                        txtUnidade.Clear();
                        txtValor.Clear();
                        txtQuantidade.Clear();
                        ValorTotal.Clear();


                    }
                }
                else
                {
                    txtCodigoVenda.Clear();
                }
            }
            else
            {
                txtNomeCliente.Clear();
                txtCpf.Clear();
                txtIdCliente.Clear();

                txtNomeCliente.Enabled = true;
                ConsultarCliente.Enabled = true;
                txtCodigoProduto.Enabled = true;
                btnConsultarProduto.Enabled = true;
                txtQuantidade.Enabled = true;
                btnCadastrar.Enabled = true;

               btnExcluir.Enabled = false;
            }
        }


        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int valor = int.Parse(txtValor.Text);
            int quantidade = int.Parse(txtQuantidade.Text);

            int total = valor * quantidade;

            ValorTotal.Text = total.ToString();
        }


    }
}
