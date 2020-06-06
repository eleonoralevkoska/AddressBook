using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.DataLayer;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class AddressController : Controller
    {
        private IAddressRepository _addressRepository;
        private IContactRepository _contactRepository;
        public AddressController(IAddressRepository addressRepository, IContactRepository contactRepository)
        {
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
        }

        public ActionResult Index()
        {
            var adresses = from address in _addressRepository.GetAllWithContact()
                             select address;
            return View(adresses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddressViewModel addressViewModel)
        {
            _addressRepository.Create(addressViewModel.Address);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var addressVM = new AddressViewModel()
            {
                Address = _addressRepository.GetById(id),

            };
            return View(addressVM);
        }

        [HttpPost]
        public IActionResult Update(AddressViewModel addressViewModel)
        {
            if (!ModelState.IsValid)
            {
                addressViewModel.Contacts = _contactRepository.GetAll();
                return View(addressViewModel);
            }
            _addressRepository.Update(addressViewModel.Address);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var address = _addressRepository.GetById(id);
            return View(address);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _addressRepository.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(AddressViewModel addressViewModel)
        {
            if (ModelState.IsValid)
            {
                var address = _addressRepository.GetById(addressViewModel.Id);
                _addressRepository.Delete(address);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}