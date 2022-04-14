using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPSC_471_Library.Client.Services.LibraryEventService
{
    interface ILibraryEventService
    {
        List<LibraryEvent> LibEvents { get; set; }
        Task getAllEvents();
        Task<LibraryEvent> getSingleEvent(int eventid);
    }
}
