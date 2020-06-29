using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rainfall.App.AppSync
{
    public interface IDbManager
    {
        void ExcuteSql(string sql);
        int QueryBySql(string sql, DataSet ds);
        string PraseSqlString(string sql);
        void SaveBlobToDb(string tabName, string keyField, object key, string blobField, string blobFilePath);
        void ReadBlobFromDb(string tabName, string keyField, object key, string blobField, string outFilePath);
        byte[] ReadBlobFromDb(string tabName, string keyField, object key, string blobField);
        void SaveBlobToDb(string tabName, string keyField, object key, string blobField, byte[] content);
        bool BuildRelations(string[] sql, string masterColumn, string[] detailColumns, string[] relations, DataView dv);
        string GetConnectionString();
    }
}
