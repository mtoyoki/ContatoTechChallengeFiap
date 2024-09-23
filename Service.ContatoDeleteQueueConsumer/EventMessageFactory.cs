using Domain.Entities;
using Domain.Events.Contato;

namespace Service.ContatoDeleteQueueConsumer
{
    public static class EventMessageFactory
    {
        private const string SuccessMessage = "[SUCCESSO] Contato foi excluído";
        private const string ErrorMessage = "[ERRO] Contato não foi excluído";
        private const string ExceptionMessage = "[EXCEÇÃO] Contato não foi excluído";

        public static EventMessage CreateSuccessMessage(ContatoDeleteEventMsg eventMsg, string details)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));

            return CreateMessage(eventMsg, SuccessMessage, details);
        }

        public static EventMessage CreateErrorMessage(ContatoDeleteEventMsg eventMsg, string? errors)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (string.IsNullOrEmpty(errors)) throw new ArgumentNullException(nameof(errors));

            return CreateMessage(eventMsg, ErrorMessage, errors);
        }

        public static EventMessage CreateExceptionMessage(ContatoDeleteEventMsg eventMsg, Exception ex)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            return CreateMessage(eventMsg, ExceptionMessage, ex.Message);
        }

        private static EventMessage CreateMessage(ContatoDeleteEventMsg eventMsg, string result, string? details)
        {
            return new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                result,
                details);
        }
    }
}
