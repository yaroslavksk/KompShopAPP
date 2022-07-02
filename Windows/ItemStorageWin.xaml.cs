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
    /// Логика взаимодействия для ItemStorageWin.xaml
    /// </summary>
    public partial class ItemStorageWin : Window
    {
        public ItemStorageWin()
        {
            InitializeComponent();
            FillTable();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Дипломный проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }
        
        private void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().DeliveryComposition.ToList();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //нажатие "Выход" на верхней панели
            Application.Current.Shutdown();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.ItemStorageEDD win = new ItemStorageEDD();
            TextBlock textBlock = DGviev.Columns[0].GetCellContent(DGviev.SelectedItem) as TextBlock;
            int ID = int.Parse(textBlock.Text);
            win.IDOrderBox.Text = Helper.GetContext().DeliveryComposition.Find(ID).IDDelivery.ToString();
            win.IDProductBox.Text= Helper.GetContext().DeliveryComposition.Find(ID).IDProduct.ToString();
            win.QunatityBox.Text= Helper.GetContext().DeliveryComposition.Find(ID).Quantity.ToString();
            win.PriceBox.Text= Helper.GetContext().DeliveryComposition.Find(ID).Price.ToString();
            win.ID = ID;
            win.ShowDialog();
            if (DialogResult == true)
            {
                MessageBox.Show("Успешно!");
                FillTable();
            }
        }
    }
}
