using PM.DbService.DBServiceApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ZORM;

namespace PM.DbService
{
    /// <summary>
    /// 事务实体模型，定义事务相关参数
    /// </summary>
    public class ZJTransaction
    {
        /// <summary>
        /// 重试次数
        /// </summary>
        private int retryCount = 0;

        /// <summary>
        /// 最大重试次数
        /// </summary>
        private int retryMaxNum = 10;

        /// <summary>
        /// 独有的OrmTransction
        /// </summary>
        public OrmTransation OrmTransation { set; get; }

        public IDbConnection transConn
        {
            get;
            set;
        }

        public IDbTransaction transAction
        {
            get;
            set;
        }

        public IDbService iDbService
        {
            get;
            set;
        }


        public bool Result
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string MessageCode
        {
            get;
            set;
        }

        public int GetRetryCount()
        {
            this.retryCount++;
            return (this.retryCount >= this.retryMaxNum) ? -1 : this.retryCount;
        }

    }
}
