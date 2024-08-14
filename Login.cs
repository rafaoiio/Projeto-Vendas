using Aula_l_01_04;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_l_01_04
{
    internal class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public bool VerificarLogin() // Método // MVC 
        {
            //LoginSQL objSQL;
            //objSQL = new LoginSQL();

            LoginSQL objSQL = new LoginSQL();
            return objSQL.VerificarLogin(this);
        }

        public void InserirLogin()
        {
            LoginSQL objSQL = new LoginSQL();
            objSQL.InserirLogin(this);
        }

        public void AlterarLogin()
        {
            LoginSQL objSQL = new LoginSQL();
            objSQL.AlterarLogin(this);
        }

        public void ExcluirLogin()
        {
            LoginSQL objSQL = new LoginSQL();
            objSQL.ExcluirLogin(this);
        }

        public bool ConsultaUsuario() // usa o return para literalmente
                                      // retornar algo (sim ou não) para o função/método
                                      // public bool
        {
            LoginSQL objSQL = new LoginSQL();
            return objSQL.ConsultaUsuario(this);
        }

        public DataTable ListaLogin()
        {
            LoginSQL objSQL = new LoginSQL();
            return objSQL.ListaLogin(this);
        }
    }
}