using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Immb.App.ViewModels
{
    public class MembroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Unidade Religiosa")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Guid UnidadeReligiosaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Email { get; set; }

        [DisplayName("Data da Outorga")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataOutorga { get; set; }

        public bool Inclusao { get; set; } = true;

        /* EF Relational */
        public UnidadeReligiosaViewModel UnidadeReligiosa { get; set; }

        public IEnumerable<UnidadeReligiosaViewModel> Unidades { get; set; }

    }
}
