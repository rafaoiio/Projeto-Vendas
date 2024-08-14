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
    internal class ProdutoSQL : conexao
    {
        public void InserirProduto(Produto obj)
        {
            try
            {
                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();

                Comando.CommandText = @"INSERT INTO produtos(id, descricao, unidade, valor)
                                       VALUES ( @id, @descricao, @unidade , @valor)";

                Comando.Parameters.Add(new MySqlParameter("@Id", obj.Id));
                Comando.Parameters.Add(new MySqlParameter("@Descricao", obj.Descricao));
                Comando.Parameters.Add(new MySqlParameter("@Unidade", obj.Unidade));
                Comando.Parameters.Add(new MySqlParameter("@Valor", obj.Valor));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();
                MessageBox.Show("Produto Inserido", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch (MySqlException ex)
            {
                Conn.Close();
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void AlterarProduto(Produto obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"UPDATE produtos SET id = @id, descricao = @descricao, 
                                      unidade = @unidade, valor = @valor  WHERE id = @id";

                Comando.Parameters.Add(new MySqlParameter("@id", obj.Id));
                Comando.Parameters.Add(new MySqlParameter("@descricao", obj.Descricao));
                Comando.Parameters.Add(new MySqlParameter("@unidade", obj.Unidade));
                Comando.Parameters.Add(new MySqlParameter("@valor", obj.Valor));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Alterado produto com sucesso!!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Comando.Dispose();
                Conn.Close();

            }
            catch(MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExcluirProduto(Produto obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = "DELETE FROM produtos WHERE id = @id";
                Comando.Parameters.Add(new MySqlParameter("@id", obj.Id));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Produto excluido com sucesso!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }catch(MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool ConsultaProduto(Produto obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT * FROM produtos WHERE descricao = @descricao";
                Comando.Parameters.Add(new MySqlParameter("@descricao", obj.Descricao)); // vai dar erro

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Descricao = dr["Descricao"].ToString();
                    obj.Unidade = Convert.ToInt32(dr["Unidade"]);
                    obj.Valor = Convert.ToInt32(dr["Valor"]);

                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public DataTable ListaProduto(Produto obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT id, descricao, unidade, valor FROM produtos";
                Comando.Connection = Conn;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Comando;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { Conn.Close(); }
            return null;
        }
    }
}
