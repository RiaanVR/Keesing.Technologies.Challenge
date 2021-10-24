using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Keesing.Technologies.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class Query : BaseAsyncEndpoint.WithRequest<QueryCalendarEventRequest>.WithResponse<QueryCalendarEventResposne>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public Query(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpGet("/calendar/query")]
        [SwaggerOperation(
            Summary = "Query Calendar Events",
            Description = "Query Calendar Events",
            OperationId = "Calendar.Query",
            Tags = new[] { "CalendarEndpoints" })]
        public override async Task<ActionResult<QueryCalendarEventResposne>> HandleAsync([FromQuery] QueryCalendarEventRequest request, CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<Core.CalendarEvent> calendarEvents = _calendarEventRepository.GetAsync((ce) => ce.EventOrganizer == request.EventOrganizer);

            return Ok(new QueryCalendarEventResposne
            {
                CalendarEvents = await calendarEvents.Select(c => new CalendarEvent(c.Name, c.Time, c.Location, (string[])c.Members.Clone(), c.EventOrganizer, c.Id)).ToArrayAsync(cancellationToken: cancellationToken)
            });
        }
    }
}