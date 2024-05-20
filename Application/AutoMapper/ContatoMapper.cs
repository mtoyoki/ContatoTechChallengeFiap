using AutoMapper;
using Domain.Commands.Contato;

namespace Application.AutoMapper
{
    public class ContatoMapper
    {
        public static Domain.Entities.Contato CommandToEntity(CreateContatoCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<CreateContatoCommand, Domain.Entities.Contato>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.Contato>(command);
        }

        public static Domain.Entities.Contato CommandToEntity(UpdateContatoCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<UpdateContatoCommand, Domain.Entities.Contato>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.Contato>(command);
        }
    }
}
