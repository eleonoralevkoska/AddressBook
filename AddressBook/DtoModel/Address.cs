using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DtoModel
{
    public class Address : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string City { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Address() { }
        public Address(string addressName, string city) 
        {
            AddressName = addressName;
            City = city;
        }
    }
}