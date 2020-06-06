using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DtoModel
{
    public class Contact : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNo { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        public Contact() { }
        public Contact(string firstName, string lastName, int phoneNo, int addressId) 
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            AddressId = addressId;
        }
        
    }
}