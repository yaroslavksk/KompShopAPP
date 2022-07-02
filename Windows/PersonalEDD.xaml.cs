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
    /// Логика взаимодействия для PersonalEDD.xaml
    /// </summary>
    public partial class PersonalEDD : Window
    {
        public PersonalEDD()
        {
            InitializeComponent();
        }
        public int Red = 0; // перем. отвечающая за понимаение того идёт редактирование или добавление 1 и 0 соответсвенно 
        public int ID;
        private void OkBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Red == 1)
            {
                try
                {
                    Helper.GetContext().Personal.Find(ID).Name = NameBox.Text;
                    Helper.GetContext().Personal.Find(ID).Patronymic = PatronimicBox.Text;
                    Helper.GetContext().Personal.Find(ID).Surname = SurnameBox.Text;
                    Helper.GetContext().Personal.Find(ID).Phone = PhoneBox.Text;
                    if (PositionBox.SelectedIndex == -1) MessageBox.Show("Не выбрана должность!");
                    if (PositionBox.SelectedIndex==0) Helper.GetContext().Personal.Find(ID).Position = "Директор";
                    if (PositionBox.SelectedIndex==1) Helper.GetContext().Personal.Find(ID).Position = "Продавец";
                    if (PositionBox.SelectedIndex==2) Helper.GetContext().Personal.Find(ID).Position = "Кладовщик";
                    Helper.GetContext().Personal.Find(ID).Login = LogBox.Text;
                    Helper.GetContext().Personal.Find(ID).Password = PassBox.Text;
                    Helper.GetContext().Personal.Find(ID).DateBirth = DateBox.SelectedDate;
                    Helper.GetContext().Personal.Find(ID).Tips = TipsBox.Text;
                    Helper.GetContext().SaveChanges();
                    DialogResult = true;
                }
                catch { MessageBox.Show("Ошибка, проверьте правильность заполненных полей"); }
            }
            if (Red == 0)
            {
                try
                {
                    Personal add = Helper.GetContext().Personal.Add(
                            new Personal()
                            {
                                Name = NameBox.Text,
                                Patronymic = PatronimicBox.Text,
                                Surname = SurnameBox.Text,
                                Phone = PhoneBox.Text,
                                DateBirth = DateBox.SelectedDate,
                                Position = PositionBox.Text,
                                Login = LogBox.Text,
                                Password = PassBox.Text,
                                Tips = TipsBox.Text
                            }); ;

                    Helper.GetContext().Personal.Add(add);
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
