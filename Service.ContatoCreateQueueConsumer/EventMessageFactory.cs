using Domain.Entities;
using Domain.Events.Contato;

namespace Service.ContatoCreateQueueConsumer
{
    public static class EventMessageFactory
    {
        private const string SuccessMessage = "[SUCCESSO] Contato foi inserido";
        private const string ErrorMessage = "[ERRO] Contato não foi inserido";
        private const string ExceptionMessage = "[EXCEÇÃO] Contato não foi inserido";

        public static EventMessage CreateSuccessMessage(ContatoCreateEventMsg eventMsg, Contato contato)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (contato == null) throw new ArgumentNullException(nameof(contato));

            return CreateMessage(eventMsg, SuccessMessage, contato.Id.ToString());
        }

        public static EventMessage CreateErrorMessage(ContatoCreateEventMsg eventMsg, string? errors)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (string.IsNullOrEmpty(errors)) throw new ArgumentNullException(nameof(errors));

            return CreateMessage(eventMsg, ErrorMessage, errors);
        }

        public static EventMessage CreateExceptionMessage(ContatoCreateEventMsg eventMsg, Exception ex)
        {
            if (eventMsg == null) throw new ArgumentNullException(nameof(eventMsg));
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            return CreateMessage(eventMsg, ExceptionMessage, ex.Message);
        }

        private static EventMessage CreateMessage(ContatoCreateEventMsg eventMsg, string result, string? details)
        {
            return new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                result,
                details);
        }
    }
}
