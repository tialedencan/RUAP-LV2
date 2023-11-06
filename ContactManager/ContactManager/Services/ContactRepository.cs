using ContactManager.Models;

namespace ContactManager.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            var ctx = _httpContextAccessor.HttpContext;

            if (ctx != null)
            {
                if (ctx.Items[CacheKey] == null)
                {
                    var contacts = new Contact[]
                    {
                  new Contact
                  {
                      Id = 1, Name = "Glenn Block"
                  },
                  new Contact
                  {
                      Id = 2, Name = "Dan Roth"
                  }
                    };

                    ctx.Items[CacheKey] = contacts;
                }
            }
        }

        public Contact[] GetAllContacts()
        {
            var ctx = _httpContextAccessor.HttpContext;

            if (ctx != null)
            {
                return (Contact[])ctx.Items[CacheKey];
            }

            return new Contact[]
            {
           new Contact
           {
               Id = 0,
               Name = "Placeholder"
           }
            };
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = _httpContextAccessor.HttpContext;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Items[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Items[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}

