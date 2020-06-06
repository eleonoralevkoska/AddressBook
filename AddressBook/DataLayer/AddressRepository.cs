using AddressBook.DtoModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataLayer
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AddressBookDbContext context) : base(context)
        {
        }
        public IEnumerable<Address> GetAllWithContact()
        {
            return _context.Addresses.Include(a => a.Contacts);
        }
    }    
}