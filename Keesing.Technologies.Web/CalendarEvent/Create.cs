using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Keesing.Technologies.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Keesing.Technologies.Web.CalendarEvent
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateCalendarEventRequest>
        .WithResponse<CreateCalenarEventResponse>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public Create(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpPost("/calendar")]
        [SwaggerOperation(
            Summary = "Creates a new Calendar Event",
            Description = "Creates a new Calendar Event",
            OperationId = "Calendar.Create",
            Tags = new[] { "CalendarEndpoints" })]
        [SwaggerResponse(StatusCodes.Status201Created, "The calendar event was created", typeof(CreateCalenarEventResponse))]
        public override async Task<ActionResult<CreateCalenarEventResponse>> HandleAsync(CreateCalendarEventRequest request, CancellationToken cancellationToken = new CancellationToken())
        {
            var newCalendarEvent = new Core.CalendarEvent(request.Name, request.Time, request.Location, (string[])request.Members.Clone(), request.EventOrganizer, Guid.NewGuid());

            Core.CalendarEvent createdCalendarEvent = await _calendarEventRepository.AddAsync(newCalendarEvent);

            return Created(GetCalendarEventRequest.BuildRoute(createdCalendarEvent.Id),
                new CreateCalenarEventResponse
                {
                    Id = createdCalendarEvent.Id,
                    EventOrganizer = createdCalendarEvent.EventOrganizer,
                    Location = createdCalendarEvent.Location,
                    Members = createdCalendarEvent.Members,
                    Name = createdCalendarEvent.Name,
                    Time = createdCalendarEvent.Time,
                });
        }
    }

}