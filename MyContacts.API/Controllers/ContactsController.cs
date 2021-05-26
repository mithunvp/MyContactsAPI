using Microsoft.AspNetCore.Mvc;
using MyContacts.Entities;
using MyContacts.Providers.Repository;
using System;
using System.Collections.Generic;

namespace MyContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository ??
                throw new ArgumentNullException(nameof(contactsRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> GetAll()
        {
            return Ok(_contactsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var item = _contactsRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _contactsRepository.Add(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = _contactsRepository.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }

            return Ok(_contactsRepository.Update(item));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _contactsRepository.Remove(id);
            return NoContent();
        }
    }
}
