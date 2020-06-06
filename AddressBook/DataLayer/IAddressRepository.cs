using AddressBook.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataLayer
{
    public interface IAddressRepository : IRepository<Address>
    {
        IEnumerable<Address> GetAllWithContact();
    }
}