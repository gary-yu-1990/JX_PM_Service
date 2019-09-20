using Microsoft.Extensions.Configuration;
using PMUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.Contrib;
using PM.DbService.DBServiceApi;
using PM.DbService.MsSqlService;

namespace PM.DbService
{
    /// <summary>
    /// 连接工厂
    /// </summary>
    /// 
    public  class DbFactory
    {
        /// <summary>
        /// 转换数据库类型
        /// </summary>
        /// <param name="databaseType">数据库类型</param>
        /// <returns></returns>
        private  static DatabaseType GetDataBaseType(string databaseType)
        {
            DatabaseType returnValue = DatabaseType.SqlServer;
            foreach (DatabaseType dbType in Enum.GetValues(typeof(DatabaseType)))
            {
                if (dbType.ToString().Equals(databaseType, StringComparison.OrdinalIgnoreCase))
                {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 获取数据服务
        /// </summary>
        /// <returns></returns>
        public static IDbService CreateConnection()
        {
            IDbService dbService = null;

            string orm = ConfigHelper.Configuration.GetSection("ORM").Value;

            string dbType = ConfigHelper.Configuration.GetSection("DbType").Value;
  
            string strConn = ConfigHelper.Configuration.GetConnectionString(string.Format("{0}:dev", dbType)); ;
            //获取配置进行转换
            var dataBaseType = GetDataBaseType(dbType);

            switch (orm)
            {
                case "ZORM":
                    dbService = new XROMService(strConn, dataBaseType);
                    break;
                case "Dapper":
                    dbService = new DapperDbService(strConn, dataBaseType);
                    break;
                    //case DatabaseType.MySql:
                    //    connection = new MySql.Data.MySqlClient.MySqlConnection(strConn);
                    //    break;
                    //case DatabaseType.Npgsql:
                    //    connection = new Npgsql.NpgsqlConnection(strConn);
                    //    break;
                    //case DatabaseType.Sqlite:
                    //    connection = new SQLiteConnection(strConn);
                    //    break;
                    //case DatabaseType.Oracle:
                    //    connection = new Oracle.ManagedDataAccess.Client.OracleConnection(strConn);
                    //    break;
                    //case DatabaseType.DB2:
                    //    break;
            }
            return dbService;
        }
    }
    public enum DatabaseType
    {
        SqlServer,  //SQLServer数据库
        MySql,      //Mysql数据库
        Npgsql,     //PostgreSQL数据库
        Oracle,     //Oracle数据库
        Sqlite,     //SQLite数据库
        DB2         //IBM DB2数据库
    }
}
