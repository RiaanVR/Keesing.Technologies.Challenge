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
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteCalendarEventRequest>
        .WithoutResponse
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        public Delete(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpDelete("/calendar/{id:int}")]
        [SwaggerOperation(
            Summary ="Deletes an existing Calendar Event",
            Description ="Deletes an existing Calendar Event",
            OperationId ="Calendar.Delete",
            Tags=new[] { "CalendarEndpoints"})]
        [SwaggerResponse(StatusCodes.Status200OK, "The calendare event corresponding to id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The calendar event does not exist")]
        public override async Task<ActionResult> HandleAsync([FromRoute]DeleteCalendarEventRequest request, CancellationToken cancellationToken = default)
        {
            Core.CalendarEvent? calendarEvent = await _calendarEventRepository.GetAsync(request.Id);

            if (calendarEvent is not null)
            {
                await _calendarEventRepository.DeleteAsync(calendarEvent);
                return Ok();
            }

            return NotFound();
        }
    }

}