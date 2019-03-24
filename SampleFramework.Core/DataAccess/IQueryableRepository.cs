using System.Linq;
using SampleFramework.Core.Entities;

namespace SampleFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T: class, IEntity, new ()
    {
        IQueryable<T> Table { get; }
    }
}