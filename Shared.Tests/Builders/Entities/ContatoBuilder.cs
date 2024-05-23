using Domain.Entities;

namespace Shared.Tests.Builders.Commands
{
    public class ContatoBuilder
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string Telefone { get; set; }
        private string Email { get; set; }
        private int RegiaoId { get; set; }

        public ContatoBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ContatoBuilder WithTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public ContatoBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public ContatoBuilder WithRegiaoId(int regiaoId)
        {
            RegiaoId = regiaoId;
            return this;
        }


        public ContatoBuilder Default()
        {
            this.Nome = "João da Silva";
            this.Email = "jose@gmail.com";
            this.Telefone = "11972117173";
            this.RegiaoId = 11;
            return this;
        }


        public Contato Build()
        {
            var entity = new Contato()
            {
                Nome = this.Nome,
                Telefone = this.Telefone,
                Email = this.Email,
                RegiaoId = this.RegiaoId
            };

            return entity;
        }
    }
}
