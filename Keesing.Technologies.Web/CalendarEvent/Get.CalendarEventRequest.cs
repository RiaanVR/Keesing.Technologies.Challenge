using System;
using Microsoft.AspNetCore.Mvc;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class GetCalendarEventRequest
    {

        public const string Route = "/calendar/{id}";
        public static string BuildRoute(Guid calendarEventId) => Route.Replace("{id}", calendarEventId.ToString());

        public Guid Id { get; set; }

    }
}