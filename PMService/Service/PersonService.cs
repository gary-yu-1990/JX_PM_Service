using PM.DAL;
using PM.DbService;
using PM.Service.Service;
using PMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Service.ServiceApi
{
    public class PersonService : BaseServcie, IPersonService
    {
      
        public string GetPersonName()
        {
            Person t = new Person();
            t.Name = "余春来";
            ZJTransaction tran = this.CreateTransaction();
            return PersonDAL.Instance.Query(t,"张婷",tran);
        }
    }
}
