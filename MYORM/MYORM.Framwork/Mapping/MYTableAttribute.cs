using System;
using System.Collections.Generic;
using System.Text;

namespace MYORM.Framwork.Mapping
{
    public class MYTableAttribute:Attribute
    {
        private string _TableName = null;
        public MYTableAttribute(string tableName)
        {
            this._TableName = tableName;
        }

        public string GetMappingName()
        {
            return this._TableName;
        }
    }
}
