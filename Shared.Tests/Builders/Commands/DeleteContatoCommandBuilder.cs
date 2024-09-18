using Domain.Commands.Contato;

namespace Shared.Tests.Builders.Commands
{
    public class DeleteContatoCommandBuilder
    {
        private int Id { get; set; }

        public DeleteContatoCommandBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public DeleteContatoCommandBuilder Default()
        {
            this.Id = 1;
            return this;
        }

        public DeleteContatoCommandBuilder Empty()
        {
            this.Id = 0;
            return this;
        }


        public ContatoDeleteCommand Build()
        {
            var command = new ContatoDeleteCommand()
            {
                Id = this.Id                
            };

            return command;
        }
    }
}
