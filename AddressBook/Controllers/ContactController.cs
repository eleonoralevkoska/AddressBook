using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.DataLayer;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private IAddressRepository _addressRepository;
        private IContactRepository _contactRepository;
        public ContactController(IAddressRepository addressRepository, IContactRepository contactRepository)
        {
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
        }

        public ActionResult Index(string SearchString)
        {
            var contacts = from contact in _contactRepository.GetAllWithAddress()
                           select contact;

            if (!String.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(s => s.Address.AddressName.Contains(SearchString)).ToList();
            }
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var contactVM = new ContactViewModel()
            {
                Addresses = _addressRepository.GetAll()
            };
            return View(contactVM);
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                contactViewModel.Addresses = _addressRepository.GetAll();
                return View(contactViewModel);
            }
            _contactRepository.Create(contactViewModel.Contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var contactVM = new ContactViewModel()
            {
                Contact = _contactRepository.GetById(id),
                Addresses = _addressRepository.GetAll()
            };
            return View(contactVM);
        }

        [HttpPost]
        public IActionResult Update(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                contactViewModel.Addresses = _addressRepository.GetAll();
                return View(contactViewModel);
            }
            _contactRepository.Update(contactViewModel.Contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _contactRepository.GetById(id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _contactRepository.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var contact = _contactRepository.GetById(contactViewModel.Id);
                _contactRepository.Delete(contact);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}