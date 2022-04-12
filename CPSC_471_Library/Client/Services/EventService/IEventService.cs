using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPSC_471_Library.Client.Services.EventService
{
    interface IEventService
    {
        List<Event> Events { get; set; }
        Task GetEvents();
        Task<Event> GetSingleEvent(int EventId);
    }
}
