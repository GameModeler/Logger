using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.DataBase.Interfaces
{
    public interface ICrudMethods<T>
    {
        Task<T> Insert(T item);

        Task<IEnumerable<T>> Insert(IEnumerable<T> items);

        Task<T> Update(T item);

        Task<IEnumerable<T>> Update(IEnumerable<T> items);

        Task<T> Get(Int32 id);

        Task<IEnumerable<T>> Get();

        Task<Int32> Delete(T item);

        Task<Int32> Delete(IEnumerable<T> items);

        //Task<IEnumerable<T>> CustomQuery(Criteria criteria)
        //{
        //    return await this.DbSetT.SqlQuery(criteria.MySQLCompute()).ToListAsync();
        //}
    }
}
