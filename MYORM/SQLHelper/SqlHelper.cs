using System;
using System.Data.SqlClient;
using System.Linq;
using MYModels;

namespace SQLHelper
{
    public class SqlHelper
    {
        public static string ConnectionString = "";

        public T Find<T>(int id) where T:BaseModel
        {
            Type type = typeof(T);
            //通过反射获取泛型属性也就是colunmn信息
            string columnString = string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"));
            string sql = $@"SELECT {columnString} FROM [{type.Name}] WHERE ID={id}";
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
                        prop.SetValue(t, reader[prop.Name]);

                    }
                    return t;
                }
                else
                {
                    return null;
                }
            }
      
        }

    }
}
