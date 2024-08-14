using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula_l_01_04
{
    internal class conexao
    {
        protected MySqlConnection Conn;

        public conexao()
        {
            try
            {
                Conn = new MySqlConnection("Persist Security Info = False;"
                    + "server =" + Properties.Settings.Default.servidor + ";"
                    + "Port =" + Properties.Settings.Default.porta + ";"
                    + "database =" + Properties.Settings.Default.banco + ";"
                    + "uid ="+ Properties.Settings.Default.usuario + ";"
                    + "pwd=" + Properties.Settings.Default.senha + ";");
            }
            catch (MySqlException ex)
            {
               MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
