using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Praktika2
{
    public class GeoLocaion
    {
        public double Lat { get; private set; }
        public double Lng { get; private set; }

        public GeoLocaion(double Lat , double Lng)
        {
            this.Lat = Lat;
            this.Lng = Lng;
        }
        public GeoLocaion(string Name)
        {
            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            try
            {
                MySqlCommand query = new MySqlCommand($"SELECT lat, lng FROM `geo` WHERE city = '{Name}'", dataBase.GetConnect());

                using (MySqlDataReader dataReader = query.ExecuteReader())
                {
                    dataReader.Read();
                    this.Lat = Double.Parse(dataReader["lat"].ToString().Replace(".",","));
                    this.Lng = Double.Parse(dataReader["lng"].ToString().Replace(".", ","));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            dataBase.CloseConnect();
        }

        static public double CalculatingDistance(GeoLocaion l1, GeoLocaion l2)
        {
            const double _eQuatorialEarthRadius = 6378.1370D;
            double _d2r = (Math.PI / 180D);
            double dlong = (l2.Lng - l1.Lng) * _d2r;
            double dlat = (l2.Lat - l1.Lat) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(l1.Lat * _d2r) * Math.Cos(l2.Lat * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            return d;
        }
        

    }
}
