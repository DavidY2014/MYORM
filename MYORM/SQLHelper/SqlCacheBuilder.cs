using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLHelper
{
    /// <summary>
    /// 泛型sql缓存
    /// </summary>
    public class SqlCacheBuilder<T>
    {
        private static string _InsertSql = null;
        static SqlCacheBuilder()
        {
            Type type = typeof(T);
            string columnStrings = string.Join(",", type.GetProperties().Select(p =>
             $"[{p.Name}]"));
            string valueStrings = string.Join(",", type.GetProperties().Select(p =>
             $"@{p.Name}"));
            _InsertSql = $"Insert Into [{type.Name}] ({columnStrings}) Values " +
                $"({valueStrings})";
            
        }


        public static string GetSql()
        {
            return _InsertSql;
        }


    }


    /// <summary>
    /// 常规的字典缓存
    /// </summary>
    public class CustomCache
    {
        private static Dictionary<string, string> CustomCacheDic = new Dictionary<string, string>();

    }



}
