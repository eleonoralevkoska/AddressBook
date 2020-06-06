using AddressBook.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string AddressName { get; set; }
        public string City { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}