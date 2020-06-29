using System;
using System.Data;

namespace rainfalls.Abstract.Interface
{
    public interface IDBManager : IDisposable
    {
        IDbConnection getConnection();
        void releaseConnection(IDbConnection conn);
    }
}
