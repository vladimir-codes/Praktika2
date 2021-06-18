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
        //delegate void qwe(List<string> conditions , Delegate function);

        //delegate List<Travel> Result(string From, string Where, DateTime date, int End, string requirement, DataBaseConnecting dataBase);

        public static List<Travel> JustSearch(string From, string Where, DateTime Start, int End)
        {

            var travels = new List<Travel>();

            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

             if (CheckToExists(From, dataBase) != true) return travels;
             if (CheckToExists(Where, dataBase) != true) return travels;
            
            List<string> conditions = new List<string>();
            conditions.Add($"SELECT * FROM `geo` WHERE city = '{Where}' AND time >= '{Start.Date.ToString(@"yyyy-MM-dd")}'");
            conditions.Add($"SELECT * FROM `geo` WHERE (region = (SELECT region From `geo` Where city = '{Where}' LIMIT 1) AND city<>'{Where}' AND time >= '{Start.Date.ToString(@"yyyy-MM-dd")}')");
            conditions.Add($"SELECT * FROM `geo` WHERE (country = (SELECT country From `geo` Where city = '{Where}' LIMIT 1) AND city<>'{Where}' AND time >= '{Start.Date.ToString(@"yyyy-MM-dd")}') ORDER BY population DESC ");
                         
                foreach (var item in conditions)
                {
                    if (travels.Count > TravelPanel.MAX_CARDS) break;
                    int limit = TravelPanel.MAX_CARDS - travels.Count;
                    travels.AddRange(QueueCheck(From, Where, Start, End, item, dataBase, limit));
                }
            

            dataBase.CloseConnect();
            return travels;

        }

        static private List<Travel> QueueCheck(string From, string Where, DateTime date, int End,string requirement, DataBaseConnecting dataBase, int limit)
        {
            List<Travel> travels = new List<Travel>();
            try
            {
                MySqlCommand query = new MySqlCommand($"{requirement} LIMIT {limit}", dataBase.GetConnect());

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
                return travels;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return travels;
            }
        }


        static private bool CheckToExists(string field, DataBaseConnecting dataBase)
        {
            MySqlCommand CheckExists = new MySqlCommand($"SELECT COUNT(id) as count FROM `geo` WHERE city = '{field}'", dataBase.GetConnect());
            int count = 0;
            using (MySqlDataReader dataReader = CheckExists.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    count = Int32.Parse(dataReader["count"].ToString()); 
                }
            }
            if (count == 0)
            {
                MessageBox.Show($"Города {field} не существует, или вы неправильно написали");
                return false;
            } 
            else return true;
        }
    }
}
