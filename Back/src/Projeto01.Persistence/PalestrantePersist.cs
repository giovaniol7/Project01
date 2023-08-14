using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto01.Domain;
using Projeto01.Persistence.Contratos;
using Projeto01.Persistence.Contexts;

namespace Projeto01.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly Projeto01Context _context;

         public PalestrantePersist(Projeto01Context context)
        {
            _context = context;

        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(ev => ev.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(ev => ev.Evento);
            }

            query = query.OrderBy(p => p.Id)
                   .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(ev => ev.Evento);
            }

            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}