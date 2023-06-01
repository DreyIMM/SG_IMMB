using System;
using System.Collections.Generic;
using System.Text;

namespace Immb.Business.Models
{
    public class Religiosidade : Entity
    {
        public Guid MembroId { get; set; }
        public DateTime DataReligiosidade { get; set; }
        public int TotalMinistracao { get; set; }

        /* EF Relational */
        public Membro Membro { get; set; }

    }

}
