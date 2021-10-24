using System;
using System.Collections.Generic;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class ListCalendarEventsResponse
    {
        public IEnumerable<CalendarEvent> CalendarEvents { get; set; } = Array.Empty<CalendarEvent>();
    }
}