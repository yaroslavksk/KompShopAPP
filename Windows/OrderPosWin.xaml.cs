using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для OrderPosWin.xaml
    /// </summary>
    public partial class OrderPosWin : Window
    {
        public OrderPosWin()
        {
            InitializeComponent();
            FillTable();
            TotalSum();
            
        }
        public int RED = 0;
        public int IDOrd;

        public int IDPersonal;
        public int IDClient;
        public int IDProduct;
        public List<OrderComposition> orderCompositions = new List<OrderComposition>();
        public void FillTable()
        {
            PersonalCBN.ItemsSource = Helper.GetContext().Personal.Select(x=>new {Name=x.Surname +" "+ x.Name+" "+x.Patronymic }.Name).ToList();
        }
        public void TotalSum()
        {
            double sum = 0;
            for (int i = 0; i < orderCompositions.Count() - 1; i++)
            {
                sum += Convert.ToDouble(DGOrder.Items[2]);
            }

            TotalBox.Text = "Итого: " + sum; //не работает
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
        private void SeatchBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.ClientsWin win = new ClientsWin();
            win.selectedBit = 1;
            win.BackBTN.IsEnabled = false;
            win.ShowDialog();
            IDClient = win.RejID;
            ClientCBN.Text = Helper.GetContext().Client.Find(IDClient).Surname.ToString() + " " + Helper.GetContext().Client.Find(IDClient).Name.ToString() + " " + Helper.GetContext().Client.Find(IDClient).Patronymic.ToString();
           
        }

        private void ProductAddBTN_Click(object sender, RoutedEventArgs e)
        {
            Windows.WarehouseWin win = new WarehouseWin();
            win.selectedBit = 1;
            win.BackBTN.IsEnabled = false;
            win.ShowDialog();
            IDProduct = win.RejID;
            ProductBox.Text = Helper.GetContext().WareHouse.Find(IDProduct).Name.ToString();
        }

        private void AddPosBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!(QuantityBox.Text.Length==0))
            {
                if (!(int.Parse(QuantityBox.Text) > Helper.GetContext().WareHouse.Find(IDProduct).FullQuantity))
                {
                    if (!(Helper.GetContext().WareHouse.Find(IDProduct).FullQuantity == 0))
                    {
                        DGOrder.ItemsSource = null;
                        int quantity = int.Parse(QuantityBox.Text);
                        int numberOrder = Helper.GetContext().Order.Max(p => p.IDOrder);
                        orderCompositions.Add(new OrderComposition()
                        {
                            IDOrder = numberOrder + 1,
                            IDProduct = IDProduct,
                            Quantity = quantity
                        });
                        DGOrder.ItemsSource = orderCompositions;
                    }
                    else
                    {
                        MessageBox.Show("Товар отсутсвует на складе!");
                    }
                }
                else
                {
                    MessageBox.Show("На складе нет такого количетсва товаров!");
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void DelPosBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DGOrder.SelectedItem != null)
            {
                int a = DGOrder.SelectedIndex;
                orderCompositions.RemoveAt(a);
                DGOrder.ItemsSource = null;
                DGOrder.Items.Clear();
                DGOrder.ItemsSource = orderCompositions;
            }
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RED == 0)
            {
                try
                {
                    List<Order> list = new List<Order>();
                    list.Add(new Order() { IDPersonal = PersonalCBN.SelectedIndex + 1, IDClient = IDClient, Date = DateBox.SelectedDate, Tips = TipsBox.Text, IsFinily = IsFinCheck.IsChecked, IsProcess = IsProcCheck.IsChecked });
                    Helper.GetContext().Order.Add(list.First());
                    foreach (var item in orderCompositions)
                    {
                        Helper.GetContext().OrderComposition.Add(item);
                    }
                    Helper.GetContext().SaveChanges();
                    if (IsFinCheck.IsChecked == true)
                    {
                        foreach (var item in orderCompositions)
                        {
                            Helper.GetContext().WareHouse.Find(orderCompositions).FullQuantity = Helper.GetContext().WareHouse.Find(orderCompositions).FullQuantity - item.Quantity.Value;
                        }
                        Helper.GetContext().SaveChanges();
                    }

                    DialogResult = true;
                }
                catch { MessageBox.Show("Проверьте заполненность полей", "Ошибка!"); }
            }
            else
            {
                try
                {
                    Helper.GetContext().Order.Find(IDOrd).IDClient = IDClient;
                    Helper.GetContext().Order.Find(IDOrd).IDPersonal = PersonalCBN.SelectedIndex + 1;
                    Helper.GetContext().Order.Find(IDOrd).Date = DateBox.SelectedDate;
                    Helper.GetContext().Order.Find(IDOrd).Tips = TipsBox.Text;
                    Helper.GetContext().Order.Find(IDOrd).IsFinily = IsFinCheck.IsChecked;
                    Helper.GetContext().Order.Find(IDOrd).IsProcess = IsProcCheck.IsChecked;
                    if (IsFinCheck.IsChecked == true)
                    {
                        foreach (var item in orderCompositions)
                        {
                            Helper.GetContext().WareHouse.Find(orderCompositions).FullQuantity = Helper.GetContext().WareHouse.Find(orderCompositions).FullQuantity - item.Quantity.Value; //не списывает;
                        }

                    }
                    Helper.GetContext().SaveChanges();
                    DialogResult = true;
                }
                catch { MessageBox.Show("Проверьте заполненность полей", "Ошибка!"); }
            }
        }
    }
}
