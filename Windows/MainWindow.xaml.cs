using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MuraevKursovoi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public int ClickLogin = 0;
        public int ClickPass = 0;

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ClickLogin == 0)
            {
                LoginBox.Text = "";
                ClickLogin = 1;
            }
        }

        private void PassBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ClickPass == 0)
            {
                PassBox.Password = "";
                ClickPass = 1;
            }
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

        public void AutorizBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutorizBtn.IsEnabled = false;
                var Personal = Helper.GetContext().Personal.Any(x => x.Login == LoginBox.Text && x.Password == PassBox.Password);
                if (Personal == false)
                {
                    MessageBox.Show("Неверные логин или пароль!");
                    AutorizBtn.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Успешная авторизация");

                    MenuWin win = new MenuWin();
                    var Zap = Helper.GetContext().Personal.Where(x => x.Login == LoginBox.Text && x.Password == PassBox.Password).FirstOrDefault();
                    win.Main.Text +=( Zap.Surname+" "+Zap.Name+" "+Zap.Patronymic).ToString();
                    if(Helper.GetContext().Personal.Where(x=>x.Password==PassBox.Password).FirstOrDefault().Position == "Продавец")
                    {
                        win.WareHouseGroup.IsEnabled = false;
                        win.VendorGroup.IsEnabled = false;
                        win.UsersGroup.IsEnabled = false;
                        win.Show();
                        this.Close();
                    }

                    if(Helper.GetContext().Personal.Where(x => x.Password == PassBox.Password).FirstOrDefault().Position == "Кладовщик")
                    {
                        win.UsersGroup.IsEnabled = false;
                        win.OrdersGroup.IsEnabled = false;
                        win.ClientsGroup.IsEnabled = false;
                        win.PriceGroup.IsEnabled = false;
                        win.Show();
                        this.Close();
                    }
                    if (Helper.GetContext().Personal.Where(x => x.Password == PassBox.Password).FirstOrDefault().Position == "Директор")
                    {
                        win.Show();
                        this.Close();
                    }


                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Проверьте подключение необходимой базы данных '/sqlexpress/KompShop.dbo'");
                AutorizBtn.IsEnabled = true;
            }
        }

        
    }
}
