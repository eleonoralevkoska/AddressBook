using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DtoModel
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(s => s.Address)
                .WithMany(a => a.Contacts)
                .HasForeignKey(c => c.AddressId);

            #region seed
            var contacts = new List<Contact>
            {
                new Contact("FirstName1", "LastName1", 111222,1){ Id=1}
            };

            var adresses = new List<Address>
            {
                new Address("AddressName1", "CityName1"){ Id=1}
            };
            modelBuilder.Entity<Contact>().HasData(contacts);
            modelBuilder.Entity<Address>().HasData(adresses);
            #endregion
        }
    }
}