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
using System.Windows.Shapes;

namespace Praktika2
{
    /// <summary>
    /// Логика взаимодействия для SignUP.xaml
    /// </summary>
    public partial class SignUP : Window
    {
        public SignUP()
        {
            InitializeComponent();
        }

        private void Button_Click_SignUP(object sender, RoutedEventArgs e)
        {
            DataBaseConnecting dataBase = new DataBaseConnecting();
            dataBase.OpenConnect();

            try
            {
                MySqlCommand connect = new MySqlCommand($"INSERT INTO `logins`(`login`, `password`) VALUES (@login, @pass)", dataBase.GetConnect());
                connect.Parameters.Add("@login", MySqlDbType.VarChar).Value = TBLog.Text;
                connect.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TBPas.Text;
                if (connect.ExecuteNonQuery()==1) if (MessageBox.Show("Успешная регистрация" ,"Успешно", MessageBoxButton.OK) == MessageBoxResult.OK) this.Close();
                else MessageBox.Show("Не удалось зарегистрировать" , "Ошибка");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataBase.CloseConnect();
        }
    }
}
