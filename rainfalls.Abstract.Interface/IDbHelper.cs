using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rainfalls.Abstract.Interface
{
    public interface IDbHelper
    {
        int ExcuteSql(string sql);
        int QueryBySql(string sql, System.Data.DataSet ds);

    }
}
