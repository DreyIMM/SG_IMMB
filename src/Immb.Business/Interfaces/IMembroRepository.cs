using Immb.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Immb.Business.Interfaces
{
    public interface IMembroRepository : IRepository<Membro>
    {
       Task<Membro> ObterMembroPorUnidade(Guid id);
       Task<Membro> ObterMembroEndereco(Guid id);

    }
}
