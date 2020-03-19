using System;
using System.Collections.Generic;
using System.Text;

namespace MYORM.Framwork.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MYColumnAttribute:Attribute
    {
        private string _ColumnName = null;

        public MYColumnAttribute(string columnName)
        {
            this._ColumnName = columnName;
        }

        public string GetMappingName()
        {
            return this._ColumnName;
        }
    }
}
