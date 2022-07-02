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
using System.Runtime.InteropServices;

namespace MuraevKursovoi.Windows
{
    
    public partial class ReportWin : Window
    {
        public ReportWin()
        {
            InitializeComponent();
        }
        private void TextBlockMes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //вызов справки
            MessageBox.Show("Дипломный проект: \n         Мураева Ярослава (Kelur's) \n                            2022", "Справка");
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        public List Report = new List();
        private void PostReportBTN_Click(object sender, RoutedEventArgs e)
        {
            //списания

            var Report1Ras = Helper.GetContext().Order.Where(r=>r.IsFinily==true).Join(Helper.GetContext().OrderComposition,

                    x => x.IDOrder,
                    y => y.IDOrder,
                    (x, y) => new
                    {
                        IDOrder=x.IDOrder,
                        Personal = Helper.GetContext().Personal.Where(q=>q.IDPersonal==x.IDPersonal).First().Name +" "+ Helper.GetContext().Personal.Where(q => q.IDPersonal == x.IDPersonal).First().Patronymic +" "+ Helper.GetContext().Personal.Where(q => q.IDPersonal == x.IDPersonal).First().Surname,
                        Date = x.Date,
                        Client = Helper.GetContext().Client.Where(q=>q.IDClient == x.IDClient).First().Name +" "+ Helper.GetContext().Client.Where(q => q.IDClient == x.IDClient).First().Patronymic+" "+ Helper.GetContext().Client.Where(q => q.IDClient == x.IDClient).First().Surname,
                        Quantity = y.Quantity

                    }).GroupBy(x=>x.IDOrder).ToList();
            
        }
    }
}
