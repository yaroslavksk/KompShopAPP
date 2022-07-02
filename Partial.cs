using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuraevKursovoi
{
    public partial class  WareHouse
    {
        public DateTime? LastDateProduct
        {
            get
            {
                var list = Helper.GetContext().Price.Where(p => p.IDProduct == IDProduct);
                
                if (list.Count() == 0)
                    return null;
                return list.Max(p=>p.Date);
            }
        }

        public int? LastPriceProduct
        {
            get
            {
               var list = Helper.GetContext().Price.Where(p => p.IDProduct == IDProduct).FirstOrDefault(p=>p.Date==LastDateProduct);

               if (list == null)
               {
                    return null;
               }
                return list.Price1;
            }
        }
    }
    public partial class DeliveryComposition
    {
        public string NameProductDel
        {
            get
            {
                var Name = Helper.GetContext().WareHouse.Find(IDProduct);
                return Name.Name;
            }
        }
        public string SumPDel
        {
            get
            {
                var LastDate = Helper.GetContext().Price.Where(p => p.IDProduct == IDProduct);
                var list = Helper.GetContext().Price.Where(s => s.IDProduct == IDProduct).FirstOrDefault(s => s.Date == LastDate.Max(q => q.Date));
                return (Quantity * list.Price1).ToString();
            }
        }
        public string Prices
        {
            get
            {
                var LastDate = Helper.GetContext().Price.Where(p => p.IDProduct == IDProduct);
                var list = Helper.GetContext().Price.Where(s => s.IDProduct == IDProduct).FirstOrDefault(s => s.Date == LastDate.Max(q => q.Date));
                return list.Price1.ToString();
            }
        }
    }
    public partial class OrderComposition
    {
        public int? AllQuantity
        {
            get
            {
                var list = Helper.GetContext().OrderComposition.Where(p => p.IDProduct == IDProduct).Sum(p=>p.Quantity);

                if (list == null)
                {
                    return null;
                }
                return list.Value;
            }
        }
        
        public string NameProduct
        {
            get
            {
                return Helper.GetContext().WareHouse.Find(IDProduct).Name;
            }
        }
        
        public string SumP
        {
            get
            {
                var LastDate = Helper.GetContext().Price.Where(p => p.IDProduct == IDProduct);
                var list = Helper.GetContext().Price.Where(s => s.IDProduct == IDProduct).FirstOrDefault(s => s.Date == LastDate.Max(q => q.Date));
                return (Quantity * list.Price1).ToString();
            }
        }
        public string Prices
        {
            get
            {
                var LastDate = Helper.GetContext().Price.Where(p => p.IDProduct == IDProduct);
                var list = Helper.GetContext().Price.Where(s => s.IDProduct == IDProduct).FirstOrDefault(s => s.Date == LastDate.Max(q => q.Date));
                return list.Price1.ToString();
            }
        }
    }
}
