using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using ContactManager.Services;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository contactRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public ContactController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this.contactRepository = new ContactRepository(httpContextAccessor);
        }

        [HttpGet]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }

        [HttpPost]
        public ActionResult<Contact> Post([FromBody] Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }
    }
}
