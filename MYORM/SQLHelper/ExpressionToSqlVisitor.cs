using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SQLHelper
{
    /// <summary>
    /// 解析expression树成sql
    /// </summary>
    public class ExpressionToSqlVisitor:ExpressionVisitor
    {
        /// <summary>
        /// 解析入口
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }
    }
}
