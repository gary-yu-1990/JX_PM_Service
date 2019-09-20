using PM.DbService.DBServiceApi;
using System;
using System.Collections.Generic;
using System.Text;
using ZORM;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace PM.DbService.MsSqlService
{
    public class DapperDbService : IDbService 
    {
        private string _connectionString = "";
        private DatabaseType _dataBaseType;
        public DapperDbService(string connectionString, DatabaseType dataBaseType) {
            _connectionString = connectionString;
            _dataBaseType = dataBaseType;
        }

        public DatabaseType DatabaseType
        {
            get { return _dataBaseType; }
        }


        public ZJTransaction CreateTransaction()
        {
            ZJTransaction zJTransaction;
            IDbConnection dbConnection = this.CreateDbConnection();
            dbConnection.Open();
            IDbTransaction dbTransaction = dbConnection.BeginTransaction();
            zJTransaction = new ZJTransaction();
            zJTransaction.transAction = dbTransaction;
            zJTransaction.transConn = dbConnection;
            zJTransaction.iDbService = this;
            return zJTransaction;
        }



        public string CloseTransaction(ZJTransaction trans)
        {
            trans.transAction.Commit();
            return "Y";
        }

        public IDbConnection CreateDbConnection()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection;
        }

        public string ExecuteSql(string sql)
        {
            throw new NotImplementedException();
        }

        public string Query<T>(T entity,string tt, ZJTransaction transaction = null) where T : class, new()
        {
            return tt ;
        }
        public bool Delete<T>(T entity) where T : class, new()
        {
            var tt = DataFactory.DeleteEntity<T>(entity, null, null);
            return true;
        }

        public string CreateEntity<T>(T t, ZJTransaction trans) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
