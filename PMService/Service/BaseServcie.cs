using PM.DAL;
using PM.DbService;
using PM.Service.ServiceApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PM.Service.Service
{
    public class BaseServcie : IBaseServcie
    {
        public string CloseTransaction()
        {
            throw new NotImplementedException();
        }

        public ZJTransaction CreateTransaction()
        {
             DaoBase daoBase = new DaoBase();
             return daoBase.CreateTransaction();
        }

        IDbTransaction IBaseServcie.CreateTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
