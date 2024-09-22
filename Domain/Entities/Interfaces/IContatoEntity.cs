using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IContatoEntity
    {
        string Nome { get; set; }
        string Email { get; set; }
        string Telefone { get; set; }
        int RegiaoId { get; set; }
    }
}
