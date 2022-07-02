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
    /// Логика взаимодействия для WarehouseWin.xaml
    /// </summary>
    public partial class WarehouseWin : Window
    {
        public WarehouseWin()
        {
            InitializeComponent();
            FillTable();
        }
        public int selectedBit;
        public int RejID;
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
        private void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().WareHouse.ToList();
        }
        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            WareEDD win = new WareEDD();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }


        }
        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            var zap = Helper.GetContext().WareHouse.Find(DGviev.SelectedIndex);
            if (zap == null) MessageBox.Show("Нечего удалять");
            else Helper.GetContext().WareHouse.Remove(zap);
            Helper.GetContext().SaveChanges();
            FillTable();

        }

        private void UpBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.WareEDD win = new Windows.WareEDD();
            win.Red = 1;
            WareHouse post = (WareHouse)DGviev.SelectedItem;
            try
            {
                win.ID = post.IDProduct;
                win.NameBox.Text = post.Name;
                win.TipsBox.Text = post.Description;
                win.QuantityBox.Text = post.FullQuantity.ToString();
                win.ShowDialog();

                if (win.DialogResult == true)
                {
                    MessageBox.Show("Успешно");
                    FillTable();
                }
            }
            catch { MessageBox.Show("Ошибка! \n   Проверьте выбрана ли запись"); }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void DGviev_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (selectedBit == 1)
            {
                try
                {
                    TextBlock textBlock = DGviev.Columns[0].GetCellContent(DGviev.SelectedItem) as TextBlock;
                    RejID = int.Parse(textBlock.Text);
                    DialogResult = true;
                }
                catch { MessageBox.Show("Не выбрана строка!"); }
            }
        }
    }
}
