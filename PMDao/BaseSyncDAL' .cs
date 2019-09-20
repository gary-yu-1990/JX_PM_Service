
using Microsoft.Extensions.Configuration;
using PM.DbService;
using PM.DbService.DBServiceApi;
using PM.DbService.MsSqlService;
using PMUtil;
using System;
using System.Collections.Generic;
using System.Transactions;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace PM.DAL
{
    /// <summary>
    /// 数据访问基类-同步访问
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class BaseDAL<T>
          where T : class, new()
    {
        protected IDbService iDbService;//数据访问接口
        public BaseDAL()
        {
             iDbService = DbFactory.CreateConnection();
        }

        public string Query(T t,string sql1,ZJTransaction transaction = null)
        {
            return iDbService.Query(t, sql1, transaction);
        }

    } 
}
