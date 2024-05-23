using Domain.Entities;

namespace Shared.Tests.Builders.Commands
{
    public class RegiaoBuilder
    {
        private int Id { get; set; }
        private string Descricao { get; set; }


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


        public RegiaoBuilder SaoPaulo()
        {
            this.Id = 11;
            this.Descricao = "SAO PAULO";
            return this;
        }

        public RegiaoBuilder LitoralSaoPaulo()
        {
            this.Id = 12;
            this.Descricao = "LITORAL";
            return this;
        }

        public RegiaoBuilder RioDeJaneiro()
        {
            this.Id = 21;
            this.Descricao = "RIO DE JANEIRO";
            return this;
        }



        public Regiao Build()
        {
            var entity = new Regiao()
            {
                Id = Id,
                Descricao = Descricao,
            };

            return entity;
        }
    }
}
