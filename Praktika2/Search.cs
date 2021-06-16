using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Praktika2
{
    abstract class Search
    {
        private static string requirement = "";
        private static int count = 0;
        public static List<Travel> JustSearch(string From, string Where, DateTime Start, DateTime End)
        {
            var travels = new List<Travel>();

            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            if(count==0)requirement = $"city = '{Where}' AND time > '{Start.Date.ToString(@"yyyy-MM-dd")}'";

            try
            {
                MySqlCommand query =
                new MySqlCommand($"SELECT * FROM `geo` WHERE {requirement}", dataBase.GetConnect());

                using (MySqlDataReader dataReader = query.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        travels.Add(new Travel
                        (
                            dataReader["region"].ToString(),
                            dataReader["city"].ToString(),
                            ((DateTime)dataReader["time"]),
                            (Boolean)dataReader["food"],
                            (Boolean)dataReader["guided_tours"]
                        ));

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataBase.CloseConnect();
            if (travels.Count == 0)
            {
                if (count == 0)
                {
                    // TODO : добавить условие на основе прошлых поездок
                    count = 1;
                    requirement = $"region = (SELECT region From `geo` Where city = '{Where}') AND time > '{Start.Date.ToString(@"yyyy-MM-dd")}'";
                    travels = JustSearch(From, Where, Start, End);
                }
                else
                {
                    // TODO : добавить условие для групповой выборки популярных мест

                    requirement = $"city = 'Москва'";
                    travels = JustSearch(From, Where, Start, End);                 
                }
            }
            count = 0;
            return travels;

        }
    }
}
