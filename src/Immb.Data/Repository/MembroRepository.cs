using Immb.Business.Interfaces;
using Immb.Business.Models;
using Immb.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immb.Data.Repository
{
    public class MembroRepository : Repository<Membro>, IMembroRepository
    {
        public MembroRepository(MeuDbContext context) : base(context) { }

        public async Task<Membro> ObterMembroEndereco(Guid id)
        {
            return await Db.Membros.AsNoTracking().Include(e => e.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Membro>> ObterMembros()
        {
            return await Db.Membros.AsNoTracking().Include(u => u.UnidadeReligiosa).ToListAsync();
        }

        public async Task<Membro> ObterMembroPorUnidade(Guid id)
        {
            return await Db.Membros.AsNoTracking().Include(u => u.UnidadeReligiosa)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
