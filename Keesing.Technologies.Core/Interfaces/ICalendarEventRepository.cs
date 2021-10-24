using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Keesing.Technologies.Core.Interfaces
{
    public interface ICalendarEventRepository
    {
        Task<CalendarEvent> AddAsync(CalendarEvent newCalendarEvent, CancellationToken cancellationToken = default);
        Task<CalendarEvent?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task DeleteAsync(CalendarEvent calendarEvent, CancellationToken cancellationToken = default);
        Task UpdateAsync(CalendarEvent editedCalendarEvent, CancellationToken cancellationToken = default);
        IAsyncEnumerable<CalendarEvent> GetAsync(Expression<Func<CalendarEvent, bool>>? filter = null);
    }
}
