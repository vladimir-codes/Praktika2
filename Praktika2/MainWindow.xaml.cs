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

            List<TestModel> coll = new List<TestModel>();
            coll.Add(new TestModel() { Id = 1, Name = "Москва", Description = "Описание города" });
            coll.Add(new TestModel() { Id = 2, Name = "Санкт-Петербург", Description = "Описание города" });
            coll.Add(new TestModel() { Id = 3, Name = "Екатеринбург", Description = "Описание города" });
            coll.Add(new TestModel() { Id = 4, Name = "Уфа", Description = "Описание города" });
            coll.Add(new TestModel() { Id = 5, Name = "Пенза", Description = "Описание города" });

            DataContext = new { TestCollection = coll };
        }

        void TextBoxDropDownHintControl_OnSelect(object sender, TextBoxDropDownHint.Controls.SelectionChanged e)
        {
            if (e.Value != null)
            {
                TestModel model = e.Value as TestModel;
                if (model == null) return;

                tbxDescription.Text = model.Description;
            }
        }


            
    }
}
