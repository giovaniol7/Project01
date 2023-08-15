using System.Threading.Tasks;
using Projeto01.Persistence.Contratos;
using Projeto01.Persistence.Contexts;

namespace Projeto01.Persistence
{
   public class GeralPersist : IGeralPersist
    {
        private readonly Projeto01Context _context;
        public GeralPersist(Projeto01Context context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}