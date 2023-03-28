using Immb.Business.Interfaces;
using Immb.Business.Models;
using Immb.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Immb.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }


        public async Task<Endereco> ObterEnderecoPorMembro(Guid membroId)
        {
            return await Db.Enderecos.AsNoTracking().Include(m => m.Membro)
                .FirstOrDefaultAsync(e => e.MembroId == membroId);
        }
    }
}
