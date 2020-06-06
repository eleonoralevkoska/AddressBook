using AddressBook.DtoModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataLayer
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(AddressBookDbContext context) : base(context)
        {
        }
        public IEnumerable<Contact> GetAllWithAddress()
        {
            return _context.Contacts.Include(a => a.Address);
        }
    }
}