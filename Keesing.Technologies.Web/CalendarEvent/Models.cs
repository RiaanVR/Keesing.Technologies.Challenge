using System;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public record CalendarEvent(string Name, DateTimeOffset Time, string Location, string[] Members, string EventOrganizer, Guid Id);

}
