using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _contactService.TGetListAsync();
            var contactList = _mapper.Map<List<ResultContactDto>>(values);
            return View(contactList);
        }

        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await _contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var newContact = _mapper.Map<Contact>(createContactDto);
            await _contactService.TCreateAsync(newContact);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateContact(ObjectId id)
        {
            var value = await _contactService.TGetByIdAsync(id);
            var updateContact = _mapper.Map<UpdateContactDto>(value);
            return View(updateContact);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var newContact = _mapper.Map<Contact>(updateContactDto);
            await _contactService.TUpdateAsync(newContact);
            return RedirectToAction("Index");
        }


    }
}