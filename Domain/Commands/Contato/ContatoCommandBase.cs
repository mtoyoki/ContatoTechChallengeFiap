using Core.Commands;

namespace Domain.Commands.Contato
{
    public class ContatoCommandBase : CommandBase
    {
        public required string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }
    }
}