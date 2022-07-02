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
    /// Логика взаимодействия для DeliveryWinEDD.xaml
    /// </summary>
    public partial class DeliveryWinEDD : Window
    {
        public DeliveryWinEDD()
        {
            InitializeComponent();
            VendorCBN.ItemsSource = Helper.GetContext().Vendor.Select(x=>new {Name=x.Name}.Name).ToList();
        }
        public int IDDel;
        public int IDProduct;
        public int RED=0;
        public List<DeliveryComposition> orderCompositions = new List<DeliveryComposition>();
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
        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RED == 0)
            {
                try
                {
                    List<Delivery> list = new List<Delivery>();
                    list.Add(new Delivery() { IDVendor = VendorCBN.SelectedIndex + 1, Date = (DateTime)DateBox.SelectedDate, Notes = TipsBox.Text});
                    Helper.GetContext().Delivery.Add(list.First());
                    foreach (var item in orderCompositions)
                    {
                        Helper.GetContext().DeliveryComposition.Add(item);
                    }
                    Helper.GetContext().SaveChanges();
                    foreach (var item in orderCompositions)
                    {
                        Helper.GetContext().WareHouse.Find(orderCompositions).FullQuantity = Helper.GetContext().WareHouse.Find(orderCompositions).FullQuantity + item.Quantity; //не списывает
                    }

                    Helper.GetContext().SaveChanges(); 
                    DialogResult = true;
                }
                catch { MessageBox.Show("Проверьте заполненность полей", "Ошибка!"); }
            }
            else
            {
                try
                {
                    Helper.GetContext().Delivery.Find(IDDel).IDVendor=VendorCBN.SelectedIndex+1;
                    Helper.GetContext().Delivery.Find(IDDel).Date = DateTime.Parse(DateBox.SelectedDate.ToString());
                    Helper.GetContext().Delivery.Find(IDDel).Notes = TipsBox.Text;
                    Helper.GetContext().SaveChanges();
                    DialogResult = true;
                }
                catch { MessageBox.Show("Проверьте заполненность полей", "Ошибка!"); }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
            if (!(QuantityBox.Text == null && int.Parse(QuantityBox.Text) < 0))
            {
                DGOrder.ItemsSource = null;
                int quantity = int.Parse(QuantityBox.Text);
                int numberDelivery = Helper.GetContext().Order.Max(p => p.IDOrder);
                orderCompositions.Add(new DeliveryComposition()
                {
                    IDDelivery = numberDelivery + 1,
                    IDProduct = IDProduct,
                    Quantity = quantity
                });
                DGOrder.ItemsSource = orderCompositions;
            }

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
    }
}
