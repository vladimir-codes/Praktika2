using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2
{
    public class Travel
    {
        public string Country { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public DateTime Date { get; private set; }
        public double Price { get; private set; }
        public bool Food { get; private set; }
        public bool Guided_tours { get; private set; }
        public double Distance { get; private set; }

        public Travel(string country , string district, string city, DateTime Start, int Days, bool food, bool guided_tours , GeoLocaion from , GeoLocaion where)
        {
            Country = country;
            District = district;
            City = city;
            Date = Start;
            Food = food;
            Guided_tours = guided_tours;

            Distance = GeoLocaion.CalculatingDistance(from,where);


            Price = Math.Round(Distance * 10 + Days * 5000 + (food==true? Days * 1000 : 0) + (Guided_tours == true ? Days * 1000  : 0),0);
        }

        public override string ToString()
        {
            return District + "\t" + City + "\t" + Date.ToString() + "\tЦена: " +Price.ToString();
        }
    }
}
