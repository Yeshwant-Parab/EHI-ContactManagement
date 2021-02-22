using EHI.UserManagement.Dto.Contact;
using EHI.UserManagement.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EHI.UserManagement.Business.Controllers
{
    /// <summary>
    /// Api controller class to expose Contact API's
    /// </summary>
    [Produces("application/json")]
    [Route("api/contact")]
    [ApiController]
    public class ContactBusinessController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactBusinessController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IEnumerable<ContactDetails> Get()
        {
            return _contactRepository.Get();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ContactDetails Get(int id)
        {
            return _contactRepository.Get(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContactDetails contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var status = _contactRepository.Create(contact);
                if (status)
                    return Ok();
                return StatusCode(500);
            }
            return StatusCode(400);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactRepository.Get(id);
            contact.Status = "Inactive";
            var status = _contactRepository.Update(contact);
            if (status)
                return Ok();
            return StatusCode(500);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ContactDetails contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var status = _contactRepository.Update(contact);
                if (status)
                    return Ok();
                return StatusCode(500);
            }
            return StatusCode(400);
        }
    }
}
