﻿namespace Core.Entity
{
    public class Ddd: BaseEntity
    {
        public string Regiao { get; set; }

        public IEnumerable<Contato> Contatos { get; set; }

        public Ddd()
        {            
        }

        public Ddd(int id, string regiao)
        {
            Id = id;
            Regiao = regiao;
        }
    }
}
