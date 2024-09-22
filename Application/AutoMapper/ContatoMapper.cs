using AutoMapper;
using Domain.Commands.Contato;
using Domain.Events.Contato;

namespace Application.AutoMapper
{
    public class ContatoMapper
    {
        public static ContatoCreateEventMsg CommandToEventMsg(ContatoCreateCommand command, Guid guid)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<ContatoCreateCommand, ContatoCreateEventMsg>();
            });

            var mapper = config.CreateMapper();
            var msg = mapper.Map<ContatoCreateEventMsg>(command);
            
            msg.EventMsgId = guid;

            return msg;
        }


        public static Domain.Entities.Contato CommandToEntity(ContatoCreateCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<ContatoCreateCommand, Domain.Entities.Contato>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.Contato>(command);
        }

        public static Domain.Entities.Contato CommandToEntity(ContatoUpdateCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<ContatoUpdateCommand, Domain.Entities.Contato>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.Contato>(command);
        }
    }
}
