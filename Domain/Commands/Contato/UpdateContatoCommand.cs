using Core.Commands;

namespace Domain.Commands.Contato
{
    public class UpdateContatoCommand : ContatoCommandBase
    {
        public int Id { get; set; }
    }
}