using Immb.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immb.Business.Models
{
    public class UnidadeReligiosa : Entity
    {
        public string Nome { get; set; }
        public TipoUnidadeReligiosa TipoUnidade { get; set; }

        /* EF Relational */
        public IEnumerable<Membro> Membros { get; set; }

    }
}
