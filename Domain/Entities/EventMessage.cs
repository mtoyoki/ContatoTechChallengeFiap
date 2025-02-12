﻿using Core.Entities;

namespace Domain.Entities
{
    public class EventMessage: BaseEntity
    {
        public Guid EventMsgId { get; set; }
        public string EventMsg { get; set; }
        public bool Result { get; set; }
        public string? Details { get; set; }


        public EventMessage()
        {            
        }

        public EventMessage(Guid eventMsgId, string eventMsg, bool result, string? details)
        {
            EventMsgId = eventMsgId;
            EventMsg = eventMsg;
            Result = result;
            Details = details;
        }
    }
}
