using System;
using System.Collections.Generic;

namespace Immb.Business.Models
{
    public class Membro : Entity
    {
        public Guid UnidadeReligiosaId { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataOutorga { get; set; }
        public Endereco Endereco { get; set; }

        /* EF Relational */
        public UnidadeReligiosa UnidadeReligiosa { get; set; }
        public IEnumerable<Religiosidade> Religiosidade { get; set; }


    }
}
