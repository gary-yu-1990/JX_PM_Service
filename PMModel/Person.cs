using PM.Model;
using System;

namespace PMModel
{
    public class Person: BaseModel
    {
        private string _id;
        private string _name;

        /// <summary>
        /// ID
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
    }
}
