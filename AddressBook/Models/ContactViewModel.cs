using AddressBook.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class ContactViewModel
    {    
        public int Id { get; set; }
        public Contact Contact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNo { get; set; }        
        public IEnumerable<Address> Addresses { get; set; }
    }
}