using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Praktika2
{
    static class Discount
    {
        static public int GetDiscount()
        {
            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            try
            {
                MySqlCommand connect = new MySqlCommand("SELECT discount_percentage FROM discounts WHERE total_sum < (Select SUM(price) from travels Where name=@login) ORDER BY discount_percentage DESC LIMIT 1", dataBase.GetConnect());
                connect.Parameters.Add("@login", MySqlDbType.VarChar).Value = Session.login;
                try
                {
                    return Int32.Parse(connect.ExecuteScalar().ToString());
                }
                catch (Exception )
                {
                    return 0;
                    
                } 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка БД");
            }
            finally
            {
                dataBase.CloseConnect();
            }
            return 0;

        }
    }
}
