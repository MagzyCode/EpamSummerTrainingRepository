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
        private DataConnectionCreator _dataConnection;

        public DataAdapter()
        {
            _dataConnection = DataConnectionCreator.GetConnection();
        }

        private StringBuilder GetSqlCommand(Type type, CrudCommandEnum command)
        {
            return command switch
            {
                CrudCommandEnum.Create => GetCreateCommand(type),
                CrudCommandEnum.Read => GetReadCommand(type),
                CrudCommandEnum.Update => GetUpdateCommand(type),
                CrudCommandEnum.Delete => GetDeleteCommand(type),
                _ => throw new NotImplementedException()
            };
        }

        private StringBuilder GetDeleteCommand(T deleted)
        {
            //var command = new StringBuilder();
            //var primaryKey = typeof(T).GetProperties();
            //command.Append($"DELETE FROM {typeof(T).Name} (\n");
            // DELETE FROM TelephoneDictionary WHERE TelephoneNumber = '{0}'"
            return default;
        }

        private StringBuilder GetUpdateCommand(Type type)
        {
            return default;
        }

        private StringBuilder GetReadCommand(Type type)
        {
            return default;
        }

        private StringBuilder GetCreateCommand(Type type)
        {
            var command = new StringBuilder();
            command.Append($"CREATE TABLE {type.Name} (\n");
            foreach (var item in type.GetProperties())
            {
                var typeOfProperty = item.PropertyType.ToString();
                command.Append($"{item.Name} {typeOfProperty} NOT NULL,\n");
            }
            command.Append(");");
            return command;
        }

        public string GetCorrectType(string type)
        {
            return type switch
            {
                "Int32" => "int",
                "String" => "NVARCHAR(50)",
                "DateTime" => "datetime",
                _ => throw new NotImplementedException(),
            };
        }

        public void Create()
        {
            var script = GetSqlCommand(typeof(T), CrudCommandEnum.Create).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            command.ExecuteNonQuery();
            _dataConnection.Connection.Close();
        }

        public void Delete()
        {
            var script = GetSqlCommand(typeof(T), CrudCommandEnum.Delete).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            command.ExecuteNonQuery();
            _dataConnection.Connection.Close();
        }

        public T Read()
        {
            var script = GetSqlCommand(typeof(T), CrudCommandEnum.Read).ToString();
            _dataConnection.Connection.Open();
            var command = new SqlCommand(script, _dataConnection.Connection);
            var value = command.ExecuteReader();
            _dataConnection.Connection.Close();

            return null;
        }

        //public IEnumerable<T> ReadAll()
        //{
        //    _dataConnection.Connection.Open();
            
        //    _dataConnection.Connection.Close();
        //    return null;
        //}

        public void Update()
        {
            _dataConnection.Connection.Open();
            
            _dataConnection.Connection.Close();
        }


    }
}
