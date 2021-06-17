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
        public static List<Travel> JustSearch(string From, string Where, DateTime Start, int End)
        {
            var travels = new List<Travel>();

            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            if(count==0)requirement = $"SELECT * FROM `geo` WHERE city = '{Where}' AND time > '{Start.Date.ToString(@"yyyy-MM-dd")}'";

            try
            {
                MySqlCommand query =
                new MySqlCommand($"{requirement}", dataBase.GetConnect());

                using (MySqlDataReader dataReader = query.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        travels.Add(new Travel
                        (
                            dataReader["country"].ToString(),
                            dataReader["region"].ToString(),
                            dataReader["city"].ToString(),
                            ((DateTime)dataReader["time"]),
                            End,
                            (Boolean)dataReader["food"],    
                            (Boolean)dataReader["guided_tours"],
                            new GeoLocaion(From),
                            new GeoLocaion(dataReader["city"].ToString())
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
                    //Выбираются города из того же региона что и введенный город или на основе предыдущих поездок
                    // TODO : добавить условие на основе прошлых поездок
                    count = 1;
                    requirement = $"SELECT * FROM `geo` WHERE (region = (SELECT region From `geo` Where city = '{Where}' LIMIT 1) AND time > '{Start.Date.ToString(@"yyyy-MM-dd")}')";
                    travels = JustSearch(From, Where, Start, End);
                }
                else
                {
                    // Выбираются самые популярные города 

                    requirement = $"Select DISTINCT t1.* From `geo` t1 LEFT JOIN `travels` t2 ON t1.city = t2.city Where t1.city = (SELECT t2.city FROM `travels` WHERE 1 Group By t2.city  ORDER By  COUNT(t2.id) DESC LIMIT 3)";
                    travels = JustSearch(From, Where, Start ,End);                 
                }
            }
            count = 0;
            return travels;

        }
    }
}
