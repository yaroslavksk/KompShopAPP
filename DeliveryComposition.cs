//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MuraevKursovoi
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryComposition
    {
        public int ID { get; set; }
        public Nullable<int> IDDelivery { get; set; }
        public Nullable<int> IDProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}
