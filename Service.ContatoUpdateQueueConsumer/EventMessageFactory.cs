using Domain.Entities;
using Domain.Events.Contato;

namespace Service.ContatoUpdateQueueConsumer
{
    public static class EventMessageFactory
    {
        private const string SuccessMessage = "[SUCCESSO] Contato foi atualizado";
        private const string ErrorMessage = "[ERRO] Contato não foi atualizado";
        private const string ExceptionMessage = "[EXCEÇÃO] Contato não foi atualizado";

        public static EventMessage CreateSuccessMessage(ContatoUpdateEventMsg eventMsg, Contato contato)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (contato == null) throw new ArgumentNullException(nameof(contato));

            return CreateMessage(eventMsg, SuccessMessage, contato.Id.ToString());
        }

        public static EventMessage CreateErrorMessage(ContatoUpdateEventMsg eventMsg, string? errors)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (string.IsNullOrEmpty(errors)) throw new ArgumentNullException(nameof(errors));

            return CreateMessage(eventMsg, ErrorMessage, errors);
        }

        public static EventMessage CreateExceptionMessage(ContatoUpdateEventMsg eventMsg, Exception ex)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            return CreateMessage(eventMsg, ExceptionMessage, ex.Message);
        }

        private static EventMessage CreateMessage(ContatoUpdateEventMsg eventMsg, string result, string? details)
        {
            return new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                result,
                details);
        }
    }
}
