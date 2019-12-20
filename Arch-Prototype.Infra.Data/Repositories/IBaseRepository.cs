using System.Collections.Generic;

namespace Arch_Prototype.Infra.Data.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
        
        TEntity Assign<TSource>(TSource source, TEntity destination);
    }
}