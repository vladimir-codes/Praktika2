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
using TextBoxDropDownHint;

namespace Praktika2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBFrom.Text == String.Empty) TBFrom.Focus();
            else if (TBwhere.Text == String.Empty) TBwhere.Focus();
            else if (DPStart.Text == "") DPStart.Focus();
            else if (TBEnd.Text == String.Empty) TBEnd.Focus();
            else
            {
                TravelsInfoPanel.Children.Clear();
                CreateTravelsPanels();
            }
        }

        private void CreateTravelsPanels()
        {
            List <Travel> travels = Search.JustSearch(TBFrom.Text, TBwhere.Text, DPStart.SelectedDate.Value , Int32.Parse(TBEnd.Text));
            foreach (var item in travels)
            {
                TravelPanel tp = new TravelPanel(item);
                if (TravelsInfoPanel.Children.Count < 4)
                TravelsInfoPanel.Children.Add(tp);
            }
        }

        private void TBEnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32.Parse(TBEnd.Text);
            }
            catch (Exception)
            {
                if (TBEnd.Text.Length == 0) {TBEnd.Text = ""; return;}
                TBEnd.Text = TBEnd.Text.Remove(TBEnd.Text.Length-1);
                TBEnd.SelectionStart = TBEnd.Text.Length;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
