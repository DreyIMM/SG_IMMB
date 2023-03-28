using Immb.Business.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Immb.App.ViewModels
{
    public class UnidadeReligiosaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DisplayName("Tipo de unidade")]
        public TipoUnidadeReligiosa TipoUnidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DisplayName("Tipo de unidade")]
        public int TipoUnidadeId { get; set; }

        /* EF Relational */
        public IEnumerable<MembroViewModel> MembrosViewModel { get; set; }

        /* Lista do tipo de Unidades*/
        public IEnumerable<SelectListItem> TiposUnidadesReligiosas { get; set; }


    }
}
