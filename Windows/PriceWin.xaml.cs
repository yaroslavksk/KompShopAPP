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
    /// Логика взаимодействия для PriceWin.xaml
    /// </summary>
    public partial class PriceWin : Window
    {
        public PriceWin()
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
           var grid = Helper.GetContext().WareHouse.ToList();
            DGviev.ItemsSource = grid;
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //нажатие "Выход" на верхней панели
            Application.Current.Shutdown();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.PriceEDD win = new Windows.PriceEDD();
            win.Red = 1;
            WareHouse post = DGviev.SelectedItem as WareHouse;
            try
            {
                win.ID = post.IDProduct;
                win.DateBox.SelectedDate = DateTime.Now;
                win.ProductBox.Text = post.Name;
                TextBlock textBlock = DGviev.Columns[3].GetCellContent(DGviev.SelectedItem) as TextBlock;
                win.PriceBox.Text = textBlock.Text;
                win.ShowDialog();
                if (win.DialogResult == true)
                {
                    MessageBox.Show("Успешно");
                    FillTable();
                }
            }
            catch { MessageBox.Show("Ошибка! \n   Проверьте выбрана ли запись"); }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().Price.Find(DGviev.SelectedIndex);
            if (zap == null) MessageBox.Show("Нечего удалять");
            else Helper.GetContext().Price.Remove(zap);
            Helper.GetContext().SaveChanges();
            FillTable();

        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

