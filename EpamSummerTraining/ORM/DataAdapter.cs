using EpamSummerTraining.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EpamSummerTraining.ORM
{
    // ORM 
    public class DataAdapter<T> : ICrud<T>
        where T : class, new()
    {
        private readonly DataConnectionCreator _dataConnection;
        private readonly SqlScriptCreator<T> _sqlScriptCreator = new SqlScriptCreator<T>();

        public DataAdapter()
        {
            _dataConnection = DataConnectionCreator.GetConnection();
        }

        private StringBuilder GetSqlCommand(CrudCommandEnum command, T newInstance = null)
        {
            var script = new StringBuilder();
            switch (command)
            {
                case CrudCommandEnum.Create:
                    _sqlScriptCreator.GetCreateScript(out script);
                    break;
                case CrudCommandEnum.Read:
                    _sqlScriptCreator.GetReadScript();
                    break;
                case CrudCommandEnum.Update:
                    _sqlScriptCreator.GetUpdateScript(newInstance, out script);
                    break;
                case CrudCommandEnum.Delete:
                    _sqlScriptCreator.GetDeleteScript(newInstance, out script);
                    break;
                default: throw new NotImplementedException();
            };
            return script;
        }

        public void Create()
        {
            var script = GetSqlCommand(CrudCommandEnum.Create).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            command.ExecuteNonQuery();
            _dataConnection.Connection.Close();
        }

        public void Delete()
        {
            var script = GetSqlCommand(CrudCommandEnum.Delete).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            command.ExecuteNonQuery();
            _dataConnection.Connection.Close();
        }

        public T Read()
        {
            T value = new T();
            var script = GetSqlCommand(CrudCommandEnum.Read).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    foreach (var item in typeof(T).GetProperties())
                    {
                        typeof(T).GetProperty(item.Name).SetValue(value, reader[item.Name]);
                    }
                }
            }
            reader.Close();
            _dataConnection.Connection.Close();
            return value;
        }

        
        public void Update(T newInstance)
        {
            var script = GetSqlCommand(CrudCommandEnum.Update).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            command.ExecuteNonQuery();
            _dataConnection.Connection.Close();
        }
    }
}
