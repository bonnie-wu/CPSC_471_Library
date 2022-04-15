using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_471_Library.Shared
{
    public class ContactForm
    {
        public int id { get; set; }
        public string ContactFirstName { get; set; } = string.Empty;
        public string ContactLastName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactMessage { get; set; } = string.Empty;
        public Library ContactLibrary { get; set; }

    }
}
