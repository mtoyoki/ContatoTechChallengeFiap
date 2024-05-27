using Domain.Entities;

namespace Shared.Tests.Builders.Commands
{
    public class RegiaoBuilder
    {
        private int Id { get; set; }
        private string Descricao { get; set; }
        private string Uf { get; set; }


        public RegiaoBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public RegiaoBuilder WithDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public RegiaoBuilder WithUf(string uf)
        {
            Uf = uf;
            return this;
        }

        public RegiaoBuilder SaoPaulo()
        {
            this.Id = 11;
            this.Descricao = "São Paulo e Região Metropolitana";
            this.Uf = "SP";
            return this;
        }

        public RegiaoBuilder RioDeJaneiro()
        {
            this.Id = 21;
            this.Descricao = "Rio de Janeiro e Região Metropolitana";
            this.Uf = "RJ";
            return this;
        }

        public Regiao Build()
        {
            var entity = new Regiao()
            {
                Id = Id,
                Descricao = Descricao,
                Uf = Uf
            };

            return entity;
        }
    }
}
