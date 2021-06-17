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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        MainWindow main = new MainWindow();
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text == String.Empty) TBLogin.Focus();
            else if (TBPass.Password == String.Empty) TBPass.Focus();

            else if (Session.OpenSession(TBLogin.Text, TBPass.Password) == true)
            {
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_SignUP(object sender, RoutedEventArgs e)
        {
            SignUP sign = new SignUP();
            sign.Owner = this;
            sign.ShowDialog();
        }
    }
}
