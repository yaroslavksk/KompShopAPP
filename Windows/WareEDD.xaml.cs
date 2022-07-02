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
    /// Логика взаимодействия для WareEDD.xaml
    /// </summary>
    public partial class WareEDD : Window
    {
        public WareEDD()
        {

            InitializeComponent();
        }
        public int Red = 0;
        public int ID;
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
                    Helper.GetContext().WareHouse.Find(ID).Name = NameBox.Text;
                    Helper.GetContext().WareHouse.Find(ID).Description = TipsBox.Text;
                    Helper.GetContext().WareHouse.Find(ID).FullQuantity = int.Parse(QuantityBox.Text);
                    
                    Helper.GetContext().SaveChanges();
                    DialogResult = true;
                }
                catch { MessageBox.Show("Ошибка, проверьте правильность заполненных полей"); }
            }
            if (Red == 0)
            {
                try
                {
                    if (Helper.GetContext().WareHouse.Where(x => x.Name == NameBox.Text).Count() > 0)
                    {
                        MessageBox.Show("Такой продукт уже существует!");
                    }
                    else
                    {
                        WareHouse add = Helper.GetContext().WareHouse.Add(
                            new WareHouse()
                            {
                                Name = NameBox.Text,
                                Description = TipsBox.Text,
                                FullQuantity = int.Parse(QuantityBox.Text)
                            });;
                        Price addPrice = Helper.GetContext().Price.Add(
                            new Price()
                            {
                                Date = DateTime.Now,
                                Price1=0,
                                IDProduct= Helper.GetContext().WareHouse.Count()+1
                            });;
                        Helper.GetContext().WareHouse.Add(add);                      
                        Helper.GetContext().SaveChanges();
                        Helper.GetContext().Price.Add(addPrice);
                        Helper.GetContext().SaveChanges();
                    }
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
