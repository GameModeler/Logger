using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.DataBase.Interfaces
{
    public interface IDbEntityManager<T>
    {

        IDbSettings Settings { get; }

        bool InitDb(IDbSettings dbSettings = null);

        void SetSettings(IDbSettings dbSettings);
    }
}
