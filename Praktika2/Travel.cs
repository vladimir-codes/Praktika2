using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2
{
    class Travel
    {
        public string District { get; private set; }
        public string City { get; private set; }
        public DateTime Date { get; private set; }
        public int Price { get; private set; }
        public bool Food { get; private set; }
        public bool Guided_tours { get; private set; }
        public double Distance { get; private set; }

        public Travel(string district, string city, DateTime date, bool food, bool guided_tours)
        {
            District = district;
            City = city;
            Date = date;
            Price = 1;
            Food = food;
            Guided_tours = guided_tours;
            Distance = 1;
        }

        public override string ToString()
        {
            return District + "\t" + City + "\t" + Date.ToString();
        }
    }
}
