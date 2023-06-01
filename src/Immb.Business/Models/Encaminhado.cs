using System;

namespace Immb.Business.Models
{
    public class Encaminhado : Entity
    {
        public Guid ReligiosidadeId { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
    }

}
