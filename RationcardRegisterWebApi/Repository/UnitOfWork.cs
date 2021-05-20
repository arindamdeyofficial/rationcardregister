using Repository.NewModels;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
        //where TContext : DbContext, IDisposable
    {
        
        private readonly RationcardRegisterContext _context;
        
        public UnitOfWork(RationcardRegisterContext context)
        {
            if (_context == null)
            {
                _context = context;
            }
        }
                
        public IDbRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            return new DbRepository<TEntity>(_context);
        }

        /// <summary>
        /// The CompleteAsync.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}