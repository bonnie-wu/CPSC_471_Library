using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_471_Library.Shared
{
    public class LibraryEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public int EventDuration { get; set; }
        public int EventLibraryId { get; set; } // should be a FK that references the Library Id
    }
}
