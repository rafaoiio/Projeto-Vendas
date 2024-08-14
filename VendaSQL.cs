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
    internal class VendaSQL : conexao
    {
        public void InserirVenda(Venda obj)
        {
            try
            {
                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();

                Comando.CommandText = @"INSERT INTO venda(codigocliente, codigovenda) VALUES ( @codigocliente, @codigovenda)";


                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));
                Comando.Parameters.Add(new MySqlParameter("@codigocliente", obj.CodigoCliente));


                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Venda Inserida com sucesso!!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch (MySqlException ex)
            {
                Conn.Close();
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        public void InserirVendaItens(Venda obj)
        {
            try
            {
                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();

                Comando.CommandText = @"INSERT INTO vendaiten ( codigovenda, codigoproduto, qtde, valor)
                                       VALUES (@codigovenda, @codigoproduto, @qtde, @valor)";


                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));
                Comando.Parameters.Add(new MySqlParameter("@codigoproduto", obj.CodigoProduto));
                Comando.Parameters.Add(new MySqlParameter("@qtde", obj.Qtde));
                Comando.Parameters.Add(new MySqlParameter("@valor", obj.Valor));
                Comando.Parameters.Add(new MySqlParameter("@codigocliente", obj.CodigoCliente));


                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Item Inserido na venda!!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch (MySqlException ex)
            {
                Conn.Close();
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void AlterarVenda(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"UPDATE vendaiten SET codigoproduto = @codigoproduto, qtde = @qtde, codigoproduto = @codigoproduto
                WHERE codigovenda = @codigovenda, codigoproduto = @codigoproduto ";

                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));
                Comando.Parameters.Add(new MySqlParameter("@codigocliente", obj.CodigoCliente));
                Comando.Parameters.Add(new MySqlParameter("@codigoproduto", obj.CodigoProduto));
                Comando.Parameters.Add(new MySqlParameter("@qtde", obj.Qtde));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Alterado com sucesso!!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();
            }
            catch (MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExcluirVendaIten(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"DELETE FROM vendaiten WHERE codigoproduto = @codigoproduto";

                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));
                Comando.Parameters.Add(new MySqlParameter("@codigoproduto", obj.CodigoProduto));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Iten excluido com sucesso!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Comando.Dispose();

                Conn.Close();
            }
            catch (MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ExcluirVenda(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"DELETE FROM venda WHERE codigovenda = @codigovenda;
                                        DELETE FROM vendaiten WHERE codigovenda = @codigovenda";

                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));
                

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Venda excluida com sucesso!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Comando.Dispose();

                Conn.Close();
            }
            catch (MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public bool ConsultaCliente(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT * FROM cliente WHERE nome = @nome OR cpf = @cpf OR id = @id";
                Comando.Parameters.Add(new MySqlParameter("@nome", obj.Nome));
                Comando.Parameters.Add(new MySqlParameter("@cpf", obj.Cpf));
                Comando.Parameters.Add(new MySqlParameter("@id", obj.Id));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Nome = dr["Nome"].ToString();
                    obj.Cpf = dr["Cpf"].ToString();
                    obj.Id = int.Parse(dr["Id"].ToString());

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public bool ConsultaVendas(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT * FROM vendaiten WHERE codigovenda = @codigovenda";
                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Codigovenda = Convert.ToInt32(dr["Codigovenda"]);
                    obj.CodigoProduto = Convert.ToInt32(dr["CodigoProduto"]);



                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public DataTable ListaVenda(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT codigovenda, codigoproduto FROM vendaiten";
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


        public bool ConsultaProduto(Venda obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT * FROM produtos WHERE id = @id";
                Comando.Parameters.Add(new MySqlParameter("@id", obj.Id));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    //obj.Nome = dr["Nome"].ToString();
                   // obj.Cpf = dr["Cpf"].ToString();
                   // obj.Id = Convert.ToInt32(dr["Id"]);



                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Descricao = dr["Descricao"].ToString();
                    obj.Unidade = Convert.ToInt32(dr["Unidade"]);
                    obj.Valor = Convert.ToInt32(dr["Valor"]);


                   // obj.Qtde = Convert.ToInt32(dr["Quantidade"]);
                    //obj.Codigovenda = Convert.ToInt32(dr["Codigovenda"]);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            finally
            {
                Conn.Close();
            }
        }

        public bool VerificarCodigo(Venda obj)
        {
            try
            {

                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = (@"SELECT * FROM venda WHERE codigovenda = @codigovenda ");
                Comando.Parameters.Add(new MySqlParameter("@codigovenda", obj.Codigovenda));
                Comando.Parameters.Add(new MySqlParameter("@codigocliente", obj.Id));
                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();
                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Codigovenda = Convert.ToInt32(dr["codigovenda"]);
                    obj.Id = Convert.ToInt32(dr["codigocliente"]);

                    return true;

                }

                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERRO",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            finally
            {
                Conn.Close();
            }
        }

    }
}
