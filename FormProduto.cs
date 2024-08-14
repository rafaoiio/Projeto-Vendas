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
    public partial class FormProduto : Form
    {
        private Produto objProduto;
        public FormProduto()
        {
            InitializeComponent();
            objProduto = new Produto();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja cadastrar Produto?", "Configuração", MessageBoxButtons.YesNo
            , MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objProduto.Descricao = txtDescricao.Text;
                objProduto.Unidade = Convert.ToInt32(txtQuantidade.Text);
                objProduto.Valor = Convert.ToInt32(txtValor.Text);

                if (objProduto.Unidade != 1)
                {
                    MessageBox.Show("Insira apenas 1 unidade de produto", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objProduto.InserirProduto();
                    LimparCampos();
                }



            }

        }


        public void LimparCampos()
         {
            txtDescricao.Clear();
            txtId.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();

           btn_cadastro.Enabled = true;
           btn_Excluir.Enabled = false;
           btn_Alterar.Enabled = false;

            dataGridView1.DataSource = objProduto.ListaProduto();

        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja AlTERAR produto?", "Configuração", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objProduto.Id = Convert.ToInt32(txtId.Text);
                objProduto.Descricao = txtDescricao.Text;
                objProduto.Unidade = Convert.ToInt32(txtQuantidade.Text);
                objProduto.Valor = Convert.ToInt32(txtValor.Text);

                objProduto.AlterarProduto();
                LimparCampos();

            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
         DialogResult result = MessageBox.Show(" Desja realmente EXCLUIR produto? ", "Configuração", MessageBoxButtons.YesNo,
         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                objProduto.Descricao = txtDescricao.Text;
                objProduto.ExcluirProduto();
                LimparCampos();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            objProduto.Descricao = txtDescricao.Text;

            if (objProduto.ConsultaProduto())
            {
                txtId.Text = objProduto.Id.ToString();
                txtQuantidade.Text = objProduto.Unidade.ToString();
                txtValor.Text = objProduto.Valor.ToString();

                btn_cadastro.Enabled = false;
                btn_Alterar.Enabled = true;
                btn_Excluir.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objProduto.Descricao = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();

            if (objProduto.ConsultaProduto())
            {
                txtDescricao.Text = objProduto.Descricao;
                txtId.Text = objProduto.Id.ToString();
                txtQuantidade.Text = objProduto.Unidade.ToString();
                txtValor.Text = objProduto.Valor.ToString();
                


                btn_cadastro.Enabled = false;
                btn_Alterar.Enabled = true;
                btn_Excluir.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não foi possível", "ELE" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objProduto.ListaProduto();
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroLogin CadastroLg = new CadastroLogin();
            CadastroLg.Show();
            this.Hide();
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fazerLogoofToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void limpar_table_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente frmCliente = new FormCliente();
            frmCliente.Show();
            this.Hide();

        }

        private void FormProduto_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendas formVenda = new FormVendas();
            formVenda.Show(); this.Hide();
        }
    }
}
