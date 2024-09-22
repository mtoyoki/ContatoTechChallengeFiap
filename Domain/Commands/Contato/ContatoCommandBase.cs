using Core.Commands;
using Domain.Entities.Interfaces;

namespace Domain.Commands.Contato
{
    public class ContatoCommandBase : CommandBase, IContatoEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }
    }
}