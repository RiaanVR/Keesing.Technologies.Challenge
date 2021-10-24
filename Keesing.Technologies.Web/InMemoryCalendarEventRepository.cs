using Keesing.Technologies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Keesing.Technologies.Web
{
    internal class InMemoryCalendarEventRepository : ICalendarEventRepository
    {
        private static readonly List<Core.CalendarEvent> _calendarsEvents = new();

        public Task<Core.CalendarEvent> AddAsync(Core.CalendarEvent newCalendarEvent, CancellationToken cancellationToken = default)
        {
            _calendarsEvents.Add(newCalendarEvent);

            return newCalendarEvent.AsTask();
        }

        public Task DeleteAsync(Core.CalendarEvent calendarEvent, CancellationToken cancellationToken = default)
        {
            _calendarsEvents.Remove(calendarEvent);

            return Task.CompletedTask;
        }

        public Task<Core.CalendarEvent?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _calendarsEvents.Find((ce) => ce.Id == id).AsTask();
        }

        public IAsyncEnumerable<Core.CalendarEvent> GetAsync(Expression<Func<Core.CalendarEvent, bool>>? filter = null)
        {

            return (filter is null
                ? _calendarsEvents
                : _calendarsEvents.Where(filter.Compile()))
                .ToAsyncEnumerable();
        }

        public Task UpdateAsync(Core.CalendarEvent calendarEvent, CancellationToken cancellationToken = default)
        {
            var originalCalendarEvent = _calendarsEvents.Find((ce) => ce.Id == calendarEvent.Id);

            // if this was a DB attached repository it would actually do some sort of DML statement
            if (originalCalendarEvent is not null)
            {
                _calendarsEvents.Remove(originalCalendarEvent);
            }

            _calendarsEvents.Add(calendarEvent);

            return Task.CompletedTask;
        }
    }
}