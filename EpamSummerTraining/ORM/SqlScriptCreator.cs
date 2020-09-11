using System;
using System.Text;
using System.Linq;
using System.Reflection;

namespace EpamSummerTraining.ORM
{
    public class SqlScriptCreator<T> where T : class, new()
    {
        private StringBuilder _script = new StringBuilder();
        public Type TableType { get; } = typeof(T);

        public PropertyInfo GetTablePrimaryKey()
        {
            var standartPrefix = "Id";
            var conjecturalPrimaryKey = TableType.Name + standartPrefix;
            var primaryKeyProperty = TableType.
                GetProperties().
                Where(i => i.Name == standartPrefix || i.Name == conjecturalPrimaryKey).
                First();
            return primaryKeyProperty;
        }

        public void GetDeleteScript(T delete, out StringBuilder script)
        {
            PropertyInfo primaryKey = GetTablePrimaryKey();
            var primaryKeyValue = TableType.GetProperty(primaryKey.Name).GetValue(delete);
            _script.Append($"DELETE FROM {delete.GetType().Name} WHERE" +
                $" {primaryKey.Name} = {primaryKeyValue}");
            script = _script;
            _script.Clear();
        }

        public void GetUpdateScript(T newInstance, out StringBuilder script)
        {
            PropertyInfo primaryKey = GetTablePrimaryKey();

            _script.Append($"UPDATE {TableType.Name} SET ");
            foreach (var item in TableType.GetProperties())
            {
                var updateValue = TableType.GetProperty(item.Name).GetValue(newInstance);
                _script.Append($"{item.Name} = {updateValue}");
            }
            _script.Append($" WHERE {primaryKey.Name} = " +
                $"{TableType.GetProperty(primaryKey.Name).GetValue(newInstance)}");

            script = _script;
            _script.Clear();
        }

        public StringBuilder GetReadScript()
        {
            return new StringBuilder($"SELECT * FROM {TableType.Name}");
        }

        public void GetCreateScript(out StringBuilder script)
        {
            _script.Append($"CREATE TABLE {TableType.Name} (\n");
            foreach (var item in TableType.GetProperties())
            {
                var typeOfProperty = item.PropertyType;
                var sqlType = DbTypeParser.DbTypeDictionary[typeOfProperty];
                _script.Append($"{item.Name} {sqlType} NOT NULL,\n");
            }
            _script.Append(");");
            script = _script;
            _script.Clear();
        }
    }
}
