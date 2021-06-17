using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Praktika2
{
    public static class Session
    {
        static public string login { get; private set; }
        static public bool state { get; private set; } = false;

        static public bool OpenSession(string login, string password)
        {
            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            try
            {
                MySqlCommand connect = new MySqlCommand("SELECT Count(id) FROM logins WHERE `login`=@login AND `password`=@pass", dataBase.GetConnect());
                connect.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                connect.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                int count = Int32.Parse(connect.ExecuteScalar().ToString());
                if (count > 0)
                {
                    Session.login = login;
                    state = true;
                    return true;

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataBase.CloseConnect();
            return false;
        }
        static public void CloseConnection()
        {
            login = "";
            state = false;
        }
    }
}
