using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
namespace Update
{
    public class CDbManager_Sqlite : IDbManager
    {
        private SQLiteConnection m_con = null;
        private string m_sCon = "";

        public CDbManager_Sqlite(string szDbFileName, string dbPwd)
        {
            SQLiteConnectionStringBuilder pConStr = new SQLiteConnectionStringBuilder();
            pConStr.DataSource = szDbFileName;
            m_sCon = pConStr.ToString();
        }

        private void OpenDb()
        {
            m_con = new SQLiteConnection();
            m_con.ConnectionString = m_sCon;
            m_con.Open();
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ExcuteSql(string sql)
        {
            try
            {
                OpenDb();
                SQLiteCommand cmd = new SQLiteCommand(PraseSqlString(sql), m_con);
                cmd.ExecuteNonQuery();
                CloseDb();
            }
            catch
            {

            }
        }

        public int QueryBySql(string sql, DataSet ds)
        {
            try
            {
                OpenDb();
                SQLiteDataAdapter da = new SQLiteDataAdapter(PraseSqlString(sql), m_con);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    CloseDb();
                    return ds.Tables[0].Rows.Count;
                }

            }
            catch 
            {
                CloseDb();
                return -1;
            }

            return 0;
        }

        private void CloseDb()
        {
            m_con.Close();
            m_con.Dispose();
        }

        public string PraseSqlString(string sql)
        {
            return sql;
        }

        public void SaveBlobToDb(string tabName, string keyField, object key, string blobField, string blobFilePath)
        {

        }

        public void ReadBlobFromDb(string tabName, string keyField, object key, string blobField, string outFilePath)
        {

        }

        public bool BuildRelations(string[] sql, string masterColumn, string[] detailColumns, string[] relations, DataView dv)
        {
            return false;
        }

        public byte[] ReadBlobFromDb(string tabName, string keyField, object key, string blobField)
        {
            return null;
        }

        public void SaveBlobToDb(string tabName, string keyField, object key, string blobField, byte[] content)
        {

        }

        public string GetConnectionString()
        {
            return m_sCon;
        }

        public void CreateDb(string szDbFileName)
        {
            SQLiteConnection.CreateFile(szDbFileName);
        }
    }
}
