using Core.Commands;

namespace Domain.Commands.Contato
{
    public class ContatoUpdateCommand : ContatoCommandBase
    {
        public int Id { get; set; }
    }
}