using MySql.Data.MySqlClient;
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
        private Travel travel;
        public TravelPanel()
        {
            InitializeComponent();
        }
        public TravelPanel(Travel trv)
        {
            InitializeComponent();
            this.travel = trv;
            TBCountry.Text += trv.Country;
            TBcity.Text += trv.City;
            TBDistrict.Text += trv.District;
            TBDate.Text += trv.Date.ToShortDateString();
            TBPrice.Text += trv.Price.ToString();
            TBFood.Text += trv.Food == true ? "Питание включено в цену" : "Без питания";
            TBGuided_tours.Text += trv.Guided_tours == true ? "Экскурсии включены в цену" : "Без экскурсий";
        }

        private void BBuy_Click(object sender, RoutedEventArgs e)
        {
            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            try
            {
                MySqlCommand connect = new MySqlCommand($"INSERT INTO `travels`(`name`, `city`, `price`) VALUES (@login, @city, @price)", dataBase.GetConnect());
                connect.Parameters.Add("@login", MySqlDbType.VarChar).Value = Session.login;
                connect.Parameters.Add("@city", MySqlDbType.VarChar).Value = travel.City;
                connect.Parameters.Add("@price", MySqlDbType.VarChar).Value = travel.Price;
                if (MessageBox.Show("Подтвердите бронирование", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    if (connect.ExecuteNonQuery() == 1) MessageBox.Show("Успешное бронирование", "Успешно");
                    else MessageBox.Show("Не удалось забронировать", "Ошибка");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataBase.CloseConnect();
        }
    }
}
