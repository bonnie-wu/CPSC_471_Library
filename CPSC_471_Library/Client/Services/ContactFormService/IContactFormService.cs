using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPSC_471_Library.Client.Services.ContactFormService
{
    public interface IContactFormService
    {
        List<ContactForm> SubmittedContactForms { get; set; }
        Task CreateContactForm(ContactForm contactform);
    }
}
