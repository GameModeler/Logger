using GMLogger.DataBase.Utils;
using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.DataBase.Interfaces
{
    public interface IConnectionStringBuilder
    {
        void ConfigPorvider(ProviderType provider);
        string ProviderConnectionString(ProviderType provider, IDbSettings settings);
    }
}
