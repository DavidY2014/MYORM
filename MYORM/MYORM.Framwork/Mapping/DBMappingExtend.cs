using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MYORM.Framwork.Mapping
{
    public static class DBMappingExtend
    {
        public  static string GetMappingTableName(this Type type)
        {
            if (type.IsDefined(typeof(MYTableAttribute), true))
            {
                var attribute = type.GetCustomAttributes<MYTableAttribute>();
                //return attribute.GetMappingName();
                return "";
            }
            else
            {
                return type.Name;
            }
        }

        public static string GetMappingPropertyName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(MYColumnAttribute), true))
            {
                var attribute = prop.GetCustomAttributes<MYColumnAttribute>();
                //return attribute.GetMappingName();
                return "";
            }
            else
            {
                return prop.Name;
            }
        }

    }
}
