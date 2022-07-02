using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MuraevKursovoi.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWin.xaml
    /// </summary>
    public partial class OrderWin : Window
    {
        public OrderWin()
        {
            InitializeComponent();
            FillTable();
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
        public void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().Order.ToList();
        }
        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            //открывает окно OrderPos.win
            Windows.OrderPosWin win = new OrderPosWin();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }

        }
        private void DelTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.OrderPosWin win = new OrderPosWin();
            win.DGOrder.ItemsSource = Helper.GetContext().OrderComposition.Where(x=>x.IDOrder==DGviev.SelectedIndex).ToList();
            win.PersonalCBN.ItemsSource = Helper.GetContext().Personal.Select(x => new { Name = x.Surname + " " + x.Name + " " + x.Patronymic }.Name).ToList();
            win.PersonalCBN.SelectedIndex = Helper.GetContext().Personal.Where(x => x.IDPersonal == DGviev.SelectedIndex + 1).FirstOrDefault().IDPersonal-1;
            win.IDClient = Helper.GetContext().Order.Find(DGviev.SelectedIndex + 1).IDClient;
            win.ClientCBN.Text= Helper.GetContext().Client.Find(win.IDClient).Name+" "+Helper.GetContext().Client.Find(win.IDClient).Surname;
            win.DateBox.SelectedDate = Helper.GetContext().Order.Find(DGviev.SelectedIndex+1).Date;
            win.TipsBox.Text = Helper.GetContext().Order.Find(DGviev.SelectedIndex+1).Tips;
            win.IsFinCheck.IsChecked= Helper.GetContext().Order.Find(DGviev.SelectedIndex+1).IsFinily;
            win.IsProcCheck.IsChecked= Helper.GetContext().Order.Find(DGviev.SelectedIndex+1).IsProcess;
            win.DelPosBTN.IsEnabled = false;
            win.AddPosBTN.IsEnabled = false;
            win.RED = 1;
            TextBlock textBlock = DGviev.Columns[0].GetCellContent(DGviev.SelectedItem) as TextBlock;
            win.IDOrd = int.Parse(textBlock.Text);
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
