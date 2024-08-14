using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_l_01_04
{
    internal class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int Unidade { get; set; }

        public double Valor {  get; set; }


        public void InserirProduto() { 
        
            ProdutoSQL objSQL = new ProdutoSQL();
            objSQL.InserirProduto(this);

        }

        public void AlterarProduto()
        {
            ProdutoSQL objSQL = new ProdutoSQL();
            objSQL.AlterarProduto(this);
        }

        public void ExcluirProduto()
        {
            ProdutoSQL objSQL = new ProdutoSQL();
            objSQL.ExcluirProduto(this);
        }

        public bool ConsultaProduto()
        {
            ProdutoSQL objSQL = new ProdutoSQL();
            return objSQL.ConsultaProduto(this);
        }

        public DataTable ListaProduto()
        {
            ProdutoSQL objSQL = new ProdutoSQL();
            return objSQL.ListaProduto(this);
        }
    }
}
