using Core.Events;
using Domain.Entities;

namespace Domain.Factories
{
    public static class EventMessageFactory
    {

        public static EventMessage CreateSuccessMessage(IEventMsg eventMsg, string details)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));

            return CreateMessage(eventMsg, true, details);
        }

        public static EventMessage CreateErrorMessage(IEventMsg eventMsg, string? errors)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));

            return CreateMessage(eventMsg, false, errors);
        }

        public static EventMessage CreateExceptionMessage(IEventMsg eventMsg, Exception ex)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            return CreateMessage(eventMsg, false, ex.Message);
        }

        private static EventMessage CreateMessage(IEventMsg eventMsg, bool result, string? details)
        {
            return new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                result,
                details);
        }
    }
}
