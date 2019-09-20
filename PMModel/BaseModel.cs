using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PM.Model
{
   public class BaseModel
    {
        public List<string> UpdateColumns { get; set; }
        public bool AutoAddColumns { set; get; }
        protected static void SetUpdateValues(BaseModel basemodel, BaseModel valuemodel, List<string> updateColumns, bool clearUpdateColumns = true)
        {
            if (clearUpdateColumns)
            {
                basemodel.UpdateColumns = updateColumns;
            }
            else
            {
                foreach (var item in updateColumns)
                {
                    basemodel.AddUpdateColumns(item);
                }
            }
            Type type = valuemodel.GetType();
            if (basemodel.GetType() != type)
            {
                throw new Exception("赋值实体不是同一类！");
            }
            for (int i = 0; i < updateColumns.Count; i++)
            {
                PropertyInfo info = type.GetProperty(updateColumns[i]);
                object val = info.GetValue(valuemodel);
                info.SetValue(basemodel, val);
            }
        }
        /// <summary>
        /// 赋值并把属性名加入到UpdateColumns中
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="clearUpdateColumns">是否清空UpdateColumns</param>
        public void SetUpdateValues(Expression<Func<BaseModel>> expression, bool clearUpdateColumns = true)
        {
            List<string> updateColumns = GetExpressStr((MemberInitExpression)expression.Body);
            BaseModel valuemodel = expression.Compile()();
            SetUpdateValues(this, valuemodel, updateColumns, clearUpdateColumns);
        }

        public void AddUpdateColumns(string column)
        {
            if (this.UpdateColumns == null)
                this.UpdateColumns = new List<string>();
            if (!this.UpdateColumns.Contains(column))
                this.UpdateColumns.Add(column);
        }

        protected static List<string> GetExpressStr(MemberInitExpression exp)
        {
            string result = string.Empty;
            List<string> member = new List<string>();
            foreach (MemberAssignment item in exp.Bindings)
            {
                string update = item.Member.Name;
                member.Add(update);
            }
            return member;
        }

    }
}
