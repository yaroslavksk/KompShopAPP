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

namespace MuraevKursovoi.Windows
{
    /// <summary>
    /// Логика взаимодействия для PriceEDD.xaml
    /// </summary>
    public partial class PriceEDD : Window
    {
        public PriceEDD()
        {
            InitializeComponent();
        }
        public int ID;
        public int Red = 0;

        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Курсовой проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //нажатие "Выход" на верхней панели
            Application.Current.Shutdown();
        }
        private void OkBTN_Click(object sender, RoutedEventArgs e)
        {

            if (Red == 1)
            {
                try
                {
                    Price add = Helper.GetContext().Price.Add(
                            new Price()
                            {
                                Date = (DateTime)DateBox.SelectedDate,
                                IDProduct=ID,
                                Price1 = int.Parse(PriceBox.Text)
                            }); ;
                    Helper.GetContext().Price.Add(add);
                    Helper.GetContext().SaveChanges();
                    DialogResult = true;
                }
                catch { MessageBox.Show("Ошибка, проверьте правильность заполненных полей"); }
            }
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
