using SampleFramework.Core.Entities;
using System.Data.Entity;
using System.Linq;

namespace SampleFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entities;

        protected virtual IDbSet<T> Entities => _entities ?? _context.Set<T>();

    }
}
