using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;

namespace TeretanaAPI.DataBaseManipulation
{
    public static class DataReaderExtensions
    {
        public static List<T> MapToList<T>(this DbDataReader dr) where T : new()
        {
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);
                var entities = new List<T>();
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);

                while (dr.Read())
                {
                    T newObject = new T();
                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = propDict[dr.GetName(index).ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    entities.Add(newObject);
                }
                return entities;
            }
            return null;
        }

        public static object[] executeStoredProcedure(DbContext context, string spName, string[] inputParamNames, object[] inputParamValues, string[] outputParamNames, object[] outputParamValues)
        {
            SqlParameter[] dbOutputParamsValues = new SqlParameter[outputParamValues.Length];

            using (context)
            {
                using (context.Database.GetDbConnection())
                {
                    context.Database.OpenConnection();
                    DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < inputParamNames.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(inputParamNames[i], inputParamValues[i]));
                    }
                    for (int i = 0; i < outputParamNames.Length; i++)
                    {
                        dbOutputParamsValues[i] = new SqlParameter(outputParamNames[i], SqlDbType.NVarChar,600, outputParamValues[i].ToString()) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(dbOutputParamsValues[i]);
                    }

                    List<object> tasks;
                    using (var reader = cmd.ExecuteReader())
                    {
                        tasks = DataBaseManipulation.DataReaderExtensions.MapToList<object>(reader);
                    }

                    for (int i = 0; i < dbOutputParamsValues.Length; i++)
                    {
                        outputParamValues[i] = string.IsNullOrEmpty(dbOutputParamsValues[i].Value.ToString()) ? outputParamValues[i] : dbOutputParamsValues[i].Value;
                    }


                }
            }
            return outputParamValues;
        }
    }
}
