using Core.Commands;

namespace Domain.Commands.Contato
{
    public class DeleteContatoCommand : CommandBase
    {
        public int Id { get; set; }
    }
}