using Domain.Commands.Contato;
using System.Security.Cryptography;

namespace Shared.Tests.Builders.Commands
{
    public class UpdateContatoCommandBuilder
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string Telefone { get; set; }
        private string Email { get; set; }
        private int RegiaoId { get; set; }

        public UpdateContatoCommandBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public UpdateContatoCommandBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public UpdateContatoCommandBuilder WithTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public UpdateContatoCommandBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UpdateContatoCommandBuilder WithRegiaoId(int regiaoId)
        {
            RegiaoId = regiaoId;
            return this;
        }


        public UpdateContatoCommandBuilder Default()
        {
            this.Id = 1;
            this.Nome = "Nome alterado";
            this.Email = "email_alterado@gmail.com";
            this.Telefone = "11972117173";
            this.RegiaoId = 11;
            return this;
        }

        public UpdateContatoCommandBuilder Empty()
        {
            this.Id = 0;
            this.Nome = string.Empty;
            this.Email = string.Empty;
            this.Telefone = string.Empty;
            this.RegiaoId = 0;
            return this;
        }

        public ContatoUpdateCommand Build()
        {
            var command = new ContatoUpdateCommand()
            {
                Id = this.Id,
                Nome = this.Nome,
                Telefone = this.Telefone,
                Email = this.Email,
                RegiaoId = this.RegiaoId
            };

            return command;
        }
    }
}
