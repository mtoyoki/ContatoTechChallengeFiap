using Core.Commands;

namespace Domain.Commands.Contato
{
    public class ContatoDeleteCommand : CommandBase
    {
        public int Id { get; set; }
    }
}