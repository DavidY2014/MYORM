using System;
using System.Data.SqlClient;
using System.Linq;
using MYModels;
using MYORM.Framwork.DBFilter;
using MYORM.Framwork.Mapping;

/// <summary>
/// ORM 在通用的ado.net上还封装了各种高阶特性，比如映射，缓存，延迟，事务等
/// </summary>
namespace SQLHelper
{
    public class SqlHelper
    {
        public static string ConnectionString = "";

        public T Find<T>(int id) where T:BaseModel
        {
            Type type = typeof(T);
            //通过反射获取泛型属性也就是colunmn信息
            string columnString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingPropertyName()}]"));
            string sql = $@"SELECT {columnString} 
                                FROM [{type.GetMappingTableName()}] WHERE ID={id}";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t = Activator.CreateInstance<T>();
                    foreach (var prop in type.GetProperties())
                    {
                        string propName = prop.GetMappingPropertyName();
                        prop.SetValue(t, reader[propName] is DBNull ? null : reader[propName]);
                    }
                    return t;
                }
                else
                {
                    return null;
                }
            }
      
        }

        public bool Insert<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);
            string columnString = string.Join(",", type.GetPropertiesWithNoKey().Select(p => $"[{p.Name}]"));
            string valueString = string.Join(",", type.GetPropertiesWithNoKey().Select(p => $"'{p.GetValue(t)}'"));

            string sql = $"Insert Into [{type.Name}] ({columnString}) Values ({valueString})";
            using (SqlConnection conn = new SqlConnection(""))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                conn.Open();
                int iResult = sqlCommand.ExecuteNonQuery();
                return iResult == 1;
            }


        }


    }
}
