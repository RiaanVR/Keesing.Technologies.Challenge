using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Keesing.Technologies.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class Sort : Ardalis.ApiEndpoints.BaseAsyncEndpoint.WithoutRequest.WithResponse<SortCalendarEventResponse>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public Sort(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpGet("/calendar/sort")]
        [SwaggerOperation(
            Summary = "Sort Calendar Events by Time",
            Description = "Sort Calendar Events by Time",
            OperationId = "Calendar.Sort",
            Tags = new[] { "CalendarEndpoints" })]
        public override async Task<ActionResult<SortCalendarEventResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<Core.CalendarEvent> events = _calendarEventRepository.GetAsync();

            return Ok(new SortCalendarEventResponse
            {
                CalendarEvents = await events
                    .OrderByDescending(ce => ce.Time)
                    .Select(c => new CalendarEvent(c.Name, c.Time, c.Location, (string[])c.Members.Clone(), c.EventOrganizer, c.Id))
                    .ToArrayAsync(cancellationToken)
            });
        }
    }
}
