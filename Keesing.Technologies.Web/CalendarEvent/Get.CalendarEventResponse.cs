using System;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class GetCalendarEventResponse
    {

        public string Name { get; set; } = "";
        public DateTimeOffset Time { get; set; }
        public string Location { get; set; } = "";
        public string[] Members { get; set; } = Array.Empty<string>();
        public string EventOrganizer { get; set; } = "";
        public Guid Id { get; set; }
    }
}