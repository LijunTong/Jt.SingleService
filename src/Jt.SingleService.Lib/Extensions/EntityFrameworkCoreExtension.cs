using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;

namespace Jt.SingleService.Lib.Extensions
{
    public static class EntityFrameworkCoreExtension
    {
        private static DbCommand CreateCommand(DatabaseFacade facade, string sql, out DbConnection connection, params object[] parameters)
        {
            var conn = facade.GetDbConnection();
            connection = conn;
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);

            return cmd;
        }

        public static async Task<List<T>> SqlQueryAsync<T>(this DatabaseFacade facade, string sql, params object[] parameters) where T : new()
        {
            var command = CreateCommand(facade, sql, out DbConnection conn, parameters);
            var reader = await command.ExecuteReaderAsync();
            //var reader = SqlQuery2(facade, sql, parameters);
            var list = await reader.ToListAsync<T>();
            conn.Close();
            reader.Close();
            return list;
        }

        public static async Task<List<T>> ToListAsync<T>(this DbDataReader dr) where T : new()
        {
            var result = new List<T>();
            var properties = typeof(T).GetProperties();
            while (await dr.ReadAsync())
            {
                var obj = new T();

                foreach (var property in properties)
                {
                    try
                    {
                        //Oracle字段为大写
                        string propName = "";
                        var attr = (ColumnAttribute)property.GetCustomAttribute(typeof(ColumnAttribute));
                        if (attr != null)
                        {
                            propName = attr.Name.ToUpper();
                        }
                        else
                        {
                            propName = property.Name.ToUpper();
                        }
                        var id = dr.GetOrdinal(propName);
                        if (!dr.IsDBNull(id))
                        {
                            if (dr.GetValue(id) != DBNull.Value)
                            {
                                var val = Convert.ChangeType(dr.GetValue(id), property.PropertyType);
                                property.SetValue(obj, val);
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                result.Add(obj);
            }
            return result;
        }
    }
}
