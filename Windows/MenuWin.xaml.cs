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

namespace MuraevKursovoi
{
    /// <summary>
    /// Логика взаимодействия для MenuWin.xaml
    /// </summary>
    public partial class MenuWin : Window
    {
        public MenuWin()
        {
            InitializeComponent();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Дипломный проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PriceBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.PriceWin win = new Windows.PriceWin();
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void PostBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().Vendor.ToList();
            WinListViev win = new WinListViev();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void PersonalBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().Personal.ToList();
            Windows.PersonalWin win = new Windows.PersonalWin();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().Order.ToList();
            Windows.OrderWin win = new Windows.OrderWin();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void OrderPosBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().Delivery.ToList();
            Windows.DeliveryWin win = new Windows.DeliveryWin();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }
        private void StorageBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().WareHouse.ToList();
            Windows.WarehouseWin win = new Windows.WarehouseWin();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void ItemStorageBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().DeliveryComposition.ToList();

            Windows.ItemStorageWin win = new Windows.ItemStorageWin();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void ClientsBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().Client.ToList();
            Windows.ClientsWin win = new Windows.ClientsWin();
            win.DGviev.ItemsSource = zap;
            this.Hide();
            win.ShowDialog();
            this.Show();
        }

        private void ClientOrderDelBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.OrderWin win = new Windows.OrderWin();
            win.DGviev.ItemsSource = Helper.GetContext().Order.Where(x => x.IsProcess==true).ToList();
            win.AddBTN.Visibility = Visibility.Hidden;
            win.DelTN.Visibility = Visibility.Hidden;
            win.EddBTN.Visibility = Visibility.Hidden;
            win.ShowDialog();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void ReportBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.ReportWin win = new Windows.ReportWin();
            this.Hide();
            win.ShowDialog();
            this.Show();
        }
    }
}
