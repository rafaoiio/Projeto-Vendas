using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_l_01_04
{
    internal class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public int Cep { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf {  get; set; }

        public void InserirCliente()
        {
            ClienteSQL objSQL = new ClienteSQL();
            objSQL.InserirCliente(this);
        }

        public void AlterarCliente()
        {
            ClienteSQL objSQL = new ClienteSQL();
            objSQL.AlterarCliente(this);
        }

        public void ExcluirCliente()
        {
            ClienteSQL objSQL = new ClienteSQL();
            objSQL.ExcluirCliente(this);
        }

        public bool ConsultaCliente()
        {
            ClienteSQL objSQL = new ClienteSQL();
            return objSQL.ConsultaCliente(this);
        }

        public DataTable ListaCliente()
        {
           ClienteSQL objSQL = new ClienteSQL();
            return objSQL.ListaCliente(this);
        }
    }
}
