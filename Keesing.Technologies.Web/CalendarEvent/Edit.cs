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
    public class Edit : BaseAsyncEndpoint.WithRequest<EditCalendarEventRequest>.WithoutResponse
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public Edit(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpPut("/calendar/{id}")]
        [SwaggerOperation(
            Summary = "Edit an existing calendar event",
            Description = "Edit an existing calendar event",
            OperationId = "Calendar.Edit",
            Tags = new[] { "CalendarEndpoints" })]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult> HandleAsync(EditCalendarEventRequest request, CancellationToken cancellationToken = default)
        {
            Core.CalendarEvent? calendarEvent = await _calendarEventRepository.GetAsync(request.Id);

            if (calendarEvent is not null)
            {
                Core.CalendarEvent editedCalendarEvent = calendarEvent with
                {
                    Location = request.Location,
                    Name = request.Name,
                    Members = (string[])request.Members.Clone(),
                    Time = request.Time,
                    EventOrganizer = request.EventOrganizer
                };

                await _calendarEventRepository.UpdateAsync(editedCalendarEvent);
                return Ok();
            }

            return NotFound();

        }
    }

}