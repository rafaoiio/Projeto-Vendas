using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_l_01_04
{
    internal class Venda
    {
        //------------tabela cliente--------------//

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Id { get; set; }

        //---------------------------------------//

        public int Qtde { get; set; }

        //-------------tabela produto------------//

        public string Descricao {  get; set; }

        public int Unidade { get; set; }

        public int Valor {  get; set; }

        //---------------------------------------//
        public int CodigoProduto {  get; set; }

        public int Codigovenda { get; set; }

        public int CodigoCliente {  get; set; }


        public void InserirVendaItens()
        {
            VendaSQL objSQL = new VendaSQL();
            objSQL.InserirVendaItens(this);
        }

        public void InserirVenda()
        {
            VendaSQL objSQL = new VendaSQL();
            objSQL.InserirVenda(this);
        }

        public void AlterarVenda()
          {
              VendaSQL objSQL = new VendaSQL();
              objSQL.AlterarVenda(this);
          }
        

        public void ExcluirVenda()
        {
            VendaSQL objSQL = new VendaSQL();
            objSQL.ExcluirVenda(this);
        }
      

        public bool ConsultaCliente()
        {
            VendaSQL objSQL = new VendaSQL();
            return objSQL.ConsultaCliente(this);
        }

        public bool ConsultaProduto()
        {
           VendaSQL objSQL = new VendaSQL();
            return objSQL.ConsultaProduto(this);
        }

        public DataTable ListaVenda()
        {
            VendaSQL objSQL = new VendaSQL();
            return objSQL.ListaVenda(this);
        }

        public bool ConsultaVendas()
        {
            VendaSQL objSQL = new VendaSQL();
            return objSQL.ConsultaVendas(this);
        }

         public bool VerificarCodigo()
        {
            VendaSQL objSQL = new VendaSQL();
            return objSQL.VerificarCodigo(this);
        }

        public void ExcluirVendaIten()
        {
            VendaSQL objSQL = new VendaSQL();
            objSQL.ExcluirVenda(this);
        }
    }
}
