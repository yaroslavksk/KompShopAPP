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
    /// Логика взаимодействия для PersonalWin.xaml
    /// </summary>
    public partial class PersonalWin : Window
    {
        public PersonalWin()
        {
            InitializeComponent();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Дипломный проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }
        private void FillTable()
        {
            DGviev.ItemsSource = Helper.GetContext().Personal.ToList();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //нажатие "Выход" на верхней панели
            Application.Current.Shutdown();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.PersonalEDD win = new Windows.PersonalEDD();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                MessageBox.Show("Успешно");
                FillTable();
            }
        }

        private void EddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.PersonalEDD win = new Windows.PersonalEDD();
            win.Red = 1;
            var Persona = Helper.GetContext().Personal.Find(DGviev.SelectedIndex+1);
            win.SurnameBox.Text = Persona.Surname;
            win.NameBox.Text = Persona.Name;
            win.PatronimicBox.Text = Persona.Patronymic;
            win.PhoneBox.Text = Persona.Phone;
            win.DateBox.SelectedDate = Persona.DateBirth;
            win.LogBox.Text = Persona.Login;
            win.PassBox.Text =Persona.Password;
            win.TipsBox.Text =Persona.Tips;
            if (Persona.Position == "Директор") win.PositionBox.SelectedIndex = 0;
            if (Persona.Position == "Продавец") win.PositionBox.SelectedIndex = 1;
            if (Persona.Position == "Кладовщик") win.PositionBox.SelectedIndex = 2;
            TextBlock textBlock = DGviev.Columns[0].GetCellContent(DGviev.SelectedItem) as TextBlock;
            win.ID = int.Parse(textBlock.Text);
            
            
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
