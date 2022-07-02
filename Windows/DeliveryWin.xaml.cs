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
    /// Логика взаимодействия для DeliveryWin.xaml
    /// </summary>
    public partial class DeliveryWin : Window
    {
        public DeliveryWin()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().Delivery.ToList();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Дипломный проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            DeliveryWinEDD win = new DeliveryWinEDD();
            win.ShowDialog();
            if (DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }
        }

        private void EddBTN_Click(object sender, RoutedEventArgs e)
        {
            DeliveryWinEDD win = new DeliveryWinEDD();
            win.RED = 1;
            win.AddPosBTN.IsEnabled = false;
            win.DelPosBTN.IsEnabled = false;
            TextBlock textBlock = DGviev.Columns[0].GetCellContent(DGviev.SelectedItem) as TextBlock;
            win.IDDel = int.Parse(textBlock.Text);
            win.DGOrder.ItemsSource = Helper.GetContext().DeliveryComposition.Where(x => x.IDDelivery == DGviev.SelectedIndex+1).ToList();
            win.DateBox.SelectedDate = Helper.GetContext().Delivery.Where(x => x.IDDelivery == DGviev.SelectedIndex+1).FirstOrDefault().Date;
          //  win.TipsBox.Text = Helper.GetContext().Delivery.Where(x => x.IDDelivery == DGviev.SelectedIndex+1).FirstOrDefault().Notes.ToString();
            win.VendorCBN.SelectedIndex = Helper.GetContext().Delivery.Where(x => x.IDDelivery == DGviev.SelectedIndex+1).FirstOrDefault().IDVendor - 1;

            win.ShowDialog();

            FillTable();
            
        }
    }
}
