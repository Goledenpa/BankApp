using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;

namespace BankAppData.Helper
{
    /// <summary>
    /// Class to help with executing raw SQL queries
    /// </summary>
    public static class EFSqlHelper
    {
        private class PropertyMap
        {
            public string Name { get; set; }
            public Type Type { get; set; }
            public bool IsSame(PropertyMap map)
            {
                if (map == null)
                {
                    return false;
                }
                return map.Name.Equals(Name) && map.Type.Equals(Type);
            }
        }

        public static DbTransaction GetDbTransaction(this IDbTransaction source)
        {
            return (source as IInfrastructure<DbTransaction>).Instance;
        }

        /// <summary>
        /// Execute a raw SQL query and return the results as a list of objects of the specified type, used for SELECT queries
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeOutInSeconds"></param>
        /// <returns></returns>
        public static IEnumerable<T> FromSqlQuery<T>(this DbContext context, string query,
            List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
            int? commandTimeOutInSeconds = null) where T : new()
        {
            return FromSqlQuery<T>(context.Database, query, parameters,
                commandType, commandTimeOutInSeconds);
        }

        public static IEnumerable<T> FromSqlQuery<T>(this DatabaseFacade database, string query,
            List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
            int? commandTimeOutInSeconds = null) where T : new()
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            List<PropertyMap> entityFields = (from PropertyInfo aProp
                                              in typeof(T).GetProperties(flags)
                                              select new PropertyMap
                                              {
                                                  Name = aProp.Name,
                                                  Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                                              }).ToList();

            List<PropertyMap> dbDataReaderFields = [];
            List<PropertyMap> commonFields = null;

            if (!database.CanConnect())
            {
                throw new Exception("Can't connect to the database");
            }

            using (var command = database.GetDbConnection().CreateCommand())
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                var currentTransaction = database.CurrentTransaction;
                if (currentTransaction != null)
                {
                    command.Transaction = currentTransaction.GetDbTransaction();
                }

                command.CommandText = query;
                command.CommandType = commandType;

                if (commandTimeOutInSeconds != null)
                {
                    command.CommandTimeout = (int)commandTimeOutInSeconds;
                }

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                using var res = command.ExecuteReader();
                while (res.Read())
                {
                    if (commonFields == null)
                    {
                        for (int i = 0; i < res.FieldCount; i++)
                        {
                            dbDataReaderFields.Add(new PropertyMap
                            {
                                Name = res.GetName(i),
                                Type = res.GetFieldType(i),
                            });
                        }

                        commonFields = entityFields.Where(x => dbDataReaderFields.Any(d => d.IsSame(x))).ToList();
                    }

                    var entity = new T();
                    foreach (var aField in commonFields)
                    {
                        PropertyInfo propertyInfo = entity.GetType().GetProperty(aField.Name)!;

                        var value = (res[aField.Name] == DBNull.Value) ? null : res[aField.Name];

                        propertyInfo.SetValue(entity, value, null);
                    }
                    yield return entity;
                }
            }
        }

        /// <summary>
        /// Execute a raw SQL query and return the number of affected rows, used for UDPATE and DELETE queries
        /// </summary>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeOutInSeconds"></param>
        /// <returns></returns>
        public static int ExecuteQuery(this DbContext context, string query,
            List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
            int? commandTimeOutInSeconds = null)
        {
            return ExecuteQuery(context.Database, query, parameters, commandType, commandTimeOutInSeconds).First();
        }

        public static IEnumerable<int> ExecuteQuery(this DatabaseFacade database, string query,
            List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
            int? commandTimeOutInSeconds = null)
        {

            if (!database.CanConnect())
            {
                throw new Exception("Can't connect to the database");
            }

            using var command = database.GetDbConnection().CreateCommand();

            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }

            var currentTransaction = database.CurrentTransaction;
            if (currentTransaction is not null)
            {
                command.Transaction = currentTransaction.GetDbTransaction();
            }

            command.CommandText = query;
            command.CommandType = commandType;

            if (commandTimeOutInSeconds is not null)
            {
                command.CommandTimeout = commandTimeOutInSeconds.Value;
            }

            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            int rowsAffected = command.ExecuteNonQuery();

            yield return rowsAffected;
        }

        /// <summary>
        /// Execute queries that return a single value, used for SELECT Count(*) queries
        /// </summary>
        /// <param name="context"></param>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <param name="commandTimeOutInSeconds"></param>
        /// <returns></returns>
        public static int ExecuteScalar(this DbContext context, string query,
            List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
            int? commandTimeOutInSeconds = null)
        {
            return ExecuteScalar(context.Database, query, parameters, commandType, commandTimeOutInSeconds);
        }

        public static int ExecuteScalar(this DatabaseFacade database, string query,
            List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
            int? commandTimeOutInSeconds = null)
        {
            if (!database.CanConnect())
            {
                throw new Exception("Can't connect to the database");
            }

            using var command = database.GetDbConnection().CreateCommand();

            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }

            var currentTransaction = database.CurrentTransaction;
            if (currentTransaction is not null)
            {
                command.Transaction = currentTransaction.GetDbTransaction();
            }

            command.CommandText = query;
            command.CommandType = commandType;

            if (commandTimeOutInSeconds is not null)
            {
                command.CommandTimeout = commandTimeOutInSeconds.Value;
            }

            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            int res = (int)command.ExecuteScalar()!;

            return res;
        }


        /// <summary>
        /// Method to convert an object to a list of DbParameters
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<DbParameter> ToSqlParameters(this object dto)
        {
            List<DbParameter> res = new();

            res.AddRange(dto.GetType().GetProperties((BindingFlags)60)
                .Where(x => x.PropertyType.IsPrimitive ||
                    x.PropertyType.IsEnum ||
                    x.PropertyType == typeof(string) ||
                    x.PropertyType == typeof(DateTime) ||
                    (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                ).ToList().Select(x => new SqlParameter($"@{x.Name}", x.GetValue(dto) ?? DBNull.Value)));

            return res;
        }
    }
}
