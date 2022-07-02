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
    /// Логика взаимодействия для WinListViev.xaml
    /// </summary>
    public partial class WinListViev : Window
    {
        public WinListViev()
        {
            InitializeComponent();
            FillTable();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Курсовой проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }

        private void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().Vendor.ToList();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //нажатие "Выход" на верхней панели
            Application.Current.Shutdown();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.WinListEDD win = new Windows.WinListEDD();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {     
            var zap = Helper.GetContext().Vendor.Find(DGviev.SelectedIndex);
            if (zap == null) MessageBox.Show("Нечего удалять");
            else Helper.GetContext().Vendor.Remove(zap); 
            Helper.GetContext().SaveChanges(); 
            FillTable();
            
        }

        private void UpBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.WinListEDD win = new Windows.WinListEDD();
            win.Red = 1;
            Vendor post = (Vendor)DGviev.SelectedItem;
            
            win.ID = post.IDVendor;
            var zap= Helper.GetContext().Personal;
            win.ManegerBox.Text=post.Maneger; 
            win.NameBox.Text= post.Name;
            win.TelBox.Text= post.Phone;
            win.AdressBox.Text= post.Adress;
            win.TipsBox.Text= post.Tips;
            win.ShowDialog();

            if (win.DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
