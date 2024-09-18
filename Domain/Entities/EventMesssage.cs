using Core.Entities;

namespace Domain.Entities
{
    public class EventMesssage: BaseEntity
    {
        public Guid Id { get; set; }
        public long IdEntity { get; set; }
        public string Result { get; set; }


        public EventMesssage()
        {            
        }

        public EventMesssage(Guid id, long idEntity, string result)
        {
            Id = id;
            IdEntity = idEntity;
            Result = result;
        }
    }
}
