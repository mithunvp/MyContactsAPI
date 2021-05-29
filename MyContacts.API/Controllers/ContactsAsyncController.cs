using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyContacts.Entities;
using MyContacts.Providers.Repository;

namespace MyContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsAsyncController : ControllerBase
    {
        private readonly IContactsAsyncRepository _contactsAsyncRepository;
        public ContactsAsyncController(IContactsAsyncRepository contactsAsyncRepository)
        {
            _contactsAsyncRepository = contactsAsyncRepository ??
                throw new ArgumentNullException(nameof(contactsAsyncRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactsAsyncRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _contactsAsyncRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _contactsAsyncRepository.AddAsync(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = await _contactsAsyncRepository.FindAsync(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            await _contactsAsyncRepository.UpdateAsync(item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactsAsyncRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
