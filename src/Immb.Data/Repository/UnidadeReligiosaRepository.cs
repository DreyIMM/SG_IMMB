using Immb.Business.Interfaces;
using Immb.Business.Models;
using Immb.Business.Models.Enums;
using Immb.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Immb.Data.Repository
{
    public class UnidadeReligiosaRepository : Repository<UnidadeReligiosa>, IUnidadeReligiosaRepository
    {
        public UnidadeReligiosaRepository(MeuDbContext context) : base(context) { }

        public Task<TipoUnidadeReligiosa> ObterUnidadePorTipo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task <IEnumerable<UnidadeReligiosa>> ObterTodosPorDescricao()
        {
            throw new NotImplementedException();
        }
    }
}
