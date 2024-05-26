using Domain.Commands.Contato;

namespace Shared.Tests.Builders.Commands
{
    public class CreateContatoCommandBuilder
    {
        private string Nome { get; set; }
        private string Telefone { get; set; }
        private string Email { get; set; }
        private int RegiaoId { get; set; }

        public CreateContatoCommandBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public CreateContatoCommandBuilder WithTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public CreateContatoCommandBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CreateContatoCommandBuilder WithRegiaoId(int regiaoId)
        {
            RegiaoId = regiaoId;
            return this;
        }


        public CreateContatoCommandBuilder Default()
        {
            this.Nome = "João da Silva";
            this.Email = "jose@gmail.com";
            this.Telefone = "11972117173";
            this.RegiaoId = 11;
            return this;
        }

        public CreateContatoCommandBuilder Empty()
        {
            this.Nome = "";
            this.Email = "";
            this.Telefone = "";
            this.RegiaoId = 0;
            return this;
        }


        public CreateContatoCommand Build()
        {
            var command = new CreateContatoCommand()
            {
                Nome = this.Nome,
                Telefone = this.Telefone,
                Email = this.Email,
                RegiaoId = this.RegiaoId
            };

            return command;
        }
    }
}
