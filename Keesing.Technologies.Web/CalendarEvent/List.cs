using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Keesing.Technologies.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<ListCalendarEventsResponse>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public List(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpGet("/calendar")]
        [SwaggerOperation(
            Summary = "List all the Calendar Events",
            Description = "List all the Calendar Events",
            OperationId = "Calendar.List",
            Tags = new[] { "CalendarEndpoints" })]
        public override async Task<ActionResult<ListCalendarEventsResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<Core.CalendarEvent> calendarEvents = _calendarEventRepository.GetAsync();

            return Ok(new ListCalendarEventsResponse
            {
                CalendarEvents = await calendarEvents.Select(c => new CalendarEvent(c.Name, c.Time, c.Location, (string[])c.Members.Clone(), c.EventOrganizer, c.Id)).ToArrayAsync(cancellationToken: cancellationToken)
            });

        }
    }
}