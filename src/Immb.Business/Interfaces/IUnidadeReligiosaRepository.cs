using Immb.Business.Models;
using Immb.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Immb.Business.Interfaces
{
    public interface IUnidadeReligiosaRepository : IRepository<UnidadeReligiosa>
    {
        Task<TipoUnidadeReligiosa> ObterUnidadePorTipo(Guid id);

        Task<IEnumerable<UnidadeReligiosa>> ObterTodosPorDescricao();


    }
}
