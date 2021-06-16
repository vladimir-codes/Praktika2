using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2
{
    class Search
    {
        //public static List<Product> JustSearch(bool Mode, string[] valuetextfield, string[] fieldNames)
        //{
        //    var Products = new List<Product>();
        //    string[] values = new string[fieldNames.Length];
        //    Array.Copy(valuetextfield, values, valuetextfield.Length);
        //    DataBaseConnecting dataBase = new DataBaseConnecting();
        //    dataBase.OpenConnect();
        //    string switcher = Mode == true ? "AND" : "OR";

        //    string requirement = "";
        //    for (int i = 0; i < fieldNames.Length; i++)
        //    {
        //        if (Mode == false) requirement += $" `{fieldNames[i]}` LIKE '%{values[0]}%' ";
        //        else requirement += $" `{fieldNames[i]}` LIKE '%{values[i]}%' ";
        //        if (i < fieldNames.Length - 1) requirement += switcher;
        //    }

        //    try
        //    {
        //        MySqlCommand query =
        //        new MySqlCommand($"SELECT * FROM products WHERE {requirement}", dataBase.GetConnect());

        //        using (MySqlDataReader dataReader = query.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                Products.Add(new Product
        //                (
        //                    dataReader["id"].ToString(),
        //                    dataReader["name"].ToString(),
        //                    dataReader["code"].ToString(),
        //                    dataReader["price"].ToString(),
        //                    dataReader["count"].ToString()
        //                ));

        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    dataBase.CloseConnect();
        //    if (Products.Count == 0)
        //    {
        //        MessageBox.Show("По вашему запросу ничего не найдено");
        //    }
        //    return Products;

        //}

    }
}
