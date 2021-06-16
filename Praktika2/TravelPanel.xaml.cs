using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika2
{
    /// <summary>
    /// Логика взаимодействия для TravelPanel.xaml
    /// </summary>
    public partial class TravelPanel : UserControl
    {
        public TravelPanel()
        {
            InitializeComponent();
        }
        public TravelPanel( Travel trv)
        {
            InitializeComponent();
            TBCountry.Text += trv.Country;
            TBcity.Text += trv.City;
            TBDistrict.Text += trv.District;
            TBDate.Text += trv.Date.ToShortDateString();
            TBPrice.Text += trv.Price.ToString();
            TBFood.Text += trv.Food == true ? "Питание включено в цену" : "Без питания";
            TBGuided_tours.Text += trv.Guided_tours == true ? "Экскурсии включены в цену" : "Без экскурсий";
        }
    }
}
