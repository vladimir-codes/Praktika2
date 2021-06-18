using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Praktika2
{
    class DataBaseConnecting
    {
        const string info = "server=mysql54.hostland.ru; username=host1832446; password=OSkzNufdpz; database=host1832446";
        MySqlConnection connect = new MySqlConnection(info);

        public DataBaseConnecting()
        {
            
        }

        public void OpenConnect()
        {
            try
            {
                if (connect.State == System.Data.ConnectionState.Closed)
                    connect.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CloseConnect()
        {
            try
            {
                if (connect.State == System.Data.ConnectionState.Open)
                    connect.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public MySqlConnection GetConnect()
        {
            return connect;
        }
       
    }
}
