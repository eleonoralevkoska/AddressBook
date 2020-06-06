using AddressBook.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataLayer
{
     public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetAllWithAddress();
    }
}