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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KompShopEntities : DbContext
    {
        public KompShopEntities()
            : base("name=KompShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryComposition> DeliveryComposition { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderComposition> OrderComposition { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<WareHouse> WareHouse { get; set; }
    }
}
