using Domain.Queries.Contato;

namespace Shared.Tests.Builders.Queries
{
    public class ContatoQueryResultBuilder
    {
        private ContatoQueryResult _contatoQueryResult;

        public ContatoQueryResultBuilder()
        {
            _contatoQueryResult = new ContatoQueryResult();
        }

        public ContatoQueryResultBuilder WithId(int id)
        {
            _contatoQueryResult.Id = id;
            return this;
        }

        public ContatoQueryResultBuilder WithNome(string nome)
        {
            _contatoQueryResult.Nome = nome;
            return this;
        }

        public ContatoQueryResultBuilder WithEmail(string email)
        {
            _contatoQueryResult.Email = email;
            return this;
        }

        public ContatoQueryResultBuilder WithTelefone(string telefone)
        {
            _contatoQueryResult.Telefone = telefone;
            return this;
        }

        public ContatoQueryResultBuilder WithRegiaoId(int regiaoId)
        {
            _contatoQueryResult.RegiaoId = regiaoId;
            return this;
        }

        public ContatoQueryResultBuilder Default()        
        {
            _contatoQueryResult.Id = 1;
            _contatoQueryResult.Nome = "João da Silva";
            _contatoQueryResult.Email = "jose@gmail.com";
            _contatoQueryResult.Telefone = "11972117173";
            _contatoQueryResult.RegiaoId = 11;
            return this;
        }
        
        public ContatoQueryResult Build()
        {
            return _contatoQueryResult;
        }
    }
}