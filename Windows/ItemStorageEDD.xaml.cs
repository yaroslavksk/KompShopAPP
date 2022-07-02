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
    /// Логика взаимодействия для ItemStorageEDD.xaml
    /// </summary>
    public partial class ItemStorageEDD : Window
    {
        public ItemStorageEDD()
        {
            InitializeComponent();
        }
        public int ID;
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OKBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Helper.GetContext().DeliveryComposition.Find(ID).IDDelivery = int.Parse(IDOrderBox.Text);
                Helper.GetContext().DeliveryComposition.Find(ID).IDProduct = int.Parse(IDProductBox.Text);
                Helper.GetContext().DeliveryComposition.Find(ID).Quantity = int.Parse(QunatityBox.Text);
                Helper.GetContext().DeliveryComposition.Find(ID).Price = int.Parse(PriceBox.Text);
                Helper.GetContext().SaveChanges();
            }
            catch { MessageBox.Show("Проверьте правильность заполненности полей!","Ошибка!"); }

        }
    }
}
