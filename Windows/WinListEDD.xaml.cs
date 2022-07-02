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
    /// Логика взаимодействия для WinListEDD.xaml
    /// </summary>
    public partial class WinListEDD : Window
    {
        public WinListEDD()
        {
            InitializeComponent();
        }
        public int ID;
        public int Red=0;

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
            { try {
                    Helper.GetContext().Vendor.Find(ID).Name = NameBox.Text;
                    Helper.GetContext().Vendor.Find(ID).Maneger = ManegerBox.Text;
                    Helper.GetContext().Vendor.Find(ID).Phone = TelBox.Text;
                    Helper.GetContext().Vendor.Find(ID).Adress = AdressBox.Text;
                    Helper.GetContext().Vendor.Find(ID).Tips = TipsBox.Text;
                    Helper.GetContext().SaveChanges();
                    DialogResult = true; }
                catch { MessageBox.Show("Ошибка, проверьте правильность заполненных полей"); }
            }
            if (Red == 0)
            {
                try{
                    Vendor add = Helper.GetContext().Vendor.Add(
                            new Vendor()
                            {
                                IDVendor = Helper.GetContext().Vendor.Count() + 1,
                                Name = NameBox.Text,
                                Maneger = ManegerBox.Text,
                                Phone = TelBox.Text,
                                Adress = AdressBox.Text,
                                Tips = TipsBox.Text
                            }); ;
                    Helper.GetContext().Vendor.Add(add);
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
