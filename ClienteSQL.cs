using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula_l_01_04
{
    internal class ClienteSQL : conexao
    {
        public void InserirCliente(Cliente obj)
        {
            try
            {
                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();

                Comando.CommandText = @"INSERT INTO cliente (id, nome, cpf, rg, telefone, email,
                cep, rua, numero, complemento, bairro, cidade, uf)
                VALUES ( @id, @nome, @cpf, @rg, @telefone, @email,
                @cep, @rua, @numero, @complemento, @bairro, @cidade, @uf)";

                Comando.Parameters.Add(new MySqlParameter("@Id", obj.Id));
                Comando.Parameters.Add(new MySqlParameter("@Nome", obj.Nome));
                Comando.Parameters.Add(new MySqlParameter("@Cpf", obj.Cpf));
                Comando.Parameters.Add(new MySqlParameter("@Rg", obj.Rg));
                Comando.Parameters.Add(new MySqlParameter("@Telefone", obj.Telefone));
                Comando.Parameters.Add(new MySqlParameter("@Email", obj.Email));
                Comando.Parameters.Add(new MySqlParameter("@Cep", obj.Cep));
                Comando.Parameters.Add(new MySqlParameter("@Rua", obj.Rua));
                Comando.Parameters.Add(new MySqlParameter("@Numero", obj.Numero));
                Comando.Parameters.Add(new MySqlParameter("@Complemento", obj.Complemento));
                Comando.Parameters.Add(new MySqlParameter("@Bairro", obj.Bairro));
                Comando.Parameters.Add(new MySqlParameter("@Cidade", obj.Cidade));
                Comando.Parameters.Add(new MySqlParameter("@Uf", obj.Uf));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();
                MessageBox.Show("Produto Inserido", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch(MySqlException ex)
            {
                Conn.Close();
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AlterarCliente(Cliente obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"UPDATE cliente SET id = @id, nome = @nome, cpf = @cpf,
                rg = @rg, telefone = @telefone, email = @email, cep = @cep, rua = @rua, numero = @numero, complemento = @complemento,
                bairro = @bairro, cidade = @cidade, uf = @uf";

                Comando.Parameters.Add(new MySqlParameter("@Id", obj.Id));
                Comando.Parameters.Add(new MySqlParameter("@Nome", obj.Nome));
                Comando.Parameters.Add(new MySqlParameter("@Cpf", obj.Cpf));
                Comando.Parameters.Add(new MySqlParameter("@Rg", obj.Rg));
                Comando.Parameters.Add(new MySqlParameter("@Telefone", obj.Telefone));
                Comando.Parameters.Add(new MySqlParameter("@Email", obj.Email));
                Comando.Parameters.Add(new MySqlParameter("@Cep", obj.Cep));
                Comando.Parameters.Add(new MySqlParameter("@Rua", obj.Rua));
                Comando.Parameters.Add(new MySqlParameter("@Numero", obj.Numero));
                Comando.Parameters.Add(new MySqlParameter("@Complemento", obj.Complemento));
                Comando.Parameters.Add(new MySqlParameter("@Bairro", obj.Bairro));
                Comando.Parameters.Add(new MySqlParameter("@Cidade", obj.Cidade));
                Comando.Parameters.Add(new MySqlParameter("@Uf", obj.Uf));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Alterado Cliente com sucesso!!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch (MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR de ALTERAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExcluirCliente(Cliente obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = "DELETE FROM cliente WHERE nome = @nome";
                Comando.Parameters.Add(new MySqlParameter("@nome", obj.Nome));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Cliente excluido com sucesso!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch (MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERRO EXCLUIR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool ConsultaCliente(Cliente obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT * FROM cliente WHERE nome = @nome";
                Comando.Parameters.Add(new MySqlParameter("@nome", obj.Nome));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Nome = dr["Nome"].ToString();

                    obj.Cpf = dr["Cpf"].ToString();
                    obj.Rg = dr["Rg"].ToString();
                    obj.Telefone = dr["Telefone"].ToString();
                    obj.Cep = (int)Convert.ToInt32(dr["Cep"]);
                    obj.Numero = dr["Numero"].ToString();

                    obj.Email = dr["Email"].ToString();
                    obj.Rua = dr["Rua"].ToString();
                    obj.Complemento = dr["Complemento"].ToString();
                    obj.Bairro = dr["Bairro"].ToString();
                    obj.Cidade = dr["Cidade"].ToString();
                    obj.Uf = dr["Uf"].ToString();


                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR de CONSULTAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public DataTable ListaCliente(Cliente obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT id, nome, email FROM cliente";
                Comando.Connection = Conn;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Comando;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { Conn.Close(); }
            return null;
        }

    }
}
