using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PM.DbService.DBServiceApi
{
    public interface IDbService
    {
        DatabaseType DatabaseType { get; }
        /// <summary>
        /// 创建数据库链接
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateDbConnection();

        #region 事务操作
        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        ZJTransaction CreateTransaction();
        /// <summary>
        /// 关闭事务
        /// </summary>
        /// <returns></returns>
        string CloseTransaction(ZJTransaction tans);
        #endregion

        string Query<T>(T entity,string sql, ZJTransaction transaction = null) where T : class, new();
        bool Delete<T>(T entity) where T : class, new();
        string CreateEntity<T>(T t, ZJTransaction trans) where T : class, new();
     
    }
}
