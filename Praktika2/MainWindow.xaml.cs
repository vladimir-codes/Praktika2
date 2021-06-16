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
           MessageBox.Show(String.Join(Environment.NewLine, Search.JustSearch(TBFrom.Text, TBwhere.Text, DPStart.SelectedDate.Value, DPEnd.SelectedDate.Value)));
        }

        //void TextBoxDropDownHintControl_OnSelect(object sender, TextBoxDropDownHint.Controls.SelectionChanged e)
        //{
        //    if (e.Value != null)
        //    {
        //        TestModel model = e.Value as TestModel;
        //        if (model == null) return;

        //        tbxDescription.Text = model.Description;
        //    }
        //}



    }
}
