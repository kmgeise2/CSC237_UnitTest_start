using System.Collections.Generic;

namespace CSC237_UnitTest_start.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> List(QueryOptions<T> options);

        T Get(int id);
        T Get(QueryOptions<T> options);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Save();
    }
}
