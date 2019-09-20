using PM.DbService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PM.Service.ServiceApi
{
    public  interface IBaseServcie
    {
        IDbTransaction CreateTransaction();
        string CloseTransaction();
    }
}
