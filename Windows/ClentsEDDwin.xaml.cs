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
    /// Логика взаимодействия для ClentsEDDwin.xaml
    /// </summary>
    public partial class ClentsEDDwin : Window
    {
        public ClentsEDDwin()
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
                    Helper.GetContext().Client.Find(ID).Name = NameBox.Text;
                    Helper.GetContext().Client.Find(ID).Patronymic = PatronimicBox.Text;
                    Helper.GetContext().Client.Find(ID).Surname = SurnameBox.Text;
                    Helper.GetContext().Client.Find(ID).Phone = PhoneBox.Text;

                    Helper.GetContext().SaveChanges();
                    DialogResult = true;
                }
                catch { MessageBox.Show("Ошибка, проверьте правильность заполненных полей"); }
            }
            if (Red == 0)
            {
                try
                {
                    Client add = Helper.GetContext().Client.Add(
                            new Client()
                            {
                                Name = NameBox.Text,
                                Patronymic = PatronimicBox.Text,
                                Surname = SurnameBox.Text,
                                Phone= PhoneBox.Text
                            }); ;
                       
                        Helper.GetContext().Client.Add(add);
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
