using MySql.Data.MySqlClient;
using Aula_l_01_04;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula_l_01_04
{
    internal class LoginSQL : conexao
    {
        public bool VerificarLogin(Login obj)
        {
            try
            {

                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = (@"SELECT * FROM usuario WHERE usuario = @usuario AND senha = @senha ");
                Comando.Parameters.Add(new MySqlParameter("@usuario", obj.Usuario));
                Comando.Parameters.Add(new MySqlParameter("@senha", obj.Senha));
                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();
                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Id = Convert.ToInt32(dr["ID"]);
                    obj.Usuario = dr["usuario"].ToString();
                    obj.Senha = dr["senha"].ToString();
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

        public void InserirLogin( Login obj)
        {
            try
            {
                Conn.Open();
                MySqlCommand Comando = new MySqlCommand();

                Comando.CommandText = @"INSERT INTO usuario(usuario, senha, nome, email)
                                       VALUES ( @usuario, @senha, @nome , @email)";

                Comando.Parameters.Add(new MySqlParameter("@usuario", obj.Usuario));
                Comando.Parameters.Add(new MySqlParameter("@Nome", obj.Nome));
                Comando.Parameters.Add(new MySqlParameter("@Email", obj.Email));
                Comando.Parameters.Add(new MySqlParameter("@senha", obj.Senha));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();
                MessageBox.Show("Usuário Inserido", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();

            }
            catch (MySqlException ex)
            {
                Conn.Close();
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void AlterarLogin(Login obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"UPDATE usuario SET senha = @senha, nome = @nome, email = @email WHERE id = @id";

                Comando.Parameters.Add(new MySqlParameter("@nome", obj.Nome));
                Comando.Parameters.Add(new MySqlParameter("@email", obj.Email));
                Comando.Parameters.Add(new MySqlParameter("@senha", obj.Senha));
                Comando.Parameters.Add(new MySqlParameter("@id", obj.Id));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Alterado com sucesso!!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Comando.Dispose();
                Conn.Close();
            }
            catch(MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
        }

        public void ExcluirLogin(Login obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = "DELETE FROM usuario WHERE id = @id";
                Comando.Parameters.Add(new MySqlParameter("@id", obj.Id));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MessageBox.Show("Excluido com sucesso!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Comando.Dispose();

                Conn.Close();
            }
            catch (MySqlException ex)
            {
                Conn.Close();

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public bool ConsultaUsuario(Login obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = @"SELECT * FROM usuario WHERE usuario = @usuario";
                Comando.Parameters.Add(new MySqlParameter("@usuario", obj.Usuario));

                Comando.Connection = Conn;
                Comando.ExecuteNonQuery();

                MySqlDataReader dr = Comando.ExecuteReader();

                if (dr.Read())
                {
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Usuario = dr["Usuario"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();

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


        public DataTable ListaLogin(Login obj)
        {
            try
            {
                Conn.Open();

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandText = (@"SELECT id, usuario FROM usuario");
                Comando.Connection = Conn;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Comando;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            finally
            {
                Conn.Close();
            }
            return null;
        }

    }
}

