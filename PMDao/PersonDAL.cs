using PMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.DAL
{
    public sealed class PersonDAL: BaseDAL<Person>
    {
        #region 使用静态类来实现单例模式参考链接https://www.cnblogs.com/mcyushao/p/9671357.html
        private static readonly PersonDAL instance = null;
        static PersonDAL()//Explicit static constructor to tell C# compiler
        {
            instance = new PersonDAL();
        }
        private PersonDAL()//Prevents a default instance of the 
        {
        }
        public static PersonDAL Instance//Gets the instance.
        {
            get
            {
                return instance;
            }
        }
        #endregion

    }
}
