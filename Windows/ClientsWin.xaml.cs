using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для ClientsWin.xaml
    /// </summary>
    public partial class ClientsWin : Window
    {
        public ClientsWin()
        {
            InitializeComponent();
            FillTable();
        }
        public int IDClient;
        public int selectedBit = 0;
        private void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().Client.ToList();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Дипломный проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }        
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //нажатие "Выход" на верхней панели
            Application.Current.Shutdown();
        }
        public int RejID;
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

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.ClentsEDDwin win = new Windows.ClentsEDDwin();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }
        }

        private void EddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.ClentsEDDwin win = new Windows.ClentsEDDwin();
            win.Red = 1;
            Client post = (Client)DGviev.SelectedItem;
            try
            {
                win.ID = post.IDClient;
                win.NameBox.Text = post.Name;
                win.SurnameBox.Text = post.Surname;
                win.PatronimicBox.Text = post.Patronymic;
                win.PhoneBox.Text = post.Phone;
                win.ShowDialog();

                if (win.DialogResult == true)
                {
                    MessageBox.Show("Успешно");
                    FillTable();
                }
            }
            catch { MessageBox.Show("Ошибка! \n   Проверьте выбрана ли запись"); }
        }
    }
}
