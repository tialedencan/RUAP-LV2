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

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        [HttpGet]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
    }
}
