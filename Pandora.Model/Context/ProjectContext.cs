using Pandora.Model.Entities;
using Pandora.Model.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.; Database=PandoraCode; UID=sa; PWD=123";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new PublisherMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new ReadingListMap());
            modelBuilder.Configurations.Add(new ReadingListBookMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new SearchMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new DealerMap());
            modelBuilder.Configurations.Add(new StockDetailMap());


            modelBuilder.Entity<Book>().HasOptional(m => m.Author).WithMany(t => t.WrittenBooks).HasForeignKey(m => m.AuthorID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Book>().HasOptional(m => m.Translator).WithMany(t => t.TranslatedBooks).HasForeignKey(m => m.TranslatorID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().HasOptional(m => m.BillAddress).WithMany(t => t.BillOrders).HasForeignKey(m => m.BillAddressID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Order>().HasOptional(m => m.ShipAddress).WithMany(t => t.ShipOrders).HasForeignKey(m => m.ShipAddressID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>().HasOptional(m => m.BillingAddress).WithMany(t => t.BillCustomers).HasForeignKey(m => m.BillAddressID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Customer>().HasOptional(m => m.ShippingAddress).WithMany(t => t.ShipCustomers).HasForeignKey(m => m.ShipAddressID).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ReadingListBook> ReadingListBook { get; set; }
        public DbSet<ReadingList> ReadingLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Search> Searches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<StockDetail> StockDetails { get; set; }

    }
}
