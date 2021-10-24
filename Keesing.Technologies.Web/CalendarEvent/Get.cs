using Ardalis.ApiEndpoints;
using Keesing.Technologies.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Keesing.Technologies.Web.CalendarEvent
{

    public class Get : BaseAsyncEndpoint.WithRequest<GetCalendarEventRequest>.WithResponse<GetCalendarEventResponse>
    {

        private readonly ICalendarEventRepository _calendarEventRepository;

        public Get(ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        [HttpGet(GetCalendarEventRequest.Route)]
        [SwaggerOperation(
            Summary = "Get an existing Calendar Event by Id",
            Description = "Get an existing Calendar Event by Id",
            OperationId = "Calendar.Get",
            Tags = new[] { "CalendarEndpoints" })]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetCalendarEventResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<GetCalendarEventResponse>> HandleAsync([FromRoute] GetCalendarEventRequest request, CancellationToken cancellationToken = default)
        {
            Core.CalendarEvent? calendarEvent = await _calendarEventRepository.GetAsync(request.Id);

            return calendarEvent is null 
                ? NotFound() 
                : Ok(calendarEvent);
        }
    }
}
